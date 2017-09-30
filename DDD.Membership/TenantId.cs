using DDD.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Membership
{
    public class TenantId: IntIdentity
    {
        private TenantId()
        {
        }

        protected TenantId(int identity): base(identity)
        {
        }

        public static TenantId Create(int identity)
        {
            return new TenantId(identity);
        }

        public static implicit operator int(TenantId tenantId)
        {
            return tenantId._identity;
        }

        public static implicit operator TenantId(int identity)
        {
            return Create(identity);
        }

        //public static bool operator ==(TenantId left, TenantId right)
        //{
        //    return EqualOperator(left, right);
        //}

        //public static bool operator !=(TenantId left, TenantId right)
        //{
        //    return NotEqualOperator(left, right);
        //}
    }
}
