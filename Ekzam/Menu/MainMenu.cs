using Ekzam.Dictionaries;
using System;

namespace Ekzam.Menu
{
    public class MainMenu
    {
        private SubMenu subMenu;

        public MainMenu()
        {
            subMenu = new SubMenu();
        }

        public void Mainmenu(CollectionOfDictionaries dictionary)
        {
            bool success;
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("1.Показать словари");
                Console.WriteLine("2.Добавить словарь");
                Console.WriteLine();
                Console.WriteLine("0.Выход");

                do
                {
                    var tempStr = Console.ReadLine();

                    success = int.TryParse(tempStr, out choice);
                } while (!success);

                switch (choice)
                {
                    case 1:

                        dictionary.ShowDictonaries();

                        break;

                    case 2:

                        dictionary.AddDictionary();

                        Console.WriteLine("Выберите словарь");

                        do
                        {
                            var tempStr = Console.ReadLine();

                            success = int.TryParse(tempStr, out choice);
                        } while (!success);

                        foreach (var item in dictionary.Dictionaries)
                        {
                            if (choice == item.Id)
                                subMenu.Sub(item);
                        }

                        break;
                }
            } while (choice != 0);
        }
    }
}