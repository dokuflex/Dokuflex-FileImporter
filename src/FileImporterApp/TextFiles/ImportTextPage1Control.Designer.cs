namespace FileImporterApp.TextFiles
{
    partial class ImportTextPage1Control
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
            this.components = new System.ComponentModel.Container();
            this.cbxDocumentryTypes = new System.Windows.Forms.ComboBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseCloud = new System.Windows.Forms.Button();
            this.tbxFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowsePC = new System.Windows.Forms.Button();
            this.tbxSourceFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxDocumentryTypes
            // 
            this.cbxDocumentryTypes.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, "DocumentaryId", true));
            this.cbxDocumentryTypes.DisplayMember = "name";
            this.cbxDocumentryTypes.FormattingEnabled = true;
            this.cbxDocumentryTypes.Location = new System.Drawing.Point(159, 216);
            this.cbxDocumentryTypes.Name = "cbxDocumentryTypes";
            this.cbxDocumentryTypes.Size = new System.Drawing.Size(227, 23);
            this.cbxDocumentryTypes.TabIndex = 24;
            this.cbxDocumentryTypes.ValueMember = "id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Tipo documental:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Carpeta:";
            // 
            // btnBrowseCloud
            // 
            this.btnBrowseCloud.Location = new System.Drawing.Point(454, 253);
            this.btnBrowseCloud.Name = "btnBrowseCloud";
            this.btnBrowseCloud.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseCloud.TabIndex = 21;
            this.btnBrowseCloud.Text = "...";
            this.btnBrowseCloud.UseVisualStyleBackColor = true;
            this.btnBrowseCloud.Click += new System.EventHandler(this.BtnBrowseCloud_Click);
            // 
            // tbxFolderPath
            // 
            this.tbxFolderPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FolderPath", true));
            this.tbxFolderPath.Location = new System.Drawing.Point(159, 253);
            this.tbxFolderPath.Name = "tbxFolderPath";
            this.tbxFolderPath.Size = new System.Drawing.Size(289, 23);
            this.tbxFolderPath.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Especifique el destino de los datos en Dokuflex";
            // 
            // btnBrowsePC
            // 
            this.btnBrowsePC.Location = new System.Drawing.Point(503, 97);
            this.btnBrowsePC.Name = "btnBrowsePC";
            this.btnBrowsePC.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePC.TabIndex = 16;
            this.btnBrowsePC.Text = "Navegar...";
            this.btnBrowsePC.UseVisualStyleBackColor = true;
            this.btnBrowsePC.Click += new System.EventHandler(this.BtnBrowsePC_Click);
            // 
            // tbxSourceFile
            // 
            this.tbxSourceFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FilePath", true));
            this.tbxSourceFile.Location = new System.Drawing.Point(55, 97);
            this.tbxSourceFile.Name = "tbxSourceFile";
            this.tbxSourceFile.Size = new System.Drawing.Size(442, 23);
            this.tbxSourceFile.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Especifique la fuente que define el contenido a importar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 49);
            this.panel1.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(14, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(386, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Seleccione el origen y destino de los datos";
            // 
            // ImportTextPage1Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxDocumentryTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBrowseCloud);
            this.Controls.Add(this.tbxFolderPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowsePC);
            this.Controls.Add(this.tbxSourceFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ImportTextPage1Control";
            this.Size = new System.Drawing.Size(600, 440);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDocumentryTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseCloud;
        private System.Windows.Forms.TextBox tbxFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowsePC;
        private System.Windows.Forms.TextBox tbxSourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
