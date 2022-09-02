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
    public partial class BasitRastgele : Form
    {
        public BasitRastgele()
        {
            InitializeComponent();
        }

        private void BasitRastgele_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            errorProvider3.BlinkRate = 400;
            label4.Visible = false;
            listSonuc.Visible = false;
        }

        private void txtMinimum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMaximum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSayiAdedi_TextChanged(object sender, EventArgs e)
        {
            if (txtSayiAdedi.Text == "")
            {

                errorProvider3.SetError(txtSayiAdedi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void txtSayiAdedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (txtMinimum.Text == "")
            {

                errorProvider1.SetError(txtMinimum, "Bu alan boş geçilemez");
            }
            else if (txtMaximum.Text == "")
            {
                errorProvider2.SetError(txtMaximum, "Bu alan boş geçilemez");
            }
            else if(txtSayiAdedi.Text == "")
            {
                errorProvider3.SetError(txtSayiAdedi, "Bu alan boş geçilemez");
            }
            else
            {
                label4.Visible = true;
                listSonuc.Visible = true;

                label1.Location = new Point(223, 58);
                label2.Location = new Point(218, 121);
                label3.Location = new Point(262, 187);
                txtMinimum.Location = new Point(416, 55);
                txtMaximum.Location = new Point(416, 118);
                txtSayiAdedi.Location = new Point(416, 184);
                btnHesapla.Location = new Point(450, 243);

                int minimumSayi = Convert.ToInt32(txtMinimum.Text);
                int maximumSayi = Convert.ToInt32(txtMaximum.Text);
                int sayiAdedi = Convert.ToInt32(txtSayiAdedi.Text);
                int[] sayilar = new int[sayiAdedi];
                int gecici = 0,x=0;
                Random rand = new Random();
                
                if((maximumSayi-minimumSayi)>=sayiAdedi)
                {
                    while(x<sayiAdedi)
                    {
                       gecici = rand.Next(minimumSayi, maximumSayi);
                            int yoksa =Array.IndexOf(sayilar,gecici);
                            if(yoksa==-1)
                            {
                                sayilar[x] = gecici;
                                x++;
                            }
                    }
                }else
                {
                    for(int i=0;i<sayiAdedi;i++)
                    {
                        sayilar[i] = rand.Next(minimumSayi,maximumSayi);
                    }
                }

                for(int i=0;i<sayiAdedi;i++)
                {
                    listSonuc.Items.Add(sayilar[i]);
                }
            }
        }

        private void txtMinimum_TextChanged(object sender, EventArgs e)
        {
            if (txtMinimum.Text == "")
            {

                errorProvider1.SetError(txtMinimum, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMaximum_TextChanged(object sender, EventArgs e)
        {
            if (txtMaximum.Text == "")
            {

                errorProvider2.SetError(txtMaximum, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
