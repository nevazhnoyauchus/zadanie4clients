using System;
using System.Collections.Generic;
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

namespace ИтоговоеЗадание.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            listItems.ItemsSource = DB.Data.Services.ToList();
        }
        public void GetData(string search = "")
        {
            var list = DB.Data.Services.ToList();

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                list = list.Where(m => m.Title.ToLower().Contains(search.ToLower())).ToList();

            }    

            switch (cmbSortPrice.SelectedIndex)
            {
                case 0: break;
                case 1: list = list.OrderBy(m => m.NewCostNum).ToList(); break;
                case 2: list = list.OrderByDescending(m => m.NewCostNum).ToList(); break;
            }

            listItems.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var srv = (Service)((Button)sender).DataContext;
            NavigationService.Navigate(new AddEditService(srv));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(tbSearch.Text);
        }
        

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(tbSearch.Text);
        }

        private void BtnClientService_Click(object sender, RoutedEventArgs e)
        {
            var srv = (Service)((Button)sender).DataContext;
            NavigationService.Navigate(new AddClientService(srv));
        }

        private void BtnSoonServices_Click(object sender, RoutedEventArgs e)
        {
            new SoonServices().Show();
        }
    }
}
