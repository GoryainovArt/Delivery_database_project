﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 af = new Form5();
            af.Owner = this;
            af.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 af = new Form6();
            af.Owner = this;
            af.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 af = new Form7();
            af.Owner = this;
            af.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 af = new Form8();
            af.Owner = this;
            af.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
