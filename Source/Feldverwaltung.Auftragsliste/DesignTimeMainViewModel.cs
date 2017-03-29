using Feldverwaltung.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            task.JobName = JobName.Grubbern;
            task.Comment = "Scheibenegge";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 52;
            task.JobName = JobName.ernten;
            task.FruitName = Fruit.Weizen;
            task.Comment = "Stroh ablegen";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 24;
            task.JobName = JobName.saeen;
            task.FruitName = Fruit.Weizen;
            task.Comment = "Direktsaat";
            task.Employee = "Stefan";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 1;
            task.JobName = JobName.drillen;
            task.FruitName = Fruit.Mais;
            task.Employee = "Mathias";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.FieldNumber = 6;
            task.JobName = JobName.streuen;
            task.Fertilizer = Fertilizers.Mist;
            task.Comment = "Kühe und Schweine";
            task.Done = false;
            Tasks.Add(task);

            task = new TaskItemModel();
            task.JobName = JobName.transportieren;
            task.Comment = "Weizen bei Raiffeisen verkaufen";
            task.Done = false;
            Tasks.Add(task);
        }
    }
}
