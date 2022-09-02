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
    public partial class FrekansSerisi : Form
    {
        public FrekansSerisi()
        {
            InitializeComponent();
        }

        private void FrekansSerisi_Load(object sender, EventArgs e)
        {
            txtSayilar.ScrollBars = ScrollBars.Vertical;
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            listSiralama.Visible = false;
            listTekrarSayisi.Visible = false;
            label6.Text = ("<=NOT:Bu alana girilen en son \n değerden sonra imleç degerin \n yanında kalmalı (son degerden \n sonra enter tuşuna basmayınız)!");

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (txtSayiAdedi.Text == "")
            {

                errorProvider1.SetError(txtSayiAdedi, "Bu alan boş geçilemez");
            }
            else if (txtSayilar.Text == "")
            {
                errorProvider2.SetError(txtSayilar, "Bu alan boş geçilemez");
            }
            else
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                listSiralama.Visible = true;
                listTekrarSayisi.Visible = true;
                label6.Location = new Point(590, 125);
                label1.Location = new Point(261,55);
                label2.Location = new Point(291,135);
                txtSayiAdedi.Location = new Point(413,52);
                txtSayilar.Location = new Point(413,110);
                btnHesapla.Location = new Point(449,235);

                int sayiAdedi =Convert.ToInt32(txtSayiAdedi.Text),tekrarSayisi=0;
                int[] sayilar = new int[sayiAdedi];
                int[] tekrarDegerleri = new int[sayiAdedi];
                for (int i = 0; i < txtSayilar.Lines.Length; i++)
                {
                    sayilar[i] = Convert.ToInt32(txtSayilar.Lines[i]);
                }

                Uygulamalar.sirala(sayilar);

                for (int i=0;i<sayilar.Length;i++)
                {
                    for(int j=0;j<sayilar.Length;j++)
                    {
                        if(sayilar[i]==sayilar[j])
                        {
                            tekrarSayisi++;
                        }
                    }
                    tekrarDegerleri[i] = tekrarSayisi;
                    tekrarSayisi = 0;
                }

                for (int i = 0; i < sayilar.Length; i++)
                {
                    if (i != sayilar.Length - 1)
                    {
                        if (sayilar[i] < sayilar[i + 1])
                        {
                            listSiralama.Items.Add(sayilar[i]);
                            listTekrarSayisi.Items.Add(tekrarDegerleri[i]);
                        }
                    }
                    else
                    {
                    listSiralama.Items.Add(sayilar[i]);
                    listTekrarSayisi.Items.Add(tekrarDegerleri[i]);
                    }
                }
            }

        }

        private void txtSayiAdedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSayilar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSayiAdedi_TextChanged(object sender, EventArgs e)
        {
            if (txtSayiAdedi.Text == "")
            {

                errorProvider1.SetError(txtSayiAdedi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSayilar_TextChanged(object sender, EventArgs e)
        {
            if (txtSayilar.Text == "")
            {

                errorProvider2.SetError(txtSayilar, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
