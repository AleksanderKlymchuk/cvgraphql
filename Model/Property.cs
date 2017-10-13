using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Property<T>
    {

        private T _value;

        public T Value
        {
            get => _value;
            set => _value = value;
        }


        public static implicit operator T(Property<T> value) => value.Value;

        public static implicit operator Property<T>(T value) => new Property<T> { Value = value };
    }
}
