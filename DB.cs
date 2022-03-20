using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ИтоговоеЗадание
{
    public static class DB
    {
        public static Entities Data = new Entities();
        public static bool Auth = false;
        public static Visibility CheckAuth
        {
            get
            {
                if (Auth)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
    }
}
