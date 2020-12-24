using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metropolis.BLL
{
    public interface IAdminBll
    {
        bool SearchUser(Admin data);
    }
}
