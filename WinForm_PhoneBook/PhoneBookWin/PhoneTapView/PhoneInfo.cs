namespace PhoneBookWin
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    internal class PhoneInfo : IComparable
    {
        private string compare;
        private string name;
        private string phoneNumber;
        private string etc;

        public PhoneInfo(string name, string num, string compare, string etc)
        {
            this.name = name;
            this.phoneNumber = num;
            this.etc = etc;
            this.compare = compare;
        }

        public int CompareTo(object obj)
        {
            PhoneInfo info = (PhoneInfo) obj;
            return this.name.CompareTo(info.name);
        }

        public override bool Equals(object obj)
        {
            PhoneInfo info = (PhoneInfo) obj;
            return (this.name.Equals(info.name) && this.phoneNumber.Equals(info.phoneNumber));
        }

        public override int GetHashCode() => 
            (EqualityComparer<string>.Default.GetHashCode(this.name) + EqualityComparer<string>.Default.GetHashCode(this.phoneNumber));

        public virtual void showPhoneInfo()
        {
            Console.WriteLine("name: " + this.name);
            Console.WriteLine("phone: " + this.phoneNumber);
        }

        public override string ToString() => 
            ("name: " + this.name + "\t phone: " + this.phoneNumber);

        public string Etc
        {
            get { return etc; }
            set { this.etc = value; }
        }

        public string Compare
        {
            get { return compare; }
            set { this.compare = value; }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { this.phoneNumber = value; }
        }
    }
}

