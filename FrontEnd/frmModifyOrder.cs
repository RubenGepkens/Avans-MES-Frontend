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
        public string strProductionlineWhite { get; set; }
        public string strProductionlineBrown { get; set; }
        public string strSelectedRecipe { get; set; }
        public int intOrderSize { get; set; }
        public int intAmountBrown { get; set; }
        public int intAmountWhite { get; set; }

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

            // dtpOrderStartDate - If orderdate is out of bounds, use todays date instead.
            if (dtOrderStartDate < dtpOrderStartDate.MinDate || dtOrderStartDate > dtpOrderStartDate.MaxDate)
            {
                dtpOrderStartDate.Value = DateTime.Now;
            } else
            {
                dtpOrderStartDate.Value = dtOrderStartDate;
            }

            // dtpOrderEndDate - If orderdate is out of bounds, use todays date instead.
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

            if (intOrderSize <= 100)
            {
                txtOrderize.Value = 100;
            } else if (intOrderSize > 100)
            {
                txtOrderize.Value = (decimal)intOrderSize;
            }

            // If the form's properties are filled, an order is being modified and an extra recipe is not allowed.
            // Therefore, disable this function.
            if (strOrdername != null || strOrdernumber != null || strDescription !=null)
            {                
                ckxExtraRecipe.Enabled = false;
                cbxRecipe.Enabled = false;
            }

            txtOrderizeExtra.Value = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Check if all boxes are filled with data
            if (cbxOrdername.Text == "" ||
                            txtOrdernumber.Text == "" ||
                            txtDescription.Text == "" ||
                            cbxProductionLine.Text == "" ||
                            cbxRecipe.Text == ""
                )
            {
                MessageBox.Show("Niet alle velden zijn ingevuld. De order kon niet worden ingevoegd of worden gewijzigd.\nControlleer of alle velden zijn ingevuld.", "Formulier niet compleet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (txtOrderize.Value < 100 ||
                            ckxExtraRecipe.Checked == true && (cbxProductionLineExtra.Text == "" || cbxRecipeExtra.Text == "" || txtOrderizeExtra.Value < 100)
                      )
            {
                MessageBox.Show("Het bestelde aantal mag niet kleiner zijn dan 100 stuks.\nVerander het aantal voordat .", "Formulier niet compleet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                strOrdername = cbxOrdername.Text;
                strOrdernumber = txtOrdernumber.Text;
                strDescription = txtDescription.Text;
                dtOrderStartDate = dtpOrderStartDate.Value;
                dtOrderEndDate = dtpOrderEndDate.Value;
                strProductionlineWhite = cbxProductionLine.Text;
                strProductionlineBrown = cbxProductionLineExtra.Text;
                strSelectedRecipe = cbxRecipe.Text;
                //intOrderSize                = (int)txtOrderize.Value;
                //intOrderSizeExtra           = (int)txtOrderizeExtra.Value;




                if (cbxRecipe.SelectedIndex == 0)
                {
                    //Console.WriteLine("1=0");
                    strProductionlineBrown = cbxProductionLine.SelectedItem.ToString();
                } else if (cbxRecipe.SelectedIndex == 1)
                {
                    //Console.WriteLine("1=1");
                    strProductionlineWhite = cbxProductionLine.SelectedItem.ToString();
                } 
                
                if (cbxRecipeExtra.SelectedIndex == 0)
                {
                    //Console.WriteLine("2=0");
                    strProductionlineBrown = cbxProductionLineExtra.SelectedItem.ToString();
                } else if (cbxRecipeExtra.SelectedIndex == 1)
                {
                    //Console.WriteLine("2=1");
                    strProductionlineWhite = cbxProductionLineExtra.SelectedItem.ToString();
                }

                // #################
                intAmountWhite = 0;
                intAmountBrown = 0;
                if (cbxRecipe.SelectedIndex == 0)
                {
                    intAmountBrown += (int)txtOrderize.Value;
                } else
                {
                    intAmountWhite += (int)txtOrderize.Value;
                }

                if (cbxRecipeExtra.SelectedIndex == 0)
                {
                    intAmountBrown += (int)txtOrderizeExtra.Value;
                }
                else
                {
                    intAmountWhite += (int)txtOrderizeExtra.Value;                   
                }


               // Console.WriteLine("1Line:{0}\t 1Recipe:{1}\n2Line:{3}\t2Recipe:{4}", cbxProductionLine.SelectedIndex, cbxRecipe.SelectedIndex, cbxProductionLineExtra.SelectedIndex, cbxRecipeExtra.SelectedIndex);
               //Console.WriteLine("intAmountBrown: {0}\nintAmountWhite: {1}", intAmountBrown, intAmountWhite);

                this.DialogResult = DialogResult.OK;
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
                txtOrderizeExtra.Value              = 100;
                cbxProductionLineExtra.Enabled      = true;
                cbxRecipeExtra.Enabled              = true;
                txtOrderizeExtra.Enabled            = true;
            } else
            {
                txtOrderizeExtra.Value              = 0;
                cbxProductionLineExtra.Enabled      = false;
                cbxRecipeExtra.Enabled              = false;
                txtOrderizeExtra.Enabled            = false;
            }
        }
    }
}