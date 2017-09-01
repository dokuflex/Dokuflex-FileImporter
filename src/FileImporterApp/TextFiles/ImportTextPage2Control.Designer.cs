namespace FileImporterApp.TextFiles
{
    partial class ImportTextPage2Control
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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDokuField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMandatory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsMetadata = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnSpace = new System.Windows.Forms.RadioButton();
            this.rbtnScriptUnder = new System.Windows.Forms.RadioButton();
            this.rbtnComa = new System.Windows.Forms.RadioButton();
            this.rbtnSemicolon = new System.Windows.Forms.RadioButton();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMetadata)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mapeo de Campos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDokuField,
            this.colFieldName,
            this.colMandatory});
            this.dataGridView1.DataSource = this.bsMetadata;
            this.dataGridView1.Location = new System.Drawing.Point(24, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(520, 174);
            this.dataGridView1.TabIndex = 18;
            // 
            // colDokuField
            // 
            this.colDokuField.DataPropertyName = "DokufieldName";
            this.colDokuField.HeaderText = "Propiedad";
            this.colDokuField.Name = "colDokuField";
            this.colDokuField.ReadOnly = true;
            this.colDokuField.Width = 200;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "FieldNameIndex";
            this.colFieldName.HeaderText = "Campo";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Width = 200;
            // 
            // colMandatory
            // 
            this.colMandatory.DataPropertyName = "Mandatory";
            this.colMandatory.HeaderText = "Requerido";
            this.colMandatory.Name = "colMandatory";
            this.colMandatory.ReadOnly = true;
            this.colMandatory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMandatory.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 49);
            this.panel1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(14, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(436, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Seleccione el delimitador de campos  apropiado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnSpace);
            this.groupBox1.Controls.Add(this.rbtnScriptUnder);
            this.groupBox1.Controls.Add(this.rbtnComa);
            this.groupBox1.Controls.Add(this.rbtnSemicolon);
            this.groupBox1.Location = new System.Drawing.Point(24, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 56);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliga el delimitador que separa los campos";
            // 
            // rbtnSpace
            // 
            this.rbtnSpace.AutoSize = true;
            this.rbtnSpace.Location = new System.Drawing.Point(212, 22);
            this.rbtnSpace.Name = "rbtnSpace";
            this.rbtnSpace.Size = new System.Drawing.Size(65, 19);
            this.rbtnSpace.TabIndex = 3;
            this.rbtnSpace.TabStop = true;
            this.rbtnSpace.Text = "Espacio";
            this.rbtnSpace.UseVisualStyleBackColor = true;
            this.rbtnSpace.CheckedChanged += new System.EventHandler(this.rbtnSpace_CheckedChanged);
            // 
            // rbtnScriptUnder
            // 
            this.rbtnScriptUnder.AutoSize = true;
            this.rbtnScriptUnder.Location = new System.Drawing.Point(295, 22);
            this.rbtnScriptUnder.Name = "rbtnScriptUnder";
            this.rbtnScriptUnder.Size = new System.Drawing.Size(99, 19);
            this.rbtnScriptUnder.TabIndex = 2;
            this.rbtnScriptUnder.TabStop = true;
            this.rbtnScriptUnder.Text = "Guíon bajo (_)";
            this.rbtnScriptUnder.UseVisualStyleBackColor = true;
            this.rbtnScriptUnder.CheckedChanged += new System.EventHandler(this.rbtnScriptUnder_CheckedChanged);
            // 
            // rbtnComa
            // 
            this.rbtnComa.AutoSize = true;
            this.rbtnComa.Location = new System.Drawing.Point(135, 22);
            this.rbtnComa.Name = "rbtnComa";
            this.rbtnComa.Size = new System.Drawing.Size(57, 19);
            this.rbtnComa.TabIndex = 1;
            this.rbtnComa.TabStop = true;
            this.rbtnComa.Text = "Coma";
            this.rbtnComa.UseVisualStyleBackColor = true;
            this.rbtnComa.CheckedChanged += new System.EventHandler(this.rbtnComa_CheckedChanged);
            // 
            // rbtnSemicolon
            // 
            this.rbtnSemicolon.AutoSize = true;
            this.rbtnSemicolon.Location = new System.Drawing.Point(19, 22);
            this.rbtnSemicolon.Name = "rbtnSemicolon";
            this.rbtnSemicolon.Size = new System.Drawing.Size(99, 19);
            this.rbtnSemicolon.TabIndex = 0;
            this.rbtnSemicolon.Text = "Punto y coma";
            this.rbtnSemicolon.UseVisualStyleBackColor = true;
            this.rbtnSemicolon.CheckedChanged += new System.EventHandler(this.rbtnSemicolon_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ImportTextPage2Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ImportTextPage2Control";
            this.Size = new System.Drawing.Size(600, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMetadata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnScriptUnder;
        private System.Windows.Forms.RadioButton rbtnComa;
        private System.Windows.Forms.RadioButton rbtnSemicolon;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.RadioButton rbtnSpace;
        private System.Windows.Forms.BindingSource bsMetadata;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDokuField;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMandatory;
    }
}
