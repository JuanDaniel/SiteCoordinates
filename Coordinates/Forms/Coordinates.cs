using Autodesk.Revit.UI;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Autodesk.Revit.DB;

namespace BBI.JD.Forms
{
    public partial class Coordinates : System.Windows.Forms.Form
    {
        private UIApplication application;
        private UIDocument uiDoc;
        private Document document;
        private Family family;

        public Coordinates(UIApplication application)
        {
            InitializeComponent();

            this.application = application;
            uiDoc = application.ActiveUIDocument;
            document = uiDoc.Document;
        }

        private void Coordinates_Load(object sender, EventArgs e)
        {
            family = Core.LoadCoordinateFamily(document, "ES-Coordenadas");

            if (family == null)
            {
                MessageBox.Show("Not found ES-Coordenadas.rfa", "Load ES-Coordenadas family", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Core.isSurveyPointPined(document))
            {
                lbl_Pined.Visible = true;

                cmb_SurveyPoint.Enabled = false;
            }

            cmb_SurveyPoint.SelectedIndex = 0;
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txt_ExcelPath.Text = openFileDialog1.FileName;
            }
        }

        private void txt_ExcelPath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(txt_ExcelPath.Text))
            {
                return;
            }

            SLDocument sl = null;

            try
            {
                sl = new SLDocument(txt_ExcelPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while processing the coordinates's excel.\nCheck that the excel is not being used by another application.", "Open coordinates's Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt_ExcelPath.Clear();

                return;
            }

            if (sl != null)
            {
                SLWorksheetStatistics stats = sl.GetWorksheetStatistics();

                List<string> columnsExcel = new List<string>();

                for (int i = 1; i <= stats.EndColumnIndex; i++)
                {
                    string name = sl.GetCellValueAsString(1, i);

                    if (name == "X" || name == "Y" || name == "Z" || name == "Tag")
                    {
                        columnsExcel.Add(name);
                    }
                }

                if (columnsExcel.Count < 3)
                {
                    MessageBox.Show("Incorrect excel structure.\nIt must have the following columns:\n\tX   Y   Z", "Coordinates's Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txt_ExcelPath.Clear();

                    return;
                }

                if (grid_Coordinates.Rows.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show("Before importing the coordinate's excel you want to delete the existing ones?", "Coordinates's Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        grid_Coordinates.Rows.Clear();
                    }
                }

                int indexX = columnsExcel.IndexOf("X");
                int indexY = columnsExcel.IndexOf("Y");
                int indexZ = columnsExcel.IndexOf("Z");
                int indexTag = columnsExcel.IndexOf("Tag");

                int cc = 0;
                int cc1 = 0;

                for (int i = 2; i <= stats.EndRowIndex; i++)
                {
                    double x, y, z;

                    if (!(double.TryParse(sl.GetCellValueAsString(i, indexX + 1), out x) && double.TryParse(sl.GetCellValueAsString(i, indexY + 1), out y) && double.TryParse(sl.GetCellValueAsString(i, indexZ + 1), out z)))
                    {
                        if (cc == 0)
                        {
                            // Ask to user to prefered option

                            DialogResult dialog = MessageBox.Show("Excel contains invalid coordinates.\nDo you want to continue to ignore the mistakes?", "Coordinates's Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            cc = dialog == DialogResult.Yes ? 1 : 2;
                        }
                        if (cc == 1)
                        {
                            // Continue and ignore error

                            continue;
                        }
                        else
                        {
                            // Cancel

                            MessageBox.Show("Coordinate import was canceled.", "Coordinates's Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txt_ExcelPath.Clear();

                            return;
                        }
                    }

                    string tag;

                    if (indexTag == -1)
                    {
                        if (cc1 == 0)
                        {
                            // Ask to user to prefered option

                            DialogResult dialog = MessageBox.Show("Excel does not have the Tag column.\nDo you want the tag to be generated automatically?", "Coordinates's Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            cc1 = dialog == DialogResult.Yes ? 1 : 2;
                        }
                        if (cc1 == 1)
                        {
                            tag = Core.GenerateTag(grid_Coordinates.Rows);
                        }
                        else
                        {
                            tag = string.Empty;
                        }
                    }
                    else
                    {
                        tag = sl.GetCellValueAsString(i, indexTag + 1);
                    }

                    grid_Coordinates.Rows.Add(x, y, z, tag);
                }

                if (cc == 1 || cc1 == 1)
                {
                    MessageBox.Show("Coordinate import completed ignoring errors.", "Coordinates's Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Coordinate import successfully completed.", "Coordinates's Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txt_ExcelPath.Clear();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            using (var form = new AddForm(grid_Coordinates))
            {
                form.ShowDialog();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (grid_Coordinates.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select a coordinate.", "Edit coordinate", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            if (grid_Coordinates.SelectedRows.Count > 1)
            {
                MessageBox.Show("Only the first coordinate of the selection will be edited.", "Edit coordinate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DataGridViewRow row = grid_Coordinates.SelectedRows.Cast<DataGridViewRow>().OrderBy(x => x.Index).First();

            using (var form = new EditForm(grid_Coordinates, row.Index))
            {
                form.ShowDialog();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (grid_Coordinates.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select at least one coordinate.", "Delete coordinate", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete the coordinates?", "Delete coordinates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.No)
            {
                return;
            }

            foreach (DataGridViewRow row in grid_Coordinates.SelectedRows)
            {
                grid_Coordinates.Rows.RemoveAt(row.Index);
            }
        }

        private void cmb_SurveyPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Point.Enabled = cmb_SurveyPoint.SelectedIndex == 2;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (grid_Coordinates.RowCount == 0)
            {
                MessageBox.Show("There is nothing to do. Add at least one coordinate.", "Place coordinates", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            List<CP> coordinates = new List<CP>();

            foreach (DataGridViewRow row in grid_Coordinates.Rows)
            {
                coordinates.Add(new CP(
                    new XYZ((double)row.Cells["cX"].Value, (double)row.Cells["cY"].Value, (double)row.Cells["cZ"].Value),
                    row.Cells["cTag"].ToString()
                ));
            }

            SurveyPointOption surveyPointOption = SurveyPointOption.NONE;

            if (cmb_SurveyPoint.Enabled)
            {
                surveyPointOption = (SurveyPointOption)cmb_SurveyPoint.SelectedIndex;
            }

            try
            {
                Core.PlaceCoordinates(document, coordinates, family, surveyPointOption);

                MessageBox.Show("The coordinates were correctly placed.", "Place coordinates", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Place coordinates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTiTleForm()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            return string.Format("{0} ({1}.{2}.{3}.{4})", "Coordinates", version.Major, version.Minor, version.Build, version.Revision);
        }
    }
}