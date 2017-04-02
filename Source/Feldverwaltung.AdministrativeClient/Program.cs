using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feldverwaltung.Storage;
using Feldverwaltung.Domain;
using Feldverwaltung.Enums;

namespace Feldverwaltung.AdministrativeClient
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Select Command");
                Console.WriteLine("a) Create field");
                Console.WriteLine("b) Create task");
                Console.WriteLine("c) Create many fields");
                Console.WriteLine("d) Create many tasks");
                Console.WriteLine("e) Add Fruits");
                Console.WriteLine("q) Quit");
                Console.WriteLine();
                key = default(ConsoleKeyInfo);
                key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'a':
                        CreateNewField();
                        break;
                    case 'b':
                        CreateNewTask();
                        break;
                    case 'c':
                        CreateManyFields();
                        break;
                    case 'd':
                        CreateManyTasks();
                        break;
                    case 'e':
                        AddFruits();
                        break;
                    default:
                        break;
                }
            } while (key.KeyChar != 'q');
        }

        private static void AddFruits()
        {
            Store store = new Store();
            IList<Fruit> fruits = new List<Fruit>();
            using (StoreSession session = store.GetStoreSession())
            {
                fruits = session.LoadAll<Fruit>();
            }
            foreach (var fruit in fruits)
            {
                fruit.ToString();
            }

            var fruitName = GetUserInput("Fruitname:");

            Fruit newFruit = new Fruit(fruitName);

            using (StoreSession session = store.GetStoreSession())
            {
                session.BeginTransaction();
                session.Save(newFruit);
                session.CommitTransaction();
                session.Close();
            }
        }

        private static void CreateManyTasks()
        {
            throw new NotImplementedException();
        }

        private static void CreateManyFields()
        {
            throw new NotImplementedException();
        }

        private static void CreateNewTask()
        {
            Store store = new Store();
            IList<Domain.Task> tasks = new List<Domain.Task>();
            using (StoreSession session = store.GetStoreSession())
            {
                tasks = session.LoadAll<Domain.Task>();
            }
            foreach (var task in tasks)
            {
                task.ToString();
            }

            var fieldNumber = int.Parse(GetUserInput("Feldnummer:"));
            Fruit[] fruits;
            using (StoreSession session = store.GetStoreSession())
            {
                fruits = session.LoadAll<Fruit>().ToArray();
            }
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine("Nummer: " + i +  " Frucht: " + fruits[i].ToString());
            }
            var fruitNumber = int.Parse(GetUserInput("Neue Frucht:"));
            //TODO: Auflistung Jobnames
            var jobName = (JobName)int.Parse(GetUserInput("Aufgabe:"));
            var comment = GetUserInput("Auftragskommentar:");

            Domain.Task newTask = new Domain.Task(fieldNumber, jobName, fruits[fruitNumber], comment);

            using (StoreSession session = store.GetStoreSession())
            {
                session.BeginTransaction();
                session.Save(newTask);
                session.CommitTransaction();
                session.Close();
            }
        }

        private static void CreateNewField()
        {
            Store store = new Store();
            List<Field> fields = new List<Field>();
            using (StoreSession session = store.GetStoreSession())
            {
                session.LoadAll<Field>();
            }
            fields.OrderBy(_ => _.Number);
            foreach (var field in fields)
            {
                field.ToString();
            }

            var number = int.Parse(GetUserInput("Feldnummer:"));
            Fruit[] fruits;
            using (StoreSession session = store.GetStoreSession())
            {
                fruits = session.LoadAll<Fruit>().ToArray();
            }
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine("Nummer: " + i + " Frucht: " + fruits[i].ToString());
            }
            var fruitNumber = int.Parse(GetUserInput("Neue Frucht:"));
            //TODO: Auflistung der Zustände
            var growthState = (GrowthState)int.Parse(GetUserInput("Aktuelles Wachstum:"));
            var size = double.Parse(GetUserInput("Feldgröße:"));
            //TODO: Auflistung der Düngestufen
            var fertilizerLevel = (FertilizerLevel)int.Parse(GetUserInput("Aktuelle Düngestufe:"));
            //TODO: Auflistung gepflügt
            var ploughed = (Ploughed)int.Parse(GetUserInput("Gepflügt"));

            Field newField = new Field(number, growthState, size, fertilizerLevel, ploughed, fruits[fruitNumber]);

            using (StoreSession session = store.GetStoreSession())
            {
                session.BeginTransaction();
                session.Save(newField);
                session.CommitTransaction();
                session.Close();
            }
        }

        private static string GetUserInput(string query)
        {
            Console.WriteLine(query);
            return Console.ReadLine();
        }
    }
}
