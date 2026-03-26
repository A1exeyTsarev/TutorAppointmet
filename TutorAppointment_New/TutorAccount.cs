using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;
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
        }

        // Загрузка информации о преподавателе
        private void LoadTutorInfo()
        {
            using (var db = new TutorAppointmentEntities())
            {
                var tutor = db.tutor.Find(tutorId);

                if (tutor != null)
                {
                    labelWelcome.Text = $"Добро пожаловать, {tutor.fio}!";
                    labelPhone.Text = $"Телефон: {tutor.phone ?? "не указан"}";
                    labelEmail.Text = $"Email: {tutor.mail ?? "не указан"}";

                    // Загружаем предметы
                    var subjects = db.subjectsTutor
                        .Where(st => st.tutor_id == tutorId)
                        .Join(db.Subjects,
                              st => st.subject_id,
                              s => s.subjects_id,
                              (st, s) => s.subject_name)
                        .ToList();

                    labelSubjects.Text = subjects.Count > 0
                        ? $"Предметы: {string.Join(", ", subjects)}"
                        : "Предметы: не указаны";
                }
            }
        }

        // Загрузка расписания
        // Загрузка расписания
        private void LoadSchedule()
        {
            try
            {
                using (var db = new TutorAppointmentEntities())
                {
                    var bookings = db.booking
                        .Where(b => b.tutor_id == tutorId)
                        .Join(db.student,
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
                            // Исправлено: проверяем, что date не является минимальным значением (не указана)
                            Дата = x.booking.date != DateTime.MinValue ? x.booking.date.ToString("dd.MM.yyyy") : "не указана",
                            Время = x.booking.start_time + " - " + x.booking.end_time,
                            Ученик = x.student.fio,
                            Класс = x.student.grade,
                            Комментарий = x.booking.notes ?? "",
                            Статус = GetStatusName(x.booking.status_id, db)
                        })
                        .ToList();

                    // ОЧИЩАЕМ старые колонки перед добавлением новых
                    dataGridViewSchedule.Columns.Clear();

                    dataGridViewSchedule.DataSource = schedule;
                    labelScheduleCount.Text = $"Всего занятий: {schedule.Count}";

                    // Настройка ширины колонок
                    if (dataGridViewSchedule.Columns.Count > 0)
                    {
                        dataGridViewSchedule.Columns["Дата"].Width = 100;
                        dataGridViewSchedule.Columns["Время"].Width = 120;
                        dataGridViewSchedule.Columns["Ученик"].Width = 150;
                        dataGridViewSchedule.Columns["Класс"].Width = 80;
                        dataGridViewSchedule.Columns["Комментарий"].Width = 150;
                        dataGridViewSchedule.Columns["Статус"].Width = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки расписания: " + ex.Message);
            }
        }
        // Получить статус
        private string GetStatusName(int? statusId, TutorAppointmentEntities db)
        {
            if (statusId == null) return "Не указан";

            var status = db.status
                .Where(s => s.status_id == statusId)
                .Select(s => s.status_name)
                .FirstOrDefault();

            return status ?? "Не указан";
        }

        // Кнопка "Создать занятие"
        private void buttonNewLesson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма создания занятия будет здесь", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Открываем форму создания занятия
            // CreateLessonForm createForm = new CreateLessonForm(tutorId);
            // createForm.ShowDialog();
            // LoadSchedule();
        }

        // Кнопка "Мои ученики"
        private void buttonMyStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Список учеников будет здесь", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Открываем форму со списком учеников
            // MyStudentsForm studentsForm = new MyStudentsForm(tutorId);
            // studentsForm.ShowDialog();
        }

        // Кнопка "Выйти"
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LoginTutors loginForm = new LoginTutors();
            loginForm.Show();
            this.Close();
        }

        private void panelWelcome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelScheduleHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}