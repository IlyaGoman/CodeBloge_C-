using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; }

        public List<Food> Foods { get; }

        public User User { get; }
    }
}
