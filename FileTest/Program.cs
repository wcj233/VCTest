using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    class FileClass
    {
        public void TraverseFileFunc(string root)
        {
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root) && !System.IO.File.Exists(root))
            {
                Console.WriteLine("Please enter a valid path:");
                TraverseFileFunc(Console.ReadLine());
                //throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {

                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }

            Console.WriteLine("Do you need to move or delete files?(move or delete)");
            string action = Console.ReadLine();
            if (action.Equals("move"))
            {
                Console.WriteLine("Please enter the original path:");
                moveFile(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Please enter the path of the file you want to delete:");
                if (System.IO.File.Exists(Console.ReadLine()))
                {
                    try
                    {
                        System.IO.File.Delete(Console.ReadLine());
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (System.IO.Directory.Exists(Console.ReadLine()))
                {
                    try
                    {
                        System.IO.Directory.Delete(Console.ReadLine());
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else {
                    Console.WriteLine("The file was not queried");
                }
            }
        }

        void moveFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("Please enter a valid path:");
                string source = Console.ReadLine();
                moveFile(source);
            }
            else
            {
                Console.WriteLine("Please enter the destination path:");
                string des = Console.ReadLine();
                System.IO.File.Move(path, des);
            }

        }


        static void Main()
        {
            Console.WriteLine("Please enter a path：");
            string readPath = Console.ReadLine();
            //Traverse
            FileClass fileC = new FileClass();
            fileC.TraverseFileFunc(readPath);
            Console.ReadKey();
        }
    }
}
