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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category cate = new Category();
          
            cate.ParentID = Convert.ToInt32(comboBox3.Text);
            cate.Name =  comboBox2.Text;
            if (radioButton1.Checked == true)
            {
                cate.IsActive =true;
            }
            else  
            {
                cate.IsActive = false;
            }
            if (!Categorys.CAdd(cate))
                MessageBox.Show("Ekleme başarısız. Tekrar deneyin.");
            dataGridView1.DataSource = Categorys.CList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Categorys.CList();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category sil = new Category();
            sil.CID =Convert.ToInt32(comboBox1.Text);
            if (!Categorys.CDelete(sil))
            {
                MessageBox.Show("Silme işlemi başarısız. Tekrar deneyin.");

            }
            dataGridView1.DataSource = Categorys.CList();
        }

        private void button3_Click(object sender, EventArgs e)  
        {
            Category update = new Category();
            update.CID = Convert.ToInt32(comboBox1.Text);
            update.ParentID = Convert.ToInt32(comboBox3.Text);
            update.Name = comboBox2.Text;
            if (radioButton1.Checked == true)
            {
                update.IsActive = true;
            }
            else
            {
                update.IsActive = false;
            }
            if (!Categorys.CUpdate(update))
            {
                MessageBox.Show("It wasn't updated. Try again.");
            }
            else
            {
                MessageBox.Show("Successful!");
                dataGridView1.DataSource = Categorys.CList();
            }


        }

        private void button4_Click(object sender, EventArgs e)  
        {
            Category find = new Category();
            find.CID =Convert.ToInt32(textBox1.Text);
            try
            {
                dataGridView1.DataSource = Categorys.ToSearch(find);
            }
            catch
            {
                MessageBox.Show("It isn't existed.");
            }
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            comboBox1.Text = row.Cells[0].Value.ToString();
            comboBox3.Text = row.Cells[1].Value.ToString();
            comboBox2.Text = row.Cells[2].Value.ToString();
            string a= row.Cells[3].Value.ToString();
            if ( a.ToString()=="True" || a.ToString() == "true")
            {
                radioButton1.Checked = true;  
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
             

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }
        //********************** MAIN CATEGORY**********************************
        private void button10_Click(object sender, EventArgs e)
        {
           
            MainCategory parent = new MainCategory();
            parent.ParentName = comboBox4.Text;
           
            if (!MainCategories.MainCategoryAdd(parent))
                MessageBox.Show("It wasn't added. Try again.");
           
            else
            {
                MessageBox.Show("Successful !");
                dataGridView2.DataSource = MainCategories.MainCategoryList();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainCategory del = new MainCategory();
            del.ParentID = Convert.ToInt32(comboBox5.Text);
            if (!MainCategories.MainCategoryDelete(del))
            {
                MessageBox.Show("It wasn't deleted. Try again.");

            }
            else
            {
                MessageBox.Show("Successful !");
                dataGridView2.DataSource = MainCategories.MainCategoryList();
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainCategory up=new MainCategory();
            up.ParentID = Convert.ToInt32(comboBox5.Text);
            up.ParentName =  comboBox4.Text;
            if (!MainCategories.MainCategoryUpdate(up))
            {
                MessageBox.Show("It wasn't updated. Try again.");

            }
            else
            {
                MessageBox.Show("Successful !");
                dataGridView2.DataSource = MainCategories.MainCategoryList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainCategory sr = new MainCategory();
            sr.ParentID = Convert.ToInt32(textBox2.Text);

            try
            {
                dataGridView2.DataSource=MainCategories.MainSearch(sr);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = MainCategories.MainCategoryList();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView2.CurrentRow;
            comboBox5.Text = row.Cells[0].Value.ToString();
            comboBox4.Text = row.Cells[1].Value.ToString();
           
        }
        // ********************************ORDER**************************


        private void button15_Click(object sender, EventArgs e)
        {
            Order oad = new Order();
            
            oad.UserID = Convert.ToInt32(comboBox7.Text);
            oad.UserAddress = richTextBox1.Text;
            oad.CreateDate = dateTimePicker1.Value;
            oad.TotalPrice = Convert.ToDecimal(textBox6.Text);
            oad.Order_detay_id = Convert.ToInt32(textBox7.Text);
            if (!Orders.OrderAdd(oad))
                MessageBox.Show("It wasn't added. Try again.");
            else
            {
                MessageBox.Show("Successful !");
                dataGridView3.DataSource = Orders.OrderList();
                
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            EProduct del = new EProduct();
            del.PID = Convert.ToInt32(textBox15.Text);
            if (!FProduct.ProductDelete(del))
            {
                MessageBox.Show("It wasn't deleted. Try again.");

            }
            else
            {
                MessageBox.Show("Successful !");
                dataGridView4.DataSource = FProduct.ProductList();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = Orders.OrderList();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Order del = new Order();
            del.OID = Convert.ToInt32(comboBox8.Text);
            if (!Orders.OrderDelete(del))
            {
                MessageBox.Show("It wasn't deleted. Try again.");

            }
            else
            {
                MessageBox.Show("Successful !");
                dataGridView3.DataSource = Orders.OrderList();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Order up = new Order();
            up.OID = Convert.ToInt32(comboBox8.Text);
            up.UserID = Convert.ToInt32(comboBox7.Text);
            up.UserAddress = richTextBox1.Text;
            up.CreateDate = Convert.ToDateTime(dateTimePicker1.Value);
            up.TotalPrice = Convert.ToDecimal(textBox6.Text);
            up.Order_detay_id = Convert.ToInt32(textBox7.Text);
            if (!Orders.OrderUpdate(up))
            {
                MessageBox.Show("It wasn't updated. Try again.");

            }
            else
            {
                MessageBox.Show("Successful !");
                dataGridView3.DataSource = Orders.OrderList();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Order_details o=new Order_details();
            o.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Order find = new Order();
            find.OID=Convert.ToInt32(textBox3.Text);
            try
            {
                dataGridView3.DataSource = Orders.OrderSearch(find);
            }
            catch
            {

            }
        }
        //***************PRODUCT***************************************************

        private void button20_Click(object sender, EventArgs e)
        {
            EProduct x = new EProduct();
            x.PName = textBox16.Text;
            x.CategoryID = Convert.ToInt32(textBox17.Text);
            x.Brand = textBox18.Text;
            x.Model = textBox8.Text;
            x.PDescription = richTextBox2.Text;
            x.Price = Convert.ToDecimal(textBox9.Text);
            x.Stock = Convert.ToInt32(textBox14.Text);
             
            if (FProduct.ProductEkle(x))
            {
                MessageBox.Show("Successful !");
                dataGridView4.DataSource = FProduct.ProductList();
            }
            else
            {
                MessageBox.Show("It wasn't added. Try again.");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = FProduct.ProductList();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            EProduct sr = new EProduct();
            sr.PID = Convert.ToInt32(textBox4.Text);

            try
            {
                dataGridView4.DataSource = FProduct.ProductSearch(sr);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }



        }
        //************************ USERS ************************************

        private void button22_Click(object sender, EventArgs e)
        {
            User u=new User();
            u.ID = Int32.Parse(textBox5.Text);
            try
            {
                dataGridView5.DataSource = Users.UserSearch(u);
            }

            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            User a = new User();

            a.ID = Convert.ToInt32(comboBox14.Text);
            a.Name = textBox12.Text;
            a.LastName = textBox11.Text;
            a.EMail = textBox13.Text;
            a.Telephone = maskedTextBox1.Text;
            a.TC = maskedTextBox2.Text;

            if (!Users.UserUpdate(a))
                MessageBox.Show("It wasn't updated. Try again.");
            else
            {
                MessageBox.Show("Successful !");
                dataGridView5.DataSource = Users.UserList();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {

            User br = new User();
            br.ID = Convert.ToInt32(comboBox14.Text);
            if (!Users.UserDelete(br))
            {
                MessageBox.Show("It wasn't deleted. Try again.");

            }
            else
            {
                MessageBox.Show("Successful !");
                dataGridView5.DataSource = Users.UserList();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            User ku = new User();

            ku.ID = Convert.ToInt32(comboBox14.Text);
            ku.Name = textBox12.Text;
            ku.LastName = textBox11.Text;
            ku.EMail = textBox13.Text;
            ku.Telephone = maskedTextBox1.Text;
            ku.TC = maskedTextBox2.Text;
             
            if (!Users.UserAdd(ku))
                MessageBox.Show("It wasn't added. Try again.");
            else
            {
                MessageBox.Show("Successful !");
                dataGridView5.DataSource = Users.UserList();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            UserAddress us = new UserAddress();
            us.Show();
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = Users.UserList();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewRow row = dataGridView5.CurrentRow;

            comboBox14.Text = row.Cells[0].Value.ToString();
            textBox12.Text = row.Cells[1].Value.ToString();
            textBox11.Text = row.Cells[2].Value.ToString();
            textBox13.Text = row.Cells[3].Value.ToString();
            maskedTextBox1.Text = row.Cells[4].Value.ToString();
            maskedTextBox2.Text = row.Cells[5].Value.ToString();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           //PRODUCTS
            DataGridViewRow row = dataGridView4.CurrentRow;

            textBox15.Text = row.Cells[0].Value.ToString();
            textBox16.Text = row.Cells[1].Value.ToString();
            textBox17.Text = row.Cells[2].Value.ToString();
            textBox18.Text = row.Cells[3].Value.ToString();
            textBox8.Text = row.Cells[4].Value.ToString();
            richTextBox2.Text = row.Cells[5].Value.ToString();
            textBox9.Text = row.Cells[6].Value.ToString();
            textBox10.Text = row.Cells[7].Value.ToString();
            textBox14.Text = row.Cells[8].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView3.CurrentRow;

            comboBox8.Text = row.Cells[0].Value.ToString();
            comboBox7.Text = row.Cells[1].Value.ToString();
            richTextBox1.Text = row.Cells[2].Value.ToString();
            dateTimePicker1.Text =  row.Cells[3].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox7.Text = row.Cells[5].Value.ToString();
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            EProduct x = new EProduct();
            x.PID = Convert.ToInt32(textBox15.Text);
            x.PName = textBox16.Text;
            x.CategoryID = Convert.ToInt32(textBox17.Text);
            x.Brand = textBox18.Text;
            x.Model = textBox8.Text;
            x.PDescription = richTextBox2.Text;
            x.Price = Convert.ToDecimal(textBox9.Text);
            x.Stock = Convert.ToInt32(textBox14.Text);
            if (!FProduct.ProductUpdate(x))
                MessageBox.Show("It wasn't updated. Try again.");
            else
            {
                MessageBox.Show("Successful !");
                dataGridView4.DataSource = FProduct.ProductList();
            }
        }
    }
}
