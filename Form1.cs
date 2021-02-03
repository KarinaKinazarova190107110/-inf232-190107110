using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDNK
{ 
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=KARINA2001;Initial Catalog=Media;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("EXEC insertUsers @UsersId, @UsersFirstName, @UsersLastName, @UsersAddress, @UsersCity, @UsersState, @UsersCountry, @UsersPostalCode, @UsersPhone, @UsersFax, @UsersEmail, @SupportRepId", con);
            
            cmd.Parameters.AddWithValue("@UsersId", textId.Text);
            cmd.Parameters.AddWithValue("@UsersFirstName", textFName.Text);
            cmd.Parameters.AddWithValue("@UsersLastName", textLName.Text);
            cmd.Parameters.AddWithValue("@UsersAddress", textAddress.Text);
            cmd.Parameters.AddWithValue("@UsersCity", textCity.Text);
            cmd.Parameters.AddWithValue("@UsersState", textState.Text);
            cmd.Parameters.AddWithValue("@UsersCountry", textCountry.Text); 
            cmd.Parameters.AddWithValue("@UsersPostalCode", textPostalCode.Text);
            cmd.Parameters.AddWithValue("@UsersPhone", textPhone.Text);
            cmd.Parameters.AddWithValue("@UsersFax", textFax.Text);
            cmd.Parameters.AddWithValue("@UsersEmail", textEmail.Text);
            cmd.Parameters.AddWithValue("@SupportRepId", textRepId.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("New user is successfully inserted in the database.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GetUsers();
            RefreshUsers();
        }

        private void RefreshUsers()
        {
            textId.Clear();
            textFName.Clear();
            textLName.Clear();
            textAddress.Clear();
            textCity.Clear();
            textState.Clear();
            textCountry.Clear();
            textPhone.Clear();
            textFax.Clear();
            textEmail.Clear();
            textRepId.Clear();

            textId.Focus();
        }
        private void GetUsers()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);

            DataTable dataTable = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            dataTable.Load(sdr);

            con.Close();

            UsersView.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textId.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("EXEC updateUsers @UsersId, @UsersFirstName, @UsersLastName, " +
                    "@UsersAddress,  @UsersCity,  @UsersState, @UsersCountry" +
                    ",  @UsersPostalCode, @UsersPhone,  @UsersFax , " +
                    " @UsersEmail,  @SupportRepId", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@UsersId", textId.Text);
                cmd.Parameters.AddWithValue("@UsersFirstName", textFName.Text);
                cmd.Parameters.AddWithValue("@UsersLastName", textLName.Text);
                cmd.Parameters.AddWithValue("@UsersAddress", textAddress.Text);
                cmd.Parameters.AddWithValue("@UsersCity", textCity.Text);
                cmd.Parameters.AddWithValue("@UsersState", textState.Text);
                cmd.Parameters.AddWithValue("@UsersCountry", textCountry.Text);
                cmd.Parameters.AddWithValue("@UsersPostalCode", textPostalCode.Text);
                cmd.Parameters.AddWithValue("@UsersPhone", textPhone.Text);
                cmd.Parameters.AddWithValue("@UsersFax", textFax.Text);
                cmd.Parameters.AddWithValue("@UsersEmail", textEmail.Text);
                cmd.Parameters.AddWithValue("@SupportRepId", textRepId.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Information is updated in the database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUsers();
                RefreshUsers();
                
            }
            else
            {
                MessageBox.Show("Please select member to update information", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textId.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("EXEC deleteUsers @UsersId", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@UsersId", textId.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User is deleted from the database", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUsers();
                RefreshUsers();
            }
            else
            {
                MessageBox.Show("Write User ID to delete.", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
