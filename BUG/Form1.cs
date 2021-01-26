using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace BUG
{

    public partial class Form1 : Form
    {
        PictureBox cow;
        Bitmap cow_image;
        Rectangle dropRect = new Rectangle(250, 200, 100, 100);
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
 
            this.MaximumSize = new Size(500, 500);
            this.MinimumSize = new Size(500, 500);
            this.BackgroundImage = Image.FromFile("C:\\fon_cow.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;

            cow = new PictureBox();
            cow.Width = this.Width / 10;
            cow.Height = this.Height / 10;
            cow.Image = Image.FromFile("C:\\cow.png");
            cow.SizeMode = PictureBoxSizeMode.StretchImage;
            cow.Location = new Point(100, 250);
            cow.Parent = this;
            cow.BackColor = Color.Transparent;
            this.Controls.Add(cow);
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
            cow_image = (Bitmap)cow.Image;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");

                bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
                cow.Image = bitmap;
                cow.Left += 10;
                cow_image = bitmap;
            }
            else if (e.KeyCode == Keys.Left)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipY);
                cow.Image = bitmap;
                cow.Left -= 10;
                cow_image = bitmap;
            }
            else if (e.KeyCode == Keys.Up)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                cow.Image = bitmap;
                cow.Top -= 10;
                cow_image = bitmap;
            }
            else if (e.KeyCode == Keys.Down)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipY);
                cow.Image = bitmap;
                cow.Top += 10;
                cow_image = bitmap;
            }

            if (e.KeyCode == Keys.Enter)
            {

                cow.Size = new Size(this.Width / 5, this.Height / 5);

                cow.Image = Image.FromFile("C:\\cow13.png");
                cow.SizeMode = PictureBoxSizeMode.StretchImage;
            }

                if (dropRect.Contains(cow.Bounds))
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                        cow.Image = bitmap;
                        cow.Top -= 100;
                    MessageBox.Show("Осторожно", "Stop");
                    cow_image = bitmap;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                        cow.Image = bitmap;
                        cow.Top += 100;
                    MessageBox.Show("Осторожно", "Stop");
                    cow_image = bitmap;
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                        cow.Image = bitmap;
                        cow.Left += 100;
                    MessageBox.Show("Осторожно", "Stop");
                    cow_image = bitmap;
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\cow.png");
                        cow.Image = bitmap;
                        cow.Left -= 100;
                    MessageBox.Show("Осторожно", "Stop");
                    cow_image = bitmap;
                    }
                }
            }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cow.Size = new Size(this.Width / 10, this.Height / 10);
                cow.Image = cow_image;
            }
        }
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
            e.Graphics.DrawRectangle(pen, dropRect);
        }
    }
}