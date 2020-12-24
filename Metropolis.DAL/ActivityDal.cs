using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Metropolis.DAL
{

    /// <summary>
    /// This class describes the methods for add,delete,update,read.
    /// </summary> 

    public class ActivityDal : IActivityDal
    {
        private readonly ApplicationDbContext _dbContext;
	
        public ActivityDal(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
	
	/// <summary>
	/// Defines a method to get activities for next 5 days.
	/// </summary>
	/// <param name="fromDate">current date.
	/// </param>
	/// <param name="toDate">current date +5 days.
	/// </param>
	/// <return>
	/// The activities scheduled for next 5 days.
	/// </return>
        public List<Activity> GetActivities(DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Activities
            .Where(x => x.ScheduledDate >= fromDate && x.ScheduledDate <= toDate)
            .ToList();
        }
	
	/// <summary>
	/// Defines a method to add an activity .
	/// </summary>
	/// <param name="activity"> The data about activity to be added.
	/// </param>
	/// <return>
	/// True for successful insertion else false.
	/// </return>

        public bool AddActivity(Activity activity)
        {
            if (activity != null)
            {
                try
                {
                    var activities = _dbContext.Activities;
                    activities.Add(activity);
                    _dbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }



            else
            {
                return false;
            }

        }

        /// <summary>
	/// Defines a method to edit a particular activity.
	/// </summary>
	/// <param name="activity">The details that is to be edited.
	/// </param>
	/// <param name="id">The unique id of activity that is to be edited.
	/// </param>
	/// <return>
	/// True for successful updation else false.
	/// </return>

        public bool EditActivity(Activity activity,int id)
        {
            var activities = _dbContext.Activities.Where(x => x.ActivityId == id).FirstOrDefault();

            if (activities != null)
            {
                try
                {
                    activities.ActivityName = activity.ActivityName;
                    activities.ActivityType = activity.ActivityType;
                    activities.ScheduledDate = activity.ScheduledDate;
                    activities.StreetName = activity.StreetName;
                    activities.AlternativeStreet = activity.AlternativeStreet;
                    activities.IsClosed = activity.IsClosed;
                    _dbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
	
         /// <summary>
	/// Defines a method to delete the details of a particular activity.
	/// </summary>
	/// <param name="id">The id of activity that is to be deleted.
	/// </param>
	/// <return>
	/// True for successful deletion else false.
	/// </return>
        public bool DeleteActivity(int id)
        {
            var activities = _dbContext.Activities.Where(x => x.ActivityId == id).FirstOrDefault();
            if (activities != null)
            {
                try
                {

                    _dbContext.Activities.Remove(activities);
                    _dbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;

                }

            }
            else
            {
                return false;
            }
        }

    }
}

