namespace FileImporterApp.TextFiles
{
    partial class ImportTextForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrior = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wizardPane = new System.Windows.Forms.Panel();
            this.importTextPage3Control1 = new FileImporterApp.TextFiles.ImportTextPage3Control();
            this.importTextPage2Control1 = new FileImporterApp.TextFiles.ImportTextPage2Control();
            this.importTextPage1Control1 = new FileImporterApp.TextFiles.ImportTextPage1Control();
            this.panel2.SuspendLayout();
            this.wizardPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrior);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnFinalize);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 43);
            this.panel2.TabIndex = 14;
            // 
            // btnPrior
            // 
            this.btnPrior.Location = new System.Drawing.Point(258, 8);
            this.btnPrior.Name = "btnPrior";
            this.btnPrior.Size = new System.Drawing.Size(75, 23);
            this.btnPrior.TabIndex = 3;
            this.btnPrior.Text = "< Anterior";
            this.btnPrior.UseVisualStyleBackColor = true;
            this.btnPrior.Click += new System.EventHandler(this.BtnPrior_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(339, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Siguiente >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnFinalize
            // 
            this.btnFinalize.Location = new System.Drawing.Point(420, 8);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(75, 23);
            this.btnFinalize.TabIndex = 1;
            this.btnFinalize.Text = "Finalizar";
            this.btnFinalize.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(501, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // wizardPane
            // 
            this.wizardPane.Controls.Add(this.importTextPage3Control1);
            this.wizardPane.Controls.Add(this.importTextPage2Control1);
            this.wizardPane.Controls.Add(this.importTextPage1Control1);
            this.wizardPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPane.Location = new System.Drawing.Point(0, 0);
            this.wizardPane.Name = "wizardPane";
            this.wizardPane.Size = new System.Drawing.Size(614, 378);
            this.wizardPane.TabIndex = 15;
            // 
            // importTextPage3Control1
            // 
            this.importTextPage3Control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importTextPage3Control1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importTextPage3Control1.Location = new System.Drawing.Point(0, 0);
            this.importTextPage3Control1.Name = "importTextPage3Control1";
            this.importTextPage3Control1.Size = new System.Drawing.Size(614, 378);
            this.importTextPage3Control1.TabIndex = 2;
            // 
            // importTextPage2Control1
            // 
            this.importTextPage2Control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importTextPage2Control1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importTextPage2Control1.Location = new System.Drawing.Point(0, 0);
            this.importTextPage2Control1.Name = "importTextPage2Control1";
            this.importTextPage2Control1.Size = new System.Drawing.Size(614, 378);
            this.importTextPage2Control1.TabIndex = 1;
            // 
            // importTextPage1Control1
            // 
            this.importTextPage1Control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importTextPage1Control1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importTextPage1Control1.Location = new System.Drawing.Point(0, 0);
            this.importTextPage1Control1.Name = "importTextPage1Control1";
            this.importTextPage1Control1.Size = new System.Drawing.Size(614, 378);
            this.importTextPage1Control1.TabIndex = 0;
            // 
            // ImportTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 421);
            this.Controls.Add(this.wizardPane);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportTextForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar archivo de texto";
            this.panel2.ResumeLayout(false);
            this.wizardPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrior;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel wizardPane;
        private ImportTextPage1Control importTextPage1Control1;
        private ImportTextPage2Control importTextPage2Control1;
        private ImportTextPage3Control importTextPage3Control1;
    }
}