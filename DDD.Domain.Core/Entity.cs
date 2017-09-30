using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Core
{
    public abstract class Entity<TIdentity>
    {
        TIdentity _identity;

        public virtual TIdentity Identity
        {
            get
            {
                return _identity;
            }

            protected set
            {
                _identity = value;
            }
        }

        public override int GetHashCode()
        {
            return _identity.GetHashCode();
        }
    }
}
