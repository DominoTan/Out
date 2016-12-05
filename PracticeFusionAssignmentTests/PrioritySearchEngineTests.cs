using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusionAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFusionAssignment.Tests
{
    [TestClass]
    public class PrioritySearchEngineTests
    {
        PrioritySearchEngine prioritySearchEngine;
        Doctor currentDoctor;
        List<Doctor> allStoredDoctors;

        [TestInitialize]
        public void TestInit()
        {
            prioritySearchEngine = new PrioritySearchEngine();
            currentDoctor = new Doctor() { Insurance = true, LocationDistance = 10, Name = "Dr. K", ReviewRating = 5, Specialty = "Neurosurgeon" };
            allStoredDoctors = CreateDirectoryofDoctors();
        }
        [TestMethod]
        public void AssertThatAllDoctorsWithTheSameNameAreReturned()
        {
            var orderedDoctors = prioritySearchEngine.FindDoctorsBasedOnName(currentDoctor, allStoredDoctors);
            Assert.AreEqual(orderedDoctors.Count(), 2);
        }
        [TestMethod]
        public void AssertThatAllDoctorsAreReturnedWithProximityFirst()
        {
            var orderedDoctors = prioritySearchEngine.FindDoctorsBasedOnProximity(currentDoctor, allStoredDoctors);
            Assert.AreEqual(orderedDoctors.ToArray()[0].LocationDistance, 1);
        }
        [TestMethod]
        public void AssertThatAllDoctorsAreReturnedWithRatingFirst()
        {
            var orderedDoctors = prioritySearchEngine.FindDoctorsBasedOnReviews(currentDoctor, allStoredDoctors);
            Assert.AreEqual(orderedDoctors.ToArray()[0].ReviewRating, 5);
        }
        [TestMethod]
        public void AssertThatAllDoctorsWithTheSameSpecialtyAreReturned()
        {
            var orderedDoctors = prioritySearchEngine.FindDoctorsBasedOnSpecialtyFields(currentDoctor, allStoredDoctors);
            Assert.AreEqual(orderedDoctors.Count(), 5);
        }
        private List<Doctor> CreateDirectoryofDoctors()
        {
            List<Doctor> directoryOfDoctors = new List<Doctor>()
            {
                new Doctor() {Insurance = false, LocationDistance = 25, Name = "Dr. A", ReviewRating = 5, Specialty = "Neurosurgeon" },
                new Doctor() {Insurance = true, LocationDistance = 5, Name = "Dr. K", ReviewRating = 4, Specialty = "Pediatrician" },
                new Doctor() {Insurance = false, LocationDistance = 5, Name = "Dr. N", ReviewRating = 5, Specialty = "Pediatrician" },
                new Doctor() {Insurance = true, LocationDistance = 25, Name = "Dr. K", ReviewRating = 1, Specialty = "General Doctor" },
                new Doctor() {Insurance = true, LocationDistance = 30, Name = "Dr. O", ReviewRating = 5, Specialty = "Neurosurgeon" },
                new Doctor() {Insurance = true, LocationDistance = 15, Name = "Dr. Y", ReviewRating = 4, Specialty = "General Doctor" },
                new Doctor() {Insurance = true, LocationDistance = 10, Name = "Dr. T", ReviewRating = 5, Specialty = "General Surgeon" },
                new Doctor() {Insurance = false, LocationDistance = 10, Name = "Dr. Q", ReviewRating = 3, Specialty = "Neurosurgeon" },
                new Doctor() {Insurance = true, LocationDistance = 5, Name = "Dr. H", ReviewRating = 5, Specialty = "General Surgeon" },
                new Doctor() {Insurance = true, LocationDistance = 1, Name = "Dr. P", ReviewRating = 2, Specialty = "Neurosurgeon" },
                new Doctor() {Insurance = true, LocationDistance = 25, Name = "Dr. S", ReviewRating = 5, Specialty = "General Doctor" },
                new Doctor() {Insurance = true, LocationDistance = 15, Name = "Dr. H", ReviewRating = 4, Specialty = "Neurosurgeon" },
            };
            return directoryOfDoctors;
        }
    }
}