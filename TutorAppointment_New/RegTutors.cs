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
        // Ограничения на количество символов
        private const int MAX_FIO_LENGTH = 50;
        private const int MAX_LOGIN_LENGTH = 15;
        private const int MAX_PASSWORD_LENGTH = 15;
        private const int MAX_EMAIL_LENGTH = 50;
        private const int MAX_PHONE_LENGTH = 20;
        private const int MAX_RATING_LENGTH = 10;
        private const int MAX_INFO_LENGTH = 200;

        private const int MIN_FIO_LENGTH = 5;
        private const int MIN_LOGIN_LENGTH = 3;
        private const int MIN_PASSWORD_LENGTH = 4;

        public RegTutors()
        {
            InitializeComponent();

            // Устанавливаем максимальную длину для полей ввода
            Fio.MaxLength = MAX_FIO_LENGTH;
            Login.MaxLength = MAX_LOGIN_LENGTH;
            Password.MaxLength = MAX_PASSWORD_LENGTH;
            RepeatPassword.MaxLength = MAX_PASSWORD_LENGTH;
            Email.MaxLength = MAX_EMAIL_LENGTH;
            Phone.MaxLength = MAX_PHONE_LENGTH;
            Raiting.MaxLength = MAX_RATING_LENGTH;
            Info.MaxLength = MAX_INFO_LENGTH;
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

            // ============ ПРОВЕРКИ ============

            // Проверка заполнения обязательных полей
            if (string.IsNullOrEmpty(fio))
            {
                message.Append("Введите ФИО!\n");
            }
            if (string.IsNullOrEmpty(login))
            {
                message.Append("Введите логин!\n");
            }
            if (string.IsNullOrEmpty(password))
            {
                message.Append("Введите пароль!\n");
            }
            if (string.IsNullOrEmpty(repeatPassword))
            {
                message.Append("Повторите пароль!\n");
            }

            // Проверка ФИО (минимальная длина)
            if (!string.IsNullOrEmpty(fio) && fio.Length < MIN_FIO_LENGTH)
            {
                message.Append($"ФИО должно содержать минимум {MIN_FIO_LENGTH} символов! (Сейчас: {fio.Length})\n");
            }

            // Проверка ФИО (максимальная длина)
            if (fio.Length > MAX_FIO_LENGTH)
            {
                message.Append($"ФИО не может превышать {MAX_FIO_LENGTH} символов! (Сейчас: {fio.Length})\n");
            }

            // Проверка логина (минимальная длина)
            if (!string.IsNullOrEmpty(login) && login.Length < MIN_LOGIN_LENGTH)
            {
                message.Append($"Логин должен содержать минимум {MIN_LOGIN_LENGTH} символа! (Сейчас: {login.Length})\n");
            }

            // Проверка логина (максимальная длина)
            if (login.Length > MAX_LOGIN_LENGTH)
            {
                message.Append($"Логин не может превышать {MAX_LOGIN_LENGTH} символов! (Сейчас: {login.Length})\n");
            }

            // Проверка логина (только буквы и цифры)
            if (!string.IsNullOrEmpty(login) && !IsValidLogin(login))
            {
                message.Append("Логин может содержать только буквы латинского алфавита и цифры!\n");
            }

            // Проверка пароля (минимальная длина)
            if (!string.IsNullOrEmpty(password) && password.Length < MIN_PASSWORD_LENGTH)
            {
                message.Append($"Пароль должен содержать минимум {MIN_PASSWORD_LENGTH} символа! (Сейчас: {password.Length})\n");
            }

            // Проверка пароля (максимальная длина)
            if (password.Length > MAX_PASSWORD_LENGTH)
            {
                message.Append($"Пароль не может превышать {MAX_PASSWORD_LENGTH} символов! (Сейчас: {password.Length})\n");
            }

            // Проверка пароля (не должен содержать пробелы)
            if (!string.IsNullOrEmpty(password) && password.Contains(" "))
            {
                message.Append("Пароль не должен содержать пробелы!\n");
            }

            // Проверка совпадения паролей
            if (password != repeatPassword)
            {
                message.Append("Пароли не совпадают!\n");
            }

            // Проверка email (если заполнен)
            if (!string.IsNullOrEmpty(email))
            {
                if (email.Length > MAX_EMAIL_LENGTH)
                {
                    message.Append($"Email не может превышать {MAX_EMAIL_LENGTH} символов! (Сейчас: {email.Length})\n");
                }
                if (!IsValidEmail(email))
                {
                    message.Append("Введите корректный email (пример: user@example.com)!\n");
                }
            }

            // Проверка телефона (если заполнен)
            if (!string.IsNullOrEmpty(phone))
            {
                if (phone.Length > MAX_PHONE_LENGTH)
                {
                    message.Append($"Телефон не может превышать {MAX_PHONE_LENGTH} символов! (Сейчас: {phone.Length})\n");
                }
                if (!IsValidPhone(phone))
                {
                    message.Append("Телефон должен содержать только цифры, пробелы, знак + и дефис!\n");
                }
            }

            // Проверка рейтинга (если заполнен)
            if (!string.IsNullOrEmpty(rating))
            {
                if (rating.Length > MAX_RATING_LENGTH)
                {
                    message.Append($"Рейтинг не может превышать {MAX_RATING_LENGTH} символов! (Сейчас: {rating.Length})\n");
                }
                if (!IsValidRating(rating))
                {
                    message.Append("Рейтинг должен быть числом от 1 до 5 (например: 4.5)!\n");
                }
            }

            // Проверка информации (если заполнена)
            if (!string.IsNullOrEmpty(info) && info.Length > MAX_INFO_LENGTH)
            {
                message.Append($"Информация о себе не может превышать {MAX_INFO_LENGTH} символов! (Сейчас: {info.Length})\n");
            }

            // Проверка уникальности логина, email и телефона
            try
            {
                if (!string.IsNullOrEmpty(login) && AppData.AppConnect.model01.tutor.Any(x => x.login == login))
                {
                    message.Append("Логин уже занят! Выберите другой.\n");
                }

                if (!string.IsNullOrEmpty(email) &&
                    AppData.AppConnect.model01.tutor.Any(x => x.mail == email))
                {
                    message.Append("Email уже используется! Введите другой.\n");
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

        // Проверка валидности логина (только буквы и цифры)
        private bool IsValidLogin(string login)
        {
            foreach (char c in login)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        // Проверка валидности email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Проверка валидности телефона (цифры, пробелы, +, -, (, ))
        private bool IsValidPhone(string phone)
        {
            foreach (char c in phone)
            {
                if (!char.IsDigit(c) && c != '+' && c != ' ' && c != '-' && c != '(' && c != ')')
                {
                    return false;
                }
            }
            return true;
        }

        // Проверка валидности рейтинга (число от 1 до 5)
        private bool IsValidRating(string rating)
        {
            if (decimal.TryParse(rating, out decimal ratingValue))
            {
                return ratingValue >= 1 && ratingValue <= 5;
            }
            return false;
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

        // Обработчики для отображения количества символов (опционально)
        private void Login_TextChanged(object sender, EventArgs e)
        {
            int remaining = MAX_LOGIN_LENGTH - Login.Text.Length;
            // Если есть label для отображения, раскомментируйте:
            // labelLoginCounter.Text = $"Осталось: {remaining}";
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            int remaining = MAX_PASSWORD_LENGTH - Password.Text.Length;
            // Если есть label для отображения, раскомментируйте:
            // labelPasswordCounter.Text = $"Осталось: {remaining}";
        }
    }
}