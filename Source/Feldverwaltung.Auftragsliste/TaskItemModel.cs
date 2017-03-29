using Feldverwaltung.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Feldverwaltung.Auftragsliste
{
    [ImplementPropertyChanged]
    public class TaskItemModel
    {
        public int FieldNumber { get; set; }
        public JobName JobName { get; set; }
        public Fruit FruitName { get; set; }
        public Fertilizers Fertilizer { get; set; }
        public string Comment { get; set; }
        public string Employee { get; set; }
        public bool Done { get; set; }
        public bool Active
        {
            get
            {
                if (string.IsNullOrEmpty(Employee) && Done == true)
                    return false;
                else
                    return true;
            }
        }

        public TaskItemModel(Domain.Task task)
        {
            FieldNumber = task.Field.Number;
            JobName = task.TaskDescription.JobName;
            FruitName = task.TaskDescription.Fruit;
            Fertilizer = task.TaskDescription.Fertilizer;
            Comment = task.TaskDescription.Comment;
            Employee = task.Employee;
            Done = task.Done;
        }

        public TaskItemModel()
        {

        }
    }
}
