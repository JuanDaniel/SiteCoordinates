using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace BBI.JD.Forms
{
    public partial class EditForm : System.Windows.Forms.Form
    {
        DataGridView grid_Coordinates;
        int index;

        public EditForm(DataGridView grid_Coordinates, int index)
        {
            InitializeComponent();

            this.grid_Coordinates = grid_Coordinates;
            this.index = index;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            txt_X.Text = grid_Coordinates.Rows[index].Cells["cX"].Value.ToString();
            txt_Y.Text = grid_Coordinates.Rows[index].Cells["cY"].Value.ToString();
            txt_Z.Text = grid_Coordinates.Rows[index].Cells["cZ"].Value.ToString();
            txt_Tag.Text = grid_Coordinates.Rows[index].Cells["cTag"].Value.ToString();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            double x, y, z;
            string tag = txt_Tag.Text;

            if (!(double.TryParse(txt_X.Text, out x) && double.TryParse(txt_Y.Text, out y) && double.TryParse(txt_Z.Text, out z)))
            {
                MessageBox.Show("Invalid coordinates values.", "Edit coordinate", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Core.ExistCoordinate(grid_Coordinates.Rows, new XYZ(x, y, z), index))
            {
                MessageBox.Show("Duplicates coordinates.", "Edit coordinate", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrEmpty(tag))
            {
                MessageBox.Show("Invalid Tag.", "Edit coordinate", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Core.ExistTag(grid_Coordinates.Rows, tag, index))
            {
                MessageBox.Show("Duplicates Tag.", "Edit coordinate", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            grid_Coordinates.Rows[index].Cells["cX"].Value = x;
            grid_Coordinates.Rows[index].Cells["cY"].Value = y;
            grid_Coordinates.Rows[index].Cells["cZ"].Value = z;
            grid_Coordinates.Rows[index].Cells["cTag"].Value = tag;

            Close();
        }
    }
}
