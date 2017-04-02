using PropertyChanged;
using Feldverwaltung.Domain;

namespace Feldverwaltung.Auftragsliste
{
    [ImplementPropertyChanged]
    public class TaskItemModel
    {
        public int FieldNumber { get; set; }
        public Job Job { get; set; }
        public string FruitName { get; set; }
        public Fertilizers Fertilizer { get; set; }
        public string Comment { get; set; }
        public string Employee { get; set; }
        public bool Done { get; set; }
        public bool Active
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Employee))
                    return false;
                else
                    return true;
            }
        }

        public TaskItemModel(Domain.Task task)
        {
            FieldNumber = task.Field.Number;
            Job = task.TaskDescription.JobName;
            FruitName = task.TaskDescription.Fruit.FruitName;
            Fertilizer = task.TaskDescription.Fertilizer;
            Comment = task.TaskDescription.Comment;
            Employee = task.Employee;
            Done = task.Done;
        }

        public TaskItemModel()
        {
            FruitName = null;
            Fertilizer = null;
            Employee = " ";
        }
    }
}
