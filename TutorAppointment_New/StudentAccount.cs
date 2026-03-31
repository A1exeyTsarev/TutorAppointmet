using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class StudentAccount : Form
    {
        private int studentId;
        private dynamic selectedBooking; // Для хранения выбранной записи

        // Конструктор - принимает ТОЛЬКО ID студента
        public StudentAccount(int id)
        {
            InitializeComponent();
            studentId = id;

            LoadStudentInfo();
            LoadSchedule();

            // Подписываемся на событие двойного клика
            dataGridViewSchedule.CellDoubleClick += DataGridViewSchedule_CellDoubleClick;
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
        private void LoadSchedule()
        {
            using (var db = new TutorAppointmentEntities())
            {
                var bookings = db.booking
                    .Where(b => b.student_id == studentId)
                    .ToList();

                var schedule = bookings.Select(b => new
                {
                    booking_id = b.booking_id, // Добавляем ID записи для редактирования
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

                // Скрываем колонку с ID (не показываем пользователю)
                if (dataGridViewSchedule.Columns["booking_id"] != null)
                {
                    dataGridViewSchedule.Columns["booking_id"].Visible = false;
                }

                // Настраиваем колонки
                if (dataGridViewSchedule.Columns.Count > 0)
                {
                    if (dataGridViewSchedule.Columns["Дата"] != null)
                        dataGridViewSchedule.Columns["Дата"].Width = 100;
                    if (dataGridViewSchedule.Columns["Время"] != null)
                        dataGridViewSchedule.Columns["Время"].Width = 120;
                    if (dataGridViewSchedule.Columns["Предмет"] != null)
                        dataGridViewSchedule.Columns["Предмет"].Width = 120;
                    if (dataGridViewSchedule.Columns["Преподаватель"] != null)
                        dataGridViewSchedule.Columns["Преподаватель"].Width = 150;
                    if (dataGridViewSchedule.Columns["Комментарий"] != null)
                        dataGridViewSchedule.Columns["Комментарий"].Width = 200;
                    if (dataGridViewSchedule.Columns["Статус"] != null)
                        dataGridViewSchedule.Columns["Статус"].Width = 100;
                }

                labelScheduleCount.Text = $"Всего занятий: {schedule.Count}";
            }
        }

        // Обработчик двойного клика по ячейке
        private void DataGridViewSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что клик не по заголовку и есть данные
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    // Получаем ID записи из скрытой колонки
                    int bookingId = (int)dataGridViewSchedule.Rows[e.RowIndex].Cells["booking_id"].Value;

                    // Находим запись в базе данных
                    var bookingToEdit = AppConnect.model01.booking
                        .FirstOrDefault(b => b.booking_id == bookingId);

                    if (bookingToEdit != null)
                    {
                        // Открываем форму редактирования
                        EditLesson editForm = new EditLesson(bookingToEdit, studentId, this);
                        editForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Запись не найдена!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии записи: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // НОВЫЙ МЕТОД: Обновление расписания
        public void RefreshSchedule()
        {
            LoadSchedule(); // Вызываем метод загрузки расписания
        }

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

        private void buttonNewLesson_Click(object sender, EventArgs e)
        {
            // Передаем ID студента и ссылку на текущую форму
            NewLesson NL = new NewLesson(studentId, this);
            NL.Show();
            this.Hide(); // Скрываем форму студента, пока открыта форма записи
        }

        private void buttonFavorites_Click(object sender, EventArgs e)
        {

        }

        private void buttonMyTutors_Click(object sender, EventArgs e)
        {
            // Открываем форму со списком преподавателей
            //FindTutorForm findTutor = new FindTutorForm(studentId, this);
           // findTutor.Show();
            //this.Hide(); // Скрываем текущую форму
        }

        private void buttonLogout_Click_2(object sender, EventArgs e)
        {

        }

        private void dataGridViewSchedule_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}