using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfCore
{
    [AddINotifyPropertyChangedInterface]
    internal class TestClass : INotifyPropertyChanged
    {
        public string Text { get; set; } = "Hell World";

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}