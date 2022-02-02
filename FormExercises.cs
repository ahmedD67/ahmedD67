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
    public partial class FormExercises : Form
    {
        internal Workout currentWorkout = new Workout();
        bool exerciseEditMode = false;
        bool workoutEditMode = false;
        bool closeForm;
        

        /// <summary>
        /// The form constructor will check whether a "new" or "edited" workout were passed into it.
        /// If a new workout is passed, it records the start time as Now. If an edited workout is passed,
        /// it doesn't change the StartTime value and enters all the exercise info into the listbox right
        /// away. A counter is used to keep track of how many exercises are present.
        /// </summary>
        /// <param name="inWorkout"></param>
        internal FormExercises(Workout inWorkout)
        {
            InitializeComponent();
            this.Icon = WorkoutTracker.Properties.Resources.dumbbell;
            timer1.Start();
            currentWorkout = inWorkout;
            if (inWorkout.ExerciseList.Count != 0)
            {
                workoutEditMode = true;
                this.Text = String.Format("Editing Workout: {0} from {1}",
                    inWorkout.Name, inWorkout.StartTime);
                foreach (Exercise ex in inWorkout.ExerciseList)
                {
                    string exerciseString = String.Format("{0,-30}{1,-15}{2,-15} {3,-15}",
                        ex.name, ex.weight.ToString(), ex.sets.ToString(), ex.reps.ToString());
                    exLstBox.Items.Add(exerciseString);
                    label2.Text = exLstBox.Items.Count.ToString();
                }
                noteTxtBox.Text = inWorkout.Note;
            }
            else
            {
                currentWorkout.StartTime = DateTime.Now;
                this.Text = "New Workout";
                label2.Text = exLstBox.Items.Count.ToString();
            }

        }

        /// <summary>
        /// Add button event. If not all input is given it raises an error. Othewise, it adds the exercise
        /// to the listbox. The exercise is also added to the workout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addbtn_Click(object sender, EventArgs e)
        {
            int parsedSet;
            int parsedRep;
            int parsedWeight;
            bool boolSet = int.TryParse(setTextBox.Text, out parsedSet);
            bool boolRep = int.TryParse(repTxtBox.Text, out parsedRep);
            bool boolweight = int.TryParse(weightTxtBox.Text, out parsedWeight);

            if (string.IsNullOrEmpty(nameTxtBox.Text) || !boolSet || !boolRep || !boolweight)
            {
                MessageBox.Show("An exercise name and/or sets x reprs numbers are needed!","Error");
            }
            else
            {
                string lstboxtxt = String.Format("{0,-30}{1,-15}{2,-15} {3,-15}"
                    ,nameTxtBox.Text,parsedWeight,parsedSet,parsedRep);
                exLstBox.Items.Add(lstboxtxt);
                Exercise newExercise = new Exercise(nameTxtBox.Text, parsedSet, parsedRep, parsedWeight);
                currentWorkout.AddExercise(newExercise);
                resetTxtBox();
                label2.Text = exLstBox.Items.Count.ToString();
                
            }
        }
        /// Del button event. If an exercise is not selected, error is raised. Otherwise, selected 
        /// exercise is deleted from the listbox and is also removed from the workout using a Workout method.
        private void delbtn_Click(object sender, EventArgs e)
        {
            if (exLstBox.SelectedIndex == -1)
            { MessageBox.Show("Please select an exercise before deleting!"); }
            else
            {
                int selectedIndex = exLstBox.SelectedIndex;
                exLstBox.Items.Remove(exLstBox.SelectedItem);
                currentWorkout.DelExercise(selectedIndex);
                label2.Text = exLstBox.Items.Count.ToString();
            }
        }
        /// Closes the form as long as the user has 1 or more exercises. It records the FinishTime IF the
        /// form is not editing a previous workout, hence the "workoutEditMode" flag variable.
        private void okbtn_Click(object sender, EventArgs e)
        {
            if (exLstBox.Items.Count <= 0)
            {
                MessageBox.Show("Please enter at least one exercise!", "Error");
            }
            else
            {
                if (workoutEditMode == false)
                {
                    currentWorkout.FinishTime = DateTime.Now;
                }
                currentWorkout.Note = noteTxtBox.Text;
                this.Close();
            }
        }
        /// Closes the form without saving any of the exercises.
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }
        /// Edit button. User selects the desired exercises, makes the changes, then hits edit again.
        /// This changes info in the listbox and also edits the exercise at the same index in the Workout
        /// exercise list.
        private void editbtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = exLstBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No exercise is selected to be edited!","Error");
            }
            else if (exerciseEditMode == false)
            {
                exerciseEditMode = true;
                EnableButtons();
                loadTxtBox(currentWorkout.GetExerciseAt(selectedIndex));

            }
            else if (exerciseEditMode == true)
            {

                int parsedSet;
                int parsedRep;
                int parsedWeight;
                bool boolSet = int.TryParse(setTextBox.Text, out parsedSet);
                bool boolRep = int.TryParse(repTxtBox.Text, out parsedRep);
                bool boolweight = int.TryParse(weightTxtBox.Text, out parsedWeight);

                if (string.IsNullOrEmpty(nameTxtBox.Text) || !boolSet || !boolRep || !boolweight)
                {
                    MessageBox.Show("An exercise name and/or sets x reprs numbers are needed!", "Error");
                }
                else
                {
                    string lstboxtxt = String.Format("{0,-30}{1,-15}{2,-15} {3,-15}"
                            , nameTxtBox.Text, parsedWeight, parsedSet, parsedRep);
                    exLstBox.Items[selectedIndex] = lstboxtxt;
                    Exercise newExercise = new Exercise(nameTxtBox.Text, parsedSet, parsedRep, parsedWeight);
                    currentWorkout.EditExercise(selectedIndex, newExercise);
                    exerciseEditMode = false;
                    resetTxtBox();
                    EnableButtons();
                }
            }
        }
        /// <summary>
        /// Brief method to reset all the text boxes.
        /// </summary>
        private void resetTxtBox()
        {
            nameTxtBox.Text = "Name";
            repTxtBox.Text = "Reps";
            setTextBox.Text = "Sets";
            weightTxtBox.Text = "Weight";
        }
        /// <summary>
        /// Brief method to load all exercise info into textboxes for Edit.
        /// </summary>
        /// <param name="inExercise"></param>
        private void loadTxtBox(Exercise inExercise)
        {
            nameTxtBox.Text = inExercise.name;
            repTxtBox.Text = inExercise.reps.ToString();
            setTextBox.Text = inExercise.sets.ToString();
            weightTxtBox.Text = inExercise.weight.ToString();
        }
        /// <summary>
        /// Summary method to toggle buttons on and off during Edit.
        /// </summary>
        private void EnableButtons()
        {
            exLstBox.Enabled = !exLstBox.Enabled;
            addBtn.Enabled = !addBtn.Enabled;
            delBtn.Enabled = !delBtn.Enabled;
            okBtn.Enabled = !okBtn.Enabled;
            cancelBtn.Enabled = !cancelBtn.Enabled;
        }
        /// <summary>
        /// Sender event to let MainForm know when the form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormIngredients_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeForm = true;
        }

    }
}
