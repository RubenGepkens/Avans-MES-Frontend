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
        public int intBatchNumber { get; set; }
        public string strCustomerName { get; set; }
        public string strOrderDate { get; set; }
        public int intOrderSize { get; set; }
        public List<string> lstRecipes { get; set; }
        public string strSelectedRecipe { get; set; }

        public frmModifyOrder()
        {
            InitializeComponent();
        }

        private void frmModifyOrder_Load(object sender, EventArgs e)
        {
            int intRecipeSize = lstRecipes.Count;

            if ( intRecipeSize > 0)
            {
                for ( int x = 0; x < intRecipeSize; x++)
                {
                    cbxRecipe.Items.Add(lstRecipes[x]);
                }
                
            }

            DateTime dtOrderDate = Convert.ToDateTime(strOrderDate);

            txtBatchnumber.Value = intBatchNumber;
            txtCustomerName.Text = strCustomerName;
            dtpOrderDate.Value = dtOrderDate;
            txtOrderize.Value = intOrderSize;
            cbxRecipe.SelectedItem = strSelectedRecipe;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DateTime dtOrderDate = dtpOrderDate.Value;

            intBatchNumber = (int)txtBatchnumber.Value;
            strCustomerName = txtCustomerName.Text;
            strOrderDate = dtOrderDate.ToString("yyy-MM-dd");
            intOrderSize = (int)txtOrderize.Value;
            strSelectedRecipe = cbxRecipe.SelectedItem.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
