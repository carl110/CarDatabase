using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDatabase
{
    public partial class frmCars : Form
    {
        private List<Car> listOfCars = DataAccess.getAllCars();
        private int recordNumber = 0;
        public frmCars()
        {
            InitializeComponent();
            Text = "Task A Carl Wainwright " + DateTime.Now.ToString("dd/MM/yyyy");
            showRecord();
        }
        private void updateList()
        {   //method to update listOfCars
            listOfCars = DataAccess.getAllCars();
        }
        private void showRecord()
        { //Method to show data according to list number called 
            if (listOfCars.Count > 0)
            {
                txtRegNo.Text = listOfCars[recordNumber].VehicleRegNo;
                txtMake.Text = listOfCars[recordNumber].Make;
                txtEngineSize.Text = listOfCars[recordNumber].EngineSize;
                txtDateReg.Text = listOfCars[recordNumber].DateRegistered.ToString("dd/MM/yyyy");
                txtRental.Text = string.Format(new CultureInfo("en-GB"), "{0:C}", listOfCars[recordNumber].RentalPerDay);
                chkAvailable.Checked = listOfCars[recordNumber].Available;
                txtRecordCount.Text = (recordNumber + 1) + " of " + listOfCars.Count;
            }
            else
            {   //If no cars exist show empty fields
                txtRegNo.Clear();
                txtMake.Clear();
                txtEngineSize.Clear();
                txtDateReg.Clear();
                txtRental.Clear();
                chkAvailable.Checked = false;
                txtRecordCount.Text = "No Records";
            }
        }
        private bool invalidFields()
        {
            DateTime value;
            //check is an txtfields are empty
            if (txtRegNo.Text.Length == 0 || txtMake.Text.Length == 0 || txtEngineSize.Text.Equals("L") || txtDateReg.Text.Length == 0 || txtRental.Text.Length == 0)
            {
                return true;
            }//Check if date field holds a date
            else if (DateTime.TryParse(txtDateReg.Text, out value) == false)
            {
                return true;
            }
            else return false;
        }
        private string setAsDouble(object sender)
        {
            string doubleString = "";
            //Loop through each character in string
            for (int i = 0; i < (sender as TextBox).Text.Length; i++)
            {
                doubleString += (sender as TextBox).Text[i];
                //If first character accepted is a decimal add a 0 before it
                if (doubleString == ".")
                {
                    doubleString = "0.";
                }
                //Check string is double, romove character if not
                if (!double.TryParse(doubleString, out double _))
                {
                    doubleString = doubleString.Remove(doubleString.Length - 1);
                }
            }
            return doubleString;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < listOfCars.Count; i++)
            {   //loop list of cars to see if reg exists
                if (listOfCars[i].VehicleRegNo.Equals(txtRegNo.Text))
                {
                    exists = true;
                    i = listOfCars.Count;
                }
            }
            if (exists == true)
            {   //allow update if reg exists
                if (invalidFields() == false)
                {       //update sql table and show confiration message
                    DataAccess.updateCar(txtRegNo.Text, txtMake.Text, txtEngineSize.Text, DateTime.ParseExact(txtDateReg.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), Convert.ToDouble(txtRental.Text.Substring(1)), chkAvailable.Checked);
                    MessageBox.Show("Your update has been processed", "Car updated", MessageBoxButtons.OK);
                    updateList();
                    showRecord();
                }
                else
                {   //advise invalid field data
                    MessageBox.Show("One of your fields are invalid", "Invalid Field(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {   //message to advise reg doesnt exist
                MessageBox.Show("This car does not exist, you may Add this vehicle as a new record", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool duplicate = false;
            for (int i = 0; i < listOfCars.Count - 1; i++)
            {   //loop list to see if reg exists
                if (listOfCars[i].VehicleRegNo.Equals(txtRegNo.Text))
                {
                    duplicate = true;
                    i = listOfCars.Count;
                }
            }
            if (duplicate == true)
            {   //if exists then advise they can update
                MessageBox.Show("This car already exists on the database, you may update but not add as new", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {   //check txt fields
                if (invalidFields() == false)
                {   //Add car to sql table and update ist
                    DataAccess.addCar(txtRegNo.Text, txtMake.Text, txtEngineSize.Text, DateTime.ParseExact(txtDateReg.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), Convert.ToDouble(txtRental.Text.Substring(1)), chkAvailable.Checked);
                    updateList();
                    recordNumber = listOfCars.Count - 1;
                    MessageBox.Show("Your vehicle has been added to the database", "Vheicle Added", MessageBoxButtons.OK);
                    showRecord();
                }
                else
                {
                    MessageBox.Show("One of your fields are invalid", "Invalid Field(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < listOfCars.Count; i++)
            {   //loop list of cars to see if reg exists
                if (listOfCars[i].VehicleRegNo.Equals(txtRegNo.Text))
                {
                    exists = true;
                    i = listOfCars.Count;
                }
            }
            if (exists == true)
            {   //Delete current item for sql table
                DataAccess.deleteCar(txtRegNo.Text);
                if (recordNumber != 0)
                {
                    recordNumber -= 1;
                }
                updateList();
                showRecord();
            }
            else
            {
                MessageBox.Show("This Reg does not exist, there fore it cannot be deleted.", "Invalid Reg", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {   //open search form and close this
            frmSearch search = new frmSearch();
            this.Hide();
            search.ShowDialog();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {   //undo text changes by showing current held record data
            showRecord();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {   //Close program
            Application.Exit();
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {   //goto record 0 on list
            recordNumber = 0;
            showRecord();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {   //check if already on first item, if so goto last
            if (recordNumber == 0)
            {
                recordNumber = listOfCars.Count - 1;
            }
            else
            {
                recordNumber -= 1;
            }
            showRecord();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {   //check if on last item, if so goto first
            if (recordNumber == listOfCars.Count - 1)
            {
                recordNumber = 0;
            }
            else
            {
                recordNumber += 1;
            }
            showRecord();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {   //goto last item in list
            recordNumber = listOfCars.Count - 1;
            showRecord();
        }
        private void txtEngineSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 'L') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == 'L') && ((sender as TextBox).Text.IndexOf('L') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtEngineSize_Leave(object sender, EventArgs e)
        {   //Ensures L is placed at the end of number
            (sender as TextBox).Text = setAsDouble(sender) + "L";
        }
        private void txtRental_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '£') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '£') && ((sender as TextBox).Text.IndexOf('£') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtRental_Leave(object sender, EventArgs e)
        {   //Check box is not empty
            if ((sender as TextBox).TextLength > 0)
            {
                if (!string.IsNullOrEmpty(setAsDouble(sender)))
                {   //Only run if return is not null
                    (sender as TextBox).Text = String.Format(new CultureInfo("en-GB"), "{0:C}", Convert.ToDouble(setAsDouble(sender)), 2);
                }
                else
                {
                    (sender as TextBox).Clear();
                }
            }
        }
        private void txtDateReg_KeyPress(object sender, KeyPressEventArgs e)
        {   //only allow numbers and / to be entered
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }
        private void txtDateReg_Leave(object sender, EventArgs e)
        {   //Check date is correct type
            Regex reg = new Regex(@"^(\d{1,2})/(\d{1,2})/(\d{4})$");
            Match m = reg.Match((sender as TextBox).Text);
            if (m.Success)
            {
                int dd = int.Parse(m.Groups[1].Value);
                int mm = int.Parse(m.Groups[2].Value);
                int yyyy = int.Parse(m.Groups[3].Value);
                try
                {
                    (sender as TextBox).Text = System.Convert.ToDateTime((sender as TextBox).Text).ToString("dd/MM/yyyy");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Invalid date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    (sender as TextBox).Clear();
                }
            }
            else
            {
                MessageBox.Show("Wrong date format. The date should be in the format of dd/MM/yyyy ie. 21/02/2019", "Invalid date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                (sender as TextBox).Clear();
            }
        }
    }
}
