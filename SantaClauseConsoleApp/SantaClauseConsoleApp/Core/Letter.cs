using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        public DateTime Date;
        public string Name { get; set; }
        public List<Item> Presents = new List<Item>();

        public Letter(DateTime Date, string Name)
        {
            this.Date = Date;
            this.Name = Name;
        }

        public Letter()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Date).Append(" ").Append(Name).Append('\n');
            if (Presents.Count > 0)
            {
                foreach (var item in Presents)
                    sb.Append(item.ToString());
            }

            return sb.ToString();
        }
    }
}
