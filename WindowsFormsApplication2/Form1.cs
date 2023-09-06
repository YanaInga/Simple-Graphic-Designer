using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap b;
        Graphics g;
        Point startPoint;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.pictureBox1.BackColor;
            if(this.colorDialog1.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox1.BackColor = this.colorDialog1.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox2.Size.Width, this.pictureBox2.Size.Height);
            this.g = Graphics.FromImage(this.b);
            this.pictureBox2.Image = b;
            this.g.Clear(Color.White);
            this.listBox1.SelectedIndex = 0;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.g.Clear(Color.White);
            this.pictureBox2.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.g.Clear(Color.White);
                this.g.DrawImage(Image.FromFile(this.openFileDialog1.FileName), new Point(0, 0));
                this.pictureBox2.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.b.Save(this.saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void pictureBox2_MouseUp_1(object sender, MouseEventArgs e)
        {
            Pen p1 = new Pen(this.pictureBox1.BackColor, (float)this.numericUpDown1.Value);
            switch (this.listBox2.SelectedIndex)
            {
                case 0:
                    p1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case 1:
                    p1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    break;
                case 2:
                    p1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
            }
            Brush b = new SolidBrush(Color.White);
            switch(this.listBox3.SelectedIndex)
            {
                case 0: b = new SolidBrush(pictureBox3.BackColor);
                    break;
                case 1: b = new LinearGradientBrush(new Point(this.startPoint.X, this.startPoint.Y), new Point(e.X, e.Y), pictureBox1.BackColor, pictureBox3.BackColor);
                    break;
                case 2: b = new HatchBrush(HatchStyle.DarkVertical, pictureBox1.BackColor, pictureBox3.BackColor);
                    break;
            }
            switch (this.listBox1.SelectedIndex)
            {
                case 0:
                    this.g.DrawLine(p1, this.startPoint, new Point(e.X, e.Y));
                    this.pictureBox2.Invalidate();
                    break;
                case 1:
                    this.g.DrawRectangle(p1, this.startPoint.X, this.startPoint.Y, e.X - this.startPoint.X, e.Y - this.startPoint.Y);
                    if (this.checkBox1.Checked)
                    {
                        this.g.FillRectangle(b, this.startPoint.X, this.startPoint.Y, e.X - this.startPoint.X, e.Y - this.startPoint.Y);
                    }
                    this.pictureBox2.Invalidate();
                    break;
                case 2:
                    this.g.DrawEllipse(p1, this.startPoint.X, this.startPoint.Y, e.X - this.startPoint.X, e.Y - this.startPoint.Y);
                    if (this.checkBox1.Checked)
                    {
                        this.g.FillEllipse(b, this.startPoint.X, this.startPoint.Y, e.X - this.startPoint.X, e.Y - this.startPoint.Y);
                    }
                    this.pictureBox2.Invalidate();
                    break;
            }
        }

        private void pictureBox2_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.startPoint = new Point(e.X, e.Y);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.pictureBox3.BackColor;
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox3.BackColor = this.colorDialog1.Color;
            }
        }
    }
}
