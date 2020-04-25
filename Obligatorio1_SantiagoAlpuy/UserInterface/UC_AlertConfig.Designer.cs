namespace UserInterface
{
    partial class UC_AlertConfig
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
            this.entityBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.postBox = new System.Windows.Forms.TextBox();
            this.daysBox = new System.Windows.Forms.TextBox();
            this.hoursBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // entityBox
            // 
            this.entityBox.AccessibleDescription = "";
            this.entityBox.AccessibleName = "";
            this.entityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityBox.ForeColor = System.Drawing.Color.Gray;
            this.entityBox.Location = new System.Drawing.Point(44, 56);
            this.entityBox.Multiline = true;
            this.entityBox.Name = "entityBox";
            this.entityBox.Size = new System.Drawing.Size(526, 35);
            this.entityBox.TabIndex = 10;
            this.entityBox.Text = "Ingrese el nombre de una entidad";
            this.entityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.entityBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entityBox_KeyDown);
            this.entityBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.entityBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(185, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Crear Configuración de Alarma";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(590, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 38);
            this.panel1.TabIndex = 13;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(44, 290);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(665, 100);
            this.dataGrid.TabIndex = 11;
            // 
            // postBox
            // 
            this.postBox.AccessibleDescription = "";
            this.postBox.AccessibleName = "";
            this.postBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postBox.ForeColor = System.Drawing.Color.Gray;
            this.postBox.Location = new System.Drawing.Point(44, 128);
            this.postBox.Multiline = true;
            this.postBox.Name = "postBox";
            this.postBox.Size = new System.Drawing.Size(526, 35);
            this.postBox.TabIndex = 15;
            this.postBox.Text = "Ingrese la cantidad de posts para activar la alarma";
            this.postBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.postBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.postBox_KeyDown);
            this.postBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.postBox_KeyPress);
            this.postBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.postBox_KeyUp);
            // 
            // daysBox
            // 
            this.daysBox.AccessibleDescription = "";
            this.daysBox.AccessibleName = "";
            this.daysBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daysBox.ForeColor = System.Drawing.Color.Gray;
            this.daysBox.Location = new System.Drawing.Point(44, 169);
            this.daysBox.Multiline = true;
            this.daysBox.Name = "daysBox";
            this.daysBox.Size = new System.Drawing.Size(526, 35);
            this.daysBox.TabIndex = 16;
            this.daysBox.Text = "Ingrese el rango de días para activar la alarma";
            this.daysBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.daysBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.daysBox_KeyDown);
            this.daysBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.daysBox_KeyPress);
            this.daysBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.daysBox_KeyUp);
            // 
            // hoursBox
            // 
            this.hoursBox.AccessibleDescription = "";
            this.hoursBox.AccessibleName = "";
            this.hoursBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursBox.ForeColor = System.Drawing.Color.Gray;
            this.hoursBox.Location = new System.Drawing.Point(44, 210);
            this.hoursBox.Multiline = true;
            this.hoursBox.Name = "hoursBox";
            this.hoursBox.Size = new System.Drawing.Size(526, 35);
            this.hoursBox.TabIndex = 17;
            this.hoursBox.Text = "Ingrese el rango de horas para activar la alarma";
            this.hoursBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hoursBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoursBox_KeyDown);
            this.hoursBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hoursBox_KeyPress);
            this.hoursBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hoursBox_KeyUp);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.ForeColor = System.Drawing.Color.Gray;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Seleccione una categoría positiva o negativa"});
            this.categoryComboBox.Location = new System.Drawing.Point(44, 98);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(526, 24);
            this.categoryComboBox.TabIndex = 18;
            this.categoryComboBox.SelectedValueChanged += new System.EventHandler(this.categoryComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(300, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Todas las Alarmas";
            // 
            // UC_AlertConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.hoursBox);
            this.Controls.Add(this.daysBox);
            this.Controls.Add(this.postBox);
            this.Controls.Add(this.entityBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid);
            this.Name = "UC_AlertConfig";
            this.Size = new System.Drawing.Size(762, 408);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entityBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox postBox;
        private System.Windows.Forms.TextBox daysBox;
        private System.Windows.Forms.TextBox hoursBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label2;
    }
}
