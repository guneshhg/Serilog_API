using Data.Entity;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class MembershipRepository : Repository<Membership>, IMembershipRepository
    {
        public MembershipRepository(DataContext dataContext)
            : base(dataContext)
        {

        }
    }
}