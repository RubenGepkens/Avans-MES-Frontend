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
    public partial class frmOPCSettings : Form
    {
        public string strServerAdress { get; set; }
        public int intServerPort { get; set; }

        public frmOPCSettings()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
        }

        private void frmOPCSettings_Load(object sender, EventArgs e)
        {
            if ( strServerAdress != "" && intServerPort >= 0 && intServerPort <= 65536 )
            {
                txtServerAdress.Text    = strServerAdress;
                txtServerPort.Value     = (decimal)intServerPort;
            } else
            {
                txtServerAdress.Text    = "127.0.0.1";
                txtServerPort.Value     = 4840;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            strServerAdress     = txtServerAdress.Text;
            intServerPort       = (int)txtServerPort.Value;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}