using DDD.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Membership
{
    public class TenantId2 : IntIdentity2
    {
        private TenantId2()
        {
        }

        protected TenantId2(int identity) : base(identity)
        {
        }

        public static TenantId2 Create(int identity)
        {
            return new TenantId2(identity);
        }

        public static implicit operator int(TenantId2 tenantId)
        {
            return tenantId.Identity;
        }

        public static implicit operator TenantId2(int identity)
        {
            return Create(identity);
        }
    }
}
