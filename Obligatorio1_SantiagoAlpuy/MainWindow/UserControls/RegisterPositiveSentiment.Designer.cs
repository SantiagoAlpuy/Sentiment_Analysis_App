namespace UserInterface.Controls
{
    partial class RegisterPositiveSentiment
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.positiveSentimentList = new System.Windows.Forms.ListBox();
            this.statusAfterAdding = new System.Windows.Forms.Label();
            this.btnDeletePosSent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Sentimiento Positivo: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 20);
            this.textBox1.TabIndex = 1;
            // 
            // positiveSentimentList
            // 
            this.positiveSentimentList.FormattingEnabled = true;
            this.positiveSentimentList.Location = new System.Drawing.Point(34, 65);
            this.positiveSentimentList.Name = "positiveSentimentList";
            this.positiveSentimentList.Size = new System.Drawing.Size(633, 251);
            this.positiveSentimentList.TabIndex = 2;
            // 
            // statusAfterAdding
            // 
            this.statusAfterAdding.AutoSize = true;
            this.statusAfterAdding.Location = new System.Drawing.Point(466, 29);
            this.statusAfterAdding.Name = "statusAfterAdding";
            this.statusAfterAdding.Size = new System.Drawing.Size(31, 13);
            this.statusAfterAdding.TabIndex = 3;
            this.statusAfterAdding.Text = "lalala";
            // 
            // btnDeletePosSent
            // 
            this.btnDeletePosSent.Location = new System.Drawing.Point(248, 333);
            this.btnDeletePosSent.Name = "btnDeletePosSent";
            this.btnDeletePosSent.Size = new System.Drawing.Size(176, 23);
            this.btnDeletePosSent.TabIndex = 4;
            this.btnDeletePosSent.Text = "Eliminar Sentimiento";
            this.btnDeletePosSent.UseVisualStyleBackColor = true;
            // 
            // RegisterPositiveSentiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Controls.Add(this.btnDeletePosSent);
            this.Controls.Add(this.statusAfterAdding);
            this.Controls.Add(this.positiveSentimentList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "RegisterPositiveSentiment";
            this.Size = new System.Drawing.Size(711, 379);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox positiveSentimentList;
        private System.Windows.Forms.Label statusAfterAdding;
        private System.Windows.Forms.Button btnDeletePosSent;
    }
}
