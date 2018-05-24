namespace BashSoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("show")]
    public class ShowCourseCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public ShowCourseCommand(string input, string[] data) 
            : base(input, data) { }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string course = this.Data[1];
                this.repository.GetAllStudentsFromCourse(course);
            }
            else if (this.Data.Length == 3)
            {
                var course = this.Data[1];
                var username = this.Data[2];
                this.repository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
