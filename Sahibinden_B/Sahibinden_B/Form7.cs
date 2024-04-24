using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahibinden_B
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            this.Hide();
            frm5.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Çıkış Yapmak İstediğinizden Eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Form1 frm1 = new Form1();
                this.Close();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Çıkış İşlemi Yapılmamıştır");
            }
        }
    }
}
