using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorAppointment_New
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void students_Click(object sender, EventArgs e)
        {
            LoginStudents regstudents = new LoginStudents();
            regstudents.ShowDialog();

        }

        private void tutors_Click(object sender, EventArgs e)
        {
            LoginTutors regtutors = new LoginTutors();
            regtutors.ShowDialog();

        }

        
    }
}
