
namespace WorkoutTracker
{
    partial class MainForm
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
            this.grpAddWorkout = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddWorkout = new System.Windows.Forms.Button();
            this.lblWorkoutName = new System.Windows.Forms.Label();
            this.btnAddExercises = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.typeCmbBox = new System.Windows.Forms.ComboBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.descLstBox = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEditBegin = new System.Windows.Forms.Button();
            this.btnEditFinish = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblListName = new System.Windows.Forms.Label();
            this.lblListCategory = new System.Windows.Forms.Label();
            this.lblListNumIngredients = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCtrlNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitAltF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpAddWorkout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddWorkout
            // 
            this.grpAddWorkout.Controls.Add(this.txtDescription);
            this.grpAddWorkout.Controls.Add(this.btnAddWorkout);
            this.grpAddWorkout.Controls.Add(this.lblWorkoutName);
            this.grpAddWorkout.Controls.Add(this.btnAddExercises);
            this.grpAddWorkout.Controls.Add(this.lblType);
            this.grpAddWorkout.Controls.Add(this.typeCmbBox);
            this.grpAddWorkout.Controls.Add(this.nameTxtBox);
            this.grpAddWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddWorkout.Location = new System.Drawing.Point(8, 32);
            this.grpAddWorkout.Name = "grpAddWorkout";
            this.grpAddWorkout.Size = new System.Drawing.Size(388, 308);
            this.grpAddWorkout.TabIndex = 0;
            this.grpAddWorkout.TabStop = false;
            this.grpAddWorkout.Text = "Add new workout";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(361, 197);
            this.txtDescription.TabIndex = 14;
            // 
            // btnAddWorkout
            // 
            this.btnAddWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWorkout.Location = new System.Drawing.Point(16, 280);
            this.btnAddWorkout.Name = "btnAddWorkout";
            this.btnAddWorkout.Size = new System.Drawing.Size(360, 23);
            this.btnAddWorkout.TabIndex = 13;
            this.btnAddWorkout.Text = "Add Workout";
            this.btnAddWorkout.UseVisualStyleBackColor = true;
            this.btnAddWorkout.Click += new System.EventHandler(this.addworkoutbtn_Click);
            // 
            // lblWorkoutName
            // 
            this.lblWorkoutName.AutoSize = true;
            this.lblWorkoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkoutName.Location = new System.Drawing.Point(12, 22);
            this.lblWorkoutName.Name = "lblWorkoutName";
            this.lblWorkoutName.Size = new System.Drawing.Size(109, 15);
            this.lblWorkoutName.TabIndex = 7;
            this.lblWorkoutName.Text = "Add workout name";
            // 
            // btnAddExercises
            // 
            this.btnAddExercises.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExercises.Location = new System.Drawing.Point(272, 48);
            this.btnAddExercises.Name = "btnAddExercises";
            this.btnAddExercises.Size = new System.Drawing.Size(107, 23);
            this.btnAddExercises.TabIndex = 11;
            this.btnAddExercises.Text = "Add Exercises";
            this.btnAddExercises.UseVisualStyleBackColor = true;
            this.btnAddExercises.Click += new System.EventHandler(this.btnAddExercise_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(12, 49);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(81, 15);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Workout Type";
            // 
            // typeCmbBox
            // 
            this.typeCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeCmbBox.FormattingEnabled = true;
            this.typeCmbBox.Location = new System.Drawing.Point(112, 46);
            this.typeCmbBox.Name = "typeCmbBox";
            this.typeCmbBox.Size = new System.Drawing.Size(152, 23);
            this.typeCmbBox.TabIndex = 10;
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxtBox.Location = new System.Drawing.Point(176, 16);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(202, 21);
            this.nameTxtBox.TabIndex = 9;
            // 
            // descLstBox
            // 
            this.descLstBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLstBox.FormattingEnabled = true;
            this.descLstBox.ItemHeight = 16;
            this.descLstBox.Location = new System.Drawing.Point(412, 52);
            this.descLstBox.Name = "descLstBox";
            this.descLstBox.Size = new System.Drawing.Size(444, 196);
            this.descLstBox.TabIndex = 1;
            this.descLstBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.descLstBox_MouseClick);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(757, 272);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Selection";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEditBegin
            // 
            this.btnEditBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditBegin.Location = new System.Drawing.Point(412, 272);
            this.btnEditBegin.Name = "btnEditBegin";
            this.btnEditBegin.Size = new System.Drawing.Size(99, 23);
            this.btnEditBegin.TabIndex = 8;
            this.btnEditBegin.Text = "Edit - Begin";
            this.btnEditBegin.UseVisualStyleBackColor = true;
            this.btnEditBegin.Click += new System.EventHandler(this.btnEditBegin_Click);
            // 
            // btnEditFinish
            // 
            this.btnEditFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFinish.Location = new System.Drawing.Point(527, 272);
            this.btnEditFinish.Name = "btnEditFinish";
            this.btnEditFinish.Size = new System.Drawing.Size(99, 23);
            this.btnEditFinish.TabIndex = 9;
            this.btnEditFinish.Text = "Edit - Finish";
            this.btnEditFinish.UseVisualStyleBackColor = true;
            this.btnEditFinish.Click += new System.EventHandler(this.btnEditFinish_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(642, 272);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblListName
            // 
            this.lblListName.AutoSize = true;
            this.lblListName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListName.Location = new System.Drawing.Point(434, 29);
            this.lblListName.Name = "lblListName";
            this.lblListName.Size = new System.Drawing.Size(41, 15);
            this.lblListName.TabIndex = 11;
            this.lblListName.Text = "Name";
            // 
            // lblListCategory
            // 
            this.lblListCategory.AutoSize = true;
            this.lblListCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListCategory.Location = new System.Drawing.Point(610, 29);
            this.lblListCategory.Name = "lblListCategory";
            this.lblListCategory.Size = new System.Drawing.Size(81, 15);
            this.lblListCategory.TabIndex = 12;
            this.lblListCategory.Text = "Workout Type";
            // 
            // lblListNumIngredients
            // 
            this.lblListNumIngredients.AutoSize = true;
            this.lblListNumIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListNumIngredients.Location = new System.Drawing.Point(762, 29);
            this.lblListNumIngredients.Name = "lblListNumIngredients";
            this.lblListNumIngredients.Size = new System.Drawing.Size(64, 15);
            this.lblListNumIngredients.TabIndex = 13;
            this.lblListNumIngredients.Text = "Date/Time";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCtrlNToolStripMenuItem,
            this.openDataFileToolStripMenuItem,
            this.saveDataFileToolStripMenuItem,
            this.exitAltF4ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newCtrlNToolStripMenuItem
            // 
            this.newCtrlNToolStripMenuItem.Name = "newCtrlNToolStripMenuItem";
            this.newCtrlNToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.newCtrlNToolStripMenuItem.Text = "New                Ctrl+N";
            this.newCtrlNToolStripMenuItem.Click += new System.EventHandler(this.newCtrlNToolStripMenuItem_Click);
            // 
            // openDataFileToolStripMenuItem
            // 
            this.openDataFileToolStripMenuItem.Name = "openDataFileToolStripMenuItem";
            this.openDataFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openDataFileToolStripMenuItem.Text = "Open Data File";
            this.openDataFileToolStripMenuItem.Click += new System.EventHandler(this.openDataFileToolStripMenuItem_Click);
            // 
            // saveDataFileToolStripMenuItem
            // 
            this.saveDataFileToolStripMenuItem.Name = "saveDataFileToolStripMenuItem";
            this.saveDataFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveDataFileToolStripMenuItem.Text = "Save Data File";
            this.saveDataFileToolStripMenuItem.Click += new System.EventHandler(this.saveDataFileToolStripMenuItem_Click);
            // 
            // exitAltF4ToolStripMenuItem
            // 
            this.exitAltF4ToolStripMenuItem.Name = "exitAltF4ToolStripMenuItem";
            this.exitAltF4ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitAltF4ToolStripMenuItem.Text = "Exit                  Alt+F4";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 352);
            this.Controls.Add(this.lblListNumIngredients);
            this.Controls.Add(this.lblListCategory);
            this.Controls.Add(this.lblListName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditFinish);
            this.Controls.Add(this.btnEditBegin);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.descLstBox);
            this.Controls.Add(this.grpAddWorkout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.grpAddWorkout.ResumeLayout(false);
            this.grpAddWorkout.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddWorkout;
        private System.Windows.Forms.Button btnAddWorkout;
        private System.Windows.Forms.Label lblWorkoutName;
        private System.Windows.Forms.Button btnAddExercises;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox typeCmbBox;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.ListBox descLstBox;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEditBegin;
        private System.Windows.Forms.Button btnEditFinish;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblListName;
        private System.Windows.Forms.Label lblListCategory;
        private System.Windows.Forms.Label lblListNumIngredients;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCtrlNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitAltF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

