using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace OnStore.Models
{
    public class Product: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }


        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }


        private Brush _background;
        public Brush Background
        {
            get { return _background; }
            set
            {
                _background = value;
                OnPropertyChanged();
            }
        }

        
        public Product(string title, decimal price)
        {
            Title = title;
            Price = price;
            Background = null;
        }
        public Product(string title, decimal price, Brush background)
        {
            Title = title;
            Price = price;
            Background = background;

            if (Background is ImageBrush component)
                component.Stretch = Stretch.Uniform;
        }


        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public override string ToString() => Title;
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => ToString() == obj.ToString();
    }
}
