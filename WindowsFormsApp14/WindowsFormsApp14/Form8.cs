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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void addressBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.addressBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tR_1DataSet);

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tR_1DataSet.Address". При необходимости она может быть перемещена или удалена.
            this.addressTableAdapter.Fill(this.tR_1DataSet.Address);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = "exec add_address @id, @traffic, @time;";
            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("id", textBox1.Text);
                command.Parameters.AddWithValue("traffic", textBox2.Text);
                command.Parameters.AddWithValue("time", textBox3.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                command.ExecuteNonQuery();
            }
            catch { textBox1.Text = "Ошибка!"; }
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string address = "0";
                int traffic = -1;
                int time = -1;
                if (textBox1.Text != "")
                {
                    address = Convert.ToString(textBox1.Text);
                }
                if (textBox2.Text != "")
                {
                    traffic = Convert.ToInt32(textBox2.Text);
                }
                if (textBox3.Text != "")
                {
                    time = Convert.ToInt32(textBox3.Text);
                }
                string id = Convert.ToString(textBox4.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                string connectionString = @"Data Source=WIN-MCPEBV3E4IE\SQLEXPRESS;Initial Catalog=TR_1;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                if (address != "0")
                {
                    string sql = "Update dbo.Address Set Adress_id='" + address + "' where Adress_id='" + id + "'";
                    SqlCommand command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
                if (traffic != -1)
                {
                    string sql = "Update dbo.Address Set traffic='" + traffic + "'where Adress_id='" + id + "'";
                    SqlCommand command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
                if (time != -1)
                {
                    string sql = "Update dbo.Address Set Expected_time='" + time + "'where Adress_id='" + id + "'";
                    SqlCommand command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }
            catch
            {
                textBox1.Text = "Некорректные данные!";
                textBox2.Text = "Некорректные данные!";
                textBox3.Text = "Некорректные данные!";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.addressTableAdapter.Fill(this.tR_1DataSet.Address);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
