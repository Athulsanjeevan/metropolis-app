using Metropolis.BLL;
using Metropolis.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBll _ContactBLL;
        public ContactController(IContactBll ContactBLL)
        {
            _ContactBLL = ContactBLL;
        }

        [HttpGet]
        public List<Contact> GetAll()
        {
            return _ContactBLL.GetContact();
        }
    }
}
