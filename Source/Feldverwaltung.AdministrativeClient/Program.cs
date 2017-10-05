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
                Console.Clear();
                Console.WriteLine("Select Command");
                Console.WriteLine("a) Create static Values");
                Console.WriteLine("b) Create field");
                Console.WriteLine("c) Create task");
                Console.WriteLine("d) Create many fields");
                Console.WriteLine("e) Create many tasks");
                Console.WriteLine("f) ");
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
                        CreateNewField();
                        break;
                    case 'c':
                        CreateNewTask();
                        break;
                    case 'd':
                        //CreateManyFields();
                        break;
                    case 'e':
                        //CreateManyTasks();
                        break;
                    case 'f':
                        break;
                    default:
                        break;
                }
            } while (key.KeyChar != 'q');
        }

        private static void CreateStaticValues()
        {
            var fruits = new List<Fruit>();
            fruits.Add(new Fruit() { FruitName = "Sonnenblumen" });
            fruits.Add(new Fruit() { FruitName = "Sojabohnen" });
            fruits.Add(new Fruit() { FruitName = "Raps" });
            fruits.Add(new Fruit() { FruitName = "Mais" });
            fruits.Add(new Fruit() { FruitName = "Gerste" });
            fruits.Add(new Fruit() { FruitName = "Weizen" });
            fruits.Add(new Fruit() { FruitName = "Oelrettich" });
            fruits.Add(new Fruit() { FruitName = "Gras" });
            fruits.Add(new Fruit() { FruitName = "Kartoffeln" });
            fruits.Add(new Fruit() { FruitName = "Zuckerrüben" });
            fruits.Add(new Fruit() { FruitName = "Stroh" });
            fruits.Add(new Fruit() { FruitName = "" });
            SaveListInDatabase(fruits);

            var growthStates = new List<Growth>();
            growthStates.Add(new Growth() { GrowthState = "Gesaeet" });
            growthStates.Add(new Growth() { GrowthState = "Gegrubbert" });
            growthStates.Add(new Growth() { GrowthState = "Gepfluegt" });
            growthStates.Add(new Growth() { GrowthState = "Erntereif" });
            growthStates.Add(new Growth() { GrowthState = "Geerntet" });
            SaveListInDatabase(growthStates);

            var fertilizerLevels = new List<Fertilizer>();
            fertilizerLevels.Add(new Fertilizer() { FertilizerLevel = "Stufe0" });
            fertilizerLevels.Add(new Fertilizer() { FertilizerLevel = "Stufe1" });
            fertilizerLevels.Add(new Fertilizer() { FertilizerLevel = "Stufe2" });
            fertilizerLevels.Add(new Fertilizer() { FertilizerLevel = "Stufe3" });
            SaveListInDatabase(fertilizerLevels);

            var ploughedStates = new List<Ploughed>();
            ploughedStates.Add(new Ploughed("MussGepfluegtWerden"));
            ploughedStates.Add(new Ploughed("Gepfluegt1"));
            ploughedStates.Add(new Ploughed("Gepfluegt2"));
            ploughedStates.Add(new Ploughed("Gepfluegt3"));
            SaveListInDatabase(ploughedStates);

            var fertilizers = new List<Fertilizers>();
            fertilizers.Add(new Fertilizers() { Name = "Kunstduenger" });
            fertilizers.Add(new Fertilizers() { Name = "Guelle" });
            fertilizers.Add(new Fertilizers() { Name = "Mist" });
            SaveListInDatabase(fertilizers);

            var jobs = new List<Job>();
            jobs.Add(new Job() { Name = "drillen" });
            jobs.Add(new Job() { Name = "saeen" });
            jobs.Add(new Job() { Name = "duengen" });
            jobs.Add(new Job() { Name = "pfluegen" });
            jobs.Add(new Job() { Name = "grubbern" });
            jobs.Add(new Job() { Name = "streuen" });
            jobs.Add(new Job() { Name = "fahren" });
            jobs.Add(new Job() { Name = "transportieren" });
            jobs.Add(new Job() { Name = "abfahren" });
            jobs.Add(new Job() { Name = "ernten" });
            jobs.Add(new Job() { Name = "maehen" });
            jobs.Add(new Job() { Name = "sammeln" });
            jobs.Add(new Job() { Name = "schwaden" });
            jobs.Add(new Job() { Name = "zettern" });
            jobs.Add(new Job() { Name = "pressen" });
            SaveListInDatabase(jobs);

            var positions = new List<Position>();
            positions.Add(new Position("Employee"));
            positions.Add(new Position("Disponent"));
            positions.Add(new Position("Admin"));
            SaveListInDatabase(positions);
        }



        /*

        private static void CreateManyTasks()
        {
            throw new NotImplementedException();
        }

        private static void CreateManyFields()
        {
            throw new NotImplementedException();
        }
        */
        private static void CreateNewTask()
        {
            var tasks = LoadTableFromDatabase<Domain.Task>();
            Console.WriteLine("Offene Aufträge");
            foreach (var task in tasks)
            {
                if (!task.Done)
                {
                    Console.WriteLine(task.ToString());
                }
            }

            Field[] fields = LoadTableFromDatabase<Field>();
            fields.OrderBy(_ => _.Number);
            foreach (var field in fields)
            {
                Console.WriteLine(field.ToString());
            }
            var fieldNumber = int.Parse(GetUserInput("Feldnummer:"));

            Fruit[] fruits = LoadTableFromDatabase<Fruit>();
            WriteListToConsole<Fruit>(fruits, "Frucht");
            var fruitNumber = int.Parse(GetUserInput("Neue Frucht:"));


            Job[] jobs = LoadTableFromDatabase<Job>();
            WriteListToConsole<Job>(jobs, "Aufgabe");
            var jobNumber = int.Parse(GetUserInput("Aufgabe:"));

            var comment = GetUserInput("Auftragskommentar:");

            Domain.Task newTask = new Domain.Task(fieldNumber, jobs[jobNumber], fruits[fruitNumber], comment);

            Store store = new Store();
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
            Console.Clear();
            var fields = LoadTableFromDatabase<Field>();
            fields.OrderBy(_ => _.Number);
            foreach (var field in fields)
            {
                Console.WriteLine(field.ToString());
            }

            var number = int.Parse(GetUserInput("Feldnummer:"));

            Fruit[] fruits = LoadTableFromDatabase<Fruit>();
            WriteListToConsole<Fruit>(fruits, "Frucht");
            var fruitNumber = int.Parse(GetUserInput("Aktuelle Frucht:"));

            Growth[] growthStates = LoadTableFromDatabase<Growth>();
            WriteListToConsole<Growth>(growthStates, "Wachstumsstufen");
            var growthStateNumber = int.Parse(GetUserInput("Aktuelles Wachstum:"));

            var size = double.Parse(GetUserInput("Feldgröße:"));

            Fertilizer[] fertilizerLevels = LoadTableFromDatabase<Fertilizer>();
            WriteListToConsole<Fertilizer>(fertilizerLevels, "Düngestufe");
            var fertilizerLevelNumber = int.Parse(GetUserInput("Aktuelle Düngestufe:"));

            Ploughed[] ploughedStates = LoadTableFromDatabase<Ploughed>();
            WriteListToConsole<Ploughed>(ploughedStates, "Pflugstatus");
            var ploughedStateNumber = int.Parse(GetUserInput("Gepflügt"));

            Field newField = new Field(number, growthStates[growthStateNumber], size, fertilizerLevels[fertilizerLevelNumber], ploughedStates[ploughedStateNumber], fruits[fruitNumber]);

            Store store = new Store();
            using (StoreSession session = store.GetStoreSession())
            {
                session.BeginTransaction();
                session.Save(newField);
                session.CommitTransaction();
                session.Close();
            }
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

        private static T[] LoadTableFromDatabase<T>()
        {
            Store store = new Store();
            using (StoreSession session = store.GetStoreSession())
            {
                return session.LoadAll<T>().ToArray();
            }

        }

        private static void WriteListToConsole<T>(object[] objectArray, string query)
        {

            T[] arr = objectArray as T[];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Nummer: " + i + " " + query + ": " + arr[i].ToString());
            }
        }

        private static string GetUserInput(string query)
        {
            Console.WriteLine(query);
            return Console.ReadLine();
        }
    }
}
