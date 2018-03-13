using System;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            //IOManager.TraverseDirectory(@"C:\Users\user\Source\Repos");

            StudentsRepository.InitializeData();
            StudentsRepository.GetAllStudentsFromCourse("Unity");
            OutputWriter.WriteEmptyLine();
            StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        }
    }
}
