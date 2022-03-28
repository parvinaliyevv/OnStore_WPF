using System.Collections.Generic;
using System.Windows.Media;
using OnStore.Models;

namespace OnStore.DB
{
    public class Database
    {
        public List<Product> Products { get; set; }


        public Database()
        {
            var cocaCola = new ImageSourceConverter().ConvertFromString(@"https://cdn-icons-png.flaticon.com/512/1149/1149810.png") as ImageSource;
            var chips = new ImageSourceConverter().ConvertFromString(@"https://cdn-icons-png.flaticon.com/512/305/305385.png") as ImageSource;
            var chocolate = new ImageSourceConverter().ConvertFromString(@"https://cdn-icons-png.flaticon.com/512/2234/2234851.png") as ImageSource;
            var sprite = new ImageSourceConverter().ConvertFromString(@"https://cdn-icons-png.flaticon.com/512/793/793176.png") as ImageSource;

            Products = new List<Product>()
            {
                new Product("Coca-Cola", 1M, new ImageBrush(cocaCola)),
                new Product("Chips", 2M, new ImageBrush(chips)),
                new Product("Chocolate", 0.70M, new ImageBrush(chocolate)),
                new Product("Sprite", 1M, new ImageBrush(sprite)),
            };
        }
    }
}
