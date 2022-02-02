using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WorkoutTracker
{
    class FileManager
    {
        /// <summary>
        /// Initiates an instance of the FileStream object that handles opening
        /// and closing files.
        /// </summary>
        private FileStream todoFile;

        /// <summary>
        /// Method that takes in the object List<Workout> and gets the stored
        /// list. The method then iterates over each task in the list, and stores a string
        /// containing the task name, date, and enum value in an array. The array is written
        /// to a text file at the provided path.
        /// The "¤" is used as a separator for later file reading. 
        /// Each workout has one initial line containing name, times, type, and notes.
        /// Each following line corresponds to one exercise from the workout with name, weight, set, and 
        /// rep info.
        /// </summary>
        /// <param name="inTaskManager"></param>
        /// <param name="path"></param>
        public void SaveFile(List<Workout> workoutManager, string path)
        {
            List<string> lines = new List<string>();
            foreach (Workout workout in workoutManager)
            {
                string workoutStats = String.Format("{0}¤{1}¤{2}¤{3}¤{4}",
                    workout.Name,workout.StartTime.ToString("dd/MM/yy HH:mm:ss")
                    ,workout.FinishTime.ToString("dd/MM/yy HH:mm:ss"),(int)workout.Part,workout.Note);
                lines.Add(workoutStats);
                foreach (Exercise ex in workout.ExerciseList)
                {
                    string exercise = String.Format("¤{0};{1};{2};{3}",
                        ex.name, ex.weight, ex.sets, ex.reps);
                    lines.Add(exercise);
                }
            }
            File.WriteAllLines(path, lines);
        }
        /// <summary>
        /// The method opens a text file at the provided path, and reads each line in
        /// the text file and returns a List<Workout> containing the workouts.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List<Workout></returns>
        public List<Workout> OpenFile(string path)
        {
            List<Workout> workoutManager = new List<Workout>();
            List<string> lines = File.ReadAllLines(path).ToList();
            Workout newWorkout = new Workout();
            foreach (string line in lines)
            {
                if (!line.StartsWith("¤"))
                {
                    workoutManager.Add(newWorkout);
                    newWorkout = new Workout();
                    string[] workoutInfo = line.Split('¤');
                    newWorkout.Name = workoutInfo[0]; 
                    newWorkout.StartTime = DateTime.Parse(workoutInfo[1]);
                    newWorkout.FinishTime = DateTime.Parse(workoutInfo[2]);
                    bool s = Int32.TryParse(workoutInfo[3], out int part);
                    newWorkout.Part = (BodyPart)part;
                    newWorkout.Note = workoutInfo[4];
                }
                else
                {

                    string[] exerciseInfo = line.Split(';');
                    string exerciseName = exerciseInfo[0].TrimStart('¤');
                    bool boolSets = Int32.TryParse(exerciseInfo[2], out int sets);
                    bool boolReps = Int32.TryParse(exerciseInfo[3], out int reps);
                    bool boolWeight = float.TryParse(exerciseInfo[1], out float weight);
                    Exercise newExercise = new Exercise(exerciseName, sets, reps, weight);
                    newWorkout.AddExercise(newExercise);

                }
            }
            workoutManager.RemoveAt(0);
            workoutManager.Add(newWorkout);
            return workoutManager;
        }
    }
}