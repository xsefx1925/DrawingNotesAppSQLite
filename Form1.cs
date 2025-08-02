using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; 
using System.IO;


namespace DrawingNotesAppSQLite
{
	public partial class Form1 : Form
	{
        private string _selectedFilePath = null;

        // Вспомогательный класс для отображения в ListBox
        public class NoteAndFileItem
        {
            public string Note { get; set; }
            public string FilePath { get; set; }
            public override string ToString()
            {
                if (!string.IsNullOrEmpty(Note) && !string.IsNullOrEmpty(FilePath))
                    return $"{Note} (файл: {Path.GetFileName(FilePath)})";
                if (!string.IsNullOrEmpty(Note))
                    return Note;
                if (!string.IsNullOrEmpty(FilePath))
                    return $"Файл: {Path.GetFileName(FilePath)}";
                return "Без заметки и файла";
            }
        }


        public Form1()
		{
			InitializeComponent();
		}

		
            private void btnSelectFile_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath = openFileDialog.FileName;
                    labelFilePath.Text = _selectedFilePath;
                }
            }

		private void btnSave_Click(object sender, EventArgs e)
		{
            string drawingName = textBoxDrawingName.Text.Trim();
            string note = textBoxNote.Text;
            string filePath = _selectedFilePath;

            if (string.IsNullOrEmpty(drawingName))
            {
                MessageBox.Show("Пожалуйста, введите название чертежа.");
                return;
            }

            using (var connection = new SQLiteConnection("Data Source=drawingnotes.db"))
            {
                connection.Open();

                long drawingId;
                // Поиск или создание чертежа
                string sqlCheckDrawing = "SELECT Id FROM Drawings WHERE DrawingName = @drawingName";
                using (var checkCommand = new SQLiteCommand(sqlCheckDrawing, connection))
                {
                    checkCommand.Parameters.AddWithValue("@drawingName", drawingName);
                    var result = checkCommand.ExecuteScalar();
                    if (result != null)
                    {
                        drawingId = (long)result;
                    }
                    else
                    {
                        string sqlInsertDrawing = "INSERT INTO Drawings (DrawingName) VALUES (@drawingName); SELECT last_insert_rowid();";
                        using (var insertCommand = new SQLiteCommand(sqlInsertDrawing, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@drawingName", drawingName);
                            drawingId = (long)insertCommand.ExecuteScalar();
                        }
                    }
                }

                // Добавление заметки
                string sqlInsertNote = "INSERT INTO NotesAndFiles (Note, FilePath, DrawingId) VALUES (@note, @filePath, @drawingId)";
                using (var noteCommand = new SQLiteCommand(sqlInsertNote, connection))
                {
                    noteCommand.Parameters.AddWithValue("@note", note);
                    noteCommand.Parameters.AddWithValue("@filePath", (object)filePath ?? DBNull.Value);
                    noteCommand.Parameters.AddWithValue("@drawingId", drawingId);
                    noteCommand.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Данные успешно сохранены!");
            textBoxNote.Clear();
            labelFilePath.Text = "Файл не выбран";
            _selectedFilePath = null;
        }

		private void btnSearch_Click(object sender, EventArgs e)
		{
            listBoxResults.Items.Clear();
            pictureBoxPreview.Image = null;

            string drawingName = textBoxDrawingName.Text.Trim();
            if (string.IsNullOrEmpty(drawingName)) return;

            using (var connection = new SQLiteConnection("Data Source=drawingnotes.db"))
            {
                connection.Open();

                string sql = @"
            SELECT T2.Note, T2.FilePath
            FROM Drawings AS T1
            JOIN NotesAndFiles AS T2 ON T1.Id = T2.DrawingId
            WHERE T1.DrawingName = @drawingName";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@drawingName", drawingName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Чертеж с таким названием не найден.");
                            return;
                        }
                        while (reader.Read())
                        {
                            listBoxResults.Items.Add(new NoteAndFileItem
                            {
                                Note = reader["Note"].ToString(),
                                FilePath = reader["FilePath"].ToString()
                            });
                        }
                    }
                }
            }

        }

		private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (listBoxResults.SelectedItem is NoteAndFileItem selectedItem)
            {
                if (!string.IsNullOrEmpty(selectedItem.FilePath) && File.Exists(selectedItem.FilePath))
                {
                    try
                    {
                        pictureBoxPreview.Image = Image.FromFile(selectedItem.FilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось загрузить изображение: {ex.Message}");
                        pictureBoxPreview.Image = null;
                    }
                }
                else
                {
                    pictureBoxPreview.Image = null;
                }
            }
        }
	}
}
