using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    /// <summary>
    /// Defines the interface for the ActivityBLL.
    /// </summary>
    public interface IActivityBll

    {
        /// <summary>
        /// Declares a method to add activity
        /// </summary>
        /// <param name="newdata"> The data to be added </param>
        void Add(Activity newdata);
        /// <summary>
        /// Declares a method to delete an activity with id
        /// </summary>
        /// <param name="id"> The id of activity that is to be deleted.</param>
        void Delete(int id);
        /// <summary>
        /// Declares a method to get the activities for upcoming 5 days.
        /// </summary>
        /// <returns>list of activities for upcoming 5 days </returns>
        List<Activity> GetActivitiesForTheDay();
        /// <summary>
        /// Method for updating an activity with id.
        /// </summary>
        /// <param name="newdata"> data to update</param>
        /// <param name="id"> Id of activity to update   </param>
        void Update(Activity newdata, int id);
    }
}
