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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Adm_Ord1". При необходимости она может быть перемещена или удалена.
            this.adm_Ord1TableAdapter.Fill(this.tR_1DataSet.Adm_Ord1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec upd_status @id, @time;";
            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("id", textBox1.Text);
                command.Parameters.AddWithValue("time", textBox2.Text);
                command.ExecuteNonQuery();
            }
            catch { textBox1.Text = "Ошибка!"; }
            connect.Close(); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.adm_Ord1TableAdapter.Fill(this.tR_1DataSet.Adm_Ord1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec swap @cour_id, @order_id;";
            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("order_id", textBox3.Text);
                command.Parameters.AddWithValue("cour_id", textBox4.Text);
                command.ExecuteNonQuery();
            }
            catch { textBox3.Text = "Ошибка!";
                textBox4.Text = "Ошибка!";
            }
            connect.Close(); ;
        }
    }
}
