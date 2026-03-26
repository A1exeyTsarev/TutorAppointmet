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

namespace TutorAppointment_New
{
    public partial class LoginTutors : Form
    {
        public LoginTutors()
        {
            InitializeComponent();
        }

        private void LoginTutors_Load(object sender, EventArgs e)
        {

        }

        // КНОПКА ВХОДА (Sign In)
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей ввода
            string login = Login.Text.Trim(); // поле для логина
            string password = Password.Text.Trim(); // поле для пароля

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        /*AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                        this.Hide();*/
                    }
                    else if (tutor.role_id == 2) // Предполагаем, что role_id = 2 для Tutor
                    {
                        MessageBox.Show($"Добро пожаловать, преподаватель {tutor.fio}!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // TODO: Открыть форму для преподавателя
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации: " + ex.Message,
                    "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        }

        
    }
}