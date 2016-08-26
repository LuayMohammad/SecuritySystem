using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ISS_Homework3
{
    public partial class Form1 : Form
    {
        static SqlConnection conn = new SqlConnection();
        static FileSystemWatcher watcher;
        Byte[] secretkey;
        Byte[] MAC;
        String MAC_value;
        public Form1(String path,bool is_admin = true)
        {
            InitializeComponent();
            /**
             * Connecting to local database
             * 
             * **/
            string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='c:\users\luay al assadi\documents\visual studio 2013\Projects\ISS_Homework3\ISS_Homework3\labellSYSTEM.mdf';Integrated Security=True";
            //string sqlCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + Application.StartupPath + "\\labellSYSTEM.mdf';Integrated Security=True";
            conn.ConnectionString = sqlCon;
            conn.Open();

            /**
             * Getting all the local user accounts on the windows
             * **/
            int i = 0;
            grid_users.RowCount = 1;
            SqlCommand command1 = new SqlCommand("SELECT * FROM [sys_users] ", conn);
            using (SqlDataReader result = command1.ExecuteReader())
            {
                while (result.Read())
                {
                    grid_users.Rows[i].Cells[0].Value = result["user_id"].ToString().Trim();
                    String[] d_n = result["username"].ToString().Trim().Split('!');
                        grid_users.Rows[i].Cells[1].Value = d_n[0];
                        grid_users.Rows[i].Cells[2].Value = d_n[1];
                    grid_users.Rows[i].Cells[3].Value = "-------";
                    i++;
                    grid_users.RowCount = i + 1;

                }
            }
            /**
             * Get ALL security classification from database 
             * **/
            i=0;
            classes.RowCount=1;
            SqlCommand command = new SqlCommand("SELECT * FROM [isl] ", conn);
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                     classes.Rows[i].Cells[0].Value= result["id"].ToString().Trim();
                     classes.Rows[i].Cells[1].Value = result["ISL_name"].ToString().Trim();
                     if (Convert.ToInt64(result["ISL_parent"])==0)
                         classes.Rows[i].Cells[2].Value = "TOP LEVEL";
                     else if (Convert.ToInt64(result["ISL_parent"]) == -1)
                         classes.Rows[i].Cells[2].Value = "NULL [not determined]";
                     else
                         classes.Rows[i].Cells[2].Value = "ID OF " + result["ISL_parent"];

                     classes.Rows[i].Cells[3].Value = result["fullcontrol"];
                     classes.Rows[i].Cells[4].Value = result["read_"];
                     classes.Rows[i].Cells[5].Value = result["write_"];
                     classes.Rows[i].Cells[6].Value = result["execute_"];
                     classes.Rows[i].Cells[7].Value = result["modify_"];
                     classes.Rows[i].Cells[8].Value = result["Delete_"];

                     ComboboxItem item = new ComboboxItem();
                     item.Text = result["ISL_name"].ToString().Trim();
                     item.Value = Convert.ToInt32(result["id"]);
                     
                     comboBox2.Items.Add(item);
                     comboBox1.Items.Add(item);

                     i++;
                     classes.RowCount=i+1;
                }
            }
            if (!is_admin) {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button13.Enabled = false;
                MessageBox.Show("Please IMPORT The Windows Users first >>>");
            }


            Thread t = run(path);
            t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        /** ADD New Classification 
         * 
         * */
        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                int class_id = Convert.ToInt32((comboBox2.SelectedItem as ComboboxItem).Value);
                SqlCommand insertCommand = new SqlCommand("INSERT INTO [isl] (ISL_name, ISL_parent ) VALUES (@0, @1)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", textBox1.Text));
                insertCommand.Parameters.Add(new SqlParameter("1", class_id));
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                if (classes.RowCount > 1)
                    MessageBox.Show("Select The Upper level !");
                else
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO [isl] (ISL_name, ISL_parent ) VALUES (@0, @1)", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0",textBox1.Text));
                    insertCommand.Parameters.Add(new SqlParameter("1", "0"));
                    insertCommand.ExecuteNonQuery();
                }

            }
            finally {
                update_classification_grid();
                state.Text = " NEW Classification has been inserted ";
                panel1.Visible = false;
            }
            
        }

        private void update_classification_grid(){
            int i = 0;
            classes.Rows.Clear();
            classes.RowCount = 1;
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT * FROM [isl] ", conn);
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    classes.Rows[i].Cells[0].Value = result["id"].ToString().Trim();
                    classes.Rows[i].Cells[1].Value = result["ISL_name"].ToString().Trim();
                    if (Convert.ToInt64(result["ISL_parent"]) == 0)
                        classes.Rows[i].Cells[2].Value = "TOP LEVEL";
                    else if (Convert.ToInt64(result["ISL_parent"]) == -1)
                        classes.Rows[i].Cells[2].Value = "NULL [not determined]";
                    else
                        classes.Rows[i].Cells[2].Value = "ID OF " + result["ISL_parent"];

                    classes.Rows[i].Cells[3].Value = result["fullcontrol"];
                    classes.Rows[i].Cells[4].Value = result["read_"];
                    classes.Rows[i].Cells[5].Value = result["write_"];
                    classes.Rows[i].Cells[6].Value = result["execute_"];
                    classes.Rows[i].Cells[7].Value = result["modify_"];
                    classes.Rows[i].Cells[8].Value = result["Delete_"];

                    ComboboxItem item = new ComboboxItem();
                    item.Text = result["ISL_name"].ToString().Trim();
                    item.Value = Convert.ToInt32(result["id"]);
                    comboBox2.Items.Add(item);
                    comboBox1.Items.Add(item);

                    i++;
                    classes.RowCount = i + 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int user_id = Convert.ToInt32(grid_users.Rows[grid_users.CurrentCell.RowIndex].Cells[0].Value);
                int class_id = Convert.ToInt32(classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value);
                SqlCommand insertCommand = new SqlCommand("INSERT INTO [user_isl] (user_id, ISL_id ) VALUES (@0, @1)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", user_id));
                insertCommand.Parameters.Add(new SqlParameter("1", class_id));
                insertCommand.ExecuteNonQuery();

                state.Text = "User " + grid_users.Rows[grid_users.CurrentCell.RowIndex].Cells[2].Value + " Has the " + classes.Rows[classes.CurrentCell.RowIndex].Cells[1].Value + "ROLES";
            }
            catch (Exception)
            {
                if (classes.RowCount > 0)
                    MessageBox.Show("Select user from user table and classification form class table !");
                else
                {
                    MessageBox.Show("ADD classification First !");
                    panel1.Visible = true;
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            grid_users.Rows.Clear();
            ManagementObjectSearcher usersSearcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_UserAccount");
            ManagementObjectCollection users = usersSearcher.Get();

            var localUsers = users.Cast<ManagementObject>().Where(
                u => (bool)u["LocalAccount"] == true &&
                     (bool)u["Disabled"] == false &&
                     (bool)u["Lockout"] == false &&
                     int.Parse(u["SIDType"].ToString()) == 1 &&
                     u["Name"].ToString() != "HomeGroupUser$");
            grid_users.RowCount = 1;
            int i = 0;
            foreach (ManagementObject user in users)
            {
                grid_users.Rows[i].Cells[1].Value = user["Domain"].ToString();
                grid_users.Rows[i].Cells[2].Value = user["Name"].ToString();
                grid_users.Rows[i].Cells[3].Value = "Un defiend ";
                i++;
                grid_users.RowCount = i + 1;


                bool dup = false;
                SqlCommand command1 = new SqlCommand("SELECT * FROM [sys_users] where username=@0", conn);
                String x = user["Domain"].ToString() + "!" + user["Name"].ToString();
                command1.Parameters.Add(new SqlParameter("0", x.ToString()));
                using (SqlDataReader result = command1.ExecuteReader())
                {
                    while (result.Read())
                    {
                        dup = true;
                    }
                }
                if (!dup)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO [sys_users] (username, is_admin ) VALUES (@0, @1)", conn);
                    x = user["Domain"].ToString() + "!" + user["Name"].ToString();
                    insertCommand.Parameters.Add(new SqlParameter("0", x));
                    insertCommand.Parameters.Add(new SqlParameter("1", 1));
                    insertCommand.ExecuteNonQuery();
                }
            }
            button8.Enabled = false;
            button10.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = 0;
            grid_users.Rows.Clear();
            grid_users.RowCount = 1;
            SqlCommand command1 = new SqlCommand("SELECT * FROM [sys_users] inner join  [user_isl] on user_isl.user_id = sys_users.user_id inner join [isl] on user_isl.ISL_id=isl.id ", conn);
            using (SqlDataReader result = command1.ExecuteReader())
            {
                while (result.Read())
                {
                    grid_users.Rows[i].Cells[0].Value = result["user_id"].ToString().Trim();
                    String[] d_n = result["username"].ToString().Trim().Split('!');
                    grid_users.Rows[i].Cells[1].Value = d_n[0];
                    grid_users.Rows[i].Cells[2].Value = d_n[1];
                    grid_users.Rows[i].Cells[3].Value = result["ISL_name"];
                    i++;
                    grid_users.RowCount = i + 1;
                }
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            int i = 0;
            grid_users.RowCount = 1;
            SqlCommand command1 = new SqlCommand("SELECT * FROM [sys_users] ", conn);
            using (SqlDataReader result = command1.ExecuteReader())
            {
                while (result.Read())
                {
                    grid_users.Rows[i].Cells[0].Value = result["user_id"].ToString().Trim();
                    String[] d_n = result["username"].ToString().Trim().Split('!');
                    grid_users.Rows[i].Cells[1].Value = d_n[0];
                    grid_users.Rows[i].Cells[2].Value = d_n[1];
                    grid_users.Rows[i].Cells[3].Value = "-------";
                    i++;
                    grid_users.RowCount = i + 1;

                }
            }

            button13.Enabled = true;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\logfile.txt";

            // This text is added only once to the file.
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                textBox3.Text = readText;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int user_id = Convert.ToInt32(grid_users.Rows[grid_users.CurrentCell.RowIndex].Cells[0].Value);
                int class_id = Convert.ToInt32(classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value);
                SqlCommand insertCommand = new SqlCommand("DELETE FROM [user_isl] where user_id=@0 and ISL_id=@1", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", user_id));
                insertCommand.Parameters.Add(new SqlParameter("1", class_id));
                insertCommand.ExecuteNonQuery();

                state.Text = "User " + grid_users.Rows[grid_users.CurrentCell.RowIndex].Cells[2].Value + " Has left " + classes.Rows[classes.CurrentCell.RowIndex].Cells[1].Value + " ROLES";
            }
            catch (Exception)
            {
                if (classes.RowCount > 0)
                    MessageBox.Show("Select user from user table and classification form class table !");
                else
                {
                    MessageBox.Show("ADD classification First !");
                    panel1.Visible = true;
                }
            }
            finally {
                update_users_grid();
            }
        }

        private void update_users_grid() {
            int i = 0;
            grid_users.Rows.Clear();
            grid_users.RowCount = 1;
            SqlCommand command1 = new SqlCommand("SELECT * FROM [sys_users] inner join  [user_isl] on user_isl.user_id = sys_users.user_id inner join [isl] on user_isl.ISL_id=isl.id ", conn);
            using (SqlDataReader result = command1.ExecuteReader())
            {
                while (result.Read())
                {
                    grid_users.Rows[i].Cells[0].Value = result["id"].ToString().Trim();
                    String[] d_n = result["username"].ToString().Trim().Split('!');
                    grid_users.Rows[i].Cells[1].Value = d_n[0];
                    grid_users.Rows[i].Cells[2].Value = d_n[1];
                    grid_users.Rows[i].Cells[3].Value = result["ISL_name"];
                    i++;
                    grid_users.RowCount = i + 1;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int class_id = Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).Value);
                if (class_id > Convert.ToInt32(classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value))
                {
                    SqlCommand insertCommand = new SqlCommand("UPDATE [isl] SET ISL_name=@0 , ISL_parent=@1 where id=@2 ", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0", textBox2.Text));
                    insertCommand.Parameters.Add(new SqlParameter("1", class_id));
                    insertCommand.Parameters.Add(new SqlParameter("2", Convert.ToInt32(classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value)));
                    insertCommand.ExecuteNonQuery();
                    state.Text = "Classification Has been Updated  ";
                }
                else {
                    MessageBox.Show("Sorry You Can't Add lower level security [ ID ] as Parent LeveL ");
                }
            }
            catch (Exception)
            {
                if (classes.RowCount > 0)
                    MessageBox.Show("Select parent classification form class table !");
                else
                {
                    MessageBox.Show("ADD classification First !");
                    panel1.Visible = true;
                }
            }
            finally {
                update_classification_grid();
                panel2.Visible = false;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
                SqlCommand updateCommand = new SqlCommand("UPDATE [isl] SET ISL_parent=-1 where ISL_parent=@0 ", conn);
                updateCommand.Parameters.Add(new SqlParameter("0", classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value));
                updateCommand.ExecuteNonQuery();

                SqlCommand insertCommand = new SqlCommand("DELETE FROM [isl] where id=@0 ", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value));
                insertCommand.ExecuteNonQuery();
            state.Text = "Classification Has been deleted  ";
            update_classification_grid();
            panel2.Visible = false;
        }

        private long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlCommand insertCommand = new SqlCommand("UPDATE [sys_users] SET is_admin=@0 where user_id=@1 ", conn);
            insertCommand.Parameters.Add(new SqlParameter("0", 2));
            insertCommand.Parameters.Add(new SqlParameter("1", Convert.ToInt32(grid_users.Rows[grid_users.CurrentCell.RowIndex].Cells[0].Value)));
            insertCommand.ExecuteNonQuery();
            grid_users.Rows[grid_users.CurrentCell.RowIndex].Cells[3].Value = "< SYSTEM ADMIN >";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = classes.Rows[classes.CurrentCell.RowIndex].Cells[1].Value.ToString();
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 files = new Form3();
            files.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlCommand dir = new SqlCommand("SELECT * FROM [Dir]", conn);
            String Dir_name = "";
            using (SqlDataReader result = dir.ExecuteReader())
            {
                while (result.Read())
                {
                    Dir_name = result["DirectoryName"].ToString();
                }
            }
            Form4 load_files = new Form4(Dir_name);
            load_files.Show();
        }

        private void classes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(panel2.Visible)
                textBox2.Text = classes.Rows[classes.CurrentCell.RowIndex].Cells[1].Value.ToString();
            panel4.Visible = true;
            full.Checked =Convert.ToBoolean(classes.Rows[classes.CurrentCell.RowIndex].Cells[3].Value);
            read.Checked = Convert.ToBoolean(classes.Rows[classes.CurrentCell.RowIndex].Cells[4].Value);
            write.Checked = Convert.ToBoolean(classes.Rows[classes.CurrentCell.RowIndex].Cells[5].Value);
            execute.Checked = Convert.ToBoolean(classes.Rows[classes.CurrentCell.RowIndex].Cells[6].Value);
            modify.Checked = Convert.ToBoolean(classes.Rows[classes.CurrentCell.RowIndex].Cells[7].Value);
            delete.Checked = Convert.ToBoolean(classes.Rows[classes.CurrentCell.RowIndex].Cells[8].Value);
        }

        private void ACL_Click(object sender, EventArgs e)
        {
            SqlCommand insertCommand = new SqlCommand("UPDATE [isl] SET fullcontrol=@0, read_=@1, write_=@2, execute_=@3, modify_=@4, Delete_=@5 where id=@6 ", conn);
            insertCommand.Parameters.Add(new SqlParameter("0", Convert.ToInt32(full.Checked)));
            insertCommand.Parameters.Add(new SqlParameter("1", Convert.ToInt32(read.Checked)));
            insertCommand.Parameters.Add(new SqlParameter("2", Convert.ToInt32(write.Checked)));
            insertCommand.Parameters.Add(new SqlParameter("3", Convert.ToInt32(execute.Checked)));
            insertCommand.Parameters.Add(new SqlParameter("4", Convert.ToInt32(modify.Checked)));
            insertCommand.Parameters.Add(new SqlParameter("5", Convert.ToInt32(delete.Checked)));
            insertCommand.Parameters.Add(new SqlParameter("6", Convert.ToInt32(classes.Rows[classes.CurrentCell.RowIndex].Cells[0].Value)));
            insertCommand.ExecuteNonQuery();
            state.Text = "Classification ACL Has been Updated  ";
            update_classification_grid();
        }

        private Thread run(String path)
        {
            Thread thread = new Thread(new ThreadStart(() => Run(path)));
            return thread;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run(String path)
        {
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Path = path;

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;
            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            try
            {
                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText(Application.StartupPath + "\\logfile.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " : " + " Access Denied " + Environment.NewLine);
                }
            }
            // Wait for the user to quit the program.
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {

            try
            {
                watcher.EnableRaisingEvents = false;
                // Specify what is done when a file is changed, created, or deleted.
                String modifiedBy = "Un knwon ";
                
                using (StreamWriter sw = File.AppendText(Application.StartupPath + "\\logfile.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " : " + "File: " + e.FullPath + " " + e.ChangeType/* + " Modified BY :" + modifiedBy*/ + Environment.NewLine);
                }
            }

            finally
            {
                watcher.EnableRaisingEvents = true;
            }

        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            //textBox3.Text = textBox3.Text + "\n File: " 
            using (StreamWriter sw = File.AppendText(Application.StartupPath + "\\logfile.txt"))
            {
                SqlCommand insertCommand = new SqlCommand("UPDATE [files] SET filename=@0 where filename=@1", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", Path.GetFileName(e.FullPath)));
                insertCommand.Parameters.Add(new SqlParameter("1", Path.GetFileName(e.OldFullPath)));
                //insertCommand.Parameters.Add(new SqlParameter("2", Path.GetDirectoryName(e.OldFullPath)));
                insertCommand.ExecuteNonQuery();

                String modifiedBy = "Un knwon ";

                sw.WriteLine(DateTime.Now.ToString() + " : " + e.OldFullPath + " renamed to " + e.FullPath +/* " Modified By" + modifiedBy +*/ Environment.NewLine);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = Application.StartupPath;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo d = new DirectoryInfo(folderBrowser.SelectedPath);
                String data = d.Parent.FullName + " | created at : [ " + d.CreationTime.ToString() + " ] | last edit at [ " + d.LastWriteTime.ToString() + " ] | size : " + GetDirectorySize(folderBrowser.SelectedPath) +" Bytes ";
                
                // Create a random key using a random number generator. This would be the
                //  secret key shared by sender and receiver.
                secretkey = new Byte[64];
                //RNGCryptoServiceProvider is an implementation of a random number generator.
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    // The array is now filled with cryptographically strong random bytes.
                    rng.GetBytes(secretkey);

                    // Use the secret key to sign the message file.
                    MAC = SignFile(secretkey, data);
                    MAC_value = strtohes(secretkey) + "\n" + strtohes(MAC);
                    MessageBox.Show(MAC_value);
                }
            }
        }

        private byte[] SignFile(byte[] key, String sourceFile)
        {
            byte[] bytes = new byte[sourceFile.Length * sizeof(char)];
            System.Buffer.BlockCopy(sourceFile.ToCharArray(), 0, bytes, 0, bytes.Length);

            // Initialize the keyed hash object.
            HMACSHA1 hmac = new HMACSHA1(key);
            // Compute the hash of the input file.
            byte[] hashValue = hmac.ComputeHash(bytes);
            return hashValue;
            //char[] chars = new char[hashValue.Length / sizeof(char)];
            //System.Buffer.BlockCopy(hashValue, 0, chars, 0, hashValue.Length);
            //return new String( chars);
        }

        private String strtohes(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create));
                sw.WriteLine(strtohes(secretkey));
                sw.WriteLine(strtohes(MAC));
                sw.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_user = new OpenFileDialog();
            FolderBrowserDialog folderBrowserDialog_admin = new FolderBrowserDialog();
            if (openFileDialog_user.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(new FileStream(openFileDialog_user.FileName, FileMode.Open));
                String key = sr.ReadLine();
                String storedMac = sr.ReadLine();
                sr.Close();

                if (folderBrowserDialog_admin.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo d = new DirectoryInfo(folderBrowserDialog_admin.SelectedPath);
                    String data = d.Parent.FullName + " | created at : [ " + d.CreationTime.ToString() + " ] | last edit at [ " + d.LastWriteTime.ToString() + " ] | size : " + GetDirectorySize(folderBrowserDialog_admin.SelectedPath) + " Bytes ";
                    String currentMac = strtohes(SignFile(secretkey, data));

                    if (storedMac == currentMac)
                    {
                        MessageBox.Show(" Folder\n" + folderBrowserDialog_admin.SelectedPath + "\nhas not been edited");
                    }
                    else
                    {
                        MessageBox.Show("Warnning!! Folder\n" + folderBrowserDialog_admin.SelectedPath + " \nhas been edited");
                        return;
                    }
                }

            }

        }
    }
}
