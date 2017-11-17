namespace SICpsAlgorithm
{
    public abstract class Revolver
    {
      public abstract void Resolve(ref Image image);
      public bool ShortestDomain { get; set; }
    }
}