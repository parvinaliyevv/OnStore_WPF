using System;
using System.Windows;
using System.Collections.ObjectModel;
using OnStore.Models;

namespace OnStore.Views
{
    public interface IBasketView
    {
        // Events
        event EventHandler<RoutedEventArgs> BuyProductsEventHandler;
        event EventHandler<RoutedEventArgs> ClearBasketEventHandler;
        event EventHandler<RoutedEventArgs> RemoveProductEventHandler;


        // Observable Properties
        ObservableCollection<ProductBox> BasketProducts { get; set; }
    }
}
