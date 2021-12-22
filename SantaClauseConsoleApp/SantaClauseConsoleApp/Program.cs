using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static List<Child> children = new List<Child>();
        static void Main(string[] args)
        {
            //Uncomment the function to see the result
            DataSeed(); //function for implementing 3 childs
            //Question1();
            //Question2();
            //Question3();
            //Question4();
            //Question5();
            //Question6();
        }
        static void DataSeed()
        {
            //Child one
            DateTime birthdayOfFirstChild = new DateTime(2000, 8, 1);
            Child c1 = new Child("Rares", "Iasi", birthdayOfFirstChild, 21);

            Item i1 = new Item { Name = "masina", Id = 1 };
            Item i2 = new Item { Name = "tank", Id = 2 };

            DateTime date1 = new DateTime(2021, 12, 20);
            Letter l1 = new Letter(date1, c1.Name);
            l1.Presents.Add(i1);
            l1.Presents.Add(i2);
            c1.Behavior = BehaviorEnum.Good;
            c1.Letter = l1;

            children.Add(c1);

            //Child 2
            DateTime birthdayOfSecondChild = new DateTime(2000, 10, 27);
            Child c2 = new Child("Andrei", "Cluj", birthdayOfSecondChild, 21);

            Item i3 = new Item { Name = "pistol", Id = 3 };
            Item i4 = new Item { Name = "masina", Id = 1 };

            DateTime date2 = new DateTime(2021, 12, 21);
            Letter l2 = new Letter(date2, c2.Name);
            l2.Presents.Add(i3);
            l2.Presents.Add(i4);
            c2.Behavior = BehaviorEnum.Bad;
            c2.Letter = l2;

            children.Add(c2);

            DateTime birthdayOfThirdChild = new DateTime(2000, 8, 3);
            Child c3 = new Child("Alexandra", "Iasi", birthdayOfThirdChild, 21);

            Item item5 = new Item { Name = "papusa", Id = 4 };
            Item item6 = new Item { Name = "machiaje", Id = 5 };

            DateTime date3 = new DateTime(2021, 12, 22);
            Letter l3 = new Letter(date3, c3.Name);
            l3.Presents.Add(item5);
            l3.Presents.Add(item6);
            c3.Behavior = BehaviorEnum.Good;
            c3.Letter = l3;

            children.Add(c3);
        }
        static void Question1()
        {

            foreach (var child in children)
                Console.WriteLine(child);

        }

        static void Question2()
        {
            //used Regex for trying to find the pattern
            string file1 = File.ReadAllText("LetterForChildOne.txt");
            string file2 = File.ReadAllText("LetterForChildTwo.txt");
            string file3 = File.ReadAllText("LetterForChildThree.txt");
            List<Child> kids = new List<Child>();
            List<string> files = new List<string>();
            files.Add(file1);
            files.Add(file2);
            files.Add(file3);
            Regex name = new Regex(@"(?!Dear Santa,\nI am )[A-Z][a-z]+\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex age = new Regex(@"(?!I am )\d+(?!years old.)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex city = new Regex(@"(?!I live at )[A-Z][a-z]+\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex comp = new Regex(@"(?! I have been a very ) (Good|Bad) (?! child this year\n)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex pres = new Regex(@"(?!What I would like the most this Christmas is:\n)\w+, \w+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (var f in files)
            {
                var child = new Child();
                MatchCollection forName = name.Matches(f);
                child.Name = forName[0].Value.Trim();
                MatchCollection forAge = age.Matches(f);
                child.Age = Convert.ToInt32(forAge[0].Value);
                MatchCollection forCity = city.Matches(f);
                child.Adress = forCity[0].Value.Trim('.');
                MatchCollection forBehav = comp.Matches(f);
                child.Behavior = (BehaviorEnum)Enum.Parse(typeof(BehaviorEnum), forBehav[0].Value, true);
                MatchCollection forPresents = pres.Matches(f);
                var cadouri = forPresents[0].Value.Split(", ");
                var items = new List<Item>();
                foreach (var c in cadouri)
                {
                    items.Add(new Item
                    {
                        Name = c,
                    });
                }
                child.Letter.Presents.AddRange(items);

                Console.WriteLine(child.Name);

            }
        }

        static void Question3()
        {
            for (int i = 0; i < children.Count; i++)
            {
                string text = children[i].CreateLetter();
                File.WriteAllText("Kid" + i + ".txt", text);
            }
        }

        static void Question4()
        {
            Dictionary<string, int> ToyFactory =
    new Dictionary<string, int>();
            foreach (var kid in children)
            {
                foreach (var item in kid.Letter.Presents)
                {
                    if (ToyFactory.ContainsKey(item.Name))
                    {
                        ToyFactory[item.Name]++;
                    }
                    else
                    {
                        ToyFactory.Add(item.Name, 1);
                    }
                }
            }

            var myList = ToyFactory.ToList();
            myList.Sort((x, y) => y.Value.CompareTo(x.Value));
            foreach (var item in myList)
                Console.WriteLine("Toy: {0}, Quantity: {1}", item.Key, item.Value);
        }

        static void Question5()
        {
            /*
              We could've implemented Singleton if the output from question 4 was in a file, because we write every data in the same file.
              Firstly, we create the file and next time we want to write in it, we just return the Handler to the file and it is overwriten.
              In this case the resource is the same - File Handler.
            */
        }

        static void Question6()
        {
            var city = new List<string>();
            foreach (var kid in children)
            {
                if (!city.Any(s => s.Contains(kid.Adress)))
                    city.Add(kid.Adress);

            }
            foreach (var c in city)
            {
                Console.WriteLine(c);
            }
        }
    }
}
