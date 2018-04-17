using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConApp
{
    internal class GitDeno
    {
        private static void SortUrl()
        {
            List<string> gitList = new List<string>();

            String[] strs = File.ReadAllLines(@"D:\js");
            foreach (string pathStr in strs)
            {
                if (!gitList.Contains(pathStr))
                {
                    gitList.Add(pathStr);
                }
            }

            gitList.Sort();
            File.AppendAllLines(@"D:\js.sort", gitList);
        }

        private static string GetDirName(string url)
        {
            return url.Substring(url.LastIndexOf("/") + 1).Replace(".git", ""); ;
        }

        public static void Clone(string url, string destPath)
        {
            string dstDir = GetDirName(url);
            CheckoutProgressHandler checkoutProgressHandler = (path, completedSteps, totalSteps) =>
            {
                Console.WriteLine(path + "  " + completedSteps + "  " + totalSteps);
            };
            CloneOptions options = new CloneOptions
            {
                OnCheckoutProgress = checkoutProgressHandler,
                OnProgress = (serverProgressOutput) =>
                {
                    Console.WriteLine("Progress: " + serverProgressOutput);
                    return true;
                },
            };

            string clonedRepoPath = Repository.Clone(url, Path.Combine(destPath, dstDir), options);
            using (Repository repo = new Repository(clonedRepoPath))
            {
                Console.WriteLine(repo.Stashes);
            }
        }

        private static void TaskClone(string urlLines, string destPath)
        {
            Queue<string> list = new Queue<string>();

            String[] strs = File.ReadAllLines(urlLines);
            foreach (string pathStr in strs)
            {
                list.Enqueue(pathStr);
            }

            Task t1 = Task.Factory.StartNew(() =>
            {
                while (list.Any())
                    Clone(list.Dequeue(), destPath);
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                while (list.Any())
                    Clone(list.Dequeue(), destPath);
            });

            Task t3 = Task.Factory.StartNew(() =>
            {
                while (list.Any())
                    Clone(list.Dequeue(), destPath);
            });

            Task t4 = Task.Factory.StartNew(() =>
            {
                while (list.Any())
                    Clone(list.Dequeue(), destPath);
            });

            Task t5 = Task.Factory.StartNew(() =>
            {
                while (list.Any())
                    Clone(list.Dequeue(), destPath);
            });
            Task.WaitAll(t1, t2, t3, t4, t5);
        }
    }
}
