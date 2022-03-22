using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Store.Entity;
using Store.Facade;

namespace _16022022_ORM_STORE_PROJECT
{
    public partial class UserAddress : Form
    {
        public UserAddress()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = UAdress.UList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserAdres x = new UserAdres();

            x.UID = Convert.ToInt32(textBox1.Text);

            try
            {
                dataGridView3.DataSource = UAdress.USearch(x);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserAdres x = new UserAdres();

            x.UID = Convert.ToInt32(comboBox8.Text);
            x.UserID = Convert.ToInt32(comboBox7.Text);
            x.Title = comboBox2.Text;
            x.City =  comboBox1.Text;
            x.Adress =  richTextBox1.Text;
            if (!UAdress.UUpdate(x))
            {
                MessageBox.Show("Upps...Somethings go wrong!");
              
            }
            else
            {
                MessageBox.Show("Successful!");
                dataGridView3.DataSource = UAdress.UList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAdres x = new UserAdres();

            x.UID = Convert.ToInt32(textBox1.Text);

            try
            {
                dataGridView3.DataSource = UAdress.USearch(x);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView3.CurrentRow;

            comboBox8.Text = row.Cells[0].Value.ToString();
            comboBox7.Text = row.Cells[1].Value.ToString();
            comboBox2.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();
            richTextBox1.Text = row.Cells[4].Value.ToString();
             
        }

        private void UserAddress_Load(object sender, EventArgs e)
        {

        }
    }
}
