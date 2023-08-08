using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speller.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Id + Name.Length + Age + (int)Name[0];
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}
