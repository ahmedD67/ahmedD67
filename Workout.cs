using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    class Workout
    {
        /// <summary>
        /// The Workout class has a few fields: 
        /// List of exercises in a workout. Exercise is a class defined separately.
        /// Two DateTime values for starting and finishing the workout.
        /// Notes the user leaves during or at the end of a workout.
        /// What body part was the main focus of the workout.
        /// A preferred name for the workout.
        /// </summary>
        private List<Exercise> exerciseList = new List<Exercise>();
        private DateTime startTime;
        private DateTime finishTime;
        private string workoutNotes;
        private BodyPart bodyPart;
        private string name;

        /// <summary>
        /// Basic Getters and Setters
        /// </summary>
        public List<Exercise> ExerciseList
        {
            get { return exerciseList; }
            set { this.exerciseList = value; }
        }
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public DateTime FinishTime
        {
            get { return finishTime; }
            set { finishTime = value; }
        }
        public string Note
        {
            get { return workoutNotes; }
            set { workoutNotes = value; }
        }
        public BodyPart Part
        {
            get { return bodyPart; }
            set { bodyPart = value; }
        }
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        /// <summary>
        /// Standard Methods below for adding, deleting, and replacing exercises from the List<Exercise>
        /// They're actually not really needed since one can technically edit the List directly but it's safer
        /// to not interact with the field.
        /// /// </summary>
        /// <param name="inputExercise"></param>
        public void AddExercise(Exercise inputExercise)
        {
            exerciseList.Add(inputExercise);
        }
        public void DelExercise(int index)
        {
            exerciseList.RemoveAt(index);
        }
        public void EditExercise(int index, Exercise inputExercise)
        {
            exerciseList[index] = inputExercise;
        }
        /// <summary>
        /// Calculates the workout time length.
        /// </summary>
        /// <returns></returns>
        public string WorkoutLength()
        {
            int totalSeconds =  (int)(finishTime - startTime).TotalSeconds;
            int hours = (int)(totalSeconds/3600);
            int minutes = (int)((totalSeconds - 3600 * hours)/60);
            int seconds = (int)(totalSeconds - 3600 * hours - 60*minutes);
            return String.Format("{0}:{1}:{2}", hours, minutes, seconds);
        }
        /// <summary>
        /// Returns exercise at chosen index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Exercise GetExerciseAt(int index)
        {
            return exerciseList[index];
        }
        /// <summary>
        /// Overrides toString() method to be used to provide all the class fields into the description
        /// box on the MainForm.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string description = "Exercises:\r\n";
            string exercises = "";
            foreach (Exercise ex in this.ExerciseList)
            {
                exercises += ex.ToString() + "\r\n";
            }
            description += exercises
                         + "\r\nNotes:\r\n"
                         + this.Note
                         + "\r\nWorkout Time: " 
                         + this.WorkoutLength();
            return description;
        }
    }
}
