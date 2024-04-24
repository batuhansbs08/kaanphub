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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AracBilgileri.mdb");
        public void goruntule()
        {
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From SistemKullanicilari", baglan);
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
            OleDbCommand komut = new OleDbCommand("Insert into SistemKullanicilari(KullaniciAdi,Sifre,Email,Telefon) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4 + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand(" Update SistemKullanicilari Set Sifre ='" + textBox2.Text + "',Email ='" + textBox3.Text + "',Telefon ='" + textBox4.Text + "'where KullaniciAdi = '" + textBox1.Text + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Delete From SistemKullanicilari Where KullaniciAdi = '" + textBox1.Text + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }
    }
}
