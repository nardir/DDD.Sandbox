using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.BuildingBlocks
{
    public abstract class IntIdentity: ValueObject
    {
        protected readonly int _identity;

        protected IntIdentity()
        {
        }

        protected IntIdentity(int identity)
        {
            if (identity <= 0)
                throw new ArgumentException(nameof(identity));

            _identity = identity;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _identity;
        }

        public static bool operator ==(IntIdentity left, IntIdentity right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(IntIdentity left, IntIdentity right)
        {
            return NotEqualOperator(left, right);
        }
    }
}
