using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.BuildingBlocks
{
    public abstract class ValueObject2<T> : IEquatable<T>
        where T : ValueObject2<T>
    {
        protected static bool EqualOperator(ValueObject2<T> left, ValueObject2<T> right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject2<T> left, ValueObject2<T> right)
        {
            return !(EqualOperator(left, right));
        }

        public static bool operator ==(ValueObject2<T> left, ValueObject2<T> right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(ValueObject2<T> left, ValueObject2<T> right)
        {
            return NotEqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            T other = obj as T;

            return Equals(other);
        }

        public virtual bool Equals(T other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }
            
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
   
        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }
    }
}