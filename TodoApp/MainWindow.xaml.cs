using System.Windows;
using WpfCore.TodoList.ViewModel;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new TodoListViewModel();
        }
    }
}