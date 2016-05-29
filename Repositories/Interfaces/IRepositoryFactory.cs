using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepositoryFactory
    {
        ICompanyRepository GetCompanyRepository();
        IDealRepository GetDealRepository();
        IObjectRepository GetObjectRepository();
        IPersonRepository GetClientRepository();
        IPersonRepository GetOwnerRepository();
        IShowRepository GetShowRepository();
        IStaffRepository GetStaffRepository();
        IWishRepository GetWishRepository();
    }
}
