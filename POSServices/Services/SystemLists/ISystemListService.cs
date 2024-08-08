using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.SystemLists
{
	public interface ISystemListService
	{
		Task<IEnumerable<SystemList>> GetSystemListByListTypeID(int listTypeID);
        Task<IEnumerable<SystemList>> GetAllSystemList();
    }
}
