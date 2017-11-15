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
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var imageReader = new ImageReader();
      var cDomains = new CreateDomains();
      var bckTracking = new BackTracking();
      var fchecking = new ForwardChecking();

      var image = imageReader.GetImage(@"C:\aga\PWR\semestr 7\Sztuczna inteligencja -l-\imageLog3.json");
      
      cDomains.Create2(ref image);
      var watch = new Stopwatch();
      watch.Start();
      //bckTracking.Resolve(ref image);
      fchecking.Resolve(ref image);
      watch.Stop();
      img = image;
      groupBox1.Refresh();
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
            g.FillRectangle(System.Drawing.Brushes.SlateGray,rect);
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
