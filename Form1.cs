using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VirtutuaJDrive\Visualstadiopractice\LoginForm\Login.mdf;Integrated Security=True";
        //string cs= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\LoginForm\Login.mdf";
        //string cs= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Login.mdf";
        //string cs= @"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename=\LoginForm\Login.mdf";
        //string cs= @"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename==|DataDirectory|Login.mdf";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == " ")
            {
                MessageBox.Show("Please enter User Name and Password", "Error");
                //txtUserName.Focus();
                return;
            }
            try
            {
                // Create SqlConnection
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs);
                SqlCommand myCommand = default(SqlCommand);
                string cmdString = ("SELECT * FROM Users1 WHERE UserID = @UserID AND LoginID = @LoginID");
                myCommand = new SqlCommand(cmdString, myConnection);
                SqlParameter uName = new SqlParameter("@UserID", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@LoginID", SqlDbType.VarChar);
                uName.Value = txtUserName.Text;
                uPassword.Value = txtPassword.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);
                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read() == true)
                {
                    MessageBox.Show("You have logged in Successfully" + txtUserName.Text);
                    //Hide the login window
                    this.Hide();
                }
                else
                    MessageBox.Show("Login Failed... Try again");
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
