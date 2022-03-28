using System;
using System.Windows;
using System.Collections.ObjectModel;
using OnStore.Models;
using OnStore.Presenters;

namespace OnStore.Views
{
    public partial class MainView : Window, IMainView
    {
        //Events
        public event EventHandler<RoutedEventArgs> OpenBasketEventHandler;
        public event EventHandler<RoutedEventArgs> AddProductEventHandler;
        public event EventHandler<RoutedEventArgs> SearchProductEventHandler;
        public event EventHandler<RoutedEventArgs> EditProductEventHandler;
        public event EventHandler<RoutedEventArgs> AddToBasketEventHandler;


        // Observable Properties
        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<ProductBox> BasketProducts { get; set; }

        public string SearchProductContent
        {
            get { return (string)GetValue(SearchProductContentProperty); }
            set { SetValue(SearchProductContentProperty, value); }
        }
        public static readonly DependencyProperty SearchProductContentProperty =
            DependencyProperty.Register("SearchProductContent", typeof(string), typeof(MainView));


        public MainView()
        {
            InitializeComponent();

            BasketProducts = new ObservableCollection<ProductBox>();
            
            new MainPresenter(this);
            DataContext = this;
        }


        private void OpenBasket_MenuItemClicked(object sender, RoutedEventArgs e)
            => OpenBasketEventHandler.Invoke(sender, e);

        private void AddProduct_MenuItemClicked(object sender, RoutedEventArgs e)
            => AddProductEventHandler.Invoke(sender, e);

        private void SearchProduct_ButtonClicked(object sender, RoutedEventArgs e)
            => SearchProductEventHandler.Invoke(sender, e);

        private void EditProduct_ButtonClicked(object sender, RoutedEventArgs e) 
            => EditProductEventHandler.Invoke(sender, e);

        private void AddToBasket_ButtonClicked(object sender, RoutedEventArgs e)
            => AddToBasketEventHandler.Invoke(sender, e);
    }
}
