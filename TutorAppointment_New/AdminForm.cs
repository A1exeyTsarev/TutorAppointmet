using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class AdminForm : Form
    {
        private int adminId;
        private string adminName;

        public AdminForm(int id, string name)
        {
            InitializeComponent();
            adminId = id;
            adminName = name;

            LoadWelcomeMessage();
            LoadAllBookings();

            // Подписываемся на события
            buttonRefresh.Click += ButtonRefresh_Click;
            buttonEdit.Click += ButtonEdit_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonLogout.Click += ButtonLogout_Click;
        }

        private void LoadWelcomeMessage()
        {
            labelWelcome.Text = $"Добро пожаловать, {adminName}!";
        }

        private void LoadAllBookings()
        {
            try
            {
                var bookings = AppConnect.model01.booking
                    .OrderByDescending(b => b.date)
                    .ThenBy(b => b.start_time)
                    .ToList();

                var bookingList = bookings.Select(b => new
                {
                    ID = b.booking_id,
                    Дата = b.date,
                    ВремяНачала = b.start_time,
                    ВремяОкончания = b.end_time,
                    Предмет = GetSubjectName(b.subject_id),
                    Преподаватель = GetTutorName(b.tutor_id),
                    Студент = GetStudentName(b.student_id),
                    Комментарий = b.notes ?? "",
                    Статус = GetStatusName(b.status_id)
                }).ToList();

                dataGridViewBookings.DataSource = bookingList;
                labelCount.Text = $"Всего записей: {bookingList.Count}";

                // Настройка колонок
                if (dataGridViewBookings.Columns.Count > 0)
                {
                    dataGridViewBookings.Columns["ID"].Width = 50;
                    dataGridViewBookings.Columns["Дата"].Width = 100;
                    dataGridViewBookings.Columns["ВремяНачала"].Width = 100;
                    dataGridViewBookings.Columns["ВремяОкончания"].Width = 100;
                    dataGridViewBookings.Columns["Предмет"].Width = 120;
                    dataGridViewBookings.Columns["Преподаватель"].Width = 150;
                    dataGridViewBookings.Columns["Студент"].Width = 150;
                    dataGridViewBookings.Columns["Комментарий"].Width = 150;
                    dataGridViewBookings.Columns["Статус"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSubjectName(int? subjectId)
        {
            if (subjectId == null) return "Не указан";
            var subject = AppConnect.model01.Subjects.Find(subjectId);
            return subject?.subject_name ?? "Не указан";
        }

        private string GetTutorName(int tutorId)
        {
            var tutor = AppConnect.model01.tutor.Find(tutorId);
            return tutor?.fio ?? "Не указан";
        }

        private string GetStudentName(int studentId)
        {
            var student = AppConnect.model01.student.Find(studentId);
            return student?.fio ?? "Не указан";
        }

        private string GetStatusName(int? statusId)
        {
            if (statusId == null) return "Не указан";
            var status = AppConnect.model01.status.Find(statusId);
            return status?.status_name ?? "Не указан";
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadAllBookings();
            statusLabel.Text = "Данные обновлены";
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                try
                {
                    int bookingId = (int)dataGridViewBookings.SelectedRows[0].Cells["ID"].Value;
                    var bookingToEdit = AppConnect.model01.booking.Find(bookingId);

                    if (bookingToEdit != null)
                    {
                        // Открываем форму редактирования для администратора
                        AdminEditLesson editForm = new AdminEditLesson(bookingToEdit, this);
                        editForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при редактировании: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int bookingId = (int)dataGridViewBookings.SelectedRows[0].Cells["ID"].Value;
                        var bookingToDelete = AppConnect.model01.booking.Find(bookingId);

                        if (bookingToDelete != null)
                        {
                            AppConnect.model01.booking.Remove(bookingToDelete);
                            AppConnect.model01.SaveChanges();

                            MessageBox.Show("Запись успешно удалена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadAllBookings();
                            statusLabel.Text = "Запись удалена";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?",
                "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginTutors loginForm = new LoginTutors();
                loginForm.Show();
                this.Close();
            }
        }
    }
}