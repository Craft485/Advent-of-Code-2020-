﻿using System;
using System.IO;
using System.Diagnostics;

namespace Advent_of_Code {
    class App {
        public static string[] dirs = Directory.GetDirectories(".");
        //This eval function isn't valid
        static void Main(string[] args) {
            // Advent_of_Code.Test.Main(args);
            string year = args[0];
            string day = args[1];
            // Console.WriteLine("[{0}]", string.Join(", ", args));
            // Console.WriteLine($"arg 0:{year}\narg 1:{day}");
            if (Array.Exists(dirs, e => e == $@".\{year}")) {
                string[] files = Directory.GetFiles($@".\{year}\days");
                // Console.WriteLine("[{0}]", string.Join(", ", files));
                if (Array.Exists(files, e => e.EndsWith($"{day}.cs"))) {
                    string cmdStr = $@"cd .\{year}\days\bin && day{day}.exe";
                    // Setup new cmd prompt process
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();
                    // Run said process and read out its result
                    cmd.StandardInput.WriteLine(cmdStr);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                }
            }
        }
    }
}

