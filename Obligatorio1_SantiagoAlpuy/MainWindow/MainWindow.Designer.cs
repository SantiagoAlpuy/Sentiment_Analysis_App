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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRegPos = new System.Windows.Forms.Button();
            this.btnRegNeg = new System.Windows.Forms.Button();
            this.btnRegEnt = new System.Windows.Forms.Button();
            this.btnAddPhrase = new System.Windows.Forms.Button();
            this.btnMngAlert = new System.Windows.Forms.Button();
            this.btnRepAn = new System.Windows.Forms.Button();
            this.btnRepAlert = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Teal;
            this.flowLayoutPanel1.Controls.Add(this.btnRegPos);
            this.flowLayoutPanel1.Controls.Add(this.btnRegNeg);
            this.flowLayoutPanel1.Controls.Add(this.btnRegEnt);
            this.flowLayoutPanel1.Controls.Add(this.btnAddPhrase);
            this.flowLayoutPanel1.Controls.Add(this.btnMngAlert);
            this.flowLayoutPanel1.Controls.Add(this.btnRepAn);
            this.flowLayoutPanel1.Controls.Add(this.btnRepAlert);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(183, 464);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnRegPos
            // 
            this.btnRegPos.Location = new System.Drawing.Point(3, 3);
            this.btnRegPos.Name = "btnRegPos";
            this.btnRegPos.Size = new System.Drawing.Size(177, 60);
            this.btnRegPos.TabIndex = 0;
            this.btnRegPos.Text = "Registrar Sentimiento Positivo";
            this.btnRegPos.UseVisualStyleBackColor = true;
            this.btnRegPos.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegNeg
            // 
            this.btnRegNeg.Location = new System.Drawing.Point(3, 69);
            this.btnRegNeg.Name = "btnRegNeg";
            this.btnRegNeg.Size = new System.Drawing.Size(177, 60);
            this.btnRegNeg.TabIndex = 1;
            this.btnRegNeg.Text = "Registrar Sentimiento Negativo";
            this.btnRegNeg.UseVisualStyleBackColor = true;
            // 
            // btnRegEnt
            // 
            this.btnRegEnt.Location = new System.Drawing.Point(3, 135);
            this.btnRegEnt.Name = "btnRegEnt";
            this.btnRegEnt.Size = new System.Drawing.Size(177, 60);
            this.btnRegEnt.TabIndex = 2;
            this.btnRegEnt.Text = "Registrar Entidades";
            this.btnRegEnt.UseVisualStyleBackColor = true;
            // 
            // btnAddPhrase
            // 
            this.btnAddPhrase.Location = new System.Drawing.Point(3, 201);
            this.btnAddPhrase.Name = "btnAddPhrase";
            this.btnAddPhrase.Size = new System.Drawing.Size(177, 60);
            this.btnAddPhrase.TabIndex = 3;
            this.btnAddPhrase.Text = "Ingresar Frase";
            this.btnAddPhrase.UseVisualStyleBackColor = true;
            // 
            // btnMngAlert
            // 
            this.btnMngAlert.Location = new System.Drawing.Point(3, 267);
            this.btnMngAlert.Name = "btnMngAlert";
            this.btnMngAlert.Size = new System.Drawing.Size(177, 60);
            this.btnMngAlert.TabIndex = 4;
            this.btnMngAlert.Text = "Crear Configuración de Alarma";
            this.btnMngAlert.UseVisualStyleBackColor = true;
            // 
            // btnRepAn
            // 
            this.btnRepAn.Location = new System.Drawing.Point(3, 333);
            this.btnRepAn.Name = "btnRepAn";
            this.btnRepAn.Size = new System.Drawing.Size(177, 60);
            this.btnRepAn.TabIndex = 5;
            this.btnRepAn.Text = "Reporte de Análisis";
            this.btnRepAn.UseVisualStyleBackColor = true;
            // 
            // btnRepAlert
            // 
            this.btnRepAlert.Location = new System.Drawing.Point(3, 399);
            this.btnRepAlert.Name = "btnRepAlert";
            this.btnRepAlert.Size = new System.Drawing.Size(177, 60);
            this.btnRepAlert.TabIndex = 6;
            this.btnRepAlert.Text = "Reporte de Alarmas";
            this.btnRepAlert.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(194, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(787, 463);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(984, 463);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 502);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 502);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRegPos;
        private System.Windows.Forms.Button btnRegNeg;
        private System.Windows.Forms.Button btnRegEnt;
        private System.Windows.Forms.Button btnAddPhrase;
        private System.Windows.Forms.Button btnMngAlert;
        private System.Windows.Forms.Button btnRepAn;
        private System.Windows.Forms.Button btnRepAlert;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

