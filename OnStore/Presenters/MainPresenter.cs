using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using OnStore.DB;
using OnStore.Models;
using OnStore.Views;

namespace OnStore.Presenters
{
    public class MainPresenter
    {
        private readonly Database _database;
        private readonly IMainView _view;


        public MainPresenter(IMainView view)
        {
            _database = new Database();
            _view = view;

            _view.OpenBasketEventHandler += OpenBasket;
            _view.AddProductEventHandler += AddProduct;
            _view.SearchProductEventHandler += SearchProduct;
            _view.EditProductEventHandler += EditProduct;
            _view.AddToBasketEventHandler += AddToBasket;

            _view.Products = new ObservableCollection<Product>(_database.Products);
        }

        
        private void OpenBasket(object sender, RoutedEventArgs e)
        {
            var basketDialog = new BasketView(_view.BasketProducts);

            basketDialog.ShowDialog();
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            var productDialog = new ProductView(new Product(string.Empty, decimal.Zero));
            productDialog.Title = "New Product";

            if (productDialog.ShowDialog() == true)
            {
                Product product = productDialog.Product;

                if (_view.Products.Contains(product))
                {
                    foreach (var item in _view.Products)
                    {
                        if (item.Equals(product))
                        {
                            _view.Products.Remove(item);
                            _database.Products.Remove(item);

                            _view.Products.Add(product);
                            _database.Products.Add(product);

                            break;
                        }
                    }
                }
                else
                {
                    _view.Products.Add(product);
                    _database.Products.Add(product);
                }
            }
        }

        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SearchProductContent) && _view.Products.Count == _database.Products.Count) return;
            
            _view.Products.Clear();

            var upperCaseVariant = _view.SearchProductContent.ToUpper();

            foreach (var item in _database.Products)
                if (item.Title.ToUpper().Contains(upperCaseVariant)) _view.Products.Add(item);
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            if (sender is Button component)
            {
                var productName = (((component.Parent as FrameworkElement).Parent as StackPanel).Children[2] as TextBlock).Text;
                Product product = null;

                foreach (var item in _view.Products)
                    if (item.Equals(productName)) product = item;

                var productDialog = new ProductView(product);
                productDialog.Title = "Product Edit";

                productDialog.ShowDialog();
            }
        }

        private void AddToBasket(object sender, RoutedEventArgs e)
        {
            if (sender is Button component)
            {
                var productName = (((component.Parent as FrameworkElement).Parent as StackPanel).Children[2] as TextBlock).Text;
                ProductBox productBox = null;

                foreach (var item in _view.Products)
                    if (item.Equals(productName)) { productBox = new ProductBox(item); break; }

                if (_view.BasketProducts.Contains(productBox))
                    _view.BasketProducts[_view.BasketProducts.IndexOf(productBox)].Count++;
                else 
                    _view.BasketProducts.Add(productBox);
            }
        }
    }
}
