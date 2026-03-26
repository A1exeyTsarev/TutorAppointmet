using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutorAppointment_New.AppData;
using TutorAppointment_New;


namespace TutorAppointment_New
{
    public partial class LoginStudents : Form
    {
        public LoginStudents()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // КНОПКА ВХОДА (Sign In)
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (AppData.AppConnect.model01 == null)
                {
                    AppData.AppConnect.model01 = new TutorAppointmentEntities();
                }

                // Проверяем подключение к БД
                if (!AppData.AppConnect.model01.Database.Exists())
                {
                    MessageBox.Show("База данных не найдена! Проверьте подключение.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var student = AppData.AppConnect.model01.student
                    .FirstOrDefault(x => x.login == login && x.password == password);

                if (student != null)
                {
                    MessageBox.Show($"Добро пожаловать, {student.fio}!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    StudentAccount sa = new StudentAccount(student.student_id);
                    sa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Показываем полную информацию об ошибке
                string errorMessage = $"Ошибка: {ex.Message}\n\n";

                if (ex.InnerException != null)
                {
                    errorMessage += $"Внутренняя ошибка: {ex.InnerException.Message}\n\n";

                    if (ex.InnerException.InnerException != null)
                    {
                        errorMessage += $"Детали: {ex.InnerException.InnerException.Message}";
                    }
                }

                MessageBox.Show(errorMessage, "Ошибка базы данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА РЕГИСТРАЦИИ
        private void buttonReg_Click_1(object sender, EventArgs e)
        {
            // Открываем форму регистрации для студентов
            RegStudents regStudents = new RegStudents();
            regStudents.ShowDialog();
        }

        // КНОПКА НАЗАД
        private void Back_Click_1(object sender, EventArgs e)
        {

            this.Close(); // Закрываем текущую форму
        }

        private void Login_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    }
}