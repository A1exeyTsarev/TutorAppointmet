using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class NewLesson : Form
    {
        // ID текущего авторизованного студента
        private int currentStudentId;

        // Ссылка на форму студента, чтобы вернуться к ней
        private StudentAccount studentAccountForm;

        public NewLesson(int studentId, StudentAccount studentAccount)
        {
            InitializeComponent();
            currentStudentId = studentId;
            studentAccountForm = studentAccount;

            // Настройка DateTimePicker для выбора даты и времени
            ConfigureDateTimePickers();

            LoadComboBoxes();
        }

        private void ConfigureDateTimePickers()
        {
            // Настройка для выбора даты и времени начала
            StartTime.Format = DateTimePickerFormat.Custom;
            StartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            StartTime.ShowUpDown = true;

            // Настройка для выбора даты и времени окончания
            EndTime.Format = DateTimePickerFormat.Custom;
            EndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            EndTime.ShowUpDown = true;

            // Устанавливаем время по умолчанию (текущая дата, следующий час)
            DateTime now = DateTime.Now;
            StartTime.Value = new DateTime(now.Year, now.Month, now.Day, now.Hour + 1, 0, 0);
            EndTime.Value = StartTime.Value.AddHours(1);
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Загрузка предметов (Subjects)
                var subjects = AppConnect.model01.Subjects.ToList();
                Subject.DataSource = subjects;
                Subject.DisplayMember = "subject_name";
                Subject.ValueMember = "subjects_id";

                // Проверка, есть ли предметы
                if (subjects.Count == 0)
                {
                    MessageBox.Show("Список предметов пуст!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При выборе предмета фильтруем репетиторов
            if (Subject.SelectedItem != null)
            {
                try
                {
                    // Получаем выбранный объект предмета
                    var selectedSubject = Subject.SelectedItem as Subjects;
                    if (selectedSubject == null) return;

                    int selectedSubjectId = selectedSubject.subjects_id;

                    // Загрузка репетиторов, которые ведут выбранный предмет
                    var tutorsForSubject = AppConnect.model01.subjectsTutor
                        .Where(st => st.subject_id == selectedSubjectId)
                        .Select(st => st.tutor)
                        .ToList();

                    Tutor.DataSource = tutorsForSubject;
                    Tutor.DisplayMember = "fio";
                    Tutor.ValueMember = "tutor_id";

                    if (tutorsForSubject.Count == 0)
                    {
                        MessageBox.Show("Для выбранного предмета нет преподавателей!",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка фильтрации репетиторов: " + ex.Message);
                }
            }
        }

        private void Tutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Здесь можно добавить логику при выборе репетитора
        }

        private void StartTime_ValueChanged(object sender, EventArgs e)
        {
            // Автоматически устанавливаем время окончания (например, +1 час)
            if (StartTime.Value != null)
            {
                EndTime.Value = StartTime.Value.AddHours(1);
            }
        }

        private void Notes_TextChanged(object sender, EventArgs e)
        {
            // Здесь можно добавить логику при изменении заметок
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Возвращаемся на страницу студента
            if (studentAccountForm != null)
            {
                studentAccountForm.Show();
            }
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка обязательных полей
                if (Subject.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите предмет!",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Subject.Focus();
                    return;
                }

                if (Tutor.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите преподавателя!",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Tutor.Focus();
                    return;
                }

                // Получаем выбранные объекты
                var selectedSubject = Subject.SelectedItem as Subjects;
                var selectedTutor = Tutor.SelectedItem as tutor;

                if (selectedSubject == null || selectedTutor == null)
                {
                    MessageBox.Show("Ошибка получения данных!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка времени
                if (StartTime.Value >= EndTime.Value)
                {
                    MessageBox.Show("Время начала должно быть раньше времени окончания!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StartTime.Focus();
                    return;
                }

                // Проверка даты (нельзя записаться на прошедшую дату)
                if (StartTime.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("Нельзя записаться на урок в прошедшую дату!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Поиск статуса "planed"
                var plannedStatus = AppConnect.model01.status
                    .FirstOrDefault(s => s.status_name == "planed");

                if (plannedStatus == null)
                {
                    MessageBox.Show("Статус 'planed' не найден в базе данных!\n" +
                        "Обратитесь к администратору.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка на существующие записи в это время
                var existingBooking = AppConnect.model01.booking
                    .FirstOrDefault(b => b.tutor_id == selectedTutor.tutor_id &&
                                         b.date == StartTime.Value.Date &&
                                         ((b.start_time <= StartTime.Value.TimeOfDay &&
                                           b.end_time > StartTime.Value.TimeOfDay) ||
                                          (b.start_time < EndTime.Value.TimeOfDay &&
                                           b.end_time >= EndTime.Value.TimeOfDay) ||
                                          (b.start_time >= StartTime.Value.TimeOfDay &&
                                           b.end_time <= EndTime.Value.TimeOfDay)));

                if (existingBooking != null)
                {
                    MessageBox.Show("У этого преподавателя уже есть занятие в выбранное время!\n" +
                        "Пожалуйста, выберите другое время.",
                        "Конфликт расписания", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создание новой записи
                var newBooking = new booking
                {
                    subject_id = selectedSubject.subjects_id,
                    tutor_id = selectedTutor.tutor_id,
                    student_id = currentStudentId,
                    notes = Notes.Text.Trim(),
                    status_id = plannedStatus.status_id,
                    date = StartTime.Value.Date,
                    start_time = StartTime.Value.TimeOfDay,
                    end_time = EndTime.Value.TimeOfDay
                };

                // Добавление в контекст
                AppConnect.model01.booking.Add(newBooking);

                // Сохранение изменений
                int rowsAffected = AppConnect.model01.SaveChanges();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Урок успешно запланирован!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем расписание на странице студента
                    if (studentAccountForm != null)
                    {
                        studentAccountForm.RefreshSchedule(); // Вызываем метод обновления расписания
                        studentAccountForm.Show();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось запланировать урок.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}