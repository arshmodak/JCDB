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
    public partial class FrmUploadDoc : Form
    {
        public FrmUploadDoc()
        {
            InitializeComponent();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

        }
        public void ClearControl()
        {
            cmbdoctype .SelectedIndex = 1;
            txtarticle.Text = "";
            txtjournal.Text = "";
            txtauthor1.Text = "";
            txtfaculty.Text = "";
            cmbdept.SelectedIndex = 1;
            txtaffication.Text = "";
            txtvolume.Text = "";
            txtissue.Text = "";
            txtpagefrom.Text = "";
            txtpageto.Text = "";
            //this.dateTimePicker1.Value = DateTime.Now;
            lblDocPath.Text = "";
            comboBox1.SelectedIndex = 1; 

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "E:\\Project\\JCstoreFolder";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "PDF Files Only|*.pdf";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        lblDocPath.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload Document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {//Data Source=PC-PC\SQLEXPRESS;Initial Catalog=IEEEPAPER;Integrated Security=True
                    //SqlConnection con = new SqlConnection("data source=PC-PC\\SQLEXPRESS (sa); integrated security=true; database=IEEEPAPER;");
                    //Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\SAIRAM1\DOCUMENTS\IEEEPAPER.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True
                    //SqlConnection con = new SqlConnection(@"Data Source=(local) (LAPTOP-0EIS76DV\Arsh Modak);AttachDbFilename=C:\Users\Arsh Modak\Documents\jcdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0EIS76DV;Initial Catalog=jcdb;Integrated Security=True");
                    //Data Source=LAPTOP-0EIS76DV;Initial Catalog=jcdb;Integrated Security=True
                    con.Open();
                    DateTime dt = this.dateTimePicker1.Value.Date;
                    //string date = dt.ToString();
                   // string monthyear = CmbMonth.Text + CmbYear.Text;
                    //SqlCommand cmd = new SqlCommand("insert into PaperDetails (DocumentType)values ('" + cmbdoctype.SelectedItem.ToString() + "')",con);
                    //ArticleTitle, JournalTitle, Author1, Author2, Author3, Faculty, Department, Affiliation, Volume, Issue, PagenoFrom, PagenoTo, YearofPublication, DocPath, UpdatedBy, UpdatedOn) values('" + cmbdoctype.SelectedItem.ToString() + "','" + txtarticle.Text + "','" + txtjournal.Text + "','" + txtauthor1.Text + "','" + txtauthor2.Text + "','" + txtAuthor3.Text + "','" + txtfaculty.Text + "','" + cmbdept.SelectedItem.ToString() + "','" + txtaffication.Text + "','" + txtvolume.Text + "','" + txtissue.Text + "','" + txtpagefrom.Text + "','" + txtpageto.Text + "','" + dt + "','E:\\Project\\JCstoreFolder\\" + filename + "','cd02238',getdate())", con);
                    SqlCommand cmd = new SqlCommand("insert into PaperDetails (DocumentType, ArticleTitle, JournalTitle, Author1, Author2, Author3, Faculty, Department, Affiliation, Volume, Issue, PagenoFrom, PagenoTo, YearofPublication, DocPath, UpdatedBy, UpdatedOn, Indexing) values('" + cmbdoctype.SelectedItem.ToString() + "','" + txtarticle.Text + "','" + txtjournal.Text + "','" + txtauthor1.Text + "','" + txtauthor2.Text + "','" + txtAuthor3.Text + "','" + txtfaculty.Text + "','" + cmbdept.SelectedItem.ToString() + "','" + txtaffication.Text + "','" + txtvolume.Text + "','" + txtissue.Text + "','" + txtpagefrom.Text + "','" + txtpageto.Text + "','" + dt + "','E:\\Project\\JCstoreFolder\\" + filename + "','cd02238', getdate(), '" + comboBox1.SelectedItem.ToString() + "')", con);
                    //string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    string path = "E:\\Project\\JCstoreFolder\\";
                    System.IO.File.Copy(openFileDialog1.FileName, path  + filename);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Document uploaded.");
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbdoctype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbdoctype.SelectedItem.ToString() == "National Conference" || cmbdoctype.SelectedItem.ToString() == "InterNational Conference")
            {
                txtvolume.Visible = false;
                txtissue.Visible = false;
                lblvolume.Visible = false;
                lblissue.Visible = false;
            }else
            {
                txtvolume.Visible = true ;
                txtissue.Visible = true;
                lblvolume.Visible = true;
                lblissue.Visible = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblissue_Click(object sender, EventArgs e)
        {

        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

           
     

    }
}
