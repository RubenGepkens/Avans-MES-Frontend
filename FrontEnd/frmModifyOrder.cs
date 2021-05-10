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
        public int intBatchNumber { get; set; }
        public string strCustomerName { get; set; }
        public DateTime dtOrderDate { get; set; }
        public int intOrderSize { get; set; }
        public List<string> lstRecipes { get; set; }
        public string strSelectedRecipe { get; set; }

        public frmModifyOrder()
        {
            InitializeComponent();
        }

        private void frmModifyOrder_Load(object sender, EventArgs e)
        {
            this.Text = strFormTitle;
            
            int intRecipeSize = lstRecipes.Count;

            if ( intRecipeSize > 0)
            {
                for ( int x = 0; x < intRecipeSize; x++)
                {
                    cbxRecipe.Items.Add(lstRecipes[x]);
                }                
            }


            DateTime dtOrderDate = Convert.ToDateTime( DateTime.Now.ToString("dd-MM-yyyy") );

            txtBatchnumber.Value    = intBatchNumber;
            txtCustomerName.Text    = strCustomerName;
            dtpOrderDate.Value      = dtOrderDate;
            txtOrderize.Value       = intOrderSize;
            
            if ( strSelectedRecipe == null)
            {
                Console.WriteLine("strSelectedRecipe == null");
                cbxRecipe.SelectedIndex = 0;
            } else
            {
                Console.WriteLine("strSelectedRecipe != null");
                cbxRecipe.SelectedItem = strSelectedRecipe;
            }                        
        }

        private void frmModifyOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            intBatchNumber = (int)txtBatchnumber.Value;
            strCustomerName = txtCustomerName.Text;
            dtOrderDate = dtpOrderDate.Value;
            intOrderSize = (int)txtOrderize.Value;
            strSelectedRecipe = cbxRecipe.SelectedItem.ToString();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
