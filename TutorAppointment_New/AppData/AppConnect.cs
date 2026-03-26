using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New.AppData
{
    internal class AppConnect
    {
        // Инициализация при объявлении
        public static TutorAppointmentEntities model01 = new TutorAppointmentEntities();
    }
}