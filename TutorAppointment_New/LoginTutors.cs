using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutorAppointment_New;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class LoginTutors : Form
    {
        // Максимальная длина логина и пароля - 15 символов
        private const int MAX_LOGIN_LENGTH = 15;
        private const int MAX_PASSWORD_LENGTH = 15;
        private const int MIN_LOGIN_LENGTH = 3;
        private const int MIN_PASSWORD_LENGTH = 4;

        public LoginTutors()
        {
            InitializeComponent();

            // Устанавливаем максимальную длину для полей ввода (15 символов)
            Login.MaxLength = MAX_LOGIN_LENGTH;
            Password.MaxLength = MAX_PASSWORD_LENGTH;
        }

        private void LoginTutors_Load(object sender, EventArgs e)
        {

        }

        // КНОПКА ВХОДА (Sign In)
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей ввода
            string login = Login.Text.Trim();
            string password = Password.Text.Trim();

            // ПРОВЕРКА 1: Пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Login.Focus();
                return;
            }

            // ПРОВЕРКА 2: Минимальная длина логина
            if (login.Length < MIN_LOGIN_LENGTH)
            {
                MessageBox.Show($"Логин должен содержать минимум {MIN_LOGIN_LENGTH} символа!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Login.Focus();
                Login.SelectAll();
                return;
            }

            // ПРОВЕРКА 3: Максимальная длина логина (15 символов)
            if (login.Length > MAX_LOGIN_LENGTH)
            {
                MessageBox.Show($"Логин не может превышать {MAX_LOGIN_LENGTH} символов!\n" +
                    $"Текущая длина: {login.Length} символов.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Login.Focus();
                Login.SelectAll();
                return;
            }

            // ПРОВЕРКА 4: Минимальная длина пароля
            if (password.Length < MIN_PASSWORD_LENGTH)
            {
                MessageBox.Show($"Пароль должен содержать минимум {MIN_PASSWORD_LENGTH} символа!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password.Focus();
                Password.SelectAll();
                return;
            }

            // ПРОВЕРКА 5: Максимальная длина пароля (15 символов)
            if (password.Length > MAX_PASSWORD_LENGTH)
            {
                MessageBox.Show($"Пароль не может превышать {MAX_PASSWORD_LENGTH} символов!\n" +
                    $"Текущая длина: {password.Length} символов.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password.Focus();
                Password.SelectAll();
                return;
            }

            // ПРОВЕРКА 6: Логин не должен содержать специальные символы (только буквы и цифры)
            if (!IsValidLogin(login))
            {
                MessageBox.Show("Логин может содержать только буквы латинского алфавита и цифры!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Login.Focus();
                Login.SelectAll();
                return;
            }

            // ПРОВЕРКА 7: Пароль не должен содержать пробелы
            if (password.Contains(" "))
            {
                MessageBox.Show("Пароль не должен содержать пробелы!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password.Focus();
                Password.SelectAll();
                return;
            }

            try
            {
                // Ищем преподавателя в базе данных по логину и паролю
                var tutor = AppData.AppConnect.model01.tutor
                    .FirstOrDefault(x => x.login == login && x.password == password);

                if (tutor != null)
                {
                    // Проверяем роль пользователя
                    if (tutor.role_id == 1) // Предполагаем, что role_id = 1 для Admin
                    {
                        MessageBox.Show($"Добро пожаловать, администратор {tutor.fio}!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // TODO: Открыть форму для администратора
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                        this.Hide();
                    }
                    else if (tutor.role_id == 2) // Предполагаем, что role_id = 2 для Tutor
                    {
                        MessageBox.Show($"Добро пожаловать, преподаватель {tutor.fio}!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Открываем форму для преподавателя
                        TutorAccount ta = new TutorAccount(tutor.tutor_id);
                        ta.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная роль пользователя!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Неправильный логин или пароль
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Password.Focus();
                    Password.SelectAll();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Ошибка при авторизации: {ex.Message}\n\n";

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

        // КНОПКА НАЗАД
        private void Back_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем текущую форму
        }

        // КНОПКА РЕГИСТРАЦИИ
        private void buttonReg_Click_1(object sender, EventArgs e)
        {
            RegTutors regtutors = new RegTutors();
            regtutors.ShowDialog();
        }

        private void Login_TextChanged(object sender, EventArgs e)
        {
            // При вводе логина можно добавить счетчик символов
        }

        // Обработка нажатия Enter для быстрого входа
        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSignIn_Click(sender, e);
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Password.Focus();
            }
        }

        private void Login_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}