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
        public DateTime dtOrderDate { get; set; }      
        
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
                }
            }

            if (lstProductionlines != null)
            {
                foreach (string item in lstProductionlines)
                {
                    cbxProductionLine.Items.Add(item);
                }
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
            if (dtOrderDate < dtpOrderDate.MinDate || dtOrderDate > dtpOrderDate.MaxDate)
            {
                dtpOrderDate.Value = DateTime.Now;
            } else
            {
                dtpOrderDate.Value = dtOrderDate;
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
                txtOrderize1.Value = (decimal)intOrderSize;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            strOrdername                = cbxOrdername.Text;
            strOrdernumber              = txtOrdernumber.Text;
            strDescription              = txtDescription.Text;
            dtOrderDate                 = dtpOrderDate.Value;
            strSelectedProducionline    = cbxProductionLine.Text;
            strSelectedRecipe           = cbxRecipe.Text;
            intOrderSize                = (int)txtOrderize1.Value;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
