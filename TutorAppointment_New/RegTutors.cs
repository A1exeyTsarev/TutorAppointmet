using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TutorAppointment_New.AppData;
namespace TutorAppointment_New
{
    public partial class RegTutors : Form
    {
        public RegTutors()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();

            // Сбор данных из формы в переменные
            string fio = Fio.Text.Trim();
            string login = Login.Text.Trim();
            string password = Password.Text.Trim();
            string repeatPassword = RepeatPassword.Text.Trim();
            string email = Email.Text.Trim();
            string phone = Phone.Text.Trim();
            string rating = Raiting.Text.Trim();
            string info = Info.Text.Trim();

            // Проверка заполнения обязательных полей
            if (string.IsNullOrEmpty(fio) ||
                string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(repeatPassword))
            {
                message.Append("Не все обязательные поля заполнены!\n");
            }

            // Проверка совпадения паролей
            if (password != repeatPassword)
            {
                message.Append("Пароли не совпадают!\n");
            }

            // Проверка уникальности логина, email и телефона
            try
            {
                if (AppData.AppConnect.model01.tutor.Any(x => x.login == login))
                {
                    message.Append("Логин уже занят!\n");
                }

                if (!string.IsNullOrEmpty(email) &&
                    AppData.AppConnect.model01.tutor.Any(x => x.mail == email))
                {
                    message.Append("Email уже используется!\n");
                }

                if (!string.IsNullOrEmpty(phone) &&
                    AppData.AppConnect.model01.tutor.Any(x => x.phone == phone))
                {
                    message.Append("Номер телефона уже используется!\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке данных: " + ex.Message, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если есть ошибки - показываем сообщение и прерываем регистрацию
            if (message.Length > 0)
            {
                MessageBox.Show(message.ToString(), "Предупреждение",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создание нового преподавателя
            try
            {
                tutor newTutor = new tutor()
                {
                    login = login,
                    password = password,
                    fio = fio,
                    phone = string.IsNullOrEmpty(phone) ? null : phone,
                    mail = string.IsNullOrEmpty(email) ? null : email,
                    raiting = string.IsNullOrEmpty(rating) ? null : rating,
                    info = string.IsNullOrEmpty(info) ? null : info,
                    role_id = 2 // role_id = 2 для преподавателя
                };

                AppData.AppConnect.model01.tutor.Add(newTutor);
                AppData.AppConnect.model01.SaveChanges();

                // Получаем ID созданного преподавателя
                int tutorId = newTutor.tutor_id;

                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Открываем форму TutorAccount с передачей ID
                TutorAccount tutorAccount = new TutorAccount(tutorId);
                tutorAccount.Show();

                this.Close(); // Закрываем форму регистрации
            }
            catch (Exception ex)
            {
                string errorMessage = "Ошибка при сохранении в базу данных: " + ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nВнутренняя ошибка: " + ex.InnerException.Message;
                }
                MessageBox.Show(errorMessage, "Ошибка базы данных",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для очистки полей формы
        private void ClearForm()
        {
            Fio.Text = "";
            Login.Text = "";
            Password.Text = "";
            RepeatPassword.Text = "";
            Email.Text = "";
            Phone.Text = "";
            Raiting.Text = "";
            Info.Text = "";
        }

        

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}