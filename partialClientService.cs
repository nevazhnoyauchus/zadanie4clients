using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИтоговоеЗадание
{
    partial class ClientService
    {
        public TimeSpan TimeDifference
        {
            get
            {
                var a = DateTime.Now;
                var b = StartTime;
                var c = b - a;
                return c;
            }
        }
        public string TimeUntilString
        {
            get 
            {
                int hours = TimeDifference.Hours;
                int minutes = TimeDifference.Minutes;

                if (StartTime >= DateTime.Now)
                {
                    return $"{hours} часа {minutes} минут осталось";
                }
                else
                {
                    return $"{-hours} часа {-minutes} минут прошло";
                }
            }
        }
        public string TimeColor
        {
            get
            {
                if (TimeDifference.Hours < 1 && TimeDifference.Hours >= 0)
                {
                    return "Red";
                }
                
                return "Black";
            }
        }
    }
}
