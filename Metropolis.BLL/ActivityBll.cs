using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
    /// <summary>
    /// The ActivityBll class.
    /// Contains all methods for performing basic logic functions.
    /// </summary>
    /// <remarks>
    /// This class can order the actvities and check the conditions for update and add activities.
    /// </remarks>
    public class ActivityBll : IActivityBll
    {
        private readonly IActivityDal _activityDal;
        private readonly ApplicationDbContext _db;
        public ActivityBll(IActivityDal activityDal, ApplicationDbContext db)
        {
            _activityDal = activityDal;
            _db = db;
        }
        
        
        /// <summary>
        ///List the activities for upcoming 5 days.
        /// </summary>
        ///<remarks>
        ///This method orders the list sorted alphabetically based on street name and ascending order of the day.
        /// Activities with streets completely closed appears on the top of the list.
        ///</remarks>
        ///<returns>list of activities displayed in the website for upcoming 5 days
        
  
        public List<Activity> GetActivitiesForTheDay()
        {
          ///1.Store the value of current date.
          ///2.Get the list of activities for next 5 days.
          ///3.Order them.
          
            List<Activity> activities = new List<Activity>();
            var  fromDate = DateTime.UtcNow.Date;
            var toDate = fromDate.AddDays(5).Date;
            activities = _activityDal.GetActivities(fromDate, toDate);
            return activities.OrderBy(x => x.ScheduledDate).ThenByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ToList();
        }


        ///<summary>This method checks the conditions for adding the acitivities in to the list.</summary>
        ///<param name="newdata">new data to add</param>
         

        public void Add(Activity newdata) 
        {
            /// 1.Check whether the no.of activites per day is less than 15 
            /// 2.Also check whether Activity name of input data doen't exist in the database for same date.
            /// 3.If the conditions are true,check the street is completely closed.
            /// 4.Then check the no.of activies with street completely closed for the date is less than 6, then add the activity to the database.
            /// 4.Else add to database.
        
           Activity data = new Activity();
            int count_activity_per_day = _db.Activities.Where(u => u.ScheduledDate.Date == newdata.ScheduledDate.Date).Count();
            data = _db.Activities.Where(u => u.ScheduledDate.Date == newdata.ScheduledDate.Date).FirstOrDefault(u => u.ActivityName == newdata.ActivityName);
            if (count_activity_per_day < 15 && data == null)
            { 
                if (newdata.IsClosed == true)
                {
                    int count_isclosed = _db.Activities.Where(u => u.ScheduledDate.Date == newdata.ScheduledDate.Date).Where(u => u.IsClosed == true).Count();
                    if (count_isclosed < 6) { _activityDal.AddActivity(newdata);}
                }
                else { _activityDal.AddActivity(newdata); } 
               
            }
        }



        ///<summary> Method for deleting an activity with id.</summary>
         ///<param name="id">Id of activity to delete</param>

        public void Delete(int id)
        {
          _activityDal.DeleteActivity(id);
        }

        
        
        
        
        ///<summary>Method for updating an activity with id.</summary>
        ///<param name="new data">data to update</param>
        ///<param name="id">Id of activity to update</param>
        
        public void Update(Activity newdata, int id)
        {
            ///1.Check whether activity with the id present in database.
            /// 2.If exists, Check whether the no.of activites per day is less than 15 
            /// 3.Also check whether Activity name of input data doen't exist in the database for same date.
            /// 4.if the street is completey closed for the input data and existing data in databse is completely closed.
            /// 5.Then check the no.of activies with street completely closed for the date is less than 6, then add the activity to the database
            /// 5.else update the databse
        
            
            Activity data = new Activity();
            Activity rdata = new Activity();
            rdata = _db.Activities.FirstOrDefault(u => u.ActivityId == id);
            if (rdata!= null)
            {
                int count_activity_per_day = _db.Activities.Where(u => u.ScheduledDate.Date == newdata.ScheduledDate.Date).Count();
                data = _db.Activities.Where(u => u.ScheduledDate.Date == newdata.ScheduledDate.Date).Where(u => u.ActivityId != id).FirstOrDefault(u => u.ActivityName == newdata.ActivityName);
                if (count_activity_per_day < 16 && data == null)
                {
                    if(newdata.IsClosed == true && rdata.IsClosed == false)
                    {
                        int count_isclosed = _db.Activities.Where(u => u.ScheduledDate.Date == newdata.ScheduledDate.Date).Where(u => u.IsClosed == true).Count();
                        if (count_isclosed < 7) { _activityDal.EditActivity(newdata, id); }
                    }
                    else { _activityDal.EditActivity(newdata, id); }
                }
               
            }
         }

    }
}
