using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEEEPaperPublish
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

   
        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin" || txtpassword.Text == "admin")
            {
                this.Hide();
                MDIParent1 mdi = new MDIParent1();
                mdi.Show();




                //Frmmaster MAS = new Frmmaster();
                //MAS.Show();
            }
            else
                MessageBox.Show("Please Enter Correct Username or Password");
        }
    }
}
