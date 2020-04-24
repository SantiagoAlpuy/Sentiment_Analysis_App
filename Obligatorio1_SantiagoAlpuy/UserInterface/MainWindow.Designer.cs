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
            this.btnManagePositiveSentiment = new System.Windows.Forms.Button();
            this.btnManageNegativeSentiment = new System.Windows.Forms.Button();
            this.btnManageEntities = new System.Windows.Forms.Button();
            this.btnManagePhrases = new System.Windows.Forms.Button();
            this.btnAlertConfig = new System.Windows.Forms.Button();
            this.btnAnalysisReport = new System.Windows.Forms.Button();
            this.btnAlertReport = new System.Windows.Forms.Button();
            this.uC_ManagePosSentiment1 = new UserInterface.UC_ManagePosSentiment();
            this.uC_ManagePhrases1 = new UserInterface.UC_ManagePhrases();
            this.uC_ManageNegSentiment1 = new UserInterface.UC_ManageNegSentiment();
            this.uC_ManageEntities1 = new UserInterface.UC_ManageEntities();
            this.uC_AnalysisReport1 = new UserInterface.UC_AnalysisReport();
            this.uC_AlertReport1 = new UserInterface.UC_AlertReport();
            this.uC_AlertConfig1 = new UserInterface.UC_AlertConfig();
            this.PrincipalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanel1.Controls.Add(this.btnManagePositiveSentiment);
            this.flowLayoutPanel1.Controls.Add(this.btnManageNegativeSentiment);
            this.flowLayoutPanel1.Controls.Add(this.btnManageEntities);
            this.flowLayoutPanel1.Controls.Add(this.btnManagePhrases);
            this.flowLayoutPanel1.Controls.Add(this.btnAlertConfig);
            this.flowLayoutPanel1.Controls.Add(this.btnAnalysisReport);
            this.flowLayoutPanel1.Controls.Add(this.btnAlertReport);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 410);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnManagePositiveSentiment
            // 
            this.btnManagePositiveSentiment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManagePositiveSentiment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManagePositiveSentiment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePositiveSentiment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManagePositiveSentiment.Location = new System.Drawing.Point(3, 3);
            this.btnManagePositiveSentiment.Name = "btnManagePositiveSentiment";
            this.btnManagePositiveSentiment.Size = new System.Drawing.Size(205, 52);
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
            this.btnManageNegativeSentiment.Location = new System.Drawing.Point(3, 61);
            this.btnManageNegativeSentiment.Name = "btnManageNegativeSentiment";
            this.btnManageNegativeSentiment.Size = new System.Drawing.Size(205, 52);
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
            this.btnManageEntities.Location = new System.Drawing.Point(3, 119);
            this.btnManageEntities.Name = "btnManageEntities";
            this.btnManageEntities.Size = new System.Drawing.Size(205, 52);
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
            this.btnManagePhrases.Location = new System.Drawing.Point(3, 177);
            this.btnManagePhrases.Name = "btnManagePhrases";
            this.btnManagePhrases.Size = new System.Drawing.Size(205, 52);
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
            this.btnAlertConfig.Location = new System.Drawing.Point(3, 235);
            this.btnAlertConfig.Name = "btnAlertConfig";
            this.btnAlertConfig.Size = new System.Drawing.Size(205, 52);
            this.btnAlertConfig.TabIndex = 4;
            this.btnAlertConfig.Text = "Crear Configuraciones de Alarmas";
            this.btnAlertConfig.UseVisualStyleBackColor = false;
            this.btnAlertConfig.Click += new System.EventHandler(this.btnAlertConfig_Click);
            // 
            // btnAnalysisReport
            // 
            this.btnAnalysisReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAnalysisReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnalysisReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAnalysisReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnalysisReport.Location = new System.Drawing.Point(3, 293);
            this.btnAnalysisReport.Name = "btnAnalysisReport";
            this.btnAnalysisReport.Size = new System.Drawing.Size(205, 52);
            this.btnAnalysisReport.TabIndex = 5;
            this.btnAnalysisReport.Text = "Reporte de Análisis";
            this.btnAnalysisReport.UseVisualStyleBackColor = false;
            this.btnAnalysisReport.Click += new System.EventHandler(this.btnAnalysisReport_Click);
            // 
            // btnAlertReport
            // 
            this.btnAlertReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAlertReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlertReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAlertReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlertReport.Location = new System.Drawing.Point(3, 351);
            this.btnAlertReport.Name = "btnAlertReport";
            this.btnAlertReport.Size = new System.Drawing.Size(205, 52);
            this.btnAlertReport.TabIndex = 6;
            this.btnAlertReport.Text = "Reporte de Alarmas";
            this.btnAlertReport.UseVisualStyleBackColor = false;
            this.btnAlertReport.Click += new System.EventHandler(this.btnAlertReport_Click);
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
            // PrincipalPanel
            // 
            this.PrincipalPanel.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.PrincipalPanel.Location = new System.Drawing.Point(218, 1);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(759, 409);
            this.PrincipalPanel.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.unnamed;
            this.ClientSize = new System.Drawing.Size(980, 407);
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
            this.MaximumSize = new System.Drawing.Size(1000, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 450);
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAtter - Sistema de Análisis de Sentimiento Básico";
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
        private UC_AlertConfig uC_AlertConfig1;
        private UC_AlertReport uC_AlertReport1;
        private UC_AnalysisReport uC_AnalysisReport1;
        private UC_ManageEntities uC_ManageEntities1;
        private UC_ManageNegSentiment uC_ManageNegSentiment1;
        private UC_ManagePhrases uC_ManagePhrases1;
        private UC_ManagePosSentiment uC_ManagePosSentiment1;
        private System.Windows.Forms.FlowLayoutPanel PrincipalPanel;
    }
}

