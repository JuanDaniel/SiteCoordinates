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
    public partial class AddForm : System.Windows.Forms.Form
    {
        DataGridView grid_Coordinates;

        public AddForm(DataGridView grid_Coordinates)
        {
            InitializeComponent();

            this.grid_Coordinates = grid_Coordinates;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            double x, y, z;

            if (!(double.TryParse(txt_X.Text, out x) && double.TryParse(txt_Y.Text, out y) && double.TryParse(txt_Z.Text, out z)))
            {
                MessageBox.Show("Invalid coordinates values.", "Add coordinate", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Core.ExistCoordinate(grid_Coordinates.Rows, new XYZ(x, y, z)))
            {
                MessageBox.Show("Duplicates coordinates", "Add coordinate", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            grid_Coordinates.Rows.Add(x, y, z, Core.GenerateTag(grid_Coordinates.Rows));

            ResetForm();

            if (chk_Close.Checked)
            {
                Close();
            }
        }

        private void ResetForm()
        {
            txt_X.Clear();
            txt_Y.Clear();
            txt_Z.Clear();
        }
    }
}
