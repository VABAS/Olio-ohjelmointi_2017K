using System;
namespace H03T05
{
    class Program
    {
        static void Main ()
        {
            Student[] students = new Student[5];
            students[0] = new Student("K1661", "Jesse", "Siekkinen", "1994-7-7", "TTV15S6");
            students[1] = new Student("C1700", "Heikki", "Haukka", "1990-11-15", "TTV11S1");
            students[2] = new Student("K1201", "Hilla", "Haavisto", "1890-8-20", "TTV82K1");
            students[3] = new Student("PQ721", "Jaakko", "Naama", "2000-5-11", "TTV17S7");
            students[4] = new Student("T1111", "Maukka", "Mielinen", "1997-7-28", "TTV15S3");
            
            for (int i = 0; i < students.Length; i++)
            {
                students[i].printData();
            }
        }
    }
}