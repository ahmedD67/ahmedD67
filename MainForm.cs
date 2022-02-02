using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkoutTracker
{
    public partial class MainForm : Form
    {
        bool editActivated = false; // flag variable added to enable/disable certain features

        Workout currentWorkout = new Workout();
        List<Workout> workoutManager = new List<Workout>();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
            this.Icon = WorkoutTracker.Properties.Resources.dumbbell;
            string[] exerciseTypes = Enum.GetNames(typeof(BodyPart));
            foreach (string part in exerciseTypes)
            {
                typeCmbBox.Items.Add(part.Replace("_", " "));
            }
        }

        /// <summary>
        /// This method is used often to clear up the user input
        /// spaces after a new workout is added or removed.
        /// </summary>
        private void InitializeGUI()
        {
            txtDescription.Clear();
            nameTxtBox.Clear();
            typeCmbBox.SelectedIndex = -1;
            this.Text = "Workout Tracker by Ahmed Dabbous";
        }

        /// <summary>
        /// Method that adds the workout if a workout name, type, and at least one exercise are provided.
        /// A workout object is created and added to the List<Workout>. A summary description is added 
        /// to the listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addworkoutbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTxtBox.Text) || typeCmbBox.SelectedIndex == -1 
                || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Make sure that the following fields are not empty:" +
                    "\n\n    Workout Name" +
                    "\n    Workout Type" +
                    "\n    Exercises", "Error");
            }
            else
            {
                currentWorkout.Name = nameTxtBox.Text;
                currentWorkout.Part = (BodyPart)typeCmbBox.SelectedIndex;
                string workoutSummary = String.Format("{0:-30} {1:-20} {2:-10}",
                    currentWorkout.Name, currentWorkout.Part.ToString().Replace("_", " "), currentWorkout.StartTime.ToString());
                descLstBox.Items.Add(workoutSummary);
                workoutManager.Add(currentWorkout);
                btnAddExercises.Enabled = true;
                InitializeGUI();
                currentWorkout = new Workout();
            }
        }
        // Listener event that waits for the Add Exercises form to close to send
        // information back and forth.
        void Form_Closed_add(object sender, EventArgs e)
        {
            FormExercises newForm = (FormExercises)sender;
            currentWorkout = newForm.currentWorkout;
            btnAddExercises.Enabled = false;
            txtDescription.Text = currentWorkout.ToString();


        }
        private void btnAddExercise_Click(object sender, EventArgs e)
        {
            /// If user initiated a workout edit, then it will load the edited workout into the form.
            /// This will keep the exercises stored in the form.
            /// Else, a new workout is generated and loaded into the exercise form. This does not conflict
            /// with the workout name and type because those values are saved at the last step.
            if (editActivated == true)
            {
                FormExercises newForm = new FormExercises(currentWorkout);
                newForm.Show();
                newForm.FormClosed += new FormClosedEventHandler(Form_Closed_add);
            }
            else
            {
                Workout newWorkout = new Workout();
                newWorkout.StartTime = DateTime.Now;
                FormExercises newForm = new FormExercises(newWorkout);
                newForm.Show();
                newForm.FormClosed += new FormClosedEventHandler(Form_Closed_add);
            }
        }

        /// <summary>
        /// Event below clears the GUI by defaulting to empty boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            InitializeGUI();
            descLstBox.SelectedIndex = -1;
        }
        // Deletes a selected workout. Raises error if no workout selected.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (descLstBox.SelectedIndex == -1)
            { MessageBox.Show("Please select a workout before deleting!", "Error"); }
            else
            {
                workoutManager.RemoveAt(descLstBox.SelectedIndex);
                descLstBox.Items.Remove(descLstBox.SelectedItem);
            }
        }
        // Displays the workout information in the description box.
        void descLstBox_MouseClick(object sender, MouseEventArgs e)
        {
            int index = descLstBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Workout selWorkout = workoutManager[index];
                txtDescription.Text = selWorkout.ToString();
            }
        }

        /// <summary>
        /// The two methods below start and end the edit procedure. It turns on the "editActivated" 
        /// flag variable. The listbox selected item is set as the current workout. The workout name, type,
        /// and description are loaded into their respective spots.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            int index = descLstBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Please select a workout to edit first!", "Error");
            }
            else
            {
                editActivated = true;
                descLstBox.Enabled = false;
                Buttons();
                currentWorkout = workoutManager[index];
                nameTxtBox.Text = currentWorkout.Name;
                txtDescription.Text = currentWorkout.ToString();
                typeCmbBox.SelectedIndex = (int)currentWorkout.Part;
                btnAddExercises.Enabled = true;
            }
        }
        /// <summary>
        /// Raises error if no workout is already being edited. If yes, it will store the changes made
        /// in the "Add Exercises" form and the new workout type and name. It writes these changes to the
        /// workout object as well as the listbox item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            string name = nameTxtBox.Text;
            string desc = txtDescription.Text;
            int selIndex = typeCmbBox.SelectedIndex;
            if (editActivated == false)
            {
                MessageBox.Show("Please press 'Edit - Start' to make some changes first!", "Error");
            }
            else
            {
                if (string.IsNullOrEmpty(name) || selIndex == -1 || string.IsNullOrEmpty(desc))
                {
                    MessageBox.Show("Make sure that the following fields are not empty:" +
                        "\n\n    Workout Name" +
                        "\n    Workout Type" +
                        "\n    Exercises", "Error");
                }
                else
                {
                    currentWorkout.Name = nameTxtBox.Text;
                    currentWorkout.Part = (BodyPart)typeCmbBox.SelectedIndex;
                    
                    /// sends all text in listbox to an array of strings
                    /// loops over all items in listbox, converts them to string, and appends to string
                    /// array
                    string workoutSummary = String.Format("{0:-30} {1:-20} {2:-10}",
                        currentWorkout.Name, currentWorkout.Part.ToString().Replace("_", " "), currentWorkout.StartTime.ToString());
                    descLstBox.Items[descLstBox.SelectedIndex] = workoutSummary;
                    descLstBox.Enabled = true;
                    InitializeGUI();
                    Buttons();
                    btnAddExercises.Enabled = true;
                    editActivated = false;
                }
            }
        }
        /// <summary>
        /// Short method to toggle specific buttons on and off by switching their Enabled state.
        /// </summary>
        private void Buttons()
        {
            btnDelete.Enabled = !btnDelete.Enabled;
            btnEditBegin.Enabled = !btnEditBegin.Enabled;
            btnClear.Enabled = !btnClear.Enabled;
            btnAddWorkout.Enabled = !btnAddWorkout.Enabled;
        }
        /// <summary>
        /// Resets the GUI and erases everything when the New button is selected in the menustrip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGUI();
            descLstBox.Items.Clear();
            workoutManager = new List<Workout>();
        }
        /// <summary>
        /// When user presses Open button, it runs the OpenFile method from the FileManager class and loads
        /// stored data into a List<Workout>. It then writes those workouts to the listbox in the mainform.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Text Files | *.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                InitializeGUI();
                string path = sfd.FileName;
                workoutManager.Clear();
                descLstBox.Items.Clear();
                FileManager fileManager = new FileManager();
                workoutManager = fileManager.OpenFile(path);
                foreach (Workout workout in workoutManager)
                {
                    string workoutSummary = String.Format("{0:-30} {1:-20} {2:-10}",
    workout.Name, workout.Part.ToString().Replace("_", " "), workout.StartTime.ToString());
                    descLstBox.Items.Add(workoutSummary);
                }
            }
        }
        /// <summary>
        /// This code below runs the SaveFile method from the FileManager class when the save button 
        /// is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files | *.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                FileManager fileManager = new FileManager();
                fileManager.SaveFile(workoutManager, path);
            }
        }
        /// <summary>
        /// Loads the About box when the about button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.Show();
        }
    }
}
