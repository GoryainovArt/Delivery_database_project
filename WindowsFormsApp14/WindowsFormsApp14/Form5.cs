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

namespace WindowsFormsApp14
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void coefficientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.coefficientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tR_1DataSet);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Adm_couriers". При необходимости она может быть перемещена или удалена.
            this.adm_couriersTableAdapter.Fill(this.tR_1DataSet.Adm_couriers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Distances". При необходимости она может быть перемещена или удалена.
            this.distancesTableAdapter.Fill(this.tR_1DataSet.Distances);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Coefficients". При необходимости она может быть перемещена или удалена.
            this.coefficientsTableAdapter.Fill(this.tR_1DataSet.Coefficients);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.adm_couriersTableAdapter.Fill(this.tR_1DataSet.Adm_couriers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec Add_cour @Last, @First, @Middle,@Number,@trans, @exp, @average, @current, @status;";
            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Last", textBox1.Text);
                command.Parameters.AddWithValue("First", textBox2.Text);
                command.Parameters.AddWithValue("Middle", textBox3.Text);
                command.Parameters.AddWithValue("Number", textBox4.Text);
                command.Parameters.AddWithValue("trans", textBox5.Text);
                command.Parameters.AddWithValue("exp", textBox6.Text);
                command.Parameters.AddWithValue("average", textBox7.Text);
                command.Parameters.AddWithValue("current", textBox8.Text);
                command.Parameters.AddWithValue("status", textBox9.Text);
                command.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
            catch { textBox1.Text = "Ошибка!"; }
            connect.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "select dbo.Count_zp1(@id_order);";
            var result = new SqlCommand(sql, connect);
            result.Parameters.AddWithValue("id_order", textBox11.Text);
            var data = result.ExecuteScalar();
            textBox12.Text = data.ToString();
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox10.Text);
                textBox10.Clear();
                string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = "Delete from dbo.Couriers where id_courier='" + id + "'";
                SqlCommand command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }
            catch { textBox10.Text = "Некорректные данные!"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox10.Text);
                int zp = Convert.ToInt32(textBox13.Text);
                textBox10.Clear();
                textBox13.Clear();
                string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = "Update dbo.Couriers Set Average_time_of_delation='" + zp + "' where id_courier='" + id + "'";
                SqlCommand command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }
            catch { textBox10.Text = "Некорректные данные!"; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec Updstatus;";
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
