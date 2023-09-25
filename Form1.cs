using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            rich.Text = "Startup..."; 
            try
            {
                System.Diagnostics.Debug.WriteLine("within the try");
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-O31QORP\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                rich.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                rich.Text = "Error, " + ex.Message; // Use ex.Message to get the error message
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-O31QORP\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            btn_update.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (CustomerID, CompanyName) values('" + tb_id.Text + "','" + tb_company.Text + "')";
            command.ExecuteNonQuery();
            rich.Text = "Record Inserted...";
            connection.Close();
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-O31QORP\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            btn_records.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            rich.Text = "Number of records: " + count;
            connection.Close();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            db_grid.Text = "Retrieving Records...";
            command.Connection = connection;
            command.CommandText = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db_grid.DataSource = dt;
            rich.Text = "Retrieval Successful!";
            connection.Close();
        }
    }
}
