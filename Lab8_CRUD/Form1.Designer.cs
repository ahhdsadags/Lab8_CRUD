namespace Lab8_CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            labelName = new Label();
            textBoxName = new TextBox();
            labelAge = new Label();
            numericAge = new NumericUpDown();
            labelGroup = new Label();
            textBoxGroup = new TextBox();
            labelGrade = new Label();
            numericGrade = new NumericUpDown();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            labelStatus = new Label();
            buttonExport = new Button();
            buttonCancel = new Button();
            label = new Label();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(304, 3);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(648, 309);
            dataGridViewStudents.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(44, 34);
            labelName.Name = "labelName";
            labelName.Size = new Size(37, 15);
            labelName.TabIndex = 1;
            labelName.Text = "ФИО:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(88, 33);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(45, 71);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(53, 15);
            labelAge.TabIndex = 3;
            labelAge.Text = "Возраст:";
            // 
            // numericAge
            // 
            numericAge.Location = new Point(104, 69);
            numericAge.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numericAge.Name = "numericAge";
            numericAge.Size = new Size(120, 23);
            numericAge.TabIndex = 4;
            numericAge.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(41, 109);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(49, 15);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Группа:";
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(104, 109);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(100, 23);
            textBoxGroup.TabIndex = 6;
            // 
            // labelGrade
            // 
            labelGrade.AutoSize = true;
            labelGrade.Location = new Point(45, 150);
            labelGrade.Name = "labelGrade";
            labelGrade.Size = new Size(88, 15);
            labelGrade.TabIndex = 7;
            labelGrade.Text = "Средний балл:";
            // 
            // numericGrade
            // 
            numericGrade.DecimalPlaces = 2;
            numericGrade.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericGrade.Location = new Point(147, 150);
            numericGrade.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericGrade.Name = "numericGrade";
            numericGrade.Size = new Size(120, 23);
            numericGrade.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(70, 201);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(503, 353);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(904, 356);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(904, 385);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 12;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(864, 506);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(45, 15);
            labelStatus.TabIndex = 13;
            labelStatus.Text = "Готово";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(877, 414);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(95, 23);
            buttonExport.TabIndex = 14;
            buttonExport.Text = "Экспорт в CSV";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(877, 443);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 266);
            label.Name = "label";
            label.Size = new Size(92, 15);
            label.TabIndex = 16;
            label.Text = "Поиск по ФИО:";
            label.Click += label1_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(110, 266);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(100, 23);
            textBoxSearch.TabIndex = 17;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(113, 295);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 18;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(570, 452);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 19;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(label1);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearch);
            Controls.Add(label);
            Controls.Add(buttonCancel);
            Controls.Add(buttonExport);
            Controls.Add(labelStatus);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(numericGrade);
            Controls.Add(labelGrade);
            Controls.Add(textBoxGroup);
            Controls.Add(labelGroup);
            Controls.Add(numericAge);
            Controls.Add(labelAge);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelAge;
        private NumericUpDown numericAge;
        private Label labelGroup;
        private TextBox textBoxGroup;
        private Label labelGrade;
        private NumericUpDown numericGrade;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
        private Label labelStatus;
        private Button buttonExport;
        private Button buttonCancel;
        private Label label;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private Label label1;
    }
}
