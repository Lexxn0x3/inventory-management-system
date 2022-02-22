using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    internal class Article
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Prize { get; set; }
        public string ArtNr { get; set; }

        public Article(string name, int count, double prize, string ArtNr)
        {
            this.Name = name;
            this.Count = count;
            this.Prize = prize;
            this.ArtNr = ArtNr;
        }
    }
}
