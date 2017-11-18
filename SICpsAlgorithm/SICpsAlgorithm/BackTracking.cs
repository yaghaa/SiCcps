using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace SICpsAlgorithm
{
    public class BackTracking : Revolver
    {
        public override void Resolve(ref Image image)
        {
            Counters.ReccurencyCounter++;
            var variable = ShortestDomain ? GetFirstUnresolvedLowestDomainsCount(image) : GetFirstUnresolved(image);

            if (variable != null)
            {
                if (image.Rows.Contains(variable))
                {
                    var indexRow = image.Rows.IndexOf(variable);
                    while (RowDomainExists(image, indexRow))
                    {
                        var domain = GetFirsMatchingRowDomain(image, indexRow);
                        var index = variable.Domains.IndexOf(domain);
                        variable.Resolved = true;
                        variable.Fields = CopyDomainItem(domain).Fields;
                        Resolve(ref image);

                        if (!RowCheckConstraints(ref image, indexRow))
                        {
                            variable.Domains[index].Incorrect = true;
                            variable.Resolved = false;
                            variable.Fields.ForEach(x => x.Value = false);
                            Counters.ReturnsCounter++;
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
                    while (ColumnDomainExists(image, indexColumn))
                    {
                        var domain = GetFirsMatchingColumnDomain(image, indexColumn);

                        variable.Resolved = true;
                        variable.Fields = CopyDomainItem(domain).Fields;
                        Resolve(ref image);

                        if (!ColumnCheckConstraints(ref image, indexColumn))
                        {
                            Counters.ReturnsCounter++;
                            variable.Domains[variable.Domains.IndexOf(domain)].Incorrect = true;
                            variable.Resolved = false;
                            variable.Fields.ForEach(x => x.Value = false);
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
            return new Domain() { Fields = newDomain };
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

        private Domain GetFirsMatchingRowDomain(Image image, int index)
        {
            foreach (var domain in image.Rows[index].Domains)
            {
                if (!domain.Incorrect)
                {
                    var isDifferent = false;
                    foreach (var column in image.Columns)
                    {
                        if (column.Resolved)
                        {
                            if (!column.Fields[index].Value == domain.Fields[image.Columns.IndexOf(column)].Value)
                            {
                                isDifferent = true;
                            }
                        }
                    }
                    if (!isDifferent)
                    {
                        return domain;
                    }
                }
            }
            return null;
        }

        private Domain GetFirsMatchingColumnDomain(Image image, int index)
        {
            foreach (var domain in image.Columns[index].Domains)
            {
                if (!domain.Incorrect)
                {
                    var isDifferent = false;
                    foreach (var row in image.Rows)
                    {
                        if (row.Resolved)
                        {
                            if (!row.Fields[index].Value == domain.Fields[image.Rows.IndexOf(row)].Value)
                            {
                                isDifferent = true;
                            }
                        }
                    }
                    if (!isDifferent)
                    {
                        return domain;
                    }
                }
            }
            return null;
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