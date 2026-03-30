using System;
using System.Linq;
using System.Windows.Forms;
using TutorAppointment_New.AppData;

namespace TutorAppointment_New
{
    public partial class FindTutorForm : Form
    {
        private int studentId;
        private StudentAccount studentAccountForm;

        public FindTutorForm(int studentId, StudentAccount studentAccount)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.studentAccountForm = studentAccount;

            LoadTutors();

            buttonBack.Click += ButtonBack_Click;
        }

        private void LoadTutors()
        {
            try
            {
                // Находим всех преподавателей, у которых студент записан на уроки
                var tutors = AppConnect.model01.booking
                    .Where(b => b.student_id == studentId)
                    .Select(b => b.tutor)
                    .Distinct()
                    .ToList();

                if (tutors.Count == 0)
                {
                    MessageBox.Show("У вас пока нет записей к преподавателям!",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Создаем пустую таблицу
                    dataGridViewTutors.DataSource = null;
                    labelCount.Text = "Всего преподавателей: 0";
                    return;
                }

                // Создаем список для отображения
                var tutorList = tutors.Select(t => new
                {
                    ID = t.tutor_id,
                    ФИО = t.fio,
                    Телефон = t.phone ?? "Не указан",
                    Email = t.mail ?? "Не указан",
                    Рейтинг = t.raiting ?? "Нет",
                    Информация = t.info ?? "Нет информации"
                }).ToList();

                dataGridViewTutors.DataSource = tutorList;

                // Настраиваем колонки
                if (dataGridViewTutors.Columns.Count > 0)
                {
                    if (dataGridViewTutors.Columns["ID"] != null)
                        dataGridViewTutors.Columns["ID"].Visible = false;

                    if (dataGridViewTutors.Columns["ФИО"] != null)
                        dataGridViewTutors.Columns["ФИО"].Width = 150;

                    if (dataGridViewTutors.Columns["Телефон"] != null)
                        dataGridViewTutors.Columns["Телефон"].Width = 120;

                    if (dataGridViewTutors.Columns["Email"] != null)
                        dataGridViewTutors.Columns["Email"].Width = 150;

                    if (dataGridViewTutors.Columns["Рейтинг"] != null)
                        dataGridViewTutors.Columns["Рейтинг"].Width = 80;

                    if (dataGridViewTutors.Columns["Информация"] != null)
                        dataGridViewTutors.Columns["Информация"].Width = 200;
                }

                labelCount.Text = $"Всего преподавателей: {tutors.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки преподавателей: " + ex.Message, "Ошибка",
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