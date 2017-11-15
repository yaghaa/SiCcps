using System.Drawing;

namespace SICpsAlgorithm
{
  public class Field
  {
    public Field()
    {
      Value = false;
    }
    public bool Value{ get; set; }

    public Color Color => Color.Red;
  }
}