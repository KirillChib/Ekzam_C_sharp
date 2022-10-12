using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekzam.Words
{
    public class Word
    {
        public string WordForTranslation { get; set; }
        public List<string> Translation { get; set; }
        public int Count { get => Translation.Count; }



        public Word(string word)
        {
            WordForTranslation = word;
        }

        public void AddTranslation(string translation)
        {
            Translation.Append(translation);
        }

        public void ShowTransation()
        {
            if (Count == 0)
            {
                Console.WriteLine("Пока нет перевода");

                return;
            }

            Translation.Sort();

            Console.WriteLine($"{WordForTranslation} ({Count} перевод(а)) - {String.Join(",", Translation)}");
        }

        public bool SearchTranslation(string translation)
        {
            foreach (var item in Translation)
            {
                if (item.Equals(translation))
                {
                    return true;
                }
                else
                    continue;
            }
            return false;
        }

        public void DelTranslation(string translation)
        {
            if (Count == 0)
            {
                Console.WriteLine("Пока нет перевода");

                return;
            }

            if (SearchTranslation(translation) && Count > 1)
                Translation.Remove(translation);
            else
                Console.WriteLine("Нет совпадений или это единственный перевод");
        }

        public void ReplaceTranslation(string oldTranslation, string newTranslation)
        {
            foreach (var item in Translation)
            {
                if (item.Equals(oldTranslation))
                {
                    var str = item.Replace(item, newTranslation);

                    Translation.Add(str);
                    Translation.Remove(item);

                    return;
                }
                
                    
            }
            Console.WriteLine("Нет совпадений");
        }
        public void Clear()
        {
            WordForTranslation = null;
            Translation.Clear();
        }
    }
}