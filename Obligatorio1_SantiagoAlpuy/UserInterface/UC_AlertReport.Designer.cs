namespace UserInterface
{
    partial class UC_AlertReport
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.alertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.authorsBox = new System.Windows.Forms.ListBox();
            this.listBoxPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.listBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(241, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Reporte de Alarmas Activas";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(49, 218);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(665, 314);
            this.dataGrid.TabIndex = 13;
            this.dataGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Seleccione un Tipo de Alarma";
            // 
            // alertTypeComboBox
            // 
            this.alertTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alertTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alertTypeComboBox.FormattingEnabled = true;
            this.alertTypeComboBox.Location = new System.Drawing.Point(49, 176);
            this.alertTypeComboBox.Name = "alertTypeComboBox";
            this.alertTypeComboBox.Size = new System.Drawing.Size(665, 21);
            this.alertTypeComboBox.TabIndex = 35;
            this.alertTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.alertTypeComboBox_SelectedIndexChanged);
            // 
            // authorsBox
            // 
            this.authorsBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.authorsBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.authorsBox.FormattingEnabled = true;
            this.authorsBox.Location = new System.Drawing.Point(3, 54);
            this.authorsBox.Name = "authorsBox";
            this.authorsBox.ScrollAlwaysVisible = true;
            this.authorsBox.Size = new System.Drawing.Size(315, 134);
            this.authorsBox.TabIndex = 37;
            // 
            // listBoxPanel
            // 
            this.listBoxPanel.Controls.Add(this.btnCloseWindow);
            this.listBoxPanel.Controls.Add(this.label3);
            this.listBoxPanel.Controls.Add(this.authorsBox);
            this.listBoxPanel.Location = new System.Drawing.Point(228, 139);
            this.listBoxPanel.Name = "listBoxPanel";
            this.listBoxPanel.Size = new System.Drawing.Size(321, 230);
            this.listBoxPanel.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Autores de Alarma Seleccionada";
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Location = new System.Drawing.Point(3, 194);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(315, 33);
            this.btnCloseWindow.TabIndex = 39;
            this.btnCloseWindow.Text = "Cerrar Ventana";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(372, 123);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(367, 13);
            this.infoLabel.TabIndex = 39;
            this.infoLabel.Text = "Haga doble click en una alarma para ver los autores que activaron la misma.";
            // 
            // UC_AlertReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.listBoxPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.alertTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid);
            this.Name = "UC_AlertReport";
            this.Size = new System.Drawing.Size(762, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.listBoxPanel.ResumeLayout(false);
            this.listBoxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox alertTypeComboBox;
        private System.Windows.Forms.ListBox authorsBox;
        private System.Windows.Forms.Panel listBoxPanel;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label infoLabel;
    }
}
