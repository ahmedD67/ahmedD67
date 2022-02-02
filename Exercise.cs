using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    class Exercise
    {
        public int reps { get; set; }
        public int sets { get; set; }
        public double weight { get; set; }
        public string name { get; set; }
        /// <summary>
        /// Constructor to be used in the "AddExercise" form when adding new exercises.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sets"></param>
        /// <param name="reps"></param>
        /// <param name="weight"></param>
        public Exercise(string name, int sets, int reps, double weight)
        {
            this.name = name;
            this.sets = sets;
            this.reps = reps;
            this.weight = weight;
        }
        /// <summary>
        /// Overrides the ToString() method. Used as a descriptor that is used in the AddExercises form 
        /// listbox.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string descripton = String.Format("Name: {0}, Weight: {1}, Sets: {2}, Reps: {3}",
                this.name, this.weight, this.sets, this.reps);
            return descripton;
        }
    }
}
