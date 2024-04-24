using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sahibinden_B
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AracBilgileri.mdb");
        public void goruntule()
        {
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From MotorBilgi", baglan);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            goruntule();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            
            baglan.Open();
            
            OleDbCommand komut = new OleDbCommand("Insert into MotorBilgi(Marka,Model,MotorGucu,Kilometre,VitesTuru,Yil,SatisNumarasi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+comboBox1.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Delete From MotorBilgi Where SatisNumarasi = '" + textBox6.Text + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }
    }
}
