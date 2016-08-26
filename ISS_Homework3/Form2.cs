using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Security.Principal;
using System.Data.SqlClient;
using System.Threading;
using System.Management;
using System.Security.AccessControl;
namespace ISS_Homework3
{
    public partial class Form2 : Form
    {
        static SqlConnection conn = new SqlConnection();
        int user_id;
        String username;
        String filename;
        public Form2()
        {
            InitializeComponent();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath+"\\logfile.txt", true))
            {
                file.WriteLine("<: Log File :>"+ Environment.NewLine);
            }
            string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='c:\users\luay al assadi\documents\visual studio 2013\Projects\ISS_Homework3\ISS_Homework3\labellSYSTEM.mdf';Integrated Security=True";
            //string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + Application.StartupPath + "\\labellSYSTEM.mdf';Integrated Security=True";
            conn.ConnectionString = sqlCon;
            conn.Open();

            String [] x = (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\');

            SqlCommand dir = new SqlCommand("SELECT * FROM [Dir]", conn);
            String Dir_name="" ;
            using (SqlDataReader result = dir.ExecuteReader())
            {
                while (result.Read())
                {
                    Dir_name = result["DirectoryName"].ToString();
                }
            }
            bool is_users = false;
            if (Dir_name.Length > 1)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [sys_users] where username=@0", conn);
                command.Parameters.Add(new SqlParameter("0", x[0] + "!" + x[1]));
                using (SqlDataReader result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        if (Convert.ToInt32(result["is_admin"]) == 2)
                        {
                            Form1 system = new Form1(Dir_name);
                            this.Hide();
                            system.Show();
                        }
                        user_id = Convert.ToInt32(result["user_id"]);
                        is_users = true;
                    }
                }
            }
            if (!is_users) {
                panel1.Visible = true;
            }

            username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            label6.Text = username;
            label5.Text=@"C:\Users\Public\ISS_Lab";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = Application.StartupPath;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                label3.Text = folderBrowser.SelectedPath;
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO [Dir] (DirectoryName) VALUES (@0)", conn);
            insertCommand.Parameters.Add(new SqlParameter("0", label3.Text));
            insertCommand.ExecuteNonQuery();

            Form1 system = new Form1(label3.Text,false);
            system.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = Application.StartupPath;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                label5.Text = folderBrowser.SelectedPath;
                textBox2.Visible = true;
                button4.Visible = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                filename = label5.Text + "\\" + textBox2.Text;
                int file_isl_id=0;
                int user_isl_id=0;
                SqlCommand command = new SqlCommand("SELECT * FROM [files] where filename=@0", conn);
                command.Parameters.Add(new SqlParameter("0", textBox2.Text));
                using (SqlDataReader result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        file_isl_id = Convert.ToInt32(result["isl_id"]);
                    }
                }

                SqlCommand usercommand = new SqlCommand("SELECT * FROM [user_isl] where user_id=@0", conn);
                usercommand.Parameters.Add(new SqlParameter("0", user_id));
                using (SqlDataReader result = usercommand.ExecuteReader())
                {
                    while (result.Read())
                    {
                            user_isl_id = Convert.ToInt32(result["isl_id"]);
                    }
                }

                if (file_isl_id < user_isl_id)
                {
                    //AddFileSecurity(filename, username, FileSystemRights.Read, AccessControlType.Allow);
                    //RemoveFileSecurity(filename, username, FileSystemRights.Read, AccessControlType.Deny);
                    using (FileStream aFile = new FileStream(filename, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(aFile))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " Modified BY :" + username + Environment.NewLine);
                        sw.WriteLine(textBox1.Text);
                        sw.WriteLine("---------- END User Edition --------------");
                    }

                    //AddFileSecurity(filename, username, FileSystemRights.Read, AccessControlType.Deny);
                    label7.Text = "you text was added successfully";
                    textBox1.Text = "";
                }
                else
                    label7.Text = "Sorry you cant append text to this file";
            }
            catch (Exception ex) {
                MessageBox.Show("Check The file name or permissions");
            }
            finally{
                label5.Text = "";
                textBox2.Visible = false;
                button4.Visible = false;
            }
        }

        public static void AddFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {


            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fSecurity);

        }

        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {

            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Remove the FileSystemAccessRule from the security settings.
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fSecurity);

        }


    }
}
