using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        DBConnection dbc;
        public RepositoryFactory(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public ICompanyRepository GetCompanyRepository()
        {
            return new CompanyRepository(dbc);
        }
        public  IDealRepository GetDealRepository()
        {
            return new DealRepository(dbc);
        }
        public  IObjectRepository GetObjectRepository()
        {
            return new ObjectRepository(dbc);
        }
        public IPersonRepository GetClientRepository()
        {
            return new PersonRepository(dbc, "Client");
        }
        public IPersonRepository GetOwnerRepository()
        {
            return new PersonRepository(dbc, "Owner");
        }
        public  IPersonRepository GetPersonRepository(string tableName)
        {
            return new PersonRepository(dbc, tableName);
        }
        public  IShowRepository GetShowRepository()
        {
            return new ShowRepository(dbc);
        }
        public  IStaffRepository GetStaffRepository()
        {
            return new StaffRepository(dbc);
        }
        public  IWishRepository GetWishRepository()
        {
            return new WishRepository(dbc);
        }
    }
}
