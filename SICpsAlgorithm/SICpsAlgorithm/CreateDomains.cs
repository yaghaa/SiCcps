using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace SICpsAlgorithm
{
  public class CreateDomains
  {
    public CreateDomains()
    {
      Domain = new List<Domain>();
    }
    public void Create(ref Image img)
    {
      img.Columns= CreateVariableDomains(img.Columns);
      img.Rows= CreateVariableDomains(img.Rows);
    }

    public List<Variable> CreateVariableDomains(List<Variable> variables)
    {
      foreach (var variable in variables)
      {
        variable.Domains = new List<Domain>();

        var fieldsCount = variable.Fields.Count;
        var allColoredFields = variable.ColoredBlocks.Sum();
        var breaksCount = variable.ColoredBlocks.Count - 1;

        var breaksMaxLength = fieldsCount - allColoredFields;

        for (int startIndex = 0; startIndex < fieldsCount -(allColoredFields+breaksCount) + 1; startIndex++)
        {
          var currentbreaksMaxLength = breaksMaxLength - startIndex;
          var breakSum = 0;
          var breakCombinations = GetBreakCombinantions(currentbreaksMaxLength, breaksCount);

          foreach (var breakCombination in breakCombinations)
          {
            var list = new List<Field>();
            for (int i = 0; i < fieldsCount; i++)
            {
              list.Add(new Field());
            }
            var lastIndex = startIndex;

            for (int t = 0; t < variable.ColoredBlocks.Count; t++)
            {
              if (lastIndex + variable.ColoredBlocks[t] > list.Count)
              {
                continue;
              }
              for (int i = lastIndex; i < variable.ColoredBlocks[t]+ lastIndex; i++)
              {
                list[i].Value = true;
              }

              if (t < variable.ColoredBlocks.Count - 1)
              {
                breakSum += breakCombination[t];
                lastIndex += variable.ColoredBlocks[t]+ breakSum;
              }
            }

            variable.Domains.Add(new Domain(){Fields = list});
          }
        }
      }
      return variables;
    }

    private List<List<int>> GetBreakCombinantions(int breaksMaxLength, int breaksCount)
    {
      var breaks = new List<List<int>>();
      if (breaksCount == 0)
      {
        breaks.Add(new List<int>());

        return breaks;
      }

      var maxBreak = breaksMaxLength;

      for (int i = 1; i <= maxBreak; i++)
      {
        var breakValues = new List<int>();
        if (breaksCount == 1)
        {
          breaks.Add(new List<int>(){i});
          continue;
        }
        for (int j = 1; j < maxBreak - i; j++)
        {
          if (breaksCount == 2)
          {
            breaks.Add(new List<int>() { i,j });
            continue;
          }
          for (int k = 1; k < maxBreak - j - i; k++)
          {
            if (i + j + k <= breaksMaxLength)
            {
              breakValues.Add(i);
              breakValues.Add(j);
              breakValues.Add(k);

              breaks.Add(breakValues);
            }
          }
        }
      }

      return breaks;
    }

    public void Create2(ref Image img)
    {
      foreach (var VARIABLE in img.Columns)
      {
        var maxStart = VARIABLE.Fields.Count - VARIABLE.ColoredBlocks.Sum() -
                       VARIABLE.ColoredBlocks.Count + 1;

        var domainField = new Domain();
        for (int i = 0; i < VARIABLE.Fields.Count; i++)
        {
          domainField.Fields.Add(new Field());
        }
        Rysuj(VARIABLE.Fields.Count, 0, maxStart, VARIABLE.ColoredBlocks, domainField);

        VARIABLE.Domains = CopyDomain();
        Domain = new List<Domain>();
      }

     foreach(var VARIABLE in img.Rows)
      {
        var maxStart = VARIABLE.Fields.Count - VARIABLE.ColoredBlocks.Sum() -
                       VARIABLE.ColoredBlocks.Count + 1;

        var domainField = new Domain();
        for (int i = 0; i < VARIABLE.Fields.Count; i++)
        {
          domainField.Fields.Add(new Field());
        }
        Rysuj(VARIABLE.Fields.Count, 0, maxStart, VARIABLE.ColoredBlocks, domainField);

        VARIABLE.Domains = CopyDomain();
        Domain = new List<Domain>();
      }
    }

    private List<Domain> CopyDomain()
    {
      return new List<Domain>(Domain.Select(CopyDomainItem));
    }

    public void Rysuj(int SIZE, int START, int MaxSTART, List<int> coloredFields, Domain domainField)
    {
      while (START <= MaxSTART)
      {

        domainField = Zakoloruj(domainField, START, coloredFields[0]);
    

        var newColoredFields = coloredFields.Skip(1).ToList();
        
        if (newColoredFields.Count > 0)
        {
          var newSTART = START + coloredFields[0] + 1;
          var newMaxSTART = SIZE - newColoredFields.Sum() - newColoredFields.Count + 1;

          Rysuj(SIZE, newSTART, newMaxSTART, newColoredFields, domainField);

        }
        else
        {

          Domain.Add(CopyDomainItem(domainField));
          
          for (int i = START; i < SIZE; i++)
          {
            domainField.Fields[i].Value = false;
          }
          START++;
        }

        if (Domain.Last().Fields.Last().Value)
        {
          domainField.Fields.ForEach(x => x.Value = false);
          START++;
        }
      }
    }

    private Domain CopyDomainItem(Domain domainField)
    {
      var newDomain = new List<Field>();
      foreach (Field t in domainField.Fields)
      {
        var field = new Field()
        {
          Value = t.Value
        };

        newDomain.Add(field);
      }
      return new Domain() {Fields = newDomain};
    }

    public List<Domain> Domain { get; set; }

    private Domain Zakoloruj(Domain domainField, int start, int coloredField)
    {
      for (int i = 0; i < coloredField; i++)
      {
        domainField.Fields[start + i].Value = true;
      }

      return domainField;
    }
  }
}