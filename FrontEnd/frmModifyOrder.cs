using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class frmModifyOrder : Form
    {
        public string strFormTitle { get; set; }
        public string strOrdername { get; set; }
        public string strOrdernumber { get; set; }
        public DateTime dtOrderDate { get; set; }
        public int intOrderSize { get; set; }
        public List<string> lstRecipes { get; set; }
        public List<string> lstCustomers { get; set; }
        public List<string> lstProductionlines { get; set; }

        public string strSelectedRecipe { get; set; }
        public string strSelectedCustomer{ get; set; }
        public string strSelectedProducionline { get; set; }

        public frmModifyOrder()
        {
            InitializeComponent();
        }

        private void frmModifyOrder_Load(object sender, EventArgs e)
        {
            // Set the form title
            this.Text = strFormTitle;

            // Retrieve lists conaining recipes, customers (descriptions) and production lines.
            foreach (string item in lstRecipes)
            {
                cbxRecipe.Items.Add(item);
            }

            foreach (string item in lstCustomers)
            {
                cbxDescription.Items.Add(item);
            }

            foreach (string item in lstProductionlines)
            {
                cbxProductionLine.Items.Add(item);
            }

            // Fill boxes.
            if ( strOrdername != null)
            {
                txtOrderName.Text = strOrdername;
            }

            if ( strOrdernumber != null)
            {
                txtOrdernumber.Text = strOrdernumber;
            }

            if ( strSelectedCustomer != null)
            {
                cbxDescription.SelectedItem = strSelectedCustomer;
            }
            
            // If orderdate is out of bounds, use todays date instead.
            if (dtOrderDate < dtpOrderDate.MinDate || dtOrderDate > dtpOrderDate.MaxDate)
            {
                dtOrderDate = DateTime.Now;
            }

            if ( strSelectedProducionline != null)
            {
                cbxProductionLine.SelectedItem = strSelectedProducionline;
            }

        }

        private void frmModifyOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            strOrdernumber      = txtOrdernumber.Text;
            strSelectedCustomer = cbxDescription.Text;
            dtOrderDate         = dtpOrderDate.Value;
            intOrderSize        = (int)txtOrderize1.Value;
            //strSelectedRecipe   = cbxRecipe.SelectedItem.ToString();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtOrderize1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
