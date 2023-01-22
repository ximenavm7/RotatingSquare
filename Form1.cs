using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace actividad3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Point a, b, c, d;                   // Original square
        Point north, south, east, west;     // Plane coordenates
        Point new_a, new_b, new_c, new_d;   // Rotated square

        double angle;
        Point pivot, center; // Origin, center of square

        private void button3_Click(object sender, EventArgs e) // Rotate square when pivot = center
        {
            angle = Convert.ToInt32(textBox1.Text);
            angle = -(angle * Math.PI / 180);
            rotate_origin();
            g.Clear(Color.White);
            cartesian_plane();
            draw_square(new_a, new_b, new_c, new_d);

        }

        private void button2_Click(object sender, EventArgs e) // Around its own center
        {
            angle = Convert.ToInt32(textBox1.Text);
            angle = -(angle * Math.PI / 180);
            Rotation();
            g.Clear(Color.White);
            cartesian_plane();
            draw_square(new_a, new_b, new_c, new_d);
        }

        private void button1_Click(object sender, EventArgs e) // Around the origin
        {
            angle = Convert.ToInt32(textBox1.Text);
            angle = -(angle * Math.PI / 180);
            Translation();
            g.Clear(Color.White);
            cartesian_plane();
            draw_square(new_a, new_b, new_c, new_d);
        }

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            pivot = new Point(bmp.Width / 2, bmp.Height / 2);
            center = new Point((bmp.Width / 2) + 50, (bmp.Height / 2) - 50);
            cartesian_plane();

            // Inicialize the square of size 100x100
            a = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            b = new Point((pictureBox1.Width / 2) + 100, pictureBox1.Height / 2);
            c = new Point((pictureBox1.Width / 2) + 100, (pictureBox1.Height / 2) - 100);
            d = new Point(pictureBox1.Width / 2, (pictureBox1.Height / 2) - 100);

            draw_square(a, b, c, d);

        }

        private void draw_square(Point a, Point b, Point c, Point d)
        {            

            g.DrawLine(Pens.DarkViolet, a, b);
            g.DrawLine(Pens.Green, b, c);
            g.DrawLine(Pens.DarkViolet, c, d);
            g.DrawLine(Pens.DarkViolet, d, a);

            /*
            Pen pen = new Pen(Color.DarkViolet, 1);
            Rectangle rect = new Rectangle(pictureBox1.Width/2, pictureBox1.Height/2-100, 100, 100);
            g.DrawRectangle(pen, rect);
            */
            pictureBox1.Invalidate();
        }

        private void cartesian_plane() // Draws the red cartesian plane in the background
        {
            north = new Point(pictureBox1.Width / 2, 0);
            south = new Point(pictureBox1.Width / 2, pictureBox1.Height);
            west = new Point(0, pictureBox1.Height / 2);
            east = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(Pens.Red, north, south);
            g.DrawLine(Pens.Red, east, west);
        }

        private void Translation() // Translates square around the center of the cartesian plane
        {
            new_a.X = (int)(((a.X - pivot.X) * Math.Cos(angle)) - ((a.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_a.Y = (int)(((a.X - pivot.X) * Math.Sin(angle)) + ((a.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            new_b.X = (int)(((b.X - pivot.X) * Math.Cos(angle)) - ((b.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_b.Y = (int)(((b.X - pivot.X) * Math.Sin(angle)) + ((b.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            new_c.X = (int)(((c.X - pivot.X) * Math.Cos(angle)) - ((c.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_c.Y = (int)(((c.X - pivot.X) * Math.Sin(angle)) + ((c.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            new_d.X = (int)(((d.X - pivot.X) * Math.Cos(angle)) - ((d.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_d.Y = (int)(((d.X - pivot.X) * Math.Sin(angle)) + ((d.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
        }

        private void Rotation () // Rotates square around its own center
        {
            new_a.X = (int)(((a.X - center.X) * Math.Cos(angle)) - ((a.Y - center.Y) * Math.Sin(angle)) + center.X);
            new_a.Y = (int)(((a.X - center.X) * Math.Sin(angle)) + ((a.Y - center.Y) * Math.Cos(angle)) + center.Y);
            new_b.X = (int)(((b.X - center.X) * Math.Cos(angle)) - ((b.Y - center.Y) * Math.Sin(angle)) + center.X);
            new_b.Y = (int)(((b.X - center.X) * Math.Sin(angle)) + ((b.Y - center.Y) * Math.Cos(angle)) + center.Y);
            new_c.X = (int)(((c.X - center.X) * Math.Cos(angle)) - ((c.Y - center.Y) * Math.Sin(angle)) + center.X);
            new_c.Y = (int)(((c.X - center.X) * Math.Sin(angle)) + ((c.Y - center.Y) * Math.Cos(angle)) + center.Y);
            new_d.X = (int)(((d.X - center.X) * Math.Cos(angle)) - ((d.Y - center.Y) * Math.Sin(angle)) + center.X);
            new_d.Y = (int)(((d.X - center.X) * Math.Sin(angle)) + ((d.Y - center.Y) * Math.Cos(angle)) + center.Y);

        }

        private void rotate_origin() // places square's center in the pivot point and rotates
        {
            new_a.X = (int)(((a.X - 50 - pivot.X) * Math.Cos(angle)) - ((a.Y + 50 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_a.Y = (int)(((a.X - 50 - pivot.X) * Math.Sin(angle)) + ((a.Y + 50 - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            new_b.X = (int)(((b.X - 50 - pivot.X) * Math.Cos(angle)) - ((b.Y + 50 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_b.Y = (int)(((b.X - 50 - pivot.X) * Math.Sin(angle)) + ((b.Y + 50 - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            new_c.X = (int)(((c.X - 50 - pivot.X) * Math.Cos(angle)) - ((c.Y + 50 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_c.Y = (int)(((c.X - 50 - pivot.X) * Math.Sin(angle)) + ((c.Y + 50 - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            new_d.X = (int)(((d.X - 50 - pivot.X) * Math.Cos(angle)) - ((d.Y + 50 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            new_d.Y = (int)(((d.X - 50 - pivot.X) * Math.Sin(angle)) + ((d.Y + 50 - pivot.Y) * Math.Cos(angle)) + pivot.Y);
        }

    }
}
