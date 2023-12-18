using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo.Pages
{
    public partial class ProductPage : Page
    {
        List<Product> ProductList = new List<Product>();
        public ProductPage()
        {
            InitializeComponent();
            EmptyPanel.Visibility = Visibility.Hidden;
            PriceyRadioBttn.IsChecked = true;

            UpdateListView();

            var allManufacturers = DB.schoolEntities.Manufacturers.ToList();
            allManufacturers.Insert(0, new Manufacturer { Name = "Все производители" });
            ManufComboBox.ItemsSource = allManufacturers;

            #region PhotoDBUpload
            //string Path = @"C:\Users\.eski\Desktop\Товары школы\";
            //string Path1 = @"C:\Users\.eski\source\repos\demo\demo\Resources\no_photo.jpg";
            //foreach (var item in DB.schoolEntities.Products.ToList())
            //{
            //    if (item.MainImagePath == null)
            //    {
            //        item.PhotoProduct = File.ReadAllBytes(Path1);
            //        DB.schoolEntities.SaveChanges();
            //    }
            //    else if (item.MainImagePath != "")
            //    {
            //        item.PhotoProduct = File.ReadAllBytes(Path + item.MainImagePath);
            //        DB.schoolEntities.SaveChanges();
            //    }
            //}
            #endregion
        }

        private void UpdateListView()
        {
            var currentProducts = DB.schoolEntities.Products.ToList();

            if(ManufComboBox.SelectedIndex > 0)
                currentProducts = currentProducts.Where(p => p.Manufacturer == (ManufComboBox.SelectedItem as Manufacturer)).ToList();


            if(string.IsNullOrWhiteSpace(SearchTextBox.Text) == true)
                SearchTextBox.Text = "";
            else
                currentProducts = currentProducts.Where(u => u.Title.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                                                            u.Cost.ToString().Contains(SearchTextBox.Text.ToLower())).ToList();


            if(CheapRadioBttn.IsChecked == true) 
                currentProducts = currentProducts.OrderBy(p => p.Cost).ToList();
            else
                currentProducts = currentProducts.OrderByDescending(p => p.Cost).ToList();

            ListViewProducts.ItemsSource = currentProducts;


            AllItemsTextBlock.Text = DB.schoolEntities.Products.ToList().Count.ToString();
            FactItemsTextBlock.Text = currentProducts.Count.ToString();
            EmptyPanel.Visibility = ListViewProducts.HasItems ? Visibility.Hidden : Visibility.Visible;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void CheapRadioBttn_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListView();
        }

        private void PriceyRadioBttn_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListView();
        }

        private void DropFilters_Click(object sender, RoutedEventArgs e)
        {
            ManufComboBox.SelectedIndex = 0;
            SearchTextBox.Text = "";
            PriceyRadioBttn.IsChecked = true;
            UpdateListView();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateListView();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_EditProduct());
        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_EditProduct(ListViewProducts.SelectedItem as Product));
        }
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product CurrentProduct = (Product)ListViewProducts.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этот товар?", "Сообщение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (DB.schoolEntities.ProductSales.Where(c => c.Product.ID == CurrentProduct.ID).ToList().Count == 0)
                    {
                        if (DB.schoolEntities.AttachedProducts.Where(c => CurrentProduct.ID == c.MainProductID).ToList().Count == 0)
                        {
                            DB.schoolEntities.Products.Remove(CurrentProduct);
                            DB.schoolEntities.SaveChanges();
                            UpdateListView();
                        }
                        else
                        {
                            MessageBox.Show("У данного товара есть доп.товары.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данный товар находится в продажах.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка.");
            }
        }
    }
}
