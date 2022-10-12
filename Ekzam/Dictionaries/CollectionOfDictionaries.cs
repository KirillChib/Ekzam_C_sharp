using System;
using System.Collections.Generic;

namespace Ekzam.Dictionaries
{
    public class CollectionOfDictionaries
    {
        private int IdOfDictonary { get; set; }
        public List<Dictionary> Dictionaries { get => _dictionaries; set => _dictionaries = value; }

        private Dictionary _temp;

        private List<Dictionary> _dictionaries;

        public CollectionOfDictionaries()
        {
            IdOfDictonary = 1;
            _dictionaries = new List<Dictionary>();
        }

        public void AddDictionary()
        {
            Console.WriteLine("Название словаря (например Англо-Русский словарь)");

            var tempStr = Console.ReadLine();

            foreach (var item in _dictionaries)
                if (item.Name.Equals(tempStr))
                    Console.WriteLine("Таой слоаварь уже есть");

            _temp = new Dictionary(tempStr);
            _temp.Id = IdOfDictonary;

            _dictionaries.Add(_temp);

            _temp.Clear();
        }
        public void ShowDictonaries()
        {
            if (_dictionaries.Count == 0)
            {
                Console.WriteLine("Пока нет словарей");

                return;
            }

            foreach(var item in _dictionaries)
                Console.WriteLine($"{item.Id}. {item.Name}");
        }
        
    }
}