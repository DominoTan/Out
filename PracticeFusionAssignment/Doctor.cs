using System;

namespace PracticeFusionAssignment
{
    /// <summary>
    /// Basic class to represent our doctors
    /// </summary>
    public class Doctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int ReviewRating { get; set; }
        public int LocationDistance { get; set; }
        public bool Insurance { get; set; }
    }
}
