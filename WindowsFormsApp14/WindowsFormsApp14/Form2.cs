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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Meals_Popular". При необходимости она может быть перемещена или удалена.
            this.meals_PopularTableAdapter.Fill(this.tR_1DataSet.Meals_Popular);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Top10". При необходимости она может быть перемещена или удалена.
            this.top10TableAdapter.Fill(this.tR_1DataSet.Top10);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 af = new Form4();
            af.Owner = this;
            af.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec Add_Ord @Address, @house;";
            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Address", textBox1.Text);
                command.Parameters.AddWithValue("house", textBox2.Text);
                command.ExecuteNonQuery();
            }
            catch { textBox1.Text = "Ошибка!"; }
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec Add_Order @Meal;";
            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Meal", textBox3.Text);
                command.ExecuteNonQuery();
            }
            catch { textBox1.Text = "Ошибка!"; }
            textBox3.Clear();
            connect.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "select dbo.Count_price(@id_order);";
            var result = new SqlCommand(sql, connect);
            result.Parameters.AddWithValue("id_order", textBox4.Text);
            var data = result.ExecuteScalar();
            textBox5.Text = data.ToString();
            connect.Close();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void fillToolStripButton1_Click(object sender, EventArgs e)
        {


        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.personal_order2TableAdapter.Fill(this.tR_1DataSet.Personal_order2, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
