using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Task3
{
    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses;

        public Student(int studentId, string name, int age)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Age = age;
            this.Courses = new List<Course>();
        }


        public bool Enroll(Course course)
        {
            this.Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            return "Student ID: " + StudentId + ", Name: " + Name + ", Age: " + Age;
        }
    }

    class Instructor
    {
        public int InstructorId;
        public string sname;
        public string specialization;

        public Instructor(int instructorid, string sname, string specialization)
        {
            this.InstructorId = instructorid;
            this.sname = sname;
            this.specialization = specialization;
        }

        public string PrintDetails()
        {
            return "Instructor ID: " + InstructorId + ", Instructor Name: " + sname + ", Instructor Specialization: " + specialization;
        }
    }

    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.CourseId = courseId;
            this.Title = title;
            this.Instructor = instructor;
        }

        public string PrintDetails()
        {
            return "Course ID: " + CourseId + ", Title: " + Title + ", Instructor: " + Instructor.sname;
        }
    }

    class StudentManager
    {
        public List<Student> Students;
        public List<Course> Courses;
        public List<Instructor> Instructors;


        public StudentManager()
        {
            this.Students = new List<Student>();
            this.Courses = new List<Course>();
            this.Instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            this.Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            this.Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            this.Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentid)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].StudentId == studentid)
                {
                    return this.Students[i];
                }
            }
            Console.WriteLine("The Student ID Does Not Exist!");
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].CourseId == courseId)
                {
                    return this.Courses[i];
                }
            }
            Console.WriteLine("The Course ID Does Not Exist!");
            return null;
        }

        public Student FindStudentByName(string studentName)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].Name == studentName)
                {
                    return this.Students[i];
                }
            }
            Console.WriteLine("The Student Name Does Not Exist!");
            return null;
        }

        public Course FindCourseByName(string courseName)
        {
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].Title == courseName) 
                {
                    return this.Courses[i];
                }
            }
            Console.WriteLine("The Course Name Does Not Exist!");
            return null;
        }

        public Instructor FindInstructor(int instructorid)
        {
            for (int i = 0; i < this.Instructors.Count; i++)
            {
                if (this.Instructors[i].InstructorId == instructorid)
                {
                    return this.Instructors[i];
                }
            }
            Console.WriteLine("The Instructor ID Does Not Exist!");
            return null;
        }

        public bool EnrollStudentInCourse(int studentid, int courseid)
        {
            Student student = FindStudent(studentid );
            Course course = FindCourse(courseid);

            if (student != null && course != null)
            {
                if (IsStudentEnrolled(studentid, courseid))
                {
                    Console.WriteLine("Student Is Already Enrolled In This Course!");
                    return false;
                }
                student.Enroll(course);
                return true;
            }
            return false;
        }

        public bool IsStudentEnrolled(int studentId, int courseId)
        {
            Student student = FindStudent(studentId );

            if (student != null)
            {
                for (int i = 0; i < student.Courses.Count; i++)
                {
                    if (student.Courses[i].CourseId == courseId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetInstructorByCourseName(string courseName)
        {
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].Title == courseName)
                {
                    return this.Courses[i].Instructor.sname;
                }
            }
            return "Course not found!";
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'Z' };
                char choice;
                int stage;
                string stname;
                int stid;
                string sspec;
                string sname;
                int sid;
                string cname;
                int cid;

                StudentManager newmanager = new StudentManager(); 
                do
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("------------Task3------------");
                    Console.WriteLine("  Student Management System  ");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("A - Add Student");
                    Console.WriteLine("B - Add Instructor");
                    Console.WriteLine("C - Add Course");
                    Console.WriteLine("D - Enroll Student in Course");
                    Console.WriteLine("E - Show All Students");
                    Console.WriteLine("F - Show All Courses");
                    Console.WriteLine("G - Show All Instructors");
                    Console.WriteLine("H - Find the student by id or name");
                    Console.WriteLine("I - Find the course by id or name");
                    Console.WriteLine("J - Check if a student is enrolled in a course");// el bonnuss
                    Console.WriteLine("K - Get the instructor of a course by course name");// we da kman
                    Console.WriteLine("Z - Exit");
                    Console.WriteLine("-----------------------------");

                    choice = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine("");
                    switch (choice)
                    {
                        case 'A':
                            Console.WriteLine("Enter Student ID");
                            stid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Student Name");
                            stname = Console.ReadLine();
                            Console.WriteLine("Enter Student Age");
                            stage = Convert.ToInt32(Console.ReadLine());
                            Student newStudent = new Student(stid, stname, stage);
                            newmanager.AddStudent(newStudent);
                            Console.WriteLine("Student Added Successfully!");
                            break;

                        case 'B':
                            Console.WriteLine("Enter Instructor ID");
                            sid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Instructor Name");
                            sname = Console.ReadLine();
                            Console.WriteLine("Enter Instructor pecialization");
                             sspec = Console.ReadLine();
                            Instructor newInstructor = new Instructor(sid, sname, sspec);
                            newmanager.AddInstructor(newInstructor);
                            Console.WriteLine("Instructor Added Successfully!");
                            break;

                        case 'C':
                            Console.WriteLine("Enter Course ID");
                            cid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course Name");
                            cname = Console.ReadLine();
                            Console.WriteLine("Enter Instructor ID for this Course");
                            int instId = Convert.ToInt32(Console.ReadLine());

                            Instructor foundInstructor = newmanager.FindInstructor(instId);

                            if (foundInstructor != null)
                            {
                                Course newCourse = new Course(cid, cname, foundInstructor);
                                newmanager.AddCourse(newCourse);
                                Console.WriteLine("Course Added Successfully!");
                            }
                            break;

                        case 'D':
                            Console.WriteLine("Enter Student ID");
                            int enrollstid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course ID");
                            int enrollcid = Convert.ToInt32(Console.ReadLine());
                           bool enrooled =newmanager.EnrollStudentInCourse(enrollstid, enrollcid);
                            if (enrooled)
                            {
                                Console.WriteLine("Student Enrolled Successfully!");
                            }
                            break;

                        case 'E':
                            Console.WriteLine("Students:");
                            Console.WriteLine("");
                            for (int i =0;i<newmanager.Students.Count; i++)
                            {
                                Console.WriteLine(newmanager.Students[i].PrintDetails());
                            }
                            break;

                        case 'F':
                            Console.WriteLine("Courses:");
                            Console.WriteLine("");
                            for (int i = 0; i < newmanager.Courses.Count; i++)
                            {
                                Console.WriteLine(newmanager.Courses[i].PrintDetails());
                            }
                            break;

                        case 'G':
                            Console.WriteLine("Instructors:");
                            Console.WriteLine("");
                            for (int i = 0; i < newmanager.Instructors.Count; i++)
                            {
                                Console.WriteLine(newmanager.Instructors[i].PrintDetails());
                            }
                            break;

                        case 'H':
                            Console.WriteLine("Enter Student ID or Name You Want To Search:");
                            string searchInput = Console.ReadLine();

                            Student foundStudent = null;
                            int searchId;
                            if (int.TryParse(searchInput, out searchId))
                            {
                                foundStudent = newmanager.FindStudent(searchId);
                            }
                            else
                            {
                                foundStudent = newmanager.FindStudentByName(searchInput);
                            }

                            if (foundStudent != null)
                            {
                                Console.WriteLine(foundStudent.PrintDetails());
                            }
                            break;
                        case 'I':
                            Console.WriteLine("Enter Course ID or Name You Want To Search:");
                            string searchCourseInput = Console.ReadLine();

                            Course foundCourse = null;
                            int searchCourseId;

                            if (int.TryParse(searchCourseInput, out searchCourseId))
                            {
                                foundCourse = newmanager.FindCourse(searchCourseId);
                            }
                            else
                            {
                                foundCourse = newmanager.FindCourseByName(searchCourseInput);
                            }

                            if (foundCourse != null)
                            {
                                Console.WriteLine(foundCourse.PrintDetails());
                            }
                            break;

                        case 'J':        //bonus
                            Console.WriteLine("Enter Student ID!");
                            int checkstid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course ID!");
                            int checkstcourse= Convert.ToInt32(Console.ReadLine());
                            bool isStudentEnrolled = newmanager.IsStudentEnrolled(checkstid, checkstcourse);
                            if (isStudentEnrolled)
                            {
                                Console.WriteLine("Yes, the student IS enrolled in this course.");
                            }
                            else
                            {
                                Console.WriteLine("No, the student is NOT enrolled in this course.");
                            }
                            break;

                        case 'K':
                            Console.WriteLine("Enter Course Name:");
                            string searchCName = Console.ReadLine();

                            string instName = newmanager.GetInstructorByCourseName(searchCName);
                            Console.WriteLine("Instructor Name: " + instName);
                            break;

                        default:
                            if (choice == 'z')
                            {
                                break;
                            }
                            else
                            { 
                            Console.WriteLine("Wrong Choice");
                            }
                            break;
                    }


                }
                while (choice != 'Z');




                Console.WriteLine("----------Taks Ended---------");
            }
        }
    }
}