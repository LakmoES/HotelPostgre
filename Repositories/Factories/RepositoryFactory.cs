using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryFactory : IRepositoryFactory
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
        public ICompanyRepository GetCompanyRepository()
        {
            return new CompanyRepository();
        }
        public  IDealRepository GetDealRepository()
        {
            return new DealRepository();
        }
        public  IObjectRepository GetObjectRepository()
        {
            return new ObjectRepository();
        }
        public IPersonRepository GetClientRepository()
        {
            return new PersonRepository("Client");
        }
        public IPersonRepository GetOwnerRepository()
        {
            return new PersonRepository("Owner");
        }
        public  IPersonRepository GetPersonRepository(string tableName)
        {
            return new PersonRepository(tableName);
        }
        public  IShowRepository GetShowRepository()
        {
            return new ShowRepository();
        }
        public  IStaffRepository GetStaffRepository()
        {
            return new StaffRepository();
        }
        public  IWishRepository GetWishRepository()
        {
            return new WishRepository();
        }
    }
}
