using DDD.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Membership
{
    public class AccountId2: IntIdentity2
    {
        protected AccountId2()
        {
        }

        protected AccountId2(int identity): base(identity)
        {
        }

        public static AccountId2 Create(int identity)
        {
            return new AccountId2(identity);
        }

        public static implicit operator int(AccountId2 accountId)
        {
            return accountId.Identity;
        }

        public static implicit operator AccountId2(int identity)
        {
            return Create(identity);
        }
    }
}
