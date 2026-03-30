using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class EditLesson : Form
    {
        private booking currentBooking;
        private int studentId;
        private StudentAccount studentAccountForm;

        // Ограничения для комментариев
        private const int MAX_NOTES_LENGTH = 35; // Максимальная длина комментария

        public EditLesson(booking booking, int studentId, StudentAccount studentAccount)
        {
            InitializeComponent();
            currentBooking = booking;
            this.studentId = studentId;
            studentAccountForm = studentAccount;

            // Настройка DateTimePicker
            ConfigureDateTimePickers();

            // Настройка TextBox для комментариев
            ConfigureNotesTextBox();

            // Загрузка данных в форму
            LoadLessonData();

            // Загрузка ComboBox
            LoadComboBoxes();

            // Подписываемся на события
            buttonSave.Click += ButtonSave_Click;
            buttonBack.Click += ButtonBack_Click;
            Subject.SelectedIndexChanged += Subject_SelectedIndexChanged;
            StartTime.ValueChanged += StartTime_ValueChanged;
            EndTime.ValueChanged += EndTime_ValueChanged;
            Notes.KeyPress += Notes_KeyPress; // Обработчик нажатия клавиш
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
        }

        private void ConfigureNotesTextBox()
        {
            // Устанавливаем максимальную длину комментария
            Notes.MaxLength = MAX_NOTES_LENGTH;

            // Добавляем подсказку
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(Notes, $"Максимальная длина комментария: {MAX_NOTES_LENGTH} символов");
        }

        private void LoadLessonData()
        {
            // Исправлено: проверяем на null и преобразуем TimeSpan? в TimeSpan
            TimeSpan startTime = currentBooking.start_time ?? TimeSpan.Zero;
            TimeSpan endTime = currentBooking.end_time ?? TimeSpan.Zero;

            // Загружаем данные текущей записи
            StartTime.Value = currentBooking.date.Add(startTime);
            EndTime.Value = currentBooking.date.Add(endTime);
            Notes.Text = currentBooking.notes ?? "";
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Загрузка предметов
                var subjects = AppConnect.model01.Subjects.ToList();
                Subject.DataSource = subjects;
                Subject.DisplayMember = "subject_name";
                Subject.ValueMember = "subjects_id";

                // Устанавливаем выбранный предмет
                var selectedSubject = subjects.FirstOrDefault(s => s.subjects_id == currentBooking.subject_id);
                if (selectedSubject != null)
                {
                    Subject.SelectedItem = selectedSubject;
                }

                // Загружаем преподавателей
                LoadTutors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTutors()
        {
            if (Subject.SelectedItem != null)
            {
                try
                {
                    var selectedSubject = Subject.SelectedItem as Subjects;
                    if (selectedSubject == null) return;

                    // Загрузка репетиторов для выбранного предмета
                    var tutorsForSubject = AppConnect.model01.subjectsTutor
                        .Where(st => st.subject_id == selectedSubject.subjects_id)
                        .Select(st => st.tutor)
                        .ToList();

                    Tutor.DataSource = tutorsForSubject;
                    Tutor.DisplayMember = "fio";
                    Tutor.ValueMember = "tutor_id";

                    // Устанавливаем выбранного преподавателя
                    var selectedTutor = tutorsForSubject.FirstOrDefault(t => t.tutor_id == currentBooking.tutor_id);
                    if (selectedTutor != null)
                    {
                        Tutor.SelectedItem = selectedTutor;
                    }

                    if (tutorsForSubject.Count == 0)
                    {
                        MessageBox.Show("Для выбранного предмета нет преподавателей!",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки преподавателей: " + ex.Message);
                }
            }
        }

        private void Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При изменении предмета обновляем список преподавателей
            LoadTutors();
        }

        // Проверка времени (нельзя выбирать время с 22:00 до 08:00)
        private bool IsValidTime(DateTime time)
        {
            int hour = time.Hour;
            // Запрещаем время с 22:00 до 08:00
            if (hour >= 22 || hour < 8)
            {
                return false;
            }
            return true;
        }

        // Ограничение времени начала
        private void StartTime_ValueChanged(object sender, EventArgs e)
        {
            if (!IsValidTime(StartTime.Value))
            {
                MessageBox.Show("Время начала урока должно быть с 8:00 до 22:00!\n" +
                    "Недопустимое время: с 22:00 до 08:00.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Устанавливаем ближайшее допустимое время
                DateTime newTime = StartTime.Value.Date.AddHours(8);
                if (StartTime.Value.Hour >= 22)
                {
                    newTime = StartTime.Value.Date.AddDays(1).AddHours(8);
                }
                StartTime.Value = newTime;
                return;
            }

            // Если время начала изменилось, автоматически устанавливаем время окончания (+1 час)
            EndTime.Value = StartTime.Value.AddHours(1);
        }

        // Ограничение времени окончания
        private void EndTime_ValueChanged(object sender, EventArgs e)
        {
            if (!IsValidTime(EndTime.Value))
            {
                MessageBox.Show("Время окончания урока должно быть с 8:00 до 22:00!\n" +
                    "Недопустимое время: с 22:00 до 08:00.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Устанавливаем ближайшее допустимое время
                DateTime newTime = EndTime.Value.Date.AddHours(20);
                if (EndTime.Value.Hour < 8)
                {
                    newTime = EndTime.Value.Date.AddHours(8);
                }
                EndTime.Value = newTime;
            }
        }

        // Ограничение для комментариев - просто блокируем ввод после 35 символов
        private void Notes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если достигнут лимит и нажата не клавиша Backspace
            if (Notes.Text.Length >= MAX_NOTES_LENGTH && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем ввод символа

                // Показываем предупреждение только один раз
                if (Notes.Tag == null || (bool)Notes.Tag == false)
                {
                    Notes.Tag = true;
                    MessageBox.Show($"Достигнут лимит символов! Максимум: {MAX_NOTES_LENGTH}.",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Threading.Tasks.Task.Delay(2000).ContinueWith(t => Notes.Tag = false);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
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

                // ПРОВЕРКА для комментария: максимальная длина
                string notes = Notes.Text.Trim();
                if (notes.Length > MAX_NOTES_LENGTH)
                {
                    MessageBox.Show($"Комментарий не может превышать {MAX_NOTES_LENGTH} символов!\n" +
                        $"Текущая длина: {notes.Length} символов.",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Notes.Focus();
                    return;
                }

                // ПРОВЕРКА 1: Дата начала и окончания должны быть в один день
                if (StartTime.Value.Date != EndTime.Value.Date)
                {
                    MessageBox.Show("Дата начала и дата окончания должны быть в один день!\n" +
                        "Урок не может длиться больше одного дня.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StartTime.Focus();
                    return;
                }

                // ПРОВЕРКА 2: Время начала должно быть меньше времени окончания
                if (StartTime.Value >= EndTime.Value)
                {
                    MessageBox.Show("Время начала должно быть раньше времени окончания!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StartTime.Focus();
                    return;
                }

                // ПРОВЕРКА 3: Проверка времени (с 8:00 до 22:00)
                if (!IsValidTime(StartTime.Value))
                {
                    MessageBox.Show("Время начала урока должно быть с 8:00 до 22:00!\n" +
                        "Недопустимое время: с 22:00 до 08:00.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StartTime.Focus();
                    return;
                }

                if (!IsValidTime(EndTime.Value))
                {
                    MessageBox.Show("Время окончания урока должно быть с 8:00 до 22:00!\n" +
                        "Недопустимое время: с 22:00 до 08:00.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EndTime.Focus();
                    return;
                }

                // ПРОВЕРКА 4: Минимальная длительность урока (30 минут)
                TimeSpan duration = EndTime.Value - StartTime.Value;
                if (duration.TotalMinutes < 30)
                {
                    MessageBox.Show("Минимальная длительность урока - 30 минут!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ПРОВЕРКА 5: Максимальная длительность урока (3 часа)
                if (duration.TotalHours > 3)
                {
                    MessageBox.Show("Максимальная длительность урока - 3 часа!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка даты (нельзя изменить на прошедшую дату)
                if (StartTime.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("Нельзя изменить дату на прошедшую!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Проверка на конфликт расписания (исключая текущую запись)
                var existingBooking = AppConnect.model01.booking
                    .FirstOrDefault(b => b.tutor_id == selectedTutor.tutor_id &&
                                         b.booking_id != currentBooking.booking_id &&
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

                // Обновляем данные
                currentBooking.subject_id = selectedSubject.subjects_id;
                currentBooking.tutor_id = selectedTutor.tutor_id;
                currentBooking.date = StartTime.Value.Date;
                currentBooking.start_time = StartTime.Value.TimeOfDay;
                currentBooking.end_time = EndTime.Value.TimeOfDay;
                currentBooking.notes = notes; // Сохраняем комментарий

                // Сохраняем изменения
                int rowsAffected = AppConnect.model01.SaveChanges();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Запись успешно обновлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем расписание на главной форме
                    if (studentAccountForm != null)
                    {
                        studentAccountForm.RefreshSchedule();
                        studentAccountForm.Show();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить запись.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // Возвращаемся на страницу студента
            if (studentAccountForm != null)
            {
                studentAccountForm.Show();
            }
            this.Close();
        }
    }
}