using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feldverwaltung.Storage;
using Feldverwaltung.Domain;
using System.Collections;

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
                Console.WriteLine("a) Create static Values");
                Console.WriteLine("b) Create field");
                Console.WriteLine("c) Create task");
                Console.WriteLine("d) Create many fields");
                Console.WriteLine("e) Create many tasks");
                Console.WriteLine("f) Add Fruits");
                Console.WriteLine("q) Quit");
                Console.WriteLine();
                key = default(ConsoleKeyInfo);
                key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'a':
                        CreateStaticValues();
                        break;
                    case 'b':
                        //CreateNewField();
                        break;
                    case 'c':
                        //CreateNewTask();
                        break;
                    case 'd':
                        //CreateManyFields();
                        break;
                    case 'e':
                        //CreateManyTasks();
                        break;
                    case 'f':
                        //AddFruits();
                        break;
                    default:
                        break;
                }
            } while (key.KeyChar != 'q');
        }

        private static void CreateStaticValues()
        {
            var fruits = new List<Fruit>();
            fruits.Add(new Fruit("Sonnenblumen"));
            fruits.Add(new Fruit("Sojabohnen"));
            fruits.Add(new Fruit("Raps"));
            fruits.Add(new Fruit("Mais"));
            fruits.Add(new Fruit("Gerste"));
            fruits.Add(new Fruit("Weizen"));
            fruits.Add(new Fruit("Oelrettich"));
            fruits.Add(new Fruit("Gras"));
            fruits.Add(new Fruit("Kartoffeln"));
            fruits.Add(new Fruit("Zuckerrüben"));
            fruits.Add(new Fruit("Stroh"));
            SaveListInDatabase(fruits);

            var growthStates = new List<Growth>();
            growthStates.Add(new Growth("Gesaeet"));
            growthStates.Add(new Growth("Gegrubert"));
            growthStates.Add(new Growth("Gepfluegt"));
            growthStates.Add(new Growth("Erntereif"));
            growthStates.Add(new Growth("Geerntet"));
            SaveListInDatabase(growthStates);

            var fertilizerLevels = new List<Fertilizer>();
            fertilizerLevels.Add(new Fertilizer("Stufe0"));
            fertilizerLevels.Add(new Fertilizer("Stufe1"));
            fertilizerLevels.Add(new Fertilizer("Stufe2"));
            fertilizerLevels.Add(new Fertilizer("Stufe3"));
            SaveListInDatabase(fertilizerLevels);

            var ploughedStates = new List<Ploughed>();
            ploughedStates.Add(new Ploughed("MussGepfluegtWerden"));
            ploughedStates.Add(new Ploughed("Gepfluegt1"));
            ploughedStates.Add(new Ploughed("Gepfluegt2"));
            ploughedStates.Add(new Ploughed("Gepfluegt3"));
            SaveListInDatabase(ploughedStates);

            var fertilizers = new List<Fertilizers>();
            fertilizers.Add(new Fertilizers("Kunstdünger"));
            fertilizers.Add(new Fertilizers("Guelle"));
            fertilizers.Add(new Fertilizers("Mist"));
            SaveListInDatabase(fertilizers);

            var jobs = new List<Job>();
            jobs.Add(new Job("drillen"));
            jobs.Add(new Job("saeen"));
            jobs.Add(new Job("duengen"));
            jobs.Add(new Job("Pfluegen"));
            jobs.Add(new Job("Grubbern"));
            jobs.Add(new Job("streuen"));
            jobs.Add(new Job("fahren"));
            jobs.Add(new Job("transportieren"));
            jobs.Add(new Job("abfahren"));
            jobs.Add(new Job("ernten"));
            jobs.Add(new Job("maehen"));
            jobs.Add(new Job("sammeln"));
            jobs.Add(new Job("schwaden"));
            jobs.Add(new Job("zettern"));
            jobs.Add(new Job("pressen"));
            SaveListInDatabase(jobs);

            var positions = new List<Position>();
            positions.Add(new Position("Employee"));
            positions.Add(new Position("Disponent"));
            positions.Add(new Position("Admin"));
            SaveListInDatabase(positions);
        }

        private static void SaveListInDatabase(object collection)
        {
            Store store = new Store();
            using (StoreSession session = store.GetStoreSession())
            {
                session.BeginTransaction();
                IList objectList = collection as IList;
                foreach (var item in objectList)
                {
                    session.Save(item);
                }
                session.CommitTransaction();
            }
        }

        /*private static void AddFruits()
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
                Console.WriteLine("Nummer: " + i + " Frucht: " + fruits[i].ToString());
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
        }*/
    }
}
