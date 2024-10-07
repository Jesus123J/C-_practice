using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace store_desktop_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // SQL connection string
        SqlConnection conn = new SqlConnection(@"Data Source=IDEVEXPERT;Initial Catalog=StoreDesktop;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input
                string textUser = textBox1.Text;
                string textPassword = textBox2.Text;

                // Open connection
                conn.Open();

                // Use parameterized query to prevent SQL injection
                string query = "SELECT * FROM Login_new WHERE username = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", textUser);
                cmd.Parameters.AddWithValue("@password", textPassword);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Check if the user exists
                if (dataTable.Rows.Count > 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MenuForm menuForm = new MenuForm();
                    menuForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error de cuenta");
                }
            }
            catch (Exception ex)
            {
                // Show detailed error message
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
