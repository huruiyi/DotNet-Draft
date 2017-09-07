using System;
using System.Collections;

namespace ConApp.Model
{
    public class Int16Collection : CollectionBase
    {
        public Int16 this[int index]
        {
            get
            {
                return ((Int16)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(Int16 value)
        {
            return (List.Add(value));
        }

        public int IndexOf(Int16 value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, Int16 value)
        {
            List.Insert(index, value);
        }

        public void Remove(Int16 value)
        {
            List.Remove(value);
        }

        public bool Contains(Int16 value)
        {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(System.Int16))
                throw new ArgumentException("value must be of type Int16.", "value");
        }
    }
}