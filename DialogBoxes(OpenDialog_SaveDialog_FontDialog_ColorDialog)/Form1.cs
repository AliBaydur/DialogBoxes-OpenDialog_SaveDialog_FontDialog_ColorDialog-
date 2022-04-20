using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogBoxes_OpenDialog_SaveDialog_FontDialog_ColorDialog_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Yukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Dosyası(*.png) | *.png | JPG Dosyası | *.jpg | Tüm Uzantılar (*.*) | *.*";
            ofd.FilterIndex = 3;

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string DosyaAdi = ofd.SafeFileName;
                string DosyaYolu = ofd.FileName;

                pictureBox1.ImageLocation = DosyaYolu;
                textBox1.Text = DosyaAdi;
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "PNG Dosyası(*.png) | *.png | JPG Dosyası | *.jpg | Tüm Uzantılar (*.*) | *.*";
            svf.FilterIndex = 2;
            svf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (svf.ShowDialog() == DialogResult.OK)
            {
                string uzantı = System.IO.Path.GetExtension(svf.FileName);
                ImageFormat format = ImageFormat.Png;

                switch (uzantı)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(svf.FileName, format);
            }
        }
    }
}
