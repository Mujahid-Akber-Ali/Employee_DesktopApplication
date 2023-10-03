using GUI_Project.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();

        private void button1_Click(object sender, EventArgs e)
        {
            c.FullName = textBox2.Text;
            c.City = comboBox1.Text;
            c.ContactNo = textBox3.Text;
            c.Address = textBox6.Text;

            if (radioButton1.Checked == true)
            {
                c.Gender = radioButton1.Text;
            }
            else
            {
                c.Gender = radioButton2.Text;
            }



            bool sucess = c.Insert(c);
            if (sucess == true)
            {
                MessageBox.Show("New Employee Added Sucessfully");
            }
            else
            {
                MessageBox.Show("Failed to add Contact. Try Again.");
            }

            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.SerialNumber = int.Parse(textBox1.Text);
            c.FullName = textBox2.Text;
            c.City = comboBox1.Text;
            c.ContactNo = textBox3.Text;
            c.Address = textBox6.Text;

            if (radioButton1.Checked == true)
            {
                c.Gender = radioButton1.Text;
            }
            else
            {
                c.Gender = radioButton2.Text;
            }

            bool sucess = c.Update(c);
            if (sucess == true)
            {
                MessageBox.Show("Contact Updated!!");

                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Update Failed!!, Try Again");
            }
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.SerialNumber = Convert.ToInt32(textBox1.Text);
            bool sucess = c.Delete(c);
            if (sucess == true)
            {
                MessageBox.Show("Contact Deleted!!");

                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Delete Failed!!, Try Again");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("City Like '%{0}%' or Fullname Like '%{0}%' or Adress Like '%{0}%' or Gender Like '%{0}%'", textBox7.Text);
            dataGridView1.DataSource = dv;


        }

    }
}

