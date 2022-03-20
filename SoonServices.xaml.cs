using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ИтоговоеЗадание
{
    /// <summary>
    /// Логика взаимодействия для SoonServices.xaml
    /// </summary>
    public partial class SoonServices : Window
    {
        public void UpdateList()
        {
            DateTime today = DateTime.Now.Date;
            DateTime tomorrow = DateTime.Now.Date.AddDays(1);

            LVServices.ItemsSource = DB.Data.ClientServices.ToList().Where(e => e.StartTime >= today && e.StartTime <= tomorrow);
        }
        public SoonServices()
        {
            InitializeComponent();

            UpdateList();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
