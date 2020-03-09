using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class Student
    {
        string fname { get; }
        string lname { get; }
        string kierunek { get; }
        string type { get; }
        string index { get; }
        DateTime bdate { get; }
        string mail { get; }
        string mname { get; }
        string dname { get; }
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
