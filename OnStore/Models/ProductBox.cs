using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OnStore.Models
{
    public class ProductBox: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public Product Product { get; set; }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }


        public ProductBox(Product product)
        {
            Product = product;
            Count = 1;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public override string ToString() => Product.ToString();
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj)  => ToString() == obj.ToString();
    }
}
