using System;
using System.Windows;
using System.Collections.ObjectModel;
using OnStore.Models;
using System.Collections.Generic;

namespace OnStore.Views
{
    public interface IMainView
    {
        // Events
        event EventHandler<RoutedEventArgs> OpenBasketEventHandler;
        event EventHandler<RoutedEventArgs> AddProductEventHandler;
        event EventHandler<RoutedEventArgs> SearchProductEventHandler;
        event EventHandler<RoutedEventArgs> EditProductEventHandler;
        event EventHandler<RoutedEventArgs> AddToBasketEventHandler;


        // Observable Properties
        ObservableCollection<Product> Products { get; set; }

        ObservableCollection<ProductBox> BasketProducts { get; set; }

        string SearchProductContent { get; set; }
    }
}
