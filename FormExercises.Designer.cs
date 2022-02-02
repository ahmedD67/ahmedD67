
namespace WorkoutTracker
{
    partial class FormExercises
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
            this.numInglbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.exGrpBox = new System.Windows.Forms.GroupBox();
            this.weightTxtBox = new System.Windows.Forms.TextBox();
            this.repTxtBox = new System.Windows.Forms.TextBox();
            this.setTextBox = new System.Windows.Forms.TextBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.exLstBox = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.noteGrpBox = new System.Windows.Forms.GroupBox();
            this.noteTxtBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.exGrpBox.SuspendLayout();
            this.noteGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // numInglbl
            // 
            this.numInglbl.AutoSize = true;
            this.numInglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInglbl.Location = new System.Drawing.Point(8, 16);
            this.numInglbl.Name = "numInglbl";
            this.numInglbl.Size = new System.Drawing.Size(121, 15);
            this.numInglbl.TabIndex = 1;
            this.numInglbl.Text = "Number of Exercises";
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Location = new System.Drawing.Point(88, 496);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okbtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(216, 496);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // exGrpBox
            // 
            this.exGrpBox.Controls.Add(this.weightTxtBox);
            this.exGrpBox.Controls.Add(this.repTxtBox);
            this.exGrpBox.Controls.Add(this.setTextBox);
            this.exGrpBox.Controls.Add(this.nameTxtBox);
            this.exGrpBox.Controls.Add(this.exLstBox);
            this.exGrpBox.Controls.Add(this.addBtn);
            this.exGrpBox.Controls.Add(this.editBtn);
            this.exGrpBox.Controls.Add(this.delBtn);
            this.exGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exGrpBox.Location = new System.Drawing.Point(8, 40);
            this.exGrpBox.Name = "exGrpBox";
            this.exGrpBox.Size = new System.Drawing.Size(371, 311);
            this.exGrpBox.TabIndex = 0;
            this.exGrpBox.TabStop = false;
            this.exGrpBox.Text = "Exercise";
            // 
            // weightTxtBox
            // 
            this.weightTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTxtBox.Location = new System.Drawing.Point(136, 19);
            this.weightTxtBox.Name = "weightTxtBox";
            this.weightTxtBox.Size = new System.Drawing.Size(48, 21);
            this.weightTxtBox.TabIndex = 12;
            this.weightTxtBox.Text = "Weight";
            // 
            // repTxtBox
            // 
            this.repTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repTxtBox.Location = new System.Drawing.Point(240, 19);
            this.repTxtBox.Name = "repTxtBox";
            this.repTxtBox.Size = new System.Drawing.Size(40, 21);
            this.repTxtBox.TabIndex = 11;
            this.repTxtBox.Text = "Reps";
            // 
            // setTextBox
            // 
            this.setTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setTextBox.Location = new System.Drawing.Point(192, 19);
            this.setTextBox.Name = "setTextBox";
            this.setTextBox.Size = new System.Drawing.Size(40, 21);
            this.setTextBox.TabIndex = 10;
            this.setTextBox.Text = "Sets";
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxtBox.Location = new System.Drawing.Point(6, 19);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(122, 21);
            this.nameTxtBox.TabIndex = 8;
            this.nameTxtBox.Text = "Name";
            // 
            // exLstBox
            // 
            this.exLstBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLstBox.FormattingEnabled = true;
            this.exLstBox.ItemHeight = 15;
            this.exLstBox.Location = new System.Drawing.Point(8, 48);
            this.exLstBox.Name = "exLstBox";
            this.exLstBox.Size = new System.Drawing.Size(272, 259);
            this.exLstBox.TabIndex = 9;
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(288, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(288, 48);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 7;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editbtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBtn.Location = new System.Drawing.Point(288, 80);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 2;
            this.delBtn.Text = "Delete";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // noteGrpBox
            // 
            this.noteGrpBox.Controls.Add(this.noteTxtBox);
            this.noteGrpBox.Location = new System.Drawing.Point(8, 360);
            this.noteGrpBox.Name = "noteGrpBox";
            this.noteGrpBox.Size = new System.Drawing.Size(368, 136);
            this.noteGrpBox.TabIndex = 12;
            this.noteGrpBox.TabStop = false;
            this.noteGrpBox.Text = "Workout Notes";
            // 
            // noteTxtBox
            // 
            this.noteTxtBox.Location = new System.Drawing.Point(8, 16);
            this.noteTxtBox.Multiline = true;
            this.noteTxtBox.Name = "noteTxtBox";
            this.noteTxtBox.Size = new System.Drawing.Size(352, 112);
            this.noteTxtBox.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // FormIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 536);
            this.Controls.Add(this.noteGrpBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.numInglbl);
            this.Controls.Add(this.exGrpBox);
            this.Name = "FormIngredients";
            this.Text = "Form1";
            this.exGrpBox.ResumeLayout(false);
            this.exGrpBox.PerformLayout();
            this.noteGrpBox.ResumeLayout(false);
            this.noteGrpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numInglbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.GroupBox exGrpBox;
        private System.Windows.Forms.TextBox repTxtBox;
        private System.Windows.Forms.TextBox setTextBox;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.ListBox exLstBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.TextBox weightTxtBox;
        private System.Windows.Forms.GroupBox noteGrpBox;
        private System.Windows.Forms.TextBox noteTxtBox;
        private System.Windows.Forms.Timer timer1;
    }
}