using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class Student
    {
        public string fname { get; }
        public string lname { get; }
        public string kierunek { get; }
        public string type { get; }
        public string index { get; }
        public DateTime bdate { get; }
        public string mail { get; }
        public string mname { get; }
        public string dname { get; }
        public Student(string fname, string lname, string kierunek, string type, string index, DateTime bdate, string mail, string mname, string dname)
        {
            this.fname=fname;
            this.lname=lname;
            this.kierunek=kierunek;
            this.type=type;
            this.index=index;
            this.bdate=bdate;
            this.mail=mail;
            this.mname=mname;
            this.dname=dname;
        }
    }
}
