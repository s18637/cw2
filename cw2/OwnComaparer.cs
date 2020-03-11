﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class OwnComaparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.fname} {x.lname} {x.index}", $"{y.fname} {y.lname} {y.index}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode($"{obj.fname} {obj.lname} {obj.index}");
        }
    }
}
