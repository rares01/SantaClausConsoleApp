using System.Text;

namespace SantaClauseConsoleApp
{
    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }



        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name).Append("\n");
            return sb.ToString();
        }
    }
}
