
namespace Unit_test_ИС
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxМагазин = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxТовар = new System.Windows.Forms.TextBox();
            this.textBoxПоставщик = new System.Windows.Forms.TextBox();
            this.dateTimePickerОт = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerДо = new System.Windows.Forms.DateTimePicker();
            this.labelОт = new System.Windows.Forms.Label();
            this.labelДо = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "Получить номенклатуру и объем товаров в указанной торговой точке";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonQuery1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 106);
            this.button2.TabIndex = 4;
            this.button2.Text = "Получить сведения о поставках определенного товара указанным  поставщиком за все " +
    "время поставок, либо за некоторый период";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonQuery2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(644, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 82);
            this.button3.TabIndex = 6;
            this.button3.Text = "Получить сведения о поставках товаров по указанному номеру заказа";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonQuery3);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 310);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 280);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.TabStop = false;
            // 
            // textBoxМагазин
            // 
            this.textBoxМагазин.Location = new System.Drawing.Point(12, 26);
            this.textBoxМагазин.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxМагазин.Name = "textBoxМагазин";
            this.textBoxМагазин.Size = new System.Drawing.Size(146, 20);
            this.textBoxМагазин.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите название магазина";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(643, 27);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Введите номер заказа";
            // 
            // textBoxТовар
            // 
            this.textBoxТовар.Location = new System.Drawing.Point(321, 27);
            this.textBoxТовар.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxТовар.Name = "textBoxТовар";
            this.textBoxТовар.Size = new System.Drawing.Size(146, 20);
            this.textBoxТовар.TabIndex = 2;
            // 
            // textBoxПоставщик
            // 
            this.textBoxПоставщик.Location = new System.Drawing.Point(321, 66);
            this.textBoxПоставщик.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxПоставщик.Name = "textBoxПоставщик";
            this.textBoxПоставщик.Size = new System.Drawing.Size(146, 20);
            this.textBoxПоставщик.TabIndex = 3;
            // 
            // dateTimePickerОт
            // 
            this.dateTimePickerОт.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerОт.Location = new System.Drawing.Point(321, 246);
            this.dateTimePickerОт.Name = "dateTimePickerОт";
            this.dateTimePickerОт.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerОт.TabIndex = 8;
            this.dateTimePickerОт.TabStop = false;
            this.dateTimePickerОт.Visible = false;
            // 
            // dateTimePickerДо
            // 
            this.dateTimePickerДо.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerДо.Location = new System.Drawing.Point(321, 285);
            this.dateTimePickerДо.Name = "dateTimePickerДо";
            this.dateTimePickerДо.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerДо.TabIndex = 9;
            this.dateTimePickerДо.TabStop = false;
            this.dateTimePickerДо.Visible = false;
            // 
            // labelОт
            // 
            this.labelОт.AutoSize = true;
            this.labelОт.Location = new System.Drawing.Point(328, 230);
            this.labelОт.Name = "labelОт";
            this.labelОт.Size = new System.Drawing.Size(20, 13);
            this.labelОт.TabIndex = 10;
            this.labelОт.Text = "От";
            this.labelОт.Visible = false;
            // 
            // labelДо
            // 
            this.labelДо.AutoSize = true;
            this.labelДо.Location = new System.Drawing.Point(326, 268);
            this.labelДо.Name = "labelДо";
            this.labelДо.Size = new System.Drawing.Size(22, 13);
            this.labelДо.TabIndex = 10;
            this.labelДо.Text = "До";
            this.labelДо.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(331, 211);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(126, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "Определённая дата";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Введите код поставщика";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Введите код товара";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(25, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Внести";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(118, 174);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.labelДо);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelОт);
            this.Controls.Add(this.dateTimePickerДо);
            this.Controls.Add(this.dateTimePickerОт);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxПоставщик);
            this.Controls.Add(this.textBoxТовар);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxМагазин);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxМагазин;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxТовар;
        private System.Windows.Forms.TextBox textBoxПоставщик;
        private System.Windows.Forms.DateTimePicker dateTimePickerОт;
        private System.Windows.Forms.DateTimePicker dateTimePickerДо;
        private System.Windows.Forms.Label labelОт;
        private System.Windows.Forms.Label labelДо;
        public System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

