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
    public partial class Order_details : Form
    {
        public Order_details()
        {
            InitializeComponent();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            Order_detail kb = new Order_detail();

            kb.ProductID = Convert.ToInt32(comboBox7.Text);
            // kb.ProductPrice = Convert.ToDecimal(textBox7.Text);
            kb.Number = Convert.ToDecimal(numericUpDown1.Text);
            kb.UserID = Convert.ToInt32(comboBox1.Text);


            if (!OrderDetails.OrderDAdd(kb))
            {
                MessageBox.Show("It wasn't added.Try again.");
            }
            else
            {
                MessageBox.Show("Successful");
                dataGridView3.DataSource = OrderDetails.OrderList();

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            Order_detail kb = new Order_detail();
            kb.OrderDetayID = Convert.ToInt32(comboBox8.Text);
            kb.ProductID = Convert.ToInt32(comboBox7.Text);
            // kb.ProductPrice = Convert.ToDecimal(textBox7.Text);
            kb.Number = Convert.ToDecimal(numericUpDown1.Text);
            kb.UserID = Convert.ToInt32(comboBox1.Text);

            if (!OrderDetails.OrderDetailsUp(kb))
            {
                MessageBox.Show("It wasn't updated. Try again.");
            }
            else
            {

                MessageBox.Show("Successful!");
                dataGridView3.DataSource = OrderDetails.OrderList();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order_detail x = new Order_detail();

            x.OrderDetayID = Convert.ToInt32(textBox1.Text);

            try
            {
                dataGridView3.DataSource = OrderDetails.OrderDetaySearch(x);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = OrderDetails.OrderList();
        }

        private void Order_details_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView3.CurrentRow;

            comboBox8.Text = row.Cells[0].Value.ToString();
            comboBox7.Text = row.Cells[1].Value.ToString();
            textBox7.Text = row.Cells[2].Value.ToString();
            numericUpDown1.Text = row.Cells[3].Value.ToString();
            comboBox1.Text = row.Cells[4].Value.ToString();
        }
        
        
    }
}
