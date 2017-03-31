using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace Feldverwaltung.Auftragsliste
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        private MainView view;
        public ObservableCollection<TaskItemModel> Tasks { get; set; }

        public MainViewModel(Controller controller) : base(controller)
        {
            Tasks = new ObservableCollection<TaskItemModel>();
        }

        internal void Start()
        {
            view = new MainView(this);
            LoadTasks();
            view.Start();
        }

        private void LoadTasks()
        {
            var tasks = controller.LoadTasks();
            foreach (var task in tasks)
            {
                var taskItem = new TaskItemModel(task);
                Tasks.Add(taskItem);
            }
        }

        public void StarTask()
        {

        }
    }
}