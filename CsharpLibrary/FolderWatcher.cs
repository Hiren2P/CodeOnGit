using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CsharpLibrary
{
    public class FolderWatcher
    {
        /// <summary>
        /// Method watches a folder on the system
        /// </summary>
        /// <param name="folderToWatch"></param>
        public static void WatchFolder(string folderToWatch)
        {
            try
            {
                FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
                fileSystemWatcher.Path = folderToWatch;
                fileSystemWatcher.IncludeSubdirectories = true;

                fileSystemWatcher.Created += new FileSystemEventHandler(OnCreated);
                fileSystemWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                fileSystemWatcher.Error += new ErrorEventHandler(OnError);
                fileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);
                fileSystemWatcher.Disposed += new EventHandler(OnDisposed);
                fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
                fileSystemWatcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Inside changed");
        }

        static void OnDisposed(object sender, EventArgs e)
        {
            Console.WriteLine("Inside disposed");
        }

        static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Inside disposed");
        }

        static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Inside renamed");
        }

        static void OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Inside error");
        }

        static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Inside disposed");
        }

    }
}
