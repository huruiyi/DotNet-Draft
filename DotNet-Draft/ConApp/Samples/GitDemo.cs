using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConApp
{
    public class GitDemo
    {
        private static void Clone(string url, string destPath)
        {
            string dstDir = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1).Replace(".git", "");

            CloneOptions options = new CloneOptions
            {
                OnCheckoutProgress = (path, completedSteps, totalSteps) =>
                {
                    Console.WriteLine(path + "  " + completedSteps + "  " + totalSteps);
                },
                OnProgress = serverProgressOutput =>
                {
                    Console.WriteLine("Progress: " + serverProgressOutput);
                    return true;
                },
            };
            try
            {
                string path = Path.Combine(destPath, dstDir);
                if (!Directory.Exists(path))
                {
                    string clonedRepoPath = Repository.Clone(url, path, options);
                    using (Repository repo = new Repository(clonedRepoPath))
                    {
                        Console.WriteLine(repo.Stashes);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void TaskClone(string urlLines, string destPath, int taskCount)
        {
            Queue<string> list = new Queue<string>();
            String[] strs = File.ReadAllLines(urlLines);
            foreach (string pathStr in strs)
            {
                list.Enqueue(pathStr);
            }

            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    while (list.Any())
                        Clone(list.Dequeue(), destPath);
                });
                tasks[i] = task;
            }
            Task.WaitAll(tasks);
        }
    }
}