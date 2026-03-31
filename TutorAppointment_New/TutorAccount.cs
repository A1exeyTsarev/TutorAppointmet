using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class TutorAccount : Form
    {
        private int tutorId;

        // Конструктор - принимает ID преподавателя
        public TutorAccount(int id)
        {
            InitializeComponent();
            tutorId = id;

            LoadTutorInfo();
            LoadSchedule();
            
            // Подписываемся на событие двойного клика (если нужно)
            // dataGridViewSchedule.CellDoubleClick += DataGridViewSchedule_CellDoubleClick;
        }

        // Загрузка информации о преподавателе
        private void LoadTutorInfo()
        {
            try
            {
                var tutor = AppConnect.model01.tutor.Find(tutorId);

                if (tutor != null)
                {
                    labelWelcome.Text = $"Добро пожаловать, {tutor.fio}!";
                    labelPhone.Text = $"Телефон: {tutor.phone ?? "не указан"}";
                    labelEmail.Text = $"Email: {tutor.mail ?? "не указан"}";

                    // Загружаем предметы
                    var subjects = AppConnect.model01.subjectsTutor
                        .Where(st => st.tutor_id == tutorId)
                        .Join(AppConnect.model01.Subjects,
                              st => st.subject_id,
                              s => s.subjects_id,
                              (st, s) => s.subject_name)
                        .ToList();

                    labelSubjects.Text = subjects.Count > 0
                        ? $"Предметы: {string.Join(", ", subjects)}"
                        : "Предметы: не указаны";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки информации: " + ex.Message);
            }
        }

        // Загрузка расписания (как у студента - без AutoGenerateColumns = false)
        private void LoadSchedule()
        {
            try
            {
                var bookings = AppConnect.model01.booking
                    .Where(b => b.tutor_id == tutorId)
                    .Join(AppConnect.model01.student,
                          b => b.student_id,
                          s => s.student_id,
                          (b, s) => new
                          {
                              booking = b,
                              student = s
                          })
                    .OrderBy(x => x.booking.date)
                    .ThenBy(x => x.booking.start_time)
                    .ToList();

                var schedule = bookings
                    .Select(x => new
                    {
                        booking_id = x.booking.booking_id, // Добавляем ID для редактирования
                        Дата = x.booking.date.HasValue && x.booking.date.Value != DateTime.MinValue
                            ? x.booking.date.Value.ToString("dd.MM.yyyy")
                            : "не указана",
                        Время = $"{FormatTimeSpan(x.booking.start_time)} - {FormatTimeSpan(x.booking.end_time)}",
                        Ученик = x.student.fio ?? "не указан",
                        Класс = x.student.grade ?? "не указан",
                        Комментарий = x.booking.notes ?? "",
                        Статус = GetStatusName(x.booking.status_id)
                    })
                    .ToList();

                // Очищаем старые колонки перед добавлением новых
                dataGridViewSchedule.Columns.Clear();

                dataGridViewSchedule.DataSource = schedule;

                // Скрываем колонку с ID (не показываем пользователю)
                if (dataGridViewSchedule.Columns["booking_id"] != null)
                {
                    dataGridViewSchedule.Columns["booking_id"].Visible = false;
                }

                labelScheduleCount.Text = $"Всего занятий: {schedule.Count}";

                // Настраиваем ширину колонок
                if (dataGridViewSchedule.Columns.Count > 0)
                {
                    if (dataGridViewSchedule.Columns["Дата"] != null)
                        dataGridViewSchedule.Columns["Дата"].Width = 100;
                    if (dataGridViewSchedule.Columns["Время"] != null)
                        dataGridViewSchedule.Columns["Время"].Width = 120;
                    if (dataGridViewSchedule.Columns["Ученик"] != null)
                        dataGridViewSchedule.Columns["Ученик"].Width = 150;
                    if (dataGridViewSchedule.Columns["Класс"] != null)
                        dataGridViewSchedule.Columns["Класс"].Width = 80;
                    if (dataGridViewSchedule.Columns["Комментарий"] != null)
                        dataGridViewSchedule.Columns["Комментарий"].Width = 150;
                    if (dataGridViewSchedule.Columns["Статус"] != null)
                        dataGridViewSchedule.Columns["Статус"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки расписания: " + ex.Message);
            }
        }

        // Вспомогательный метод для форматирования TimeSpan?
        private string FormatTimeSpan(TimeSpan? time)
        {
            if (time == null) return "не указано";
            return time.Value.ToString(@"hh\:mm");
        }

        // Получить статус
        private string GetStatusName(int? statusId)
        {
            if (statusId == null) return "Не указан";

            var status = AppConnect.model01.status
                .Where(s => s.status_id == statusId)
                .Select(s => s.status_name)
                .FirstOrDefault();

            return status ?? "Не указан";
        }

        // Обновление расписания
        public void RefreshSchedule()
        {
            LoadSchedule();
        }

        // Кнопка "Создать занятие"
        private void buttonNewLesson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма создания занятия будет здесь", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Кнопка "Мои ученики"
        private void buttonMyStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Список учеников будет здесь", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Кнопка "Выйти"
        private void buttonLogout_Click(object sender, EventArgs e)
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

        private void buttonMyStudents_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Список учеников будет здесь", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonNewLesson_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Форма создания занятия будет здесь", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLogout_Click_1(object sender, EventArgs e)
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

        private void panelWelcome_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}