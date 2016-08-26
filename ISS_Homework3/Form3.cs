using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISS_Homework3
{
    public partial class Form3 : Form
    {
        static SqlConnection conn = new SqlConnection();
        List<ComboboxItem> isl = new List<ComboboxItem>();
        List<int> upper = new List<int>();
        public Form3()
        {
            InitializeComponent();
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='c:\users\luay al assadi\documents\visual studio 2013\Projects\ISS_Homework3\ISS_Homework3\labellSYSTEM.mdf';Integrated Security=True";
                //string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + Application.StartupPath + "\\labellSYSTEM.mdf';Integrated Security=True";
                conn.ConnectionString = sqlCon;
                conn.Open();
            }

            SqlCommand command = new SqlCommand("SELECT * FROM [isl] ", conn);
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    ComboboxItem item = new ComboboxItem();

                    item.p_id = Convert.ToInt32(result["ISL_parent"]);
                    item.Text = result["ISL_name"].ToString().Trim();
                    item.Value = Convert.ToInt32(result["id"]);
                    item.full = Convert.ToBoolean(result["fullcontrol"]);
                    item.read = Convert.ToBoolean(result["read_"]);
                    item.write = Convert.ToBoolean(result["write_"]);
                    item.execute = Convert.ToBoolean(result["execute_"]);
                    item.modify = Convert.ToBoolean(result["modify_"]);
                    item.delete = Convert.ToBoolean(result["Delete_"]);
                    comboBox1.Items.Add(item);
                    isl.Add(item);
                }
            }

            files.RowCount = 1;
            int i = 0;
            SqlCommand filecommand = new SqlCommand("SELECT * FROM [files] ", conn);
            using (SqlDataReader result = filecommand.ExecuteReader())
            {
                while (result.Read())
                {

                    files.Rows[i].Cells[0].Value = result["id"];
                    files.Rows[i].Cells[1].Value = result["directory"];
                    files.Rows[i].Cells[2].Value = result["filename"];
                    if (result["ISL_id"].ToString().Length>0)
                        try
                        {
                            files.Rows[i].Cells[3].Value = isl[search_current(Convert.ToInt32(result["ISL_id"]))].Text;
                        }
                        catch {
                            files.Rows[i].Cells[3].Value = "NULL";
                        }
                    files.RowCount++;
                    i++;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_file_permissions(Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).Value));
                    SqlCommand insertCommand = new SqlCommand("UPDATE [files] SET ISL_id=@0 where id=@1", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0", Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).Value)));
                    insertCommand.Parameters.Add(new SqlParameter("1", files.Rows[files.CurrentCell.RowIndex].Cells[0].Value));
                    insertCommand.ExecuteNonQuery();
            update_files();
            label2.Text = label2.Text + " The Classification has been added to the selected File";
        }

        private void update_file_permissions(int isl_id){
            SqlCommand command = new SqlCommand("SELECT * FROM [sys_users] inner join user_isl on user_isl.user_id = sys_users.user_id where isl_id=@0", conn);
            command.Parameters.Add(new SqlParameter("0", isl_id));
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    set_samelevel_acl(isl[search_current(isl_id)], result["username"].ToString().Trim().Replace('!','\\'));
                }
            }
            upper.Clear();
            recrusive_parents(isl[search_current(isl_id)].p_id);
            down_sons(isl_id);
        }

        private void set_samelevel_acl(ComboboxItem acl,String username){

            String fileName = files.Rows[files.CurrentCell.RowIndex].Cells[1].Value + "\\" + files.Rows[files.CurrentCell.RowIndex].Cells[2].Value;

            // Remove the access control entry from the file.
            if (acl.full)
            {
                RemoveFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Deny);
                AddFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Allow);
            }
            else {
                RemoveFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Allow);
                //AddFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Deny);
            }


            if (acl.read)
            {
                RemoveFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Deny);
                AddFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Allow);
            }
            else{
                //RemoveFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Allow);
                AddFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Deny);
            }


            if (acl.write)
            {
                RemoveFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Deny);
                AddFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Allow);
            }
            else{
                //RemoveFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Allow);
                AddFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Deny);
            }


            if (acl.execute)
            {
                RemoveFileSecurity(fileName, username, FileSystemRights.ExecuteFile, AccessControlType.Deny);
                AddFileSecurity(fileName, username, FileSystemRights.ExecuteFile, AccessControlType.Allow);
            }
            else {
                //RemoveFileSecurity(fileName, username, FileSystemRights.ExecuteFile, AccessControlType.Allow);
                AddFileSecurity(fileName, username, FileSystemRights.ExecuteFile, AccessControlType.Deny);
            }


            if (acl.delete)
            {
                RemoveFileSecurity(fileName, username, FileSystemRights.Delete, AccessControlType.Deny);
                AddFileSecurity(fileName, username, FileSystemRights.Delete, AccessControlType.Allow);
            }
            else {
                //RemoveFileSecurity(fileName, username, FileSystemRights.Delete, AccessControlType.Allow);
                AddFileSecurity(fileName, username, FileSystemRights.Delete, AccessControlType.Deny);
            }

            if (acl.modify)
            {
                RemoveFileSecurity(fileName, username, FileSystemRights.Modify, AccessControlType.Deny);
                AddFileSecurity(fileName, username, FileSystemRights.Modify, AccessControlType.Allow);
            }
            else {
                //RemoveFileSecurity(fileName, username, FileSystemRights.Modify, AccessControlType.Allow);
                //AddFileSecurity(fileName, username, FileSystemRights.Modify, AccessControlType.Deny);
            }
        }

        private void recrusive_parents(int id) {
            if ((id != -1) && (id != 0))
            {
                upper.Add(id);
                SqlCommand command = new SqlCommand("SELECT * FROM [sys_users] inner join user_isl on user_isl.user_id = sys_users.user_id where isl_id=@0", conn);
                command.Parameters.Add(new SqlParameter("0", id));
                using (SqlDataReader result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        set_higherlevel_acl(result["username"].ToString().Trim().Replace('!', '\\'));
                    }
                }
                recrusive_parents(isl[search_current(id)].p_id);
            }
        }
        private void down_sons(int id) {
            string ups = string.Join(",", upper.ToArray());
            if(ups.Length>0)
                ups=","+ups;
            SqlCommand command = new SqlCommand("SELECT * FROM [sys_users] inner join user_isl on user_isl.user_id = sys_users.user_id where isl_id NOT IN (@0"+ups+")", conn);
            command.Parameters.Add(new SqlParameter("0", id));
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    set_lowerlevel_acl(result["username"].ToString().Trim().Replace('!', '\\'));
                }
            }   
        }
        private void set_higherlevel_acl(String username)
        {
            
            String fileName = files.Rows[files.CurrentCell.RowIndex].Cells[1].Value + "\\" + files.Rows[files.CurrentCell.RowIndex].Cells[2].Value;

            //AddFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Deny);
            RemoveFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Allow);

            RemoveFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Allow);
            AddFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Deny);

            RemoveFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Deny);
            AddFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Allow);
            
        }

        private void set_lowerlevel_acl(String username)
        {
            String fileName = files.Rows[files.CurrentCell.RowIndex].Cells[1].Value + "\\" + files.Rows[files.CurrentCell.RowIndex].Cells[2].Value;

            //AddFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Deny);
            RemoveFileSecurity(fileName, username, FileSystemRights.FullControl, AccessControlType.Allow);

            RemoveFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Deny);
            AddFileSecurity(fileName, username, FileSystemRights.Write, AccessControlType.Allow);

            RemoveFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Allow);
            AddFileSecurity(fileName, username, FileSystemRights.Read, AccessControlType.Deny);
        }
        private int search_p(int parent_id) {
            for (int i = 0; i < isl.Count; i++)
                if (isl[i].p_id == parent_id)
                    return i;
            return 0; 
        }

        private int search_current(int _id)
        {
            for (int i = 0; i < isl.Count; i++)
                if (isl[i].Value == _id)
                    return i;
            return -1;
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

        private void update_files()
        {
            files.RowCount = 1;
            int i = 0;
            SqlCommand filecommand = new SqlCommand("SELECT * FROM [files] ", conn);
            using (SqlDataReader result = filecommand.ExecuteReader())
            {
                while (result.Read())
                {
                    files.Rows[i].Cells[0].Value = result["id"];
                    files.Rows[i].Cells[1].Value = result["directory"];
                    files.Rows[i].Cells[2].Value = result["filename"];
                    if (result["isl_id"].ToString().Length > 0)
                        files.Rows[i].Cells[3].Value = isl[search_current(Convert.ToInt32(result["isl_id"]))].Text;
                    files.RowCount++;
                    i++;
                }
            }
        }
    }

}
