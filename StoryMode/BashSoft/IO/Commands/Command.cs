using BashSoft.Exceptions;
using System;

namespace BashSoft.IO.Commands
{
    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Inpput = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public string Inpput
        {
            get
            {
                return this.input;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public Tester Judge
        {
            get
            {
                return this.judge;
            }
        }

        public StudentsRepository Repository
        {
            get
            {
                return this.repository;
            }
        }

        public IOManager InputOutputManager
        {
            get
            {
                return this.inputOutputManager;
            }
        }

        public abstract void Execute();
    }
}
