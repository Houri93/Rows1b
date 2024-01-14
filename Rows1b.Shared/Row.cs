using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rows1b.Shared;
public sealed class Row
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string State { get; set; }

    public override string ToString()
    {
        return $"{Id}\t{Name}\t{DateOfBirth:yyyy/MM/dd}\t{State}";
    }
}
