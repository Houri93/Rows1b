using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rows1b.Generator;
public sealed class Row
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string Company { get; set; }

    public override string ToString()
    {
        return $"{Id}\t{Name}\t{DateOfBirth.ToString("yyyy/MM/dd")}\t{City}\t{Street}\t{State}\t{ZipCode}\t{Company}";
    }
}
