using System.Collections.Generic;

namespace SICpsAlgorithm
{
  public class Domain
  {
    public Domain()
    {
      Fields = new List<Field>();
    }
    public List<Field> Fields { get; set; }
    public bool Incorrect { get; set; }
  }
}