using Business;
using Entity;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            CustomerBusiness customer = new CustomerBusiness();
            dgCustomers.ItemsSource = customer.GetCustomer();

        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {

            Customer newCustomer = new Customer
            {
                name = txtName.Text,
                address = txtAddress.Text,
                phone = txtPhone.Text,
                active = true
            };

            CustomerBusiness customerBusiness = new CustomerBusiness();
            customerBusiness.InsertCustomer(newCustomer);

            Button_Click(sender, e);
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNameBorrar.Text;

            CustomerBusiness customerBusiness = new CustomerBusiness();
            customerBusiness.DeleteCustomer(name);

            Button_Click(sender, e);
        }

    }
}