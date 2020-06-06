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
            this.btnManageAuthors = new System.Windows.Forms.Button();
            this.btnManagePositiveSentiment = new System.Windows.Forms.Button();
            this.btnManageNegativeSentiment = new System.Windows.Forms.Button();
            this.btnManageEntities = new System.Windows.Forms.Button();
            this.btnManagePhrases = new System.Windows.Forms.Button();
            this.btnAlertConfig = new System.Windows.Forms.Button();
            this.btnAlertConfigB = new System.Windows.Forms.Button();
            this.btnAnalysisReport = new System.Windows.Forms.Button();
            this.btnAlertReport = new System.Windows.Forms.Button();
            this.btnAuthorReport = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.PrincipalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uC_ManagePosSentiment1 = new UserInterface.UC_ManagePosSentiment();
            this.uC_ManagePhrases1 = new UserInterface.UC_ManagePhrases();
            this.uC_ManageNegSentiment1 = new UserInterface.UC_ManageNegSentiment();
            this.uC_ManageEntities1 = new UserInterface.UC_ManageEntities();
            this.uC_AnalysisReport1 = new UserInterface.UC_AnalysisReport();
            this.uC_AlertReport1 = new UserInterface.UC_AlertReport();
            this.uC_AlertConfig1 = new UserInterface.UC_AlertAConfig();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanel1.Controls.Add(this.btnManageAuthors);
            this.flowLayoutPanel1.Controls.Add(this.btnManagePositiveSentiment);
            this.flowLayoutPanel1.Controls.Add(this.btnManageNegativeSentiment);
            this.flowLayoutPanel1.Controls.Add(this.btnManageEntities);
            this.flowLayoutPanel1.Controls.Add(this.btnManagePhrases);
            this.flowLayoutPanel1.Controls.Add(this.btnAlertConfig);
            this.flowLayoutPanel1.Controls.Add(this.btnAlertConfigB);
            this.flowLayoutPanel1.Controls.Add(this.btnAnalysisReport);
            this.flowLayoutPanel1.Controls.Add(this.btnAlertReport);
            this.flowLayoutPanel1.Controls.Add(this.btnAuthorReport);
            this.flowLayoutPanel1.Controls.Add(this.btnHelp);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 558);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnManageAuthors
            // 
            this.btnManageAuthors.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManageAuthors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnManageAuthors.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageAuthors.Location = new System.Drawing.Point(3, 3);
            this.btnManageAuthors.Name = "btnManageAuthors";
            this.btnManageAuthors.Size = new System.Drawing.Size(205, 46);
            this.btnManageAuthors.TabIndex = 9;
            this.btnManageAuthors.Text = "Gestionar Autores";
            this.btnManageAuthors.UseVisualStyleBackColor = false;
            this.btnManageAuthors.Click += new System.EventHandler(this.btnManageAuthors_Click_1);
            // 
            // btnManagePositiveSentiment
            // 
            this.btnManagePositiveSentiment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManagePositiveSentiment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManagePositiveSentiment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePositiveSentiment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManagePositiveSentiment.Location = new System.Drawing.Point(3, 55);
            this.btnManagePositiveSentiment.Name = "btnManagePositiveSentiment";
            this.btnManagePositiveSentiment.Size = new System.Drawing.Size(205, 45);
            this.btnManagePositiveSentiment.TabIndex = 0;
            this.btnManagePositiveSentiment.Text = "Gestionar Sentimientos Positivos";
            this.btnManagePositiveSentiment.UseVisualStyleBackColor = false;
            this.btnManagePositiveSentiment.Click += new System.EventHandler(this.btnManagePositiveSentiment_Click);
            // 
            // btnManageNegativeSentiment
            // 
            this.btnManageNegativeSentiment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManageNegativeSentiment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageNegativeSentiment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnManageNegativeSentiment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageNegativeSentiment.Location = new System.Drawing.Point(3, 106);
            this.btnManageNegativeSentiment.Name = "btnManageNegativeSentiment";
            this.btnManageNegativeSentiment.Size = new System.Drawing.Size(205, 45);
            this.btnManageNegativeSentiment.TabIndex = 1;
            this.btnManageNegativeSentiment.Text = "Gestionar Sentimientos Negativos";
            this.btnManageNegativeSentiment.UseVisualStyleBackColor = false;
            this.btnManageNegativeSentiment.Click += new System.EventHandler(this.btnManageNegativeSentiment_Click);
            // 
            // btnManageEntities
            // 
            this.btnManageEntities.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManageEntities.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnManageEntities.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageEntities.Location = new System.Drawing.Point(3, 157);
            this.btnManageEntities.Name = "btnManageEntities";
            this.btnManageEntities.Size = new System.Drawing.Size(205, 43);
            this.btnManageEntities.TabIndex = 2;
            this.btnManageEntities.Text = "Gestionar Entidades";
            this.btnManageEntities.UseVisualStyleBackColor = false;
            this.btnManageEntities.Click += new System.EventHandler(this.btnManageEntities_Click);
            // 
            // btnManagePhrases
            // 
            this.btnManagePhrases.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManagePhrases.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManagePhrases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnManagePhrases.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManagePhrases.Location = new System.Drawing.Point(3, 206);
            this.btnManagePhrases.Name = "btnManagePhrases";
            this.btnManagePhrases.Size = new System.Drawing.Size(205, 43);
            this.btnManagePhrases.TabIndex = 3;
            this.btnManagePhrases.Text = "Agregar Frase";
            this.btnManagePhrases.UseVisualStyleBackColor = false;
            this.btnManagePhrases.Click += new System.EventHandler(this.btnManagePhrases_Click);
            // 
            // btnAlertConfig
            // 
            this.btnAlertConfig.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAlertConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlertConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAlertConfig.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlertConfig.Location = new System.Drawing.Point(3, 255);
            this.btnAlertConfig.Name = "btnAlertConfig";
            this.btnAlertConfig.Size = new System.Drawing.Size(205, 43);
            this.btnAlertConfig.TabIndex = 4;
            this.btnAlertConfig.Text = "Configuración de Alarmas A";
            this.btnAlertConfig.UseVisualStyleBackColor = false;
            this.btnAlertConfig.Click += new System.EventHandler(this.btnAlertConfig_Click);
            // 
            // btnAlertConfigB
            // 
            this.btnAlertConfigB.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAlertConfigB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlertConfigB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAlertConfigB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlertConfigB.Location = new System.Drawing.Point(3, 304);
            this.btnAlertConfigB.Name = "btnAlertConfigB";
            this.btnAlertConfigB.Size = new System.Drawing.Size(205, 43);
            this.btnAlertConfigB.TabIndex = 10;
            this.btnAlertConfigB.Text = "Configuración de Alarmas B";
            this.btnAlertConfigB.UseVisualStyleBackColor = false;
            this.btnAlertConfigB.Click += new System.EventHandler(this.btnAlertConfigB_Click);
            // 
            // btnAnalysisReport
            // 
            this.btnAnalysisReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAnalysisReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnalysisReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAnalysisReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnalysisReport.Location = new System.Drawing.Point(3, 353);
            this.btnAnalysisReport.Name = "btnAnalysisReport";
            this.btnAnalysisReport.Size = new System.Drawing.Size(205, 46);
            this.btnAnalysisReport.TabIndex = 5;
            this.btnAnalysisReport.Text = "Reporte de Análisis de Frases ";
            this.btnAnalysisReport.UseVisualStyleBackColor = false;
            this.btnAnalysisReport.Click += new System.EventHandler(this.btnAnalysisReport_Click);
            // 
            // btnAlertReport
            // 
            this.btnAlertReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAlertReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlertReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAlertReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlertReport.Location = new System.Drawing.Point(3, 405);
            this.btnAlertReport.Name = "btnAlertReport";
            this.btnAlertReport.Size = new System.Drawing.Size(205, 46);
            this.btnAlertReport.TabIndex = 6;
            this.btnAlertReport.Text = "Reporte de Alarmas Activas";
            this.btnAlertReport.UseVisualStyleBackColor = false;
            this.btnAlertReport.Click += new System.EventHandler(this.btnAlertReport_Click);
            // 
            // btnAuthorReport
            // 
            this.btnAuthorReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAuthorReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAuthorReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAuthorReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAuthorReport.Location = new System.Drawing.Point(3, 457);
            this.btnAuthorReport.Name = "btnAuthorReport";
            this.btnAuthorReport.Size = new System.Drawing.Size(205, 45);
            this.btnAuthorReport.TabIndex = 11;
            this.btnAuthorReport.Text = "Reporte de Autores";
            this.btnAuthorReport.UseVisualStyleBackColor = false;
            this.btnAuthorReport.Click += new System.EventHandler(this.btnAuthorReport_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHelp.Location = new System.Drawing.Point(3, 508);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(205, 43);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "Ayuda";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.PrincipalPanel.Location = new System.Drawing.Point(218, 1);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(759, 557);
            this.PrincipalPanel.TabIndex = 8;
            // 
            // uC_ManagePosSentiment1
            // 
            this.uC_ManagePosSentiment1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_ManagePosSentiment1.BackgroundImage")));
            this.uC_ManagePosSentiment1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManagePosSentiment1.Name = "uC_ManagePosSentiment1";
            this.uC_ManagePosSentiment1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManagePosSentiment1.TabIndex = 7;
            // 
            // uC_ManagePhrases1
            // 
            this.uC_ManagePhrases1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_ManagePhrases1.BackgroundImage")));
            this.uC_ManagePhrases1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManagePhrases1.Name = "uC_ManagePhrases1";
            this.uC_ManagePhrases1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManagePhrases1.TabIndex = 6;
            // 
            // uC_ManageNegSentiment1
            // 
            this.uC_ManageNegSentiment1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_ManageNegSentiment1.BackgroundImage")));
            this.uC_ManageNegSentiment1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManageNegSentiment1.Name = "uC_ManageNegSentiment1";
            this.uC_ManageNegSentiment1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManageNegSentiment1.TabIndex = 5;
            // 
            // uC_ManageEntities1
            // 
            this.uC_ManageEntities1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_ManageEntities1.BackgroundImage")));
            this.uC_ManageEntities1.Location = new System.Drawing.Point(216, 3);
            this.uC_ManageEntities1.Name = "uC_ManageEntities1";
            this.uC_ManageEntities1.Size = new System.Drawing.Size(762, 408);
            this.uC_ManageEntities1.TabIndex = 4;
            // 
            // uC_AnalysisReport1
            // 
            this.uC_AnalysisReport1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_AnalysisReport1.BackgroundImage")));
            this.uC_AnalysisReport1.Location = new System.Drawing.Point(216, 3);
            this.uC_AnalysisReport1.Name = "uC_AnalysisReport1";
            this.uC_AnalysisReport1.Size = new System.Drawing.Size(762, 408);
            this.uC_AnalysisReport1.TabIndex = 3;
            // 
            // uC_AlertReport1
            // 
            this.uC_AlertReport1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_AlertReport1.BackgroundImage")));
            this.uC_AlertReport1.Location = new System.Drawing.Point(216, 3);
            this.uC_AlertReport1.Name = "uC_AlertReport1";
            this.uC_AlertReport1.Size = new System.Drawing.Size(762, 408);
            this.uC_AlertReport1.TabIndex = 2;
            // 
            // uC_AlertConfig1
            // 
            this.uC_AlertConfig1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_AlertConfig1.BackgroundImage")));
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
            this.ClientSize = new System.Drawing.Size(980, 557);
            this.Controls.Add(this.PrincipalPanel);
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
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
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
        private System.Windows.Forms.Button btnManagePositiveSentiment;
        private System.Windows.Forms.Button btnManageNegativeSentiment;
        private System.Windows.Forms.Button btnManageEntities;
        private System.Windows.Forms.Button btnManagePhrases;
        private System.Windows.Forms.Button btnAlertConfig;
        private System.Windows.Forms.Button btnAnalysisReport;
        private System.Windows.Forms.Button btnAlertReport;
        private UC_AlertAConfig uC_AlertConfig1;
        private UC_AlertReport uC_AlertReport1;
        private UC_AnalysisReport uC_AnalysisReport1;
        private UC_ManageEntities uC_ManageEntities1;
        private UC_ManageNegSentiment uC_ManageNegSentiment1;
        private UC_ManagePhrases uC_ManagePhrases1;
        private UC_ManagePosSentiment uC_ManagePosSentiment1;
        private System.Windows.Forms.FlowLayoutPanel PrincipalPanel;
        private System.Windows.Forms.Button btnManageAuthors;
        private System.Windows.Forms.Button btnAlertConfigB;
        private System.Windows.Forms.Button btnAuthorReport;
        private System.Windows.Forms.Button btnHelp;
    }
}

