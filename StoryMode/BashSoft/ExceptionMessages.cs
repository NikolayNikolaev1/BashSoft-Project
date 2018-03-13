namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";

        public const string DataAlreadyInitialisedException = "Data is already initialized!";

        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it.";

        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";

        public const string InvalidTakeQueryParamter = "The take command expected does not match the format wanted!";

        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        public const string UnableToGoHigherInParitionHierarchy = "Unable to go higher in partition hierarchy.";

        public static string UnableToParseNumber = "The sequence you've written is not a valid number.";

        public const string UnauthorizedExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";
    }
}
