using System;
using System.Collections.Generic;
using System.Linq;

namespace SICpsAlgorithm
{
    public class ForwardChecking : Revolver
    {
        
        public override void Resolve(ref Image image)
        {
            var variable = ShortestDomain? GetFirstUnresolvedLowestDomainsCount(image): GetFirstUnresolved(image);

            if (variable != null)
            {
                if (image.Rows.Contains(variable))
                {
                    var indexRow = image.Rows.IndexOf(variable);
                    var domain = new Domain();
                    while (GetFirsMatchingRowDomain(image, indexRow, ref domain))
                    {
                        variable.Resolved = true;
                        variable.Fields = CopyDomainItem(domain.Fields);
                        //SetDomainsIncorrectForRowIndex(variable, indexRow, ref image);
                        SetColumnDomainsIncorrect(variable, indexRow, ref image);
                        Resolve(ref image);

                        if (!RowCheckConstraints(ref image, indexRow))
                        {
                            SetDomainsCorrectForRowIndex(variable, indexRow, ref image);
                            variable.Domains[variable.Domains.IndexOf(domain)].Incorrect = true;
                            variable.Resolved = false;
                            variable.Fields.ForEach(x => x.Value = false);
                            //SetColumnDomainsCorrect(variable, indexRow, ref image);
                        }
                        else
                        {
                            variable.Resolved = true;
                            break;
                        }
                    }
                    variable.Domains.ForEach(x => x.Incorrect = false);
                }
                else
                {
                    var indexColumn = image.Columns.IndexOf(variable);
                    var domain = new Domain();
                    while (GetFirsMatchingColumnDomain(image, indexColumn, ref domain))
                    {
                        variable.Resolved = true;
                        variable.Fields = CopyDomainItem(domain.Fields);
                        //SetDomainsIncorrectForColumnIndex(variable, indexColumn, ref image);
                        SetRowDomainsIncorrect(variable, indexColumn, ref image);
                        Resolve(ref image);

                        if (!ColumnCheckConstraints(ref image, indexColumn))
                        {
                            SetDomainsCorrectForColumnIndex(variable, indexColumn, ref image);
                            variable.Domains[variable.Domains.IndexOf(domain)].Incorrect = true;
                            variable.Resolved = false;
                            variable.Fields.ForEach(x => x.Value = false);
                            //SetRowDomainsCorrect(variable, indexColumn, ref image);
                        }
                        else
                        {
                            variable.Resolved = true;
                            break;
                        }
                    }
                    variable.Domains.ForEach(x => x.Incorrect = false);
                }

            }
        }

        private void SetRowDomainsIncorrect(Variable variable, int indexColumn, ref Image image)
        {
            var count = image.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                var row = image.Rows[i];
                if (row.Resolved)
                {
                    continue;
                }
                var domainsCount = row.Domains.Count;
                for (int j = 0; j < domainsCount; j++)
                {
                    var domain = row.Domains[j];
                    if (domain.Fields[indexColumn].Value != variable.Fields[i].Value)
                    {
                        domain.Incorrect = true;
                    }
                }
            }
        }

        private void SetColumnDomainsIncorrect(Variable variable, int indexRow, ref Image image)
        {
            var count = image.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                var column = image.Columns[i];
                if (column.Resolved)
                {
                    continue;
                }
                var domainsCount = column.Domains.Count;
                for (int j = 0; j < domainsCount; j++)
                {
                    var domain = column.Domains[j];
                    if (domain.Fields[indexRow].Value != variable.Fields[i].Value)
                    {
                        domain.Incorrect = true;
                    }
                }
            }
        }

        private void SetRowDomainsCorrect(Variable variable, int indexColumn, ref Image image)
        {
            foreach (var row in image.Rows)
            {
                if (row.Resolved)
                {
                    continue;
                }

                foreach (var domain in row.Domains)
                {
                    if (domain.Fields[indexColumn].Value != variable.Fields[image.Rows.IndexOf(row)].Value)
                    {
                        domain.Incorrect = false;
                    }
                }
            }
        }

        private void SetColumnDomainsCorrect(Variable variable, int indexRow, ref Image image)
        {
            foreach (var column in image.Columns)
            {
                if (column.Resolved)
                {
                    continue;
                }

                foreach (var domain in column.Domains)
                {
                    if (domain.Fields[indexRow].Value != variable.Fields[image.Columns.IndexOf(column)].Value)
                    {
                        domain.Incorrect = false;
                    }
                }
            }
        }

        //// v2
        private void SetDomainsIncorrectForRowIndex(Variable variable, int indexRow, ref Image image)
        {
            foreach (var column in image.Columns)
            {
                if (!column.Resolved)
                {
                    var columnIndex = image.Columns.IndexOf(column);

                    foreach (var domain in column.Domains)
                    {
                        if (domain.Fields[indexRow].Value != image.Rows[indexRow].Fields[columnIndex].Value)
                        {
                            domain.Incorrect = true;
                        }
                    }
                }
            }
        }

        private void SetDomainsIncorrectForColumnIndex(Variable variable, int indexColumn, ref Image image)
        {
            foreach (var row in image.Rows)
            {
                if (!row.Resolved)
                {
                    var columnIndex = image.Rows.IndexOf(row);

                    foreach (var domain in row.Domains)
                    {
                        if (domain.Fields[indexColumn].Value != image.Columns[indexColumn].Fields[columnIndex].Value)
                        {
                            domain.Incorrect = true;
                        }
                    }
                }
            }
        }

        private void SetDomainsCorrectForRowIndex(Variable variable, int indexRow, ref Image image)
        {
            foreach (var column in image.Columns)
            {
                if (!column.Resolved)
                {
                    foreach (var domain in column.Domains)
                    {
                        domain.Incorrect = false;
                    }
                }
            }
        }

        private void SetDomainsCorrectForColumnIndex(Variable variable, int indexColumn, ref Image image)
        {
            foreach (var row in image.Rows)
            {
                if (!row.Resolved)
                {
                    foreach (var domain in row.Domains)
                    {
                        domain.Incorrect = false;
                    }
                }
            }
        }

        private List<Field> CopyDomainItem(List<Field> domainField)
        {
            var newDomain = new List<Field>();
            foreach (Field t in domainField)
            {
                var field = new Field()
                {
                    Value = t.Value
                };

                newDomain.Add(field);
            }
            return newDomain;
        }

        private bool ColumnCheckConstraints(ref Image image, int index)
        {
            if (image.Columns.Any(x => !x.Resolved))
            {
                return false;
            }
            if (image.Columns[index].Fields.Sum(x => (x.Value) ? 1 : 0) != image.Columns[index].ColoredBlocks.Sum())
            {
                return false;
            }
            foreach (var columnField in image.Columns[index].Fields)
            {
                var fieldIndex = image.Columns[index].Fields.IndexOf(columnField);

                if (columnField.Value != image.Rows[fieldIndex].Fields[index].Value)
                {
                    return false;
                }
            }
            return true;
        }

        private bool RowCheckConstraints(ref Image image, int currentRow)
        {
            if (image.Rows.Any(x => !x.Resolved))
            {
                return false;
            }
            if (image.Rows[currentRow].Fields.Sum(x => (x.Value) ? 1 : 0) != image.Rows[currentRow].ColoredBlocks.Sum())
            {
                return false;
            }
            foreach (var rowField in image.Rows[currentRow].Fields)
            {
                var fieldIndex = image.Rows[currentRow].Fields.IndexOf(rowField);

                if (rowField.Value != image.Columns[fieldIndex].Fields[currentRow].Value)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ColumnDomainExists(Image image, int index)
        {
            foreach (var domain in image.Columns[index].Domains)
            {
                if (!domain.Incorrect)
                {
                    var isDifferent = false;

                    foreach (var domainField in domain.Fields)
                    {
                        var domainFieldIndex = domain.Fields.IndexOf(domainField);
                        var row = image.Rows[domainFieldIndex];

                        if (row.Resolved)
                        {
                            if (!domainField.Value == row.Fields[index].Value)
                            {
                                isDifferent = true;
                                break;
                            }
                        }
                    }
                    if (!isDifferent)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool RowDomainExists(Image image, int index)
        {
            foreach (var domain in image.Rows[index].Domains)
            {
                if (!domain.Incorrect)
                {
                    var isDifferent = false;
                    foreach (var domainField in domain.Fields)
                    {
                        var domainFieldIndex = domain.Fields.IndexOf(domainField);
                        var column = image.Columns[domainFieldIndex];

                        if (column.Resolved)
                        {
                            if (!domainField.Value == column.Fields[index].Value)
                            {
                                isDifferent = true;
                                break;
                            }
                        }
                    }
                    if (!isDifferent)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool GetFirsMatchingRowDomain(Image image, int index, ref Domain chosenDomain)
        {
            foreach (var domain in image.Rows[index].Domains)
            {
                if (!domain.Incorrect)
                {
                    var isDifferent = false;
                    for (var i = 0; i < image.Columns.Count; i++)
                    {
                        var column = image.Columns[i];
                        if (column.Resolved)
                        {
                            if (!column.Fields[index].Value == domain.Fields[i].Value)
                            {
                                isDifferent = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (!isDifferent)
                    {
                        chosenDomain = domain;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool GetFirsMatchingColumnDomain(Image image, int index, ref Domain chosenDomain)
        {
            foreach (var domain in image.Columns[index].Domains)
            {
                if (!domain.Incorrect)
                {
                    var isDifferent = false;
                    for (var i = 0; i < image.Rows.Count; i++)
                    {
                        var row = image.Rows[i];
                        if (row.Resolved)
                        {
                            if (!row.Fields[index].Value == domain.Fields[i].Value)
                            {
                                isDifferent = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (!isDifferent)
                    {
                        chosenDomain = domain;
                        return true;
                    }
                }
            }
            return false;
        }

        private Variable GetFirstUnresolved(Image image)
        {
            var maxIndex = (image.Rows.Count >= image.Columns.Count) ? image.Rows.Count : image.Columns.Count;

            for (int i = 0; i < maxIndex; i++)
            {
                if (i < image.Rows.Count && !image.Rows[i].Resolved)
                {
                    return image.Rows[i];
                }
                else if (i < image.Columns.Count && !image.Columns[i].Resolved)
                {
                    return image.Columns[i];
                }
            }

            return null;
        }

        private Variable GetFirstUnresolvedLowestDomainsCount(Image image)
        {
            var domains = image.Columns.Concat(image.Rows).ToList();
            var unresolvedDomains = domains.OrderBy(x => x.Domains.Count).Where(x => !x.Resolved);
            return unresolvedDomains.FirstOrDefault();
        }
    }
}