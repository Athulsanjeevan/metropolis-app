using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metropolis.BLL
{
    public class AdminBll:IAdminBll
    {
       private readonly ApplicationDbContext _db;
       public AdminBll(ApplicationDbContext db)
            {
                _db = db;
            }
        public bool SearchUser(Admin data)
        {
            if (_db.Admins.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password) != null)
            {
             return true;  
            }
            else { return false; }
        }

    }
    
}
