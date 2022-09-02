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
    public partial class Permutasyon : Form
    {
        public Permutasyon()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNSayisi_TextChanged(object sender, EventArgs e)
        {
            if (txtNSayisi.Text == "")
            {

                errorProvider1.SetError(txtNSayisi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtRSayisi_TextChanged(object sender, EventArgs e)
        {
            if (txtRSayisi.Text == "")
            {

                errorProvider1.SetError(txtRSayisi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (txtNSayisi.Text == "")
            {

                errorProvider1.SetError(txtNSayisi, "Bu alan boş geçilemez");
            }
            else if (txtRSayisi.Text == "")
            {
                errorProvider2.SetError(txtRSayisi, "Bu alan boş geçilemez");
            }
            else
            {
                System.Numerics.BigInteger sayiN = Convert.ToUInt64(txtNSayisi.Text);
                System.Numerics.BigInteger sayiR = Convert.ToUInt64(txtRSayisi.Text);
                if (sayiN >= sayiR)
                {
                    label3.Visible = true;
                    label4.Visible = true;
                    label1.Location = new Point(315, 144);
                    label2.Location = new Point(315, 203);
                    txtNSayisi.Location = new Point(382, 141);
                    txtRSayisi.Location = new Point(382, 200);
                    btnHesapla.Location = new Point(417, 256);
                    if (sayiR == 0)
                    {
                        label4.Text = Convert.ToString(1);
                    }
                    System.Numerics.BigInteger sayiNFaktoriyel = 1;
                    for (int i = 1; i <= sayiN; i++)
                    {
                        sayiNFaktoriyel = sayiNFaktoriyel * i;
                    }

                    System.Numerics.BigInteger sayiN_RFaktoriyel = 1;
                    for (int i = (int)(sayiN - sayiR); i >=1 ; i--)
                    {
                        sayiN_RFaktoriyel = sayiN_RFaktoriyel * i;
                    }

                    System.Numerics.BigInteger sonuc = sayiNFaktoriyel / sayiN_RFaktoriyel;
                    label4.Text = Convert.ToString(sonuc);
                }
                else
                {
                    MessageBox.Show("R Sayısı N Sayısından Büyük Olamaz.\nLütfen Kontrol Edip Tekrar Deneyiniz!", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Permutasyon_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void txtNSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
