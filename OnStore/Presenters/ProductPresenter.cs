using System.IO;
using System.Windows;
using System.Windows.Media;
using OnStore.DB;
using OnStore.Views;

namespace OnStore.Presenters
{
    public class ProductPresenter
    {
        private readonly Database _database;
        private readonly IProductView _view;

        public ProductPresenter(IProductView view)
        {
            _database = new Database();
            _view = view;

            _view.SaveOperationEventHandler += SaveOperation;
            _view.SelectImageEventHandler += SelectImage;
            _view.RandomColorEventHandler += RandomColor; 
        }

        private void SaveOperation(object sender, RoutedEventArgs e)
        {
            _view.Product.Title = _view.TitleContent;
            _view.Product.Price = _view.PriceContent;
            _view.Product.Background = _view.BackgroundContent;
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.Filter = "PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg|JPG Files(*.jpg)|*.jpg";
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.FilterIndex = 1;

            if (fileDialog.ShowDialog() == true)
                _view.BackgroundContent = new ImageBrush(new ImageSourceConverter().ConvertFrom(File.ReadAllBytes(fileDialog.FileName)) as ImageSource);
        }

        private void RandomColor(object sender, RoutedEventArgs e)
        {
            var random = new System.Random();
            _view.BackgroundContent = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256)));
        }
    }
}
