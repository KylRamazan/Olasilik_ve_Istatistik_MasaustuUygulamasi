using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlasilikveIstatistik
{
    public partial class SistematikRastgele : Form
    {
        public SistematikRastgele()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (txtKitleSayisi.Text == "")
            {

                errorProvider1.SetError(txtKitleSayisi, "Bu alan boş geçilemez");
            }
            else if (txtOrneklemSayisi.Text == "")
            {
                errorProvider2.SetError(txtOrneklemSayisi, "Bu alan boş geçilemez");
            }
            else
            {
                label3.Visible = true;
                listSonuc.Visible = true;
                label1.Location = new Point(280, 86);
                label2.Location = new Point(239, 145);
                txtKitleSayisi.Location = new Point(429, 83);
                txtOrneklemSayisi.Location = new Point(429, 142);
                btnHesapla.Location = new Point(462, 205);
                int kitleSayisi = Convert.ToInt32(txtKitleSayisi.Text);
                int orneklemSayisi = Convert.ToInt32(txtOrneklemSayisi.Text);
                int k = Convert.ToInt32(kitleSayisi / orneklemSayisi);
                Random rand = new Random();
                int a = rand.Next(1,k);
                for (int i = 0; i < orneklemSayisi; i++)
                {
                    listSonuc.Items.Add(a + (k * i));
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SistematikRastgele_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            label3.Visible = false;
            listSonuc.Visible = false;
        }

        private void txtKitleSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtOrneklemSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKitleSayisi_TextChanged(object sender, EventArgs e)
        {
            if (txtKitleSayisi.Text == "")
            {

                errorProvider1.SetError(txtKitleSayisi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtOrneklemSayisi_TextChanged(object sender, EventArgs e)
        {
            if (txtOrneklemSayisi.Text == "")
            {

                errorProvider2.SetError(txtOrneklemSayisi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
