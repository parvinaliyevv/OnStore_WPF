using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnStore.Models;
using OnStore.Presenters;
using System;

namespace OnStore.Views
{
    public partial class BasketView : Window, IBasketView
    {
        // Events
        public event EventHandler<RoutedEventArgs> BuyProductsEventHandler;
        public event EventHandler<RoutedEventArgs> ClearBasketEventHandler;
        public event EventHandler<RoutedEventArgs> RemoveProductEventHandler;


        // Observable Properties
        public ObservableCollection<ProductBox> BasketProducts { get; set; }


        public BasketView(ObservableCollection<ProductBox> productBoxs)
        {
            InitializeComponent();

            BasketProducts = productBoxs;

            new BasketPresenter(this);
            DataContext = this;
        }


        private void BuyProducts_ButtonClicked(object sender, RoutedEventArgs e)
            { BuyProductsEventHandler.Invoke(sender, e); Close(); }
        private void ClearBasket_ButtonClicked(object sender, RoutedEventArgs e)
            => ClearBasketEventHandler.Invoke(sender, e);

        private void RemoveProduct_ButtonClicked(object sender, RoutedEventArgs e)
            => RemoveProductEventHandler.Invoke(sender, e);
    }
}
