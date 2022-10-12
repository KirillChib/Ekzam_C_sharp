using Ekzam.Dictionaries;
using System;

namespace Ekzam.Menu
{
    public class SubMenu
    {
        public void Sub(Dictionary dictionary)
        {
            bool success;
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("1.Показать слова");
                Console.WriteLine("2.Работа со словом");
                Console.WriteLine("3.Добавить слово");
                Console.WriteLine("0.Назад");

                do
                {
                    var tempStr = Console.ReadLine();

                    success = int.TryParse(tempStr, out choice);
                } while (!success);

                switch (choice)
                {
                    case 1:

                        dictionary.ShowWords();

                        break;

                    case 2:

                        dictionary.SearchWordForOperation();

                        break;

                    case 3:

                        dictionary.AddWord();

                        break;
                }
            } while (choice != 0);
        }
    }
}