using Data.Entity;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext dataContext)
            : base(dataContext)
        {

        }
    }
}