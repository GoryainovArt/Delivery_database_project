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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Worst". При необходимости она может быть перемещена или удалена.
            this.worstTableAdapter.Fill(this.tR_1DataSet.Worst);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Adm_meals". При необходимости она может быть перемещена или удалена.
            this.adm_mealsTableAdapter.Fill(this.tR_1DataSet.Adm_meals);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec Checking;";
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = Convert.ToString(textBox1.Text);
                int amount = Convert.ToInt32(textBox2.Text);
                int price = Convert.ToInt32(textBox3.Text);
                int freq = Convert.ToInt32(textBox4.Text);
                string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = "insert into dbo.Meals values ('" + Name + "','" + amount + "','" + price + "','" + freq + "');";
                SqlCommand command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                connect.Close();
            }
            catch {textBox1.Text="Ошибка!"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.adm_mealsTableAdapter.Fill(this.tR_1DataSet.Adm_meals);
            this.worstTableAdapter.Fill(this.tR_1DataSet.Worst);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
