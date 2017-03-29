using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Feldverwaltung.Auftragsliste
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel viewModel;
        public MainView()
        {
            InitializeComponent();
        }

        public MainView(MainViewModel viewModel) : this()
        {
            this.viewModel = viewModel;
            this.DataContext = viewModel;
        }

        public void Start()
        {
            this.ShowDialog();
        }
    }

}
