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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AracBilgileri.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = textBox1.Text;
            string sifre = textBox2.Text;
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM YetkiliHesap WHERE YetkiliAd= '" + kullanici + "' AND YetkiliSifre = '" + sifre + "'", baglan);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Sistem Sayfasına Yönlendiriliyorsunuz...");
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.Show();
            }
            else 
            {
                MessageBox.Show("Böyle Bir Hesap Bulunamadı");
            }
            baglan.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
