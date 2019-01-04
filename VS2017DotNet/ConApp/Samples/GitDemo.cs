using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConApp
{
    public class GitDemo
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

        private static void Clone(string url, string destPath)
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

        private static void Fetch(String path)
        {
            try
            {
                string logMessage = "";
                using (var repo = new Repository(path))
                {
                    var remote = repo.Network.Remotes["origin"];
                    //var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                    //Commands.Fetch(repo, remote.Name, refSpecs, null, logMessage);
                    if(remote!=null&& remote.PushUrl != null)
                    {
                        Console.WriteLine(remote.PushUrl);
                    }
                    else
                    {
                        Console.WriteLine(path);
                    }
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(path);
            }
        }

        public static String GetPushUrl(String filePath)
        {
             
            try
            {
                using (var repo = new Repository(filePath))
                {
                    var remote = repo.Network.Remotes["origin"];
                    if (remote != null && remote.PushUrl != null)
                    {
                        filePath = remote.PushUrl;
                    }
                     
                }
            }
            catch (Exception e)
            {
              
            }

            return filePath;
        }

        public static void TaskClone(string urlLines, string destPath, int taskCount)
        {
            Queue<string> list = new Queue<string>();
            String[] strs = File.ReadAllLines(urlLines);
            foreach (string pathStr in strs)
            {
                list.Enqueue(pathStr);
            }
            Task task;
            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                task = Task.Factory.StartNew(() =>
                {
                    while (list.Any())
                        Clone(list.Dequeue(), destPath);
                });
                tasks[i] = task;
            }
            Task.WaitAll(tasks);
        }

        public static void TaskFetch(string urlLines, int taskCount)
        {
            Queue<string> list = new Queue<string>();
            String[] strs = File.ReadAllLines(urlLines);
            foreach (string pathStr in strs)
            {
                list.Enqueue(pathStr);
            }
            Task task;
            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                task = Task.Factory.StartNew(() =>
                {
                    while (list.Any())
                        Fetch(list.Dequeue());
                });
                tasks[i] = task;
            }
            Task.WaitAll(tasks);
        }
    }
}