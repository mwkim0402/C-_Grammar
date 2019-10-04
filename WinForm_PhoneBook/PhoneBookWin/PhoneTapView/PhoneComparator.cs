namespace PhoneBookWin
{
    using System;
    using System.Collections.Generic;

    internal class PhoneComparator : IComparer<PhoneInfo>
    {
        public int Compare(PhoneInfo x, PhoneInfo y) => 
            x.PhoneNumber.CompareTo(y.PhoneNumber);
    }
}

