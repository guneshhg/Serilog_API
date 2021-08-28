using System.Linq;
using Data.Entity;

namespace Data
{
    public static class SeedData
    {
        public static void Initialize(DataContext dataContext)
        {
            if (!dataContext.Memberships.Any())
            {
                dataContext.Memberships.AddRange(
                    new Membership
                    {
                        MembershipCode = "SLVR",
                        Title = "Silver",
                        Description = "Customer Accumulating $100 spent enjoy 2% discount"
                    },
                    new Membership
                    {
                        MembershipCode = "GLD",
                        Title = "Gold",
                        Description = "Customer Accumulating $500 spent enjoy 5% discount"
                    },
                    new Membership
                    {
                        MembershipCode = "PLTNM",
                        Title = "Platinum",
                        Description = "Customer Accumulating $1000 spent enjoy 10% discount"
                    }
                );
                dataContext.SaveChanges();
            }
        }
    }
}