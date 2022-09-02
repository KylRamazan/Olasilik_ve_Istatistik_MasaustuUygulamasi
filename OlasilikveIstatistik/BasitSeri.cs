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
    public partial class BasitSeri : Form
    {
        public BasitSeri()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (txtSayiAdedi.Text=="")
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
                listSonuc.Visible = true;

                label1.Location = new Point(267, 65);
                label2.Location = new Point(297, 122);
                label4.Location = new Point(590, 125);
                txtSayiAdedi.Location = new Point(420, 62);
                txtSayilar.Location = new Point(420, 115);
                btnHesapla.Location = new Point(454, 242);
                label1.Location = new Point(267, 65);

                int sayiAdedi = Convert.ToInt32(txtSayiAdedi.Text);
                int[] sayilar = new int[sayiAdedi];
                for (int i = 0; i < txtSayilar.Lines.Length; i++)
                {
                    sayilar[i] = Convert.ToInt32(txtSayilar.Lines[i]);
                }

                Uygulamalar.sirala(sayilar);

                for (int i = 0; i < sayiAdedi; i++)
                {
                    listSonuc.Items.Add(sayilar[i]);
                }
            }
        }

        private void BasitSeri_Load(object sender, EventArgs e)
        {
            txtSayilar.ScrollBars = ScrollBars.Vertical;
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            label3.Visible= false;
            listSonuc.Visible = false;
            label4.Text = ("<=NOT:Bu alana girilen en son \n değerden sonra imleç degerin \n yanında kalmalı (son degerden \n sonra enter tuşuna basmayınız)!");

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
            }else
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
    }
}
