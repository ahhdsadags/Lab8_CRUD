using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab8_CRUD
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = @"Server=PC238-7;Database=StudentDB;Trusted_Connection=True;";
        private DataTable _lastSnapshot;

        private int _selectedId = -1;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
            buttonAdd.Click += buttonAdd_Click;
            buttonUpdate.Click += buttonUpdate_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonClear.Click += buttonClear_Click;
            buttonExport.Click += buttonExport_Click;   
            buttonCancel.Click += buttonCancel_Click;   
        }

        // ---------- ЗАГРУЗКА ФОРМЫ (READ) ----------
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var da = new SqlDataAdapter(
                    "SELECT Id, FullName AS [ФИО], Age AS [Возраст], " +
                    "GroupName AS [Группа], AverageGrade AS [Средний балл] FROM Students", conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    _lastSnapshot = dt.Copy();          // для «Отмены»

                    dataGridViewStudents.DataSource = dt;
                    if (dataGridViewStudents.Columns["Id"] != null)
                        dataGridViewStudents.Columns["Id"].Visible = false;

                    UpdateStatus($"Загружено студентов: {dt.Rows.Count}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- ВЫБОР СТРОКИ ----------
        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null) return;

            var row = dataGridViewStudents.CurrentRow;
            if (row.Cells["Id"].Value == null) return;

            _selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            textBoxName.Text = row.Cells["ФИО"].Value?.ToString();
            numericAge.Value = Convert.ToDecimal(row.Cells["Возраст"].Value);
            textBoxGroup.Text = row.Cells["Группа"].Value?.ToString();
            numericGrade.Value = Convert.ToDecimal(row.Cells["Средний балл"].Value);
        }

        // ---------- CREATE ----------
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (var check = new SqlCommand(
                        "SELECT COUNT(*) FROM Students WHERE FullName = @name", conn))
                    {
                        check.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                        int exists = (int)check.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Студент с таким ФИО уже существует!",
                                "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (var cmd = new SqlCommand(
                        "INSERT INTO Students (FullName, Age, GroupName, AverageGrade) " +
                        "VALUES (@name, @age, @group, @grade)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                        cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                        cmd.Parameters.AddWithValue("@group", textBoxGroup.Text.Trim());
                        cmd.Parameters.AddWithValue("@grade", (double)numericGrade.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadStudents();
                ClearFields();
                UpdateStatus("Студент добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- UPDATE ----------
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0)
            {
                MessageBox.Show("Выберите студента в таблице.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(
                    "UPDATE Students SET FullName=@name, Age=@age, " +
                    "GroupName=@group, AverageGrade=@grade WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text.Trim());
                    cmd.Parameters.AddWithValue("@grade", (double)numericGrade.Value);
                    cmd.Parameters.AddWithValue("@id", _selectedId);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        MessageBox.Show("Запись не найдена (возможно, удалена).",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                LoadStudents();
                ClearFields();
                UpdateStatus("Данные обновлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- DELETE ----------
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0)
            {
                MessageBox.Show("Выберите студента в таблице.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var answer = MessageBox.Show(
                "Удалить выбранную запись безвозвратно?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Students WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", _selectedId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadStudents();
                ClearFields();
                UpdateStatus("Запись удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- ОЧИСТКА ----------
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            UpdateStatus("Поля очищены");
        }

        private void ClearFields()
        {
            textBoxName.Clear();
            textBoxGroup.Clear();
            numericAge.Value = 15;
            numericGrade.Value = 0;
            _selectedId = -1;
            dataGridViewStudents.ClearSelection();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog
            {
                Filter = "CSV файл (*.csv)|*.csv",
                FileName = "students.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Id;ФИО;Возраст;Группа;СреднийБалл");

                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        if (row.IsNewRow) continue;
                        sb.AppendLine(string.Join(";",
                            row.Cells["Id"].Value,
                            row.Cells["ФИО"].Value,
                            row.Cells["Возраст"].Value,
                            row.Cells["Группа"].Value,
                            row.Cells["Средний балл"].Value));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Экспорт завершён: " + sfd.FileName,
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка экспорта: " + ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_lastSnapshot == null) { LoadStudents(); return; }
            dataGridViewStudents.DataSource = _lastSnapshot.Copy();
            ClearFields();
            UpdateStatus("Изменения отменены (таблица перезагружена)");
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Поле «ФИО» не может быть пустым.",
                    "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxGroup.Text))
            {
                MessageBox.Show("Поле «Группа» не может быть пустым.",
                    "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxGroup.Focus();
                return false;
            }
            return true;
        }

        private void UpdateStatus(string message)
        {
            int count = dataGridViewStudents.Rows.Count;
            if (dataGridViewStudents.AllowUserToAddRows) count--;
            labelStatus.Text = $"{message} | Всего студентов: {count}";
        }
    }
}