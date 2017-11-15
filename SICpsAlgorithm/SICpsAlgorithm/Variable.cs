using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SICpsAlgorithm
{
  [Serializable]
  public class Variable
  {
    [JsonIgnore]
    public List<Field> Fields { get; set; }

    public List<int> ColoredBlocks { get; set; }

    [JsonIgnore]
    public List<Domain> Domains { get; set; }

    [JsonIgnore]
    public bool Resolved { get; set; }
  }
}