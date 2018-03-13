using System;
using System.Collections.Generic;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] tokens = input.Split();
                string course = tokens[0];
                string student = tokens[1];
                int mark = int.Parse(tokens[2]);

                if (!studentByCourse.ContainsKey(course))
                {
                    studentByCourse.Add(course, new Dictionary<string, List<int>>());
                }

                if (!studentByCourse[course].ContainsKey(student))
                {
                    studentByCourse[course].Add(student, new List<int>());
                }

                studentByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) 
                && studentByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }
    }
}
