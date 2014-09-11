namespace DblFin
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_path = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_analyzer = new System.Windows.Forms.Button();
            this.lbl_numberOfFolder = new System.Windows.Forms.Label();
            this.lbl_numberOfFile = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_status = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(47, 12);
            this.tb_path.Name = "tb_path";
            this.tb_path.ReadOnly = true;
            this.tb_path.Size = new System.Drawing.Size(325, 20);
            this.tb_path.TabIndex = 1;
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(378, 12);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(75, 20);
            this.btn_path.TabIndex = 2;
            this.btn_path.Text = "...";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_status);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.lbl_numberOfFile);
            this.groupBox1.Controls.Add(this.lbl_numberOfFolder);
            this.groupBox1.Controls.Add(this.btn_analyzer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 296);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Files found :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Folder Found : ";
            // 
            // btn_analyzer
            // 
            this.btn_analyzer.Location = new System.Drawing.Point(360, 19);
            this.btn_analyzer.Name = "btn_analyzer";
            this.btn_analyzer.Size = new System.Drawing.Size(75, 23);
            this.btn_analyzer.TabIndex = 2;
            this.btn_analyzer.Text = "Analyze";
            this.btn_analyzer.UseVisualStyleBackColor = true;
            this.btn_analyzer.Click += new System.EventHandler(this.btn_analyzer_Click);
            // 
            // lbl_numberOfFolder
            // 
            this.lbl_numberOfFolder.AutoSize = true;
            this.lbl_numberOfFolder.Location = new System.Drawing.Point(90, 42);
            this.lbl_numberOfFolder.Name = "lbl_numberOfFolder";
            this.lbl_numberOfFolder.Size = new System.Drawing.Size(13, 13);
            this.lbl_numberOfFolder.TabIndex = 3;
            this.lbl_numberOfFolder.Text = "0";
            // 
            // lbl_numberOfFile
            // 
            this.lbl_numberOfFile.AutoSize = true;
            this.lbl_numberOfFile.Location = new System.Drawing.Point(90, 63);
            this.lbl_numberOfFile.Name = "lbl_numberOfFile";
            this.lbl_numberOfFile.Size = new System.Drawing.Size(13, 13);
            this.lbl_numberOfFile.TabIndex = 4;
            this.lbl_numberOfFile.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 267);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(426, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(0, 163);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(44, 13);
            this.lbl_status.TabIndex = 5;
            this.lbl_status.Text = "PONEY";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 346);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "DblFin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_analyzer;
        private System.Windows.Forms.Label lbl_numberOfFolder;
        private System.Windows.Forms.Label lbl_numberOfFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_status;
    }
}

