using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDatabase
{
    public partial class frmSearch : Form
    {
        List<Car> listOfCars = DataAccess.getAllCars();
        public frmSearch()
        {
            InitializeComponent();
            Text = "Task A Search Carl Wainwright " + DateTime.Now.ToString("dd/MM/yyyy");
            //Format date and price columns in datagridview
            DateRegistered.DefaultCellStyle.Format = "dd'/'MM'/'yyyy";
            RentalPerDay.DefaultCellStyle.Format = String.Format(new CultureInfo("en-GB"), "{0:C}", 0);
            RentalPerDay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            setUp();
        }
        private void setUp()
        {   //Loop through list of cars and add to datagridview
            for (int i = 0; i < listOfCars.Count; i++)
            {
                dgvCars.Rows.Add(listOfCars[i].VehicleRegNo,
                    listOfCars[i].Make,
                    listOfCars[i].EngineSize,
                    listOfCars[i].DateRegistered,
                    listOfCars[i].RentalPerDay,
                    listOfCars[i].Available);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {   //CLose form and open first
            frmCars cars = new frmCars();
            this.Hide();
            cars.ShowDialog();
            this.Close();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {   //Check if all fields have data
            if (cboField.Text.Length == 0 || cboField.Text.Length == 0 || txtValue.TextLength == 0)
            {
                MessageBox.Show("Please ensure all fields have a selection to search", "Invalid Search Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {   //Switch to run which fields are selected
                switch (cboField.Text)
                {
                    case "Make":
                        listOfCars = DataAccess.searchOperator("Make", cboOperator.Text, txtValue.Text);
                        break;
                    case "Engine Size":
                        listOfCars = DataAccess.searchOperator("EngineSize", cboOperator.Text, txtValue.Text + "L");
                        break;
                    case "Rental Per Day":
                        listOfCars = DataAccess.searchOperator("RentalPerDay", cboOperator.Text, txtValue.Text);
                        break;
                    case "Available":
                        listOfCars = DataAccess.searchOperator("Available", cboOperator.Text, txtValue.Text);
                        break;
                }
                //Clear all data before loading new search result
                dgvCars.Rows.Clear();
                setUp();
            }
        }
    }
}
