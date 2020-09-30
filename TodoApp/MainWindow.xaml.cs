using System;
using System.Diagnostics;
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

        private void DataGrid_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            var context = (TodoListViewModel)DataContext;
            context.SelectedItem = null;
        }
    }
}