using System;
using System.Collections.Generic;

namespace SICpsAlgorithm
{
  [Serializable]
  public class Image
  {
    public List<Variable> Columns { get; set; }

    public List<Variable> Rows { get; set; }
  }
}