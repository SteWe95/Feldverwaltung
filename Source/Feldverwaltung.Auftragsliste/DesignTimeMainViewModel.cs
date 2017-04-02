using System.Collections.ObjectModel;

namespace Feldverwaltung.Auftragsliste
{
    class DesignTimeMainViewModel
    {
        public ObservableCollection<TaskItemModel> Tasks { get; set; }

        public DesignTimeMainViewModel()
        {
            InitializeTasks();
        }

        private void InitializeTasks()
        {
            Tasks = new ObservableCollection<TaskItemModel>();
            var task = new TaskItemModel();
            task.FieldNumber = 26;
            task.Job.Name = "Grubbern";
            task.Comment = "Scheibenegge";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 52;
            task.Job.Name = "ernten";
            task.FruitName = "Weizen";
            task.Comment = "Stroh ablegen";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 24;
            task.Job.Name = "saeen";
            task.FruitName = "Weizen";
            task.Comment = "Direktsaat";
            task.Employee = "Stefan";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 1;
            task.Job.Name = "drillen";
            task.FruitName = "Mais";
            task.Employee = "Mathias";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 6;
            task.Job.Name = "streuen";
            task.Fertilizer.Name = "Mist";
            task.Comment = "Kühe und Schweine";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.Job.Name = "transportieren";
            task.Comment = "Weizen bei Raiffeisen verkaufen";
            task.Done = false;
            Tasks.Add(task);
        }
    }
}
