
namespace DrawingNotesAppSQLite
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxDrawingName = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.listBoxResults = new System.Windows.Forms.ListBox();
			this.textBoxNote = new System.Windows.Forms.TextBox();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.labelFilePath = new System.Windows.Forms.Label();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxDrawingName
			// 
			this.textBoxDrawingName.Location = new System.Drawing.Point(34, 22);
			this.textBoxDrawingName.Name = "textBoxDrawingName";
			this.textBoxDrawingName.Size = new System.Drawing.Size(281, 22);
			this.textBoxDrawingName.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(357, 20);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(187, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Найти";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// listBoxResults
			// 
			this.listBoxResults.FormattingEnabled = true;
			this.listBoxResults.ItemHeight = 16;
			this.listBoxResults.Location = new System.Drawing.Point(533, 83);
			this.listBoxResults.Name = "listBoxResults";
			this.listBoxResults.Size = new System.Drawing.Size(486, 164);
			this.listBoxResults.TabIndex = 2;
			this.listBoxResults.SelectedIndexChanged += new System.EventHandler(this.listBoxResults_SelectedIndexChanged);
			// 
			// textBoxNote
			// 
			this.textBoxNote.Location = new System.Drawing.Point(34, 82);
			this.textBoxNote.Multiline = true;
			this.textBoxNote.Name = "textBoxNote";
			this.textBoxNote.Size = new System.Drawing.Size(471, 165);
			this.textBoxNote.TabIndex = 3;
			// 
			// btnSelectFile
			// 
			this.btnSelectFile.Location = new System.Drawing.Point(34, 279);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(210, 72);
			this.btnSelectFile.TabIndex = 4;
			this.btnSelectFile.Text = "Выбрать файл";
			this.btnSelectFile.UseVisualStyleBackColor = true;
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// labelFilePath
			// 
			this.labelFilePath.AutoSize = true;
			this.labelFilePath.Location = new System.Drawing.Point(250, 279);
			this.labelFilePath.MinimumSize = new System.Drawing.Size(80, 30);
			this.labelFilePath.Name = "labelFilePath";
			this.labelFilePath.Size = new System.Drawing.Size(80, 30);
			this.labelFilePath.TabIndex = 5;
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.Location = new System.Drawing.Point(294, 279);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(725, 199);
			this.pictureBoxPreview.TabIndex = 6;
			this.pictureBoxPreview.TabStop = false;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(576, 20);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(138, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1098, 490);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pictureBoxPreview);
			this.Controls.Add(this.labelFilePath);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.textBoxNote);
			this.Controls.Add(this.listBoxResults);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.textBoxDrawingName);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxDrawingName;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.ListBox listBoxResults;
		private System.Windows.Forms.TextBox textBoxNote;
		private System.Windows.Forms.Button btnSelectFile;
		private System.Windows.Forms.Label labelFilePath;
		private System.Windows.Forms.PictureBox pictureBoxPreview;
		private System.Windows.Forms.Button btnSave;
	}
}

