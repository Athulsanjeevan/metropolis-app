using Metropolis.BLL;
using Metropolis.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ActivityController : ControllerBase
    {
        private readonly IActivityBll _ActivityBLL;
        public ActivityController(IActivityBll ActivityBLL)
        {
            _ActivityBLL = ActivityBLL;
        }
        [HttpGet]
        public List<Activity> GetAll()
        {

            return _ActivityBLL.GetActivitiesForTheDay();
        }
        [HttpPost]
        [Authorize]
        public void Add(Activity activity)
        {
            _ActivityBLL.Add(activity);
        }



        [HttpDelete("{Id}")]
        [Authorize]
        public void Delete(int Id)
        {
            _ActivityBLL.Delete(Id);
        }


        [HttpPut("{Id}")]
        [Authorize]
        public void Update(Activity activity, int Id)
        {
            _ActivityBLL.Update(activity, Id);
        }
    }
}
