using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Metropolis.DAL
{
    /// <summary>
    /// Defines the interface for ActivityDal.
    /// </summary>
    public interface IActivityDal
    {
        /// <summary>
        /// Declares a method to add an activity .
        /// </summary>
        /// <param name="activity"> The data about activity to be added.
        /// </param>
        /// <return>
        /// True for successful insertion else false.
        /// </return>
        bool AddActivity(Activity activity);

        /// <summary>
        /// Declares a method to delete the details of a particular activity.
        /// </summary>
        /// <param name="id">The id of activity that is to be deleted.
        /// </param>
        /// <return>
        /// True for successful deletion else false.
        /// </return>>>>>>>> 85b0c5b2f9532f44c5bd0fb7e9e066e5e8079720
        bool DeleteActivity(int id);

        /// <summary>
        /// Declares a method to edit a particular activity.
        /// </summary>
        /// <param name="activity">The details that is to be edited.
        /// </param>
        /// <param name="id">The unique id of activity that is to be edited.
        /// </param>
        /// <return>
        /// True for successful updation else false.
        /// </return
        bool EditActivity(Activity activity, int id);

        /// <summary>
        /// Declares a method to get activities for next 5 days.
        /// </summary>
        /// <param name="fromDate">current date.
        /// </param>
        /// <param name="toDate">current date +5 days.
        /// </param>
        /// <return>
        /// The activities scheduled for next 5 days.
        /// </return>
        List<Activity> GetActivities(DateTime fromDate, DateTime toDate);
    }
}
