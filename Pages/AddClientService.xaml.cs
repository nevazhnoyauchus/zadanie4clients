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
    /// Логика взаимодействия для AddClientService.xaml
    /// </summary>
    public partial class AddClientService : Page
    {
        Service service;
        public AddClientService(Service srv)
        {
            InitializeComponent();

            service = srv;

            CBClient.ItemsSource = DB.Data.Clients.ToList();
            CBClient.SelectedValuePath = "ID";
            CBClient.DisplayMemberPath = "FIO";
            CBClient.SelectedIndex = 0;

            txtServiceDuration.Text = $"Длительность: {service.DurationInMins.ToString()} минут";
            txtServiceTitle.Text = service.Title;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DateStart.SelectedDate != null && TimeStart.Text != "")
            {
                try
                {
                    ClientService cs = new ClientService();
                    cs.ServiceID = service.ID;
                    cs.ClientID = (int)CBClient.SelectedValue;
                    cs.Comment = Comment.Text;

                    string a = DateStart.SelectedDate.Value.ToShortDateString() + " " + TimeStart.Text;
                    var datetime = DateTime.Parse(a);

                    cs.StartTime = datetime;

                    DB.Data.ClientServices.Add(cs);
                    DB.Data.SaveChanges();
                    NavigationService.Navigate(new ListPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Проверьте вводимые данные!");
                }

            }
        }
    }
}
