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
    /// Логика взаимодействия для AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Page
    {
        public string image = "";
        
        public AddEditService()
        {
            InitializeComponent();
        }
        public AddEditService(Service srv)
        {
            InitializeComponent();
            image = srv.MainImagePath;
            if (srv.MainImagePath != "" || srv.MainImagePath != null)
            {
                img.Source = new BitmapImage(new Uri(srv.MainImagePath, UriKind.Relative));
            }

            txtName.Text = srv.Title;
            txtDiscount.Text = srv.Discount.ToString();
            txtPrice.Text = srv.Cost.ToString();
            txtDescription.Text = srv.Description;
            txtTime.Text = srv.DurationInSeconds.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int last_id = DB.Data.Services.OrderByDescending(s=>s.ID).FirstOrDefault().ID;
            var new_service = new Service();
            new_service.Title = txtName.Text;
            new_service.Discount = double.Parse(txtDiscount.Text);
            new_service.Cost = decimal.Parse(txtPrice.Text);
            new_service.Description = txtDescription.Text;
            new_service.DurationInSeconds = Int32.Parse(txtTime.Text);
            new_service.MainImagePath = image != "" ? image : "";
            new_service.ID = last_id + 1;
            DB.Data.Services.Add(new_service);
            DB.Data.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
