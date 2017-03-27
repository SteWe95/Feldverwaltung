namespace Feldverwaltung
{
    partial class Feldverwaltung
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.gb_Auftragsliste = new System.Windows.Forms.GroupBox();
            this.btn_CreateTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(70, 10);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(137, 20);
            this.tb_Name.TabIndex = 1;
            // 
            // gb_Auftragsliste
            // 
            this.gb_Auftragsliste.Location = new System.Drawing.Point(12, 40);
            this.gb_Auftragsliste.Name = "gb_Auftragsliste";
            this.gb_Auftragsliste.Size = new System.Drawing.Size(539, 486);
            this.gb_Auftragsliste.TabIndex = 2;
            this.gb_Auftragsliste.TabStop = false;
            this.gb_Auftragsliste.Text = "Aufträge";
            // 
            // btn_CreateTask
            // 
            this.btn_CreateTask.Location = new System.Drawing.Point(557, 55);
            this.btn_CreateTask.Name = "btn_CreateTask";
            this.btn_CreateTask.Size = new System.Drawing.Size(121, 33);
            this.btn_CreateTask.TabIndex = 3;
            this.btn_CreateTask.Text = "Aufgabe anlegen";
            this.btn_CreateTask.UseVisualStyleBackColor = true;
            // 
            // Feldverwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 537);
            this.Controls.Add(this.btn_CreateTask);
            this.Controls.Add(this.gb_Auftragsliste);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label1);
            this.Name = "Feldverwaltung";
            this.Text = "Feldverwaltung - Auftragsliste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.GroupBox gb_Auftragsliste;
        private System.Windows.Forms.Button btn_CreateTask;
    }
}

