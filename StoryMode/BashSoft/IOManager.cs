using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                foreach (var directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }

                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));
            }

            //while (subFolders.Count != 0)
            //{
            //    string currentPath = subFolders.Dequeue();
            //    int identation = currentPath.Split('\\').Length - initialIdentation;

            //    if (depth - identation < 0)
            //    {
            //        break;
            //    }

            //    try
            //    {
            //        foreach (var directoryPath in Directory.GetDirectories(currentPath))
            //        {
            //            subFolders.Enqueue(directoryPath);
            //        }

            //        OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

            //        foreach (var file in Directory.GetFiles(SessionData.currentPath))
            //        {
            //            int indexOfLastSlash = file.LastIndexOf("\\");
            //            string fileName = file.Substring(indexOfLastSlash);
            //            OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
            //        }
            //    }
            //    catch (UnauthorizedAccessException)
            //    {
            //        OutputWriter.WriteMessageOnNewLine(ExceptionMessages.UnauthorizedExceptionMessage);
            //    }
            //}
        }
    }
}
