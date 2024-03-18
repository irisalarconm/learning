namespace CrudWindowsFormsADONET
{
    partial class FormNew
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
            Name = new Label();
            Age = new Label();
            TxtName = new TextBox();
            TxtAge = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(157, 62);
            Name.Name = "Name";
            Name.Size = new Size(51, 15);
            Name.TabIndex = 0;
            Name.Text = "Nombre";
            // 
            // Age
            // 
            Age.AutoSize = true;
            Age.Location = new Point(160, 106);
            Age.Name = "Age";
            Age.Size = new Size(33, 15);
            Age.TabIndex = 1;
            Age.Text = "Edad";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(263, 59);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(251, 23);
            TxtName.TabIndex = 2;
            // 
            // TxtAge
            // 
            TxtAge.Location = new Point(263, 103);
            TxtAge.Name = "TxtAge";
            TxtAge.Size = new Size(251, 23);
            TxtAge.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(439, 159);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 489);
            Controls.Add(button1);
            Controls.Add(TxtAge);
            Controls.Add(TxtName);
            Controls.Add(Age);
            Controls.Add(Name);
            //Name = "FormNew";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormNew";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private new Label Name;
        private Label Age;
        private TextBox TxtName;
        private TextBox TxtAge;
        private Button button1;
    }
}