using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИтоговоеЗадание
{
    public partial class Client
    {
        public string FIO
        {
            get { return $"{FirstName} {LastName} {Patronymic}"; }
        }
    }
}
