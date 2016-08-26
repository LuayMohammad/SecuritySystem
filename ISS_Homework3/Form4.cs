using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISS_Homework3
{
    public partial class Form4 : Form
    {
        static int i=0;
        static SqlConnection conn = new SqlConnection();
        String fpath;
        public Form4(String path)
        {
            InitializeComponent();
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='c:\users\luay al assadi\documents\visual studio 2013\Projects\ISS_Homework3\ISS_Homework3\labellSYSTEM.mdf';Integrated Security=True";
                //string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + Application.StartupPath + "\\labellSYSTEM.mdf';Integrated Security=True";
                conn.ConnectionString = sqlCon;
                conn.Open();
            }
            fpath = path;
            files.Rows.Clear();
            i = 0;
            files.RowCount = 1;
            ProcessDirectory(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = Application.StartupPath;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowser.SelectedPath;
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessDirectory(fpath);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
                i++;
                files.RowCount = i+1;
            }

            // Recurse into subdirectories of this directory.
            /*string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
             */ 
        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            files.Rows[i].Cells[0].Value = "*";
            files.Rows[i].Cells[1].Value = @path;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            for (int x = 0; x < files.RowCount-1; x++)
            {
                if (String.Compare(files.Rows[x].Cells[0].Value.ToString() ,"D")!=0)
                {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO [files] (filename, directory ) VALUES (@0, @1)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", Path.GetFileName(files.Rows[x].Cells[1].Value.ToString())));
                insertCommand.Parameters.Add(new SqlParameter("1", Path.GetDirectoryName(files.Rows[x].Cells[1].Value.ToString())));
                insertCommand.ExecuteNonQuery();
                files.Rows[x].Cells[0].Value = "^";
                }
            }
            label1.Text = label1.Text + " The Files Saved To Database Successfully";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            files.Rows[files.CurrentCell.RowIndex].Cells[0].Value = "D";
        }
    }
}
