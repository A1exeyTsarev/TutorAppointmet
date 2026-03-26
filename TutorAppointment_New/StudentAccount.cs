using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;
using TutorAppointment_New;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class StudentAccount : Form
    {
        private int studentId;

        // Конструктор - принимает ТОЛЬКО ID студента
        public StudentAccount(int id)
        {
            InitializeComponent();
            studentId = id;

            LoadStudentInfo();
            LoadSchedule();
        }

        // Загрузка информации о студенте
        private void LoadStudentInfo()
        {
            using (var db = new TutorAppointmentEntities())
            {
                var student = db.student.Find(studentId);

                labelWelcome.Text = $"Добро пожаловать, {student.fio}!";
                labelClass.Text = $"Класс: {student.grade}";
                labelPhone.Text = $"Телефон: {student.phone}";
                labelEmail.Text = $"Email: {student.mail}";
            }
        }

        // Загрузка расписания
        // Загрузка расписания
        private void LoadSchedule()
        {
            using (var db = new TutorAppointmentEntities())
            {
                var bookings = db.booking
                    .Where(b => b.student_id == studentId)
                    .ToList();

                var schedule = bookings.Select(b => new
                {
                    Дата = b.date,
                    Время = b.start_time + " - " + b.end_time,
                    Предмет = GetSubjectByTutorId(b.tutor_id, db),
                    Преподаватель = GetTutorName(b.tutor_id, db),
                    Комментарий = b.notes,
                    Статус = GetStatusName(b.status_id, db)
                }).ToList();

                // Очищаем старые колонки перед добавлением новых
                dataGridViewSchedule.Columns.Clear();

                dataGridViewSchedule.DataSource = schedule;

                // Настраиваем колонки
                if (dataGridViewSchedule.Columns.Count > 0)
                {
                    dataGridViewSchedule.Columns["Дата"].Width = 100;
                    dataGridViewSchedule.Columns["Время"].Width = 120;
                    dataGridViewSchedule.Columns["Предмет"].Width = 120;
                    dataGridViewSchedule.Columns["Преподаватель"].Width = 150;
                    dataGridViewSchedule.Columns["Комментарий"].Width = 200;
                    dataGridViewSchedule.Columns["Статус"].Width = 100;

                }

                labelScheduleCount.Text = $"Всего занятий: {schedule.Count}";
            }
        }

        // Получить предмет преподавателя
        // Получить предмет преподавателя
        private string GetSubjectByTutorId(int tutorId, TutorAppointmentEntities db)
        {
            var subject = db.subjectsTutor
                .Where(st => st.tutor_id == tutorId)
                .Join(db.Subjects,
                      st => st.subject_id,
                      s => s.subjects_id,
                      (st, s) => s.subject_name)
                .FirstOrDefault();

            return subject ?? "Не указан";

        }

        // Получить имя преподавателя
        private string GetTutorName(int tutorId, TutorAppointmentEntities db)
        {
            var tutor = db.tutor.Find(tutorId);
            return tutor?.fio ?? "Не указан";
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

        // Кнопка выхода
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LoginStudents loginForm = new LoginStudents();
            loginForm.Show();
            this.Close();
        }

        private void panelWelcome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLogout_Click_1(object sender, EventArgs e)
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