namespace DCAddIn
{
    partial class InspectorFormEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectorFormEdit));
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.notaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AceptarSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelarSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.nombreLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.notaLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.tipoLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.tipoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.documentoIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentoIDTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.defaultLookAndFeel1.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.Location = new System.Drawing.Point(67, 25);
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Size = new System.Drawing.Size(453, 20);
            this.nombreTextEdit.TabIndex = 0;
            // 
            // notaTextEdit
            // 
            this.notaTextEdit.Location = new System.Drawing.Point(67, 60);
            this.notaTextEdit.Name = "notaTextEdit";
            this.notaTextEdit.Size = new System.Drawing.Size(453, 20);
            this.notaTextEdit.TabIndex = 1;
            // 
            // AceptarSimpleButton
            // 
            this.AceptarSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("AceptarSimpleButton.Image")));
            this.AceptarSimpleButton.Location = new System.Drawing.Point(158, 133);
            this.AceptarSimpleButton.Name = "AceptarSimpleButton";
            this.AceptarSimpleButton.Size = new System.Drawing.Size(101, 22);
            this.AceptarSimpleButton.TabIndex = 3;
            this.AceptarSimpleButton.Text = "Aceptar";
            this.AceptarSimpleButton.Click += new System.EventHandler(this.AceptarSimpleButton_Click);
            // 
            // cancelarSimpleButton
            // 
            this.cancelarSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelarSimpleButton.Image")));
            this.cancelarSimpleButton.Location = new System.Drawing.Point(275, 133);
            this.cancelarSimpleButton.Name = "cancelarSimpleButton";
            this.cancelarSimpleButton.Size = new System.Drawing.Size(101, 22);
            this.cancelarSimpleButton.TabIndex = 4;
            this.cancelarSimpleButton.Text = "Cancelar";
            this.cancelarSimpleButton.Click += new System.EventHandler(this.cancelarSimpleButton_Click);
            // 
            // nombreLabelControl
            // 
            this.nombreLabelControl.Location = new System.Drawing.Point(24, 28);
            this.nombreLabelControl.Name = "nombreLabelControl";
            this.nombreLabelControl.Size = new System.Drawing.Size(37, 13);
            this.nombreLabelControl.TabIndex = 5;
            this.nombreLabelControl.Text = "Nombre";
            // 
            // notaLabelControl
            // 
            this.notaLabelControl.Location = new System.Drawing.Point(38, 63);
            this.notaLabelControl.Name = "notaLabelControl";
            this.notaLabelControl.Size = new System.Drawing.Size(23, 13);
            this.notaLabelControl.TabIndex = 6;
            this.notaLabelControl.Text = "Nota";
            // 
            // tipoLabelControl
            // 
            this.tipoLabelControl.Location = new System.Drawing.Point(41, 99);
            this.tipoLabelControl.Name = "tipoLabelControl";
            this.tipoLabelControl.Size = new System.Drawing.Size(20, 13);
            this.tipoLabelControl.TabIndex = 7;
            this.tipoLabelControl.Text = "Tipo";
            // 
            // tipoLookUpEdit
            // 
            this.tipoLookUpEdit.Location = new System.Drawing.Point(67, 96);
            this.tipoLookUpEdit.Name = "tipoLookUpEdit";
            this.tipoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipoLookUpEdit.Size = new System.Drawing.Size(127, 20);
            this.tipoLookUpEdit.TabIndex = 8;
            // 
            // documentoIDTextEdit
            // 
            this.documentoIDTextEdit.Location = new System.Drawing.Point(458, 135);
            this.documentoIDTextEdit.Name = "documentoIDTextEdit";
            this.documentoIDTextEdit.Size = new System.Drawing.Size(62, 20);
            this.documentoIDTextEdit.TabIndex = 9;
            this.documentoIDTextEdit.Visible = false;
            // 
            // InspectorFormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 165);
            this.Controls.Add(this.documentoIDTextEdit);
            this.Controls.Add(this.tipoLookUpEdit);
            this.Controls.Add(this.tipoLabelControl);
            this.Controls.Add(this.notaLabelControl);
            this.Controls.Add(this.nombreLabelControl);
            this.Controls.Add(this.cancelarSimpleButton);
            this.Controls.Add(this.AceptarSimpleButton);
            this.Controls.Add(this.notaTextEdit);
            this.Controls.Add(this.nombreTextEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InspectorFormEdit";
            this.Text = "Editar Item";
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentoIDTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.FormAssistant formAssistant1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private DevExpress.XtraEditors.TextEdit notaTextEdit;
        private DevExpress.XtraEditors.SimpleButton AceptarSimpleButton;
        private DevExpress.XtraEditors.SimpleButton cancelarSimpleButton;
        private DevExpress.XtraEditors.LabelControl nombreLabelControl;
        private DevExpress.XtraEditors.LabelControl notaLabelControl;
        private DevExpress.XtraEditors.LabelControl tipoLabelControl;
        private DevExpress.XtraEditors.LookUpEdit tipoLookUpEdit;
        private DevExpress.XtraEditors.TextEdit documentoIDTextEdit;

    }
}