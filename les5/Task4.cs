using System;
using System.IO;
using System.Linq;

namespace les5
{
    public class Task4
    {
        private static void AppendNode(string path, ref string[] tree)
        {
            Array.Resize(ref tree, tree.Length + 1);
            tree[tree.Length - 1] = path;
        }

        private static string PopNode(ref string[] tree)
        {
            string node = tree[tree.Length - 1];
            Array.Resize(ref tree, tree.Length - 1);
            return node;
        }

        public static void GetTreeWithoutRecursive(string path, ref string[] tree)
        {
            string[] searchDirs = {path};

            while (searchDirs.Length > 0)
            {
                string curDir = PopNode(ref searchDirs);
                if (Directory.Exists(curDir))
                {
                    string[] subPath = Directory.GetFileSystemEntries(curDir);
                    AppendNode(curDir, ref tree);
                    for (int i = 0; i < subPath.Length; i++)
                    {
                        if (Directory.Exists(subPath[i]))
                        {
                            AppendNode(subPath[i], ref searchDirs);
                        }
                        else if (subPath[i] != null)
                        {
                            AppendNode(subPath[i], ref tree);
                        }
                    }
                }
            }
        }
        public static void GetTreeRecursive(string path, ref string[] tree)
        {
            if (Directory.Exists(path))
            {
                string[] subPath = Directory.GetFileSystemEntries(path);
                AppendNode(path, ref tree);
                for (int i = 0; i < subPath.Length; i++)
                {
                    if (Directory.Exists(subPath[i]))
                    {
                        GetTreeRecursive(subPath[i], ref tree);
                    }
                    else if (subPath[i] != null)
                    {
                        AppendNode(subPath[i], ref tree);
                    }
                }
            }
        }
    }
}