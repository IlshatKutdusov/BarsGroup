using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BarsGroup12122
{
    public class Student
    {
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int Course { get; set; }
        public int GroupNumber { get; set; }
        public int Appraisals { get; set; }

        public Student(string firstName, string name, string lastName, int yearOfBirth, int course, int groupNumber, params int[] appraisals)
        {
            this.FirstName = firstName;
            this.Name = name;
            this.LastName = lastName;
            this.YearOfBirth = yearOfBirth;
            this.Course = course;
            this.GroupNumber = groupNumber;
            for (int i = 0; i < appraisals.Length; i++)
                this.Appraisals += appraisals[i];
            this.Appraisals = Appraisals / appraisals.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Log logger = new Log();

            var studentList = new List<Student>();
            studentList.Add(new Student("FName1", "Name1", "LName1", 110, 3, 1100, 1, 1, 1, 1, 1));
            studentList.Add(new Student("FName2", "Name2", "LName2", 120, 2, 2100, 2, 2, 2, 2, 2));
            studentList.Add(new Student("FName3", "Name3", "LName3", 130, 2, 3100, 3, 3, 3, 3, 3));
            studentList.Add(new Student("FName4", "Name4", "LName4", 140, 1, 4100, 4, 4, 4, 4, 4));
            studentList.Add(new Student("FName5", "Name5", "LName5", 150, 1, 5100, 5, 5, 5, 5, 5));
            var sortedStudentList = from student in studentList orderby student.Course, student.FirstName select student;
            foreach (var x in sortedStudentList)
                Console.WriteLine(x.FirstName + " " + x.Course + " " + x.GroupNumber);
            int youngest = (from student in studentList select student.YearOfBirth).Max();
            int oldest = (from student in studentList select student.YearOfBirth).Min();
            Console.WriteLine("Youngest: " + youngest + " Oldest: " + oldest);
            var averageScoreList = from student in sortedStudentList
                                   group student by student.Course into groups
                                   select new
                                   {
                                       groups.Key,
                                       average = groups.Average(p => p.Appraisals)
                                   };
            foreach (var x in averageScoreList)
                Console.WriteLine("GroupNumber: " + x.Key + " AverageScore: " + x.average);

            Console.ReadLine();
        }
    }
}
