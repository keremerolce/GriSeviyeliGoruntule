using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GriSeviyeliGoruntuler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter ="resimler|*.bmp|All Files|*.*";
            if (sfd.ShowDialog()!=System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            pictureBox1.ImageLocation = sfd.FileName;
        }
        private Bitmap griyap(Bitmap bmp )
        {
            for (int i = 0; i < bmp.Height-1; i++)
            {
                for (int j = 0; j < bmp.Width-1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    Color renk;
                    renk = Color.FromArgb(deger,deger,deger);

                    bmp.SetPixel(j,i,renk);
                }
            }
            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = griyap(image);

            pictureBox2.Image = gri;
        }
    }
}
