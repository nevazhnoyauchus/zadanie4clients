using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ИтоговоеЗадание
{
    public partial class Service
    {
        public byte[] Image
        {
            get
            {
                var path = MainImagePath;
                if (File.Exists(path))
                {
                    return File.ReadAllBytes(path);
                }
                
                return null;
            }
        }
        public string NewDiscount
        {
            get 
            {
                if (Discount ==  0)
                {
                    return "";
                }
                return (Discount*100).ToString();
            }
        }
        public SolidColorBrush Color
        {
            get
            {
                if (Discount > 0)
                {
                    return new SolidColorBrush(Colors.Lime);
                }
                return new SolidColorBrush(Colors.White);
            }
        }
        public float DurationInMins
        {
            get
            {
                return DurationInSeconds / 60;
            }
        }
        public string NewCost
        {
            get
            {
                if (Discount>0)
                {
                    return ((double)Cost * (1 - Discount)).ToString();
                }
                return Cost.ToString();
            }
        }
        public double NewCostNum
        {
            get
            {
                if (Discount > 0)
                {
                    return (double)Cost * (1 - (double)Discount);
                }
                return (double)Cost;
            }
        }
        public TextDecorationCollection Decoration
        {
            get
            {
                if (Discount > 0)
                {
                    return TextDecorations.Strikethrough;
                }
                return null;
            }
        }
    }
}
