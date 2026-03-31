using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class AdminAccount : Form
    {
        private int adminId;
        private string adminName;

        public AdminAccount(int id, string name)
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
            labelRole.Text = "Роль: Администратор";
        }

        private void LoadAllBookings()
        {
            try
            {
                // Очищаем старые колонки перед добавлением новых
                dataGridViewBookings.Columns.Clear();

                var bookings = AppConnect.model01.booking
                    .OrderByDescending(b => b.date)
                    .ThenBy(b => b.start_time)
                    .ToList();

                // Используем DataTable вместо анонимного типа
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("booking_id", typeof(int));
                table.Columns.Add("Date", typeof(string));
                table.Columns.Add("StartTime", typeof(string));
                table.Columns.Add("EndTime", typeof(string));
                table.Columns.Add("Subject", typeof(string));
                table.Columns.Add("Tutor", typeof(string));
                table.Columns.Add("Student", typeof(string));
                table.Columns.Add("Notes", typeof(string));
                table.Columns.Add("Status", typeof(string));

                foreach (var b in bookings)
                {
                    table.Rows.Add(
                        b.booking_id,
                        b.date.HasValue ? b.date.Value.ToString("dd.MM.yyyy") : "Не указана",
                        b.start_time.HasValue ? b.start_time.Value.ToString(@"hh\:mm") : "Не указано",
                        b.end_time.HasValue ? b.end_time.Value.ToString(@"hh\:mm") : "Не указано",
                        GetSubjectName(b.subject_id),
                        GetTutorName(b.tutor_id),
                        GetStudentName(b.student_id),
                        b.notes ?? "",
                        GetStatusName(b.status_id)
                    );
                }

                dataGridViewBookings.DataSource = table;
                labelCount.Text = $"Всего записей: {bookings.Count}";

                // Скрываем колонку с ID
                if (dataGridViewBookings.Columns["booking_id"] != null)
                {
                    dataGridViewBookings.Columns["booking_id"].Visible = false;
                }

                // Настройка заголовков колонок на русском
                if (dataGridViewBookings.Columns["Date"] != null)
                {
                    dataGridViewBookings.Columns["Date"].HeaderText = "Дата";
                    dataGridViewBookings.Columns["Date"].Width = 100;
                }
                if (dataGridViewBookings.Columns["StartTime"] != null)
                {
                    dataGridViewBookings.Columns["StartTime"].HeaderText = "Время начала";
                    dataGridViewBookings.Columns["StartTime"].Width = 100;
                }
                if (dataGridViewBookings.Columns["EndTime"] != null)
                {
                    dataGridViewBookings.Columns["EndTime"].HeaderText = "Время окончания";
                    dataGridViewBookings.Columns["EndTime"].Width = 100;
                }
                if (dataGridViewBookings.Columns["Subject"] != null)
                {
                    dataGridViewBookings.Columns["Subject"].HeaderText = "Предмет";
                    dataGridViewBookings.Columns["Subject"].Width = 120;
                }
                if (dataGridViewBookings.Columns["Tutor"] != null)
                {
                    dataGridViewBookings.Columns["Tutor"].HeaderText = "Преподаватель";
                    dataGridViewBookings.Columns["Tutor"].Width = 150;
                }
                if (dataGridViewBookings.Columns["Student"] != null)
                {
                    dataGridViewBookings.Columns["Student"].HeaderText = "Студент";
                    dataGridViewBookings.Columns["Student"].Width = 150;
                }
                if (dataGridViewBookings.Columns["Notes"] != null)
                {
                    dataGridViewBookings.Columns["Notes"].HeaderText = "Комментарий";
                    dataGridViewBookings.Columns["Notes"].Width = 150;
                }
                if (dataGridViewBookings.Columns["Status"] != null)
                {
                    dataGridViewBookings.Columns["Status"].HeaderText = "Статус";
                    dataGridViewBookings.Columns["Status"].Width = 100;
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
            try
            {
                var subject = AppConnect.model01.Subjects.Find(subjectId);
                return subject?.subject_name ?? "Не указан";
            }
            catch
            {
                return "Не указан";
            }
        }

        private string GetTutorName(int tutorId)
        {
            try
            {
                var tutor = AppConnect.model01.tutor.Find(tutorId);
                return tutor?.fio ?? "Не указан";
            }
            catch
            {
                return "Не указан";
            }
        }

        private string GetStudentName(int studentId)
        {
            try
            {
                var student = AppConnect.model01.student.Find(studentId);
                return student?.fio ?? "Не указан";
            }
            catch
            {
                return "Не указан";
            }
        }

        private string GetStatusName(int? statusId)
        {
            if (statusId == null) return "Не указан";
            try
            {
                var status = AppConnect.model01.status.Find(statusId);
                return status?.status_name ?? "Не указан";
            }
            catch
            {
                return "Не указан";
            }
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
                    int bookingId = (int)dataGridViewBookings.SelectedRows[0].Cells["booking_id"].Value;
                    var bookingToEdit = AppConnect.model01.booking.Find(bookingId);

                    if (bookingToEdit != null)
                    {
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
                        int bookingId = (int)dataGridViewBookings.SelectedRows[0].Cells["booking_id"].Value;
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

        private void dataGridViewBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void RefreshData()
        {
            LoadAllBookings();
            if (statusLabel != null)
            {
                statusLabel.Text = "Данные обновлены";
            }
        }
    }
}