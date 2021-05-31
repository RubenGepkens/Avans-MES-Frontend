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
        public string strDescription { get; set; }
        public DateTime dtOrderStartDate { get; set; }
        public DateTime dtOrderEndDate { get; set; }

        public List<string> lstRecipes { get; set; }
        public List<string> lstOrdername { get; set; }
        public List<string> lstProductionlines { get; set; }
        
        public string strSelectedProducionline { get; set; }
        public string strSelectedRecipe { get; set; }
        public int intOrderSize { get; set; }
        
        public frmModifyOrder()
        {
            InitializeComponent();
        }

        private void frmModifyOrder_Load(object sender, EventArgs e)
        {
            // Set the form title
            this.Text = strFormTitle;

            // Retrieve lists conaining recipes, customers (descriptions) and production lines.
            
            if (lstOrdername != null)
            {
                foreach (string item in lstOrdername)
                {
                    cbxOrdername.Items.Add(item);
                }
            }        

            if (lstRecipes != null)
            {
                foreach (string item in lstRecipes)
                {
                    cbxRecipe.Items.Add(item);
                    cbxRecipeExtra.Items.Add(item);
                }
                cbxRecipe.SelectedIndex = 0;
                cbxRecipeExtra.SelectedIndex = 1;
            }

            if (lstProductionlines != null)
            {
                foreach (string item in lstProductionlines)
                {
                    cbxProductionLine.Items.Add(item);
                    cbxProductionLineExtra.Items.Add(item);
                }
                cbxProductionLine.SelectedIndex = 0;
                cbxProductionLineExtra.SelectedIndex = 1;
            }            

            // Fill boxes.
            if (strOrdername != null)
            {
                cbxOrdername.SelectedItem = strOrdername;
            }

            if (strOrdernumber != null)
            {
                txtOrdernumber.Text = strOrdernumber;
            }

            if (strDescription != null)
            {
                txtDescription.Text = strDescription;
            }

            // If orderdate is out of bounds, use todays date instead.
            if (dtOrderStartDate < dtpOrderStartDate.MinDate || dtOrderStartDate > dtpOrderStartDate.MaxDate)
            {
                dtpOrderStartDate.Value = DateTime.Now;
            } else
            {
                dtpOrderStartDate.Value = dtOrderStartDate;
            }

            // If orderdate is out of bounds, use todays date instead.
            if (dtOrderEndDate < dtpOrderEndDate.MinDate || dtOrderEndDate > dtpOrderEndDate.MaxDate)
            {
                dtpOrderEndDate.Value = DateTime.Now;
            }
            else
            {
                dtpOrderEndDate.Value = dtOrderEndDate;
            }

            if (strSelectedProducionline != null)
            {
                cbxProductionLine.SelectedItem = strSelectedProducionline;
            }

            if (strSelectedRecipe != null)
            {
                cbxRecipe.SelectedItem = strSelectedRecipe;
            }

            if (intOrderSize >= 0)
            {
                txtOrderize.Value = (decimal)intOrderSize;
            }

            // If the form's properties are filled, an order is being modified and an extra recipe is not allowed.
            // Therefore, disable this function.
            if ( strOrdername != null || strOrdernumber != null || strDescription !=null)
            {
                ckxExtraRecipe.Enabled = false;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Check if all boxes are filled with data
            if (    cbxOrdername.Text == null ||
                    txtOrdernumber.Text == null ||
                    txtDescription.Text == null ||
                    cbxProductionLine.Text == null ||
                    cbxRecipe.Text == null ||
                    txtOrderize.Value == 0 ||
                    ckxExtraRecipe.Checked == true && (cbxProductionLineExtra.Text == null || cbxRecipeExtra.Text == null || txtOrderizeExtra.Value == 0)
                )
            {
                MessageBox.Show("Niet alle velden zijn ingevuld. De order kon niet worden ingevoegd of worden gewijzigd.\nControlleer of alle velden zijn ingevuld.", "Formulier niet compleet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                this.DialogResult           = DialogResult.OK;

                strOrdername                = cbxOrdername.Text;
                strOrdernumber              = txtOrdernumber.Text;
                strDescription              = txtDescription.Text;
                dtOrderStartDate            = dtpOrderStartDate.Value;
                dtOrderEndDate              = dtpOrderEndDate.Value;
                strSelectedProducionline    = cbxProductionLine.Text;
                strSelectedRecipe           = cbxRecipe.Text;
                intOrderSize                = (int)txtOrderize.Value;

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ckxExtraRecipe_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckxExtraRecipe.Checked)
            {
                cbxProductionLineExtra.Enabled      = true;
                cbxRecipeExtra.Enabled              = true;
                txtOrderizeExtra.Enabled            = true;
            } else
            {                
                cbxProductionLineExtra.Enabled      = false;
                cbxRecipeExtra.Enabled              = false;
                txtOrderizeExtra.Enabled            = false;
            }
        }
    }
}