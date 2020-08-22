using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IEEEPaperPublish
{
    public partial class FrmShowUploadedDocs : Form
    {
        public FrmShowUploadedDocs()
        {
            InitializeComponent();
        }

        private void FrmShowUploadedDocs_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0EIS76DV;Initial Catalog=jcdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select DocumentType, ArticleTitle, Journaltitle, Author1, Faculty, Department, Affiliation, DocPath from PaperDetails", con);

            try
            {

               
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                con.Close();

            }

            catch (Exception ec)
            {

                MessageBox.Show(ec.Message);

            }
        }
    }
}
