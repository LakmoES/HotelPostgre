using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class RepositoryFactory
    {
        //private NpgsqlConnection conn = null;
        //private static RepositoryFactory instance;
        //private RepositoryFactory() { }
        //public static RepositoryFactory Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new RepositoryFactory();
        //        return instance;
        //    }
        //}
        public static ICompanyRepository GetCompanyRepository()
        {
            return new CompanyRepository();
        }
        public static IDealRepository GetDealRepository()
        {
            return new DealRepository();
        }
        public static IObjectRepository GetObjectRepository()
        {
            return new ObjectRepository();
        }
        public static IPersonRepository GetClientRepository()
        {
            return new PersonRepository("Client");
        }
        public static IPersonRepository GetOwnerRepository()
        {
            return new PersonRepository("Owner");
        }
        public static IShowRepository GetShowRepository()
        {
            return new ShowRepository();
        }
        public static IStaffRepository GetStaffRepository()
        {
            return new StaffRepository();
        }
        public static IWishRepository GetWishRepository()
        {
            return new WishRepository();
        }
    }
}
