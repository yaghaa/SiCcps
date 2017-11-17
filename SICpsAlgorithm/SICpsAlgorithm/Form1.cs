using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICpsAlgorithm
{
    public partial class Form1 : Form
    {
        private Image img = new Image();
        public Form1()
        {
            InitializeComponent();

            shortestDomain.DataSource = new[] { "Shortest Domain", "Regular" };
            algorithmType.DataSource = new[] { "BackTracking", "ForwardChecking" };

            AddImages();
        }

        private void AddImages()
        {
            var selectedIndex = 0;
            if (images.SelectedIndex != 0 && images.SelectedIndex != -1)
            {
                selectedIndex = images.SelectedIndex;
            }
            var imageReader = new ImageReader();
            var image = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\imageDog.json");
            var image2 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\image3x3.json");
            var image3 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\imageLog2.json");
            var image4 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\image.json");
            var image5 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\imageDuck.json");
            var image6 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\imageHeart.json");
            var image7 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\cat2.json");
            var image8 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\cat.json");
            var image9 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\owl.json");
            var image10 = imageReader.GetImage(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\owl2.json");
            var list = new List<Image>();
            list.Add(image);
            list.Add(image2);
            list.Add(image3);
            list.Add(image4);
            list.Add(image5);
            list.Add(image6);
            list.Add(image7);
            list.Add(image8);
            list.Add(image9);
            list.Add(image10);
            images.DataSource = list;
            images.SelectedIndex = selectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            img = new Image();
            groupBox1.Refresh();
            var cDomains = new CreateDomains();

            var revolver = algorithmType.SelectedValue == "BackTracking" ? (Revolver)new BackTracking() : new ForwardChecking();
            revolver.ShortestDomain = shortestDomain.SelectedValue == "Shortest Domain";
            var image = (Image)images.SelectedItem;


            cDomains.Create2(ref image);
            var watch = new Stopwatch();
            watch.Start();
            revolver.Resolve(ref image);
            watch.Stop();
            img = image;
            groupBox1.Refresh();
            AddImages();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            int x, y = 20, w = 50, h = 50;

            Pen pen = new Pen(Color.Black, 2);
            Pen pen2 = new Pen(Color.Black, 2);
            Graphics g = groupBox1.CreateGraphics();

            for (int i = 0; i < img.Rows?.Count; i++)
            {
                x = 10;
                for (int j = 0; j < img.Columns?.Count; j++)
                {
                    if (img.Rows[i].Fields[j].Value)
                    {
                        var rect = new Rectangle(x, y, w, h);
                        g.DrawRectangle(pen, rect);
                        g.FillRectangle(System.Drawing.Brushes.SlateGray, rect);
                    }
                    else
                    {
                        var rect = new Rectangle(x, y, w, h);
                        g.DrawRectangle(pen2, rect);
                        g.FillRectangle(System.Drawing.Brushes.White, rect);
                    }
                    x += 50;
                }
                y += 50;
            }
        }
    }
}
