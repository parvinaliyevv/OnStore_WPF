using System;
using System.Windows;
using System.Windows.Media;
using OnStore.Models;

namespace OnStore.Views
{
    public interface IProductView
    {
        // Events
        event EventHandler<RoutedEventArgs> SaveOperationEventHandler;
        event EventHandler<RoutedEventArgs> SelectImageEventHandler;
        event EventHandler<RoutedEventArgs> RandomColorEventHandler;


        // Properties
        Product Product { get; set; }

        string TitleContent { get; set; }
        decimal PriceContent { get; set; }
        Brush BackgroundContent { get; set; }
    }
}
