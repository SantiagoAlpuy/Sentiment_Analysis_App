namespace UserInterface
{
    partial class UC_ManageAuthors
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.authorNameBox = new System.Windows.Forms.TextBox();
            this.authorSurnameBox = new System.Windows.Forms.TextBox();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.authorsDataGrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.editBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorsDataGrid)).BeginInit();
            this.btnDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(190, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestión de Autores";
            // 
            // usernameBox
            // 
            this.usernameBox.AccessibleDescription = "";
            this.usernameBox.AccessibleName = "";
            this.usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.ForeColor = System.Drawing.Color.Gray;
            this.usernameBox.Location = new System.Drawing.Point(60, 76);
            this.usernameBox.Multiline = true;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(526, 35);
            this.usernameBox.TabIndex = 11;
            this.usernameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // authorNameBox
            // 
            this.authorNameBox.AccessibleDescription = "";
            this.authorNameBox.AccessibleName = "";
            this.authorNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorNameBox.ForeColor = System.Drawing.Color.Gray;
            this.authorNameBox.Location = new System.Drawing.Point(60, 134);
            this.authorNameBox.Multiline = true;
            this.authorNameBox.Name = "authorNameBox";
            this.authorNameBox.Size = new System.Drawing.Size(526, 35);
            this.authorNameBox.TabIndex = 12;
            this.authorNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // authorSurnameBox
            // 
            this.authorSurnameBox.AccessibleDescription = "";
            this.authorSurnameBox.AccessibleName = "";
            this.authorSurnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorSurnameBox.ForeColor = System.Drawing.Color.Gray;
            this.authorSurnameBox.Location = new System.Drawing.Point(60, 195);
            this.authorSurnameBox.Multiline = true;
            this.authorSurnameBox.Name = "authorSurnameBox";
            this.authorSurnameBox.Size = new System.Drawing.Size(526, 35);
            this.authorSurnameBox.TabIndex = 13;
            this.authorSurnameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.CustomFormat = "dd\'/\'MM\'/\'yyyy";
            this.birthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthDatePicker.Location = new System.Drawing.Point(60, 255);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(526, 20);
            this.birthDatePicker.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Ingrese su Fecha de Nacimiento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(604, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 38);
            this.panel1.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Agregar";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Image = global::UserInterface.Properties.Resources.icons8_add_36;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 38);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(252, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ingrese su Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ingrese su Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(222, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Ingrese su Nombre de Usuario";
            // 
            // authorsDataGrid
            // 
            this.authorsDataGrid.AllowUserToResizeColumns = false;
            this.authorsDataGrid.AllowUserToResizeRows = false;
            this.authorsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.authorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.authorsDataGrid.Location = new System.Drawing.Point(60, 307);
            this.authorsDataGrid.MultiSelect = false;
            this.authorsDataGrid.Name = "authorsDataGrid";
            this.authorsDataGrid.ReadOnly = true;
            this.authorsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.authorsDataGrid.Size = new System.Drawing.Size(526, 146);
            this.authorsDataGrid.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(222, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Autores Agregados al Sistema";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Controls.Add(this.label8);
            this.btnDelete.Controls.Add(this.btnRemove);
            this.btnDelete.Location = new System.Drawing.Point(262, 457);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 43);
            this.btnDelete.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Eliminar";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemove.Image = global::UserInterface.Properties.Resources.icons8_delete_36;
            this.btnRemove.Location = new System.Drawing.Point(3, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(41, 41);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.TabStop = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.editBox);
            this.panel2.Location = new System.Drawing.Point(460, 492);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 38);
            this.panel2.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ir a Edición de Autores";
            // 
            // editBox
            // 
            this.editBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editBox.BackColor = System.Drawing.Color.Transparent;
            this.editBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editBox.Image = global::UserInterface.Properties.Resources.icons8_edit_36__1_;
            this.editBox.Location = new System.Drawing.Point(0, 2);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(37, 38);
            this.editBox.TabIndex = 5;
            this.editBox.TabStop = false;
            this.editBox.Click += new System.EventHandler(this.editBox_Click);
            // 
            // UC_ManageAuthors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.authorsDataGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.birthDatePicker);
            this.Controls.Add(this.authorSurnameBox);
            this.Controls.Add(this.authorNameBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.Name = "UC_ManageAuthors";
            this.Size = new System.Drawing.Size(759, 544);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorsDataGrid)).EndInit();
            this.btnDelete.ResumeLayout(false);
            this.btnDelete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox authorNameBox;
        private System.Windows.Forms.TextBox authorSurnameBox;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView authorsDataGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel btnDelete;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox btnRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox editBox;
    }
}
