using System;
using System.Text;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        public DateTime DateOfBirth { get; set; }
        public BehaviorEnum Behavior { get; set; }
        public int Age { get; set; }
        public Letter Letter { get; set; }

        public Child(string Name, string Adress, DateTime DateOfBirth, int Age)
        {
            this.Name = Name;
            this.Adress = Adress;
            this.DateOfBirth = DateOfBirth;
            this.Age = Age;
        }

        public Child()
        {
            Letter = new Letter();
        }

        public string CreateLetter()
        {
            var sb = new StringBuilder();
            sb.Append("Dear Santa").Append(",\nI am ").
                Append(this.Name).Append("\nI am ").
                Append(this.Age).Append(" years old. I live at ").
                Append(this.Adress).Append(". I have been a very ").
                Append(this.Behavior).Append(" child this year.\nWhat I would like the most this Christmas is: ");
            for (int i = 0; i < this.Letter.Presents.Count; i++)
            {
                if (i != Letter.Presents.Count - 1)
                {
                    sb.Append(Letter.Presents[i].Name).Append(", ");
                }
                else
                {
                    sb.Append(Letter.Presents[i].Name);
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name).Append(" ").Append(Adress).Append(" ").Append(DateOfBirth).Append(" ").Append(Enum.GetName(typeof(BehaviorEnum), Behavior)).Append(" ").Append(Age).Append('\n');
            if (Letter != null)
            {
                sb.Append(Letter.ToString());
            }
            return sb.ToString();
        }
    }
}
