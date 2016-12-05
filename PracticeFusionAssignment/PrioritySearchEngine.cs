using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFusionAssignment
{
    public class PrioritySearchEngine
    {
        /// <summary>
        /// This method assumes that users are looking for a specific doctors name and will return a list composed
        /// of all doctors with the same name along with prioritization of if there insurance covers it,
        /// how close the doctor is to the user, the doctor's specialty, and the review rating
        /// </summary>
        /// <param name="currentDoctor">The current doctor that is being looked at</param>
        /// <param name="allStoredDoctors">Our list of all doctors in our "database" loaded into memory</param>
        /// <returns></returns>
        public IOrderedEnumerable<Doctor> FindDoctorsBasedOnName(Doctor currentDoctor, List<Doctor> allStoredDoctors)
        {
            var sortedListOfDoctors = from doctor in allStoredDoctors
                                      where doctor.Name == currentDoctor.Name
                                      orderby doctor.Insurance descending,
                                      doctor.LocationDistance ascending,
                                      doctor.Specialty ascending,
                                      doctor.ReviewRating descending
                                      select doctor;
            return sortedListOfDoctors;
        }
        /// <summary>
        /// This method returns doctors by how close they are to you
        /// </summary>
        /// <param name="currentDoctor">The current doctor that is being looked at</param>
        /// <param name="allStoredDoctors">Our list of all doctors in our "database" loaded into memory</param>
        /// <returns></returns>
        public IOrderedEnumerable<Doctor> FindDoctorsBasedOnProximity(Doctor currentDoctor, List<Doctor> allStoredDoctors)
        {
            var sortedListOfDoctors = from doctor in allStoredDoctors
                                      orderby doctor.LocationDistance ascending,
                                      doctor.Insurance descending,
                                      doctor.Specialty ascending,
                                      doctor.ReviewRating descending
                                      select doctor;
            return sortedListOfDoctors;
        }
        /// <summary>
        /// This doctor finds doctors within the same specialty field
        /// </summary>
        /// <param name="currentDoctor">The current doctor that is being looked at</param>
        /// <param name="allStoredDoctors">Our list of all doctors in our "database" loaded into memory</param>
        /// <returns></returns>
        public IOrderedEnumerable<Doctor> FindDoctorsBasedOnSpecialtyFields(Doctor currentDoctor, List<Doctor> allStoredDoctors)
        {
            var sortedListOfDoctors = from doctor in allStoredDoctors
                                      where doctor.Specialty == currentDoctor.Specialty
                                      orderby doctor.Insurance descending,
                                      doctor.LocationDistance ascending,
                                      doctor.ReviewRating ascending
                                      select doctor;
            return sortedListOfDoctors;
        }
        /// <summary>
        /// This method ranks doctors based off of their reviews
        /// I could have changed the LINQ logic to only include doctors that are of similar rating to the currently selected one,
        /// but logically to me it makes more sense to rank descending from ratings...
        /// </summary>
        /// <param name="currentDoctor">The current doctor that is being looked at</param>
        /// <param name="allStoredDoctors">Our list of all doctors in our "database" loaded into memory</param>
        /// <returns></returns>
        public IOrderedEnumerable<Doctor> FindDoctorsBasedOnReviews(Doctor currentDoctor, List<Doctor> allStoredDoctors)
        {
            var sortedListOfDoctors = from doctor in allStoredDoctors
                                      orderby doctor.ReviewRating descending,
                                      doctor.Insurance descending,
                                      doctor.LocationDistance ascending,
                                      doctor.Specialty ascending
                                      select doctor;
            return sortedListOfDoctors;
        }
    }
}
