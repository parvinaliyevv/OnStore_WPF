using System;
using System.Windows;
using System.Windows.Media;
using OnStore.Models;
using OnStore.Presenters;

namespace OnStore.Views
{
    public partial class ProductView : Window, IProductView
    {
        // Events
        public event EventHandler<RoutedEventArgs> SaveOperationEventHandler;
        public event EventHandler<RoutedEventArgs> SelectImageEventHandler;
        public event EventHandler<RoutedEventArgs> RandomColorEventHandler;


        //Properties
        public Product Product { get; set; }

        public string TitleContent { get; set; }
        public decimal PriceContent { get; set; }
        public Brush BackgroundContent { get; set; }


        public ProductView(Product product)
        {
            InitializeComponent();

            Product = product;
            TitleContent = Product.Title;
            PriceContent = Product.Price;

            new ProductPresenter(this);
            DataContext = this;
        }


        private void SaveOperation_ButtonClicked(object sender, RoutedEventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(TitleContent))
            {
                MessageBox.Show("The product title cannot be empty!", "Product Title Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (PriceContent <= 0)
            {
                MessageBox.Show("The price of a product cannot be less than or equal to zero!", "Product Price Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (BackgroundContent is null)
            {
                if (Product.Background is null) RandomColorEventHandler.Invoke(null, null);
                else BackgroundContent = Product.Background;
            }
            else if (Product.Background != null && ColorRadioButton.IsChecked == false)
            {
                BackgroundContent = Product.Background;
            }
            

            SaveOperationEventHandler.Invoke(sender, e);
            DialogResult = true;
        }

        private void SelectImage_RadioButtonClicked(object sender, RoutedEventArgs e) => SelectImageEventHandler.Invoke(sender, e);

        private void RandomColor_RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            RandomColorEventHandler.Invoke(sender, e);
            ColorRadioButton.Foreground = BackgroundContent;
        }

        private void CancelOperation_ButtonClicked(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
