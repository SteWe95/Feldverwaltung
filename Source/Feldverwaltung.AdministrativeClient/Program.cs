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
                    default:
                        break;
                }
            } while (key.KeyChar != 'q');
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
            List<Domain.Task> tasks = new List<Domain.Task>();
            using (StoreSession session = store.GetStoreSession())
            {
                session.LoadAll<Domain.Task>();
            }
            foreach (var task in tasks)
            {
                task.ToString();
            }

            var fieldNumber = int.Parse(GetUserInput("Feldnummer:"));
            //TODO: Auflistung der Früchte
            var fruit = (Fruit)int.Parse(GetUserInput("Neue Frucht:"));
            //TODO: Auflistung Jobnames
            var jobName = (JobName)int.Parse(GetUserInput("Aufgabe:"));
            var comment = GetUserInput("Auftragskommentar:");

            Domain.Task newTask = new Domain.Task(fieldNumber,jobName, fruit, comment);

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
            //TODO: Auflistung der Früchte
            var fruit = (Fruit)int.Parse(GetUserInput("Aktuelle Frucht:"));
            //TODO: Auflistung der Zustände
            var growthState = (GrowthState)int.Parse(GetUserInput("Aktuelles Wachstum:"));
            var size = double.Parse(GetUserInput("Feldgröße:"));
            //TODO: Auflistung der Düngestufen
            var fertilizerLevel = (FertilizerLevel)int.Parse(GetUserInput("Aktuelle Düngestufe:"));
            //TODO: Auflistung gepflügt
            var ploughed = (Ploughed)int.Parse(GetUserInput("Gepflügt"));

            Field newField = new Field(number,growthState,size,fertilizerLevel, ploughed, fruit);

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
