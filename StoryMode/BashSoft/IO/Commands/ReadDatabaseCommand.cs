using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    public class ReadDatabaseCommand : Command
    {
        public ReadDatabaseCommand(
            string input, string[] data, Tester judge, StudentsRepository repository, IDirectoryManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var databasePath = this.Data[1];
            this.Repository.LoadData(databasePath);
        }
    }
}
