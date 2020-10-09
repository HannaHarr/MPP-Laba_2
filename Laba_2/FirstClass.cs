using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_2
{
    public class FirstClass
    {
        public int integerValue;
        public DateTime time;
        
        public int IntegerProperty { get; set; }
        public char CharProperty { get; private set; }

        public List<byte> list;

        public FirstClass() { }

        public FirstClass(char property)
        {
            CharProperty = property;
        }

        public override string ToString()
        {
            string ListItem = "";
            foreach (byte item in list)
            {
                ListItem += item.ToString() + "; ";
            }

            return "integerValue: " + integerValue + "\n" +
                   "time: " + time + "\n" +
                   "IntegerProperty: " + IntegerProperty + "\n" +
                   "CharProperty: " + CharProperty + "\n" +
                   "list: " + ListItem;
        }
    }
}
