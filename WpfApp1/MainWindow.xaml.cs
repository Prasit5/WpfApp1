using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> billItems = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();
            billDataGrid.ItemsSource = billItems;
        }

        private void AddToBill(Product product)
        {
            // Check if the item already exists in the bill
            var existingItem = billItems.FirstOrDefault(item => item.Name == product.Name && item.Category == product.Category);
            if (existingItem != null)
            {
                // If it exists, increase the quantity
                existingItem.Quantity++;
            }
            else
            {
                // If not, add a new item
                product.Quantity = 1;
                billItems.Add(product);
            }

            // Refresh the DataGrid
            billDataGrid.Items.Refresh();
            UpdateInvoice();
        }


        private void beverageComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                string itemName = selectedItem.Content.ToString();
                string category = "Beverage";
                double price = GetPrice(itemName, category);
                AddToBill(new Product(itemName, category, price));

                // Clear the selected item in the ComboBox
                comboBox.SelectedItem = null;
            }
        }

        private void appetizerComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                string itemName = selectedItem.Content.ToString();
                string category = "Appetizer";
                double price = GetPrice(itemName, category);
                AddToBill(new Product(itemName, category, price));

                // Clear the selected item in the ComboBox
                comboBox.SelectedItem = null;
            }
        }

        private void mainCourseComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                string itemName = selectedItem.Content.ToString();
                string category = "Main Course";
                double price = GetPrice(itemName, category);
                AddToBill(new Product(itemName, category, price));

                // Clear the selected item in the ComboBox
                comboBox.SelectedItem = null;
            }
        }

        private void dessertComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                string itemName = selectedItem.Content.ToString();
                string category = "Dessert";
                double price = GetPrice(itemName, category);
                AddToBill(new Product(itemName, category, price));

                // Clear the selected item in the ComboBox
                comboBox.SelectedItem = null;
            }
        }

        private double GetPrice(string itemName, string category)
        {
            foreach (Product product in Inventory.GetAll())
            {
                if (product.Name == itemName && product.Category == category)
                {
                    return product.Price;
                }
            }
            return 0.0;
        }
        private void UpdateInvoice()
        {
            double subtotal = 0;
            foreach (var item in billItems)
            {
                subtotal += item.Price * item.Quantity;
            }

            double tax = subtotal * 0.13; // 13% tax
            double total = subtotal + tax;

            subtotalTextBox.Text = subtotal.ToString("C");
            taxTextBox.Text = tax.ToString("C");
            totalTextBox.Text = total.ToString("C");
        }
        private void RemoveSelectedItem()
        {
            var selectedProduct = billDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                billItems.Remove(selectedProduct);
            }
            UpdateInvoice();
        }

      

        private void Button_RemoveSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            RemoveSelectedItem();
        }

        private void ClearBill()
        {
            billItems.Clear();

            // Clear invoice TextBoxes
            subtotalTextBox.Text = "";
            taxTextBox.Text = "";
            totalTextBox.Text = "";
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearBill();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Specify the URL you want to navigate to
            string url = "https://www.centennialcollege.ca/";

            // Open the URL in the default browser
            Process.Start(new ProcessStartInfo("explorer", url));
        }




        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

    }
}