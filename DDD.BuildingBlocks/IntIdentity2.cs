using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.BuildingBlocks
{
    public abstract class IntIdentity2: ValueObject2<IntIdentity2>
    {
        protected readonly int _identity;

        protected IntIdentity2()
        {
            _identity = -1;
        }

        protected IntIdentity2(int identity)
        {
            if (identity <= 0)
                throw new ArgumentException(nameof(identity));

            _identity = identity;
        }

        public override bool Equals(IntIdentity2 other)
        {
            return base.Equals(other) && _identity != -1 && other?.Identity != -1;
        }

        protected int Identity => _identity;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Identity;
        }
    }
}
