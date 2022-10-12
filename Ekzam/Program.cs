using Ekzam.Dictionaries;
using Ekzam.Helper;
using Ekzam.Menu;

namespace Ekzam
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           

            var collection = new CollectionOfDictionaries();
            var menu = new MainMenu();
            var xmlHelper = new XmlSerializationHelper();

            //xmlHelper.Serializing(collection);

            //collection = xmlHelper.Deserializing<CollectionOfDictionaries>(collection);

            menu.Mainmenu(collection);

            //xmlHelper.Serializing(collection);
        }
    }
}