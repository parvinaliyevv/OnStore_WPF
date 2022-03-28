using System.Windows;
using System.Windows.Controls;
using OnStore.DB;
using OnStore.Models;
using OnStore.Views;

namespace OnStore.Presenters
{
    public class BasketPresenter
    {
        private readonly Database _database;
        private readonly IBasketView _view;


        public BasketPresenter(IBasketView view)
        {
            _database = new Database();
            _view = view;

            _view.BuyProductsEventHandler += BuyProducts;
            _view.ClearBasketEventHandler += ClearBasket;
            _view.RemoveProductEventHandler += RemoveProduct;
        }


        private void BuyProducts(object sender, RoutedEventArgs e)
        {
            decimal money = default;

            foreach (var item in _view.BasketProducts)
                money += item.Product.Price * item.Count;

            MessageBox.Show($"The final price came out: {money}", "Successful purchase!", MessageBoxButton.OK, MessageBoxImage.Information);
            _view.BasketProducts.Clear();
        }

        private void ClearBasket(object sender, RoutedEventArgs e)
        {
            _view.BasketProducts.Clear();
        }

        private void RemoveProduct(object sender, RoutedEventArgs e)
        {
            if (sender is Button component)
            {
                var productName = (((component.Parent as FrameworkElement).Parent as StackPanel).Children[3] as TextBlock).Text;
                ProductBox productBox = null;

                foreach (var item in _view.BasketProducts)
                    if (item.Equals(productName)) { _view.BasketProducts.Remove(item); break; }
            }
        }
    }
}
