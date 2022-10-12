using Ekzam.Words;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ekzam.Dictionaries
{
    public class Dictionary
    {
        
       
        private List<Word> Words { get; set; }

        private Word temp;

        private string Path { get => "Result.txt"; }
        private int Count { get => Words.Count; }
        public string Name { get; set; }
        public int Id { get; set; }


        public Dictionary(string name)
        {
            Name = name;
        }

        public bool SearchWord(string word)
        {
            foreach (var item in Words)
                if (item.WordForTranslation.Equals(word))
                    return true;

            return false;
        }

        public void AddWord()
        {
            Console.WriteLine("Введите слово");

            string word = Console.ReadLine();

            if (SearchWord(word))
            {
                System.Console.WriteLine("Такое слово уже есть");

                return;
            }
            else
            {
                temp = new Word(word);

                Console.WriteLine("Добавьте перевод");

                string translation = Console.ReadLine();

                temp.AddTranslation(translation);

                Words.Add(temp);

                temp.Clear();
            }
        }

        public void ReplaceWord(Word word, string newWord)
        {
            word.WordForTranslation.Replace(word.WordForTranslation, newWord);
        }

        public void DelWord()
        {
            if (Count == 0)
            {
                Console.WriteLine("Нет слов");

                return;
            }

            System.Console.WriteLine("Какое слово?");

            string word = Console.ReadLine();

            if (!SearchWord(word))
            {
                Console.WriteLine("Нет совпадений");
                return;
            }
            else
            {
                foreach (var item in Words)
                {
                    if (item.WordForTranslation.Equals(word))
                        Words.Remove(item);
                }
            }
        }

        public void ShowWords()
        {
            if (Count == 0)
            {
                Console.WriteLine("Нет слов");

                return;
            }

            Words.Sort();

            Console.WriteLine($"{Count} слов(а)");

            foreach (var item in Words)
                Console.WriteLine($"{item.WordForTranslation} - {String.Join(", ", item.Translation)}");
        }

        public void SaveWordAndTranslation(Word word)
        {
            string temp = $"{word.WordForTranslation} - {string.Join(",", word.Translation)}\n";
            File.AppendAllText(Path, temp);
        }

        public void SearchWordForOperation()
        {
            int choice;

            Console.Clear();

            Console.WriteLine("Какое слово возьмем?");

            string temp = Console.ReadLine();

            foreach (var item in Words)
            {
                if (item.WordForTranslation.Equals(temp))
                {
                    Console.WriteLine($"{item.WordForTranslation} ({item.Count} перевод(ов)) - {string.Join(",", item.Translation)} ");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("1.Изменить слово");
                        Console.WriteLine("2.Добавить перевод");
                        Console.WriteLine("3.Удалить перевод");
                        Console.WriteLine("4.Заменить перевод");
                        Console.WriteLine("5.Сохранить в файл");
                        Console.WriteLine("0.Назад");

                        var str = Console.ReadLine();
                        choice = int.Parse(str);

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();

                                Console.WriteLine("На какое слово поменять?");
                                var str1 = Console.ReadLine();

                                ReplaceWord(item, str);

                                break;

                            case 2:
                                Console.Clear();

                                Console.WriteLine("Что добавляем?");
                                var str2 = Console.ReadLine();

                                item.AddTranslation(str2);

                                break;

                            case 3:
                                Console.Clear();

                                Console.WriteLine("Какой перевод удалить?");
                                var str3 = Console.ReadLine();

                                item.DelTranslation(str3);

                                break;

                            case 4:
                                Console.Clear();

                                Console.WriteLine("Какой из переводов заменить?");
                                var str4 = Console.ReadLine();

                                Console.WriteLine("Заменить на что?");
                                var str5 = Console.ReadLine();

                                item.ReplaceTranslation(str4, str5);

                                break;

                            case 5:
                                Console.Clear();

                                SaveWordAndTranslation(item);
                                Console.WriteLine("Сохранено");

                                break;
                        }
                    } while (choice != 0);
                }
                else
                    Console.WriteLine("Нет совпадений");
            }
        }

        public void Clear()
        {
            Name = null;
            temp = null;
            Words.Clear();
        }
    }
}