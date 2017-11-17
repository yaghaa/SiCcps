using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;

namespace SICpsAlgorithm
{
  public class ImageReader
  {
    public Image GetImage(string path)
    {
      Image image;

      using (StreamReader r = new StreamReader(path))
      {
        var json = r.ReadToEnd();
        image = JsonConvert.DeserializeObject<Image>(json);
      }

      image.Columns.ForEach(x=>
      {
        x.Fields = new List<Field>();
        for (var y = 0; y < image.Rows.Count; y++)
        {
          x.Fields.Add(new Field());
        }
      });

      image.Rows.ForEach(x =>
      {
        x.Fields = new List<Field>();
        for (var y = 0; y < image.Columns.Count; y++)
        {
          x.Fields.Add(new Field());
        }
      });
      image.Name = path.Replace(@"C:\aga\PWR\semestr 7\zpi\ZPI\SICcps\","");
      return image;
    }
  }
}