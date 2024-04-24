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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AracBilgileri.mdb");
        public void goruntule()
        {
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From YetkiliHesap", baglan);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            goruntule();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Insert into YetkiliHesap(YetkiliAd,YetkiliSifre) values ('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
            textBox1.Clear();
            textBox2.Clear();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand(" Update YetkiliHesap Set Sifre ='" + textBox2.Text + "'where YetkiliAd = '" + textBox1.Text + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }
    }
}
