using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    public partial class Add_EditProduct : Page
    {
        Product Product = new Product();
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        bool IsAdded;
        bool wasDialogOpened;
        string defaultPath = $@"C:\Users\{Environment.UserName}\source\repos\demo\demo\Resources\no_photo.jpg";

        public Add_EditProduct(Product product = null)
        {
            InitializeComponent();
            DataContext = Product;
            if(product != null)
            {
                try
                {
                    ManufacturerComboBox.Items.Clear();
                    IsAdded = true;
                    Product = product;
                    DataContext = product;
                    ProductPhoto.DataContext = product.PhotoProduct;
                    ManufacturerComboBox.ItemsSource = DB.schoolEntities.Manufacturers.ToList();
                    StatusComboBox.SelectedIndex = product.IsActive ? 0 : 1;
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка.");
                }
            }
            else
            {
                try
                {
                    ProductPhoto.DataContext = File.ReadAllBytes(defaultPath);
                    ManufacturerComboBox.Items.Clear();
                    ManufacturerComboBox.ItemsSource = DB.schoolEntities.Manufacturers.ToList();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка.");
                }
            }
        }

        private void CostTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length != 1) return;
            if (Char.IsDigit(e.Text, 0)) return;
            if (e.Text[0] == 46) return;
            e.Handled = true;
        }

        private void CostTextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ManufacturerComboBox.ItemsSource = DB.schoolEntities.Manufacturers.ToList();
            if (wasDialogOpened)
            {
                if (OpenFileDialog.FileName == "")
                {
                    Product.PhotoProduct = File.ReadAllBytes(defaultPath);
                    Product.MainImagePath = defaultPath.Trim($@"C:\Users\{Environment.UserName}\source\repos\Srezik\Srezik\Resources\Photos\".ToCharArray());
                }
                else
                {
                    Product.PhotoProduct = File.ReadAllBytes(OpenFileDialog.FileName);
                    Product.MainImagePath = OpenFileDialog.FileName.Trim($@"C:\Users\{Environment.UserName}\source\repos\Srezik\Srezik\Resources\Photos\".ToCharArray());
                }
            }
            

            if (string.IsNullOrWhiteSpace(NameTextBox.Text) == true ||
                                string.IsNullOrWhiteSpace(CostTextBox.Text) == true ||
                                string.IsNullOrWhiteSpace(ManufacturerComboBox.Text) == true ||
                                string.IsNullOrWhiteSpace(StatusComboBox.Text) == true)
            {
                MessageBox.Show("Обязательные поля не заполнены.");
            }
            else if (CostTextBox.Text == Convert.ToString(0))
                MessageBox.Show("Цена не может быть равна 0.");
            else
            {
                if (StatusComboBox.SelectedIndex == 0)
                    Product.IsActive = true;
                else
                    Product.IsActive = false;

                switch (IsAdded)
                {
                    case false:
                        try
                        {
                            DB.schoolEntities.Products.Add(Product);
                            DB.schoolEntities.SaveChanges();
                            NavigationService.GoBack();
                            break;
                        }
                        catch { MessageBox.Show("Произошла ошибка."); break; }


                    case true:
                        try
                        {
                            DB.schoolEntities.SaveChanges();
                            NavigationService.GoBack();
                            break;
                        }
                        catch { MessageBox.Show("Произошла ошибка."); break; }

                }
            }
        }
        private void ProductPhoto_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                wasDialogOpened = true;
                OpenFileDialog.Filter = "Image| *.png;*.jpg";
                if (OpenFileDialog.ShowDialog() == true)
                {
                    ProductPhoto.DataContext = File.ReadAllBytes(OpenFileDialog.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка.");
            }
        }
    }
}
