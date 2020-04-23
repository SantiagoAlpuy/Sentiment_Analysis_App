namespace UserInterface
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.uC_ManagePosSentiment1 = new UserInterface.UC_ManagePosSentiment();
            this.uC_ManagePhrases1 = new UserInterface.UC_ManagePhrases();
            this.uC_ManageNegSentiment1 = new UserInterface.UC_ManageNegSentiment();
            this.uC_ManageEntities1 = new UserInterface.UC_ManageEntities();
            this.uC_AnalysisReport1 = new UserInterface.UC_AnalysisReport();
            this.uC_AlertReport1 = new UserInterface.UC_AlertReport();
            this.uC_AlertConfig1 = new UserInterface.UC_AlertConfig();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 410);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gestionar Sentimientos Positivos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(3, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Gestionar Sentimientos Negativos";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(3, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "Gestionar Entidades";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(3, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(205, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "Agregar Frase";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DodgerBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(3, 235);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(205, 52);
            this.button5.TabIndex = 4;
            this.button5.Text = "Crear Configuraciones de Alarmas";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DodgerBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(3, 293);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(205, 52);
            this.button6.TabIndex = 5;
            this.button6.Text = "Reporte de Análisis";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DodgerBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Location = new System.Drawing.Point(3, 351);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(205, 52);
            this.button7.TabIndex = 6;
            this.button7.Text = "Reporte de Alarmas";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // uC_ManagePosSentiment1
            // 
            this.uC_ManagePosSentiment1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManagePosSentiment1.Name = "uC_ManagePosSentiment1";
            this.uC_ManagePosSentiment1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManagePosSentiment1.TabIndex = 7;
            // 
            // uC_ManagePhrases1
            // 
            this.uC_ManagePhrases1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManagePhrases1.Name = "uC_ManagePhrases1";
            this.uC_ManagePhrases1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManagePhrases1.TabIndex = 6;
            // 
            // uC_ManageNegSentiment1
            // 
            this.uC_ManageNegSentiment1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManageNegSentiment1.Name = "uC_ManageNegSentiment1";
            this.uC_ManageNegSentiment1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManageNegSentiment1.TabIndex = 5;
            // 
            // uC_ManageEntities1
            // 
            this.uC_ManageEntities1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManageEntities1.Name = "uC_ManageEntities1";
            this.uC_ManageEntities1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManageEntities1.TabIndex = 4;
            // 
            // uC_AnalysisReport1
            // 
            this.uC_AnalysisReport1.Location = new System.Drawing.Point(216, 3);
            this.uC_AnalysisReport1.Name = "uC_AnalysisReport1";
            this.uC_AnalysisReport1.Size = new System.Drawing.Size(762, 408);
            this.uC_AnalysisReport1.TabIndex = 3;
            // 
            // uC_AlertReport1
            // 
            this.uC_AlertReport1.Location = new System.Drawing.Point(216, 3);
            this.uC_AlertReport1.Name = "uC_AlertReport1";
            this.uC_AlertReport1.Size = new System.Drawing.Size(762, 408);
            this.uC_AlertReport1.TabIndex = 2;
            // 
            // uC_AlertConfig1
            // 
            this.uC_AlertConfig1.Location = new System.Drawing.Point(216, 3);
            this.uC_AlertConfig1.Name = "uC_AlertConfig1";
            this.uC_AlertConfig1.Size = new System.Drawing.Size(762, 408);
            this.uC_AlertConfig1.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.ClientSize = new System.Drawing.Size(980, 407);
            this.Controls.Add(this.uC_ManagePosSentiment1);
            this.Controls.Add(this.uC_ManagePhrases1);
            this.Controls.Add(this.uC_ManageNegSentiment1);
            this.Controls.Add(this.uC_ManageEntities1);
            this.Controls.Add(this.uC_AnalysisReport1);
            this.Controls.Add(this.uC_AlertReport1);
            this.Controls.Add(this.uC_AlertConfig1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 450);
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAtter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private UC_AlertConfig uC_AlertConfig1;
        private UC_AlertReport uC_AlertReport1;
        private UC_AnalysisReport uC_AnalysisReport1;
        private UC_ManageEntities uC_ManageEntities1;
        private UC_ManageNegSentiment uC_ManageNegSentiment1;
        private UC_ManagePhrases uC_ManagePhrases1;
        private UC_ManagePosSentiment uC_ManagePosSentiment1;
    }
}

