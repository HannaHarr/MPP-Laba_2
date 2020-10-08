using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_2
{
    public class FirstClass
    {
        public int integerValue;
        
        public int IntegerProperty { get; set; }
        public char CharProperty { get; private set; }

        public FirstClass() { }

        public FirstClass(char property)
        {
            CharProperty = property;
        }

        public override string ToString()
        {
            return "integerValue: " + integerValue + "\n" +
                   "IntegerProperty: " + IntegerProperty + "\n" +
                   "CharProperty: " + CharProperty;
        }
    }
}
