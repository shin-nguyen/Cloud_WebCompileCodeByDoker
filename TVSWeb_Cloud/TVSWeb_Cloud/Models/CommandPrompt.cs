using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public class CommandPrompt
    {
        public static string ExecuteCommand(object command)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = processStartInfo;

                process.Start();
                string result = process.StandardOutput.ReadToEnd();
                return result;
            }
            catch (Exception objEx)
            {
                return objEx.ToString();
            }
        }
        public static string ExecuteCommands(List<string> commands, string path, string fileName)
        {
            string batFileName = path + fileName + ".bat";
            using (StreamWriter batFile = new StreamWriter(batFileName))
            {
                foreach (var command in commands)
                {
                    batFile.WriteLine(command);
                }
            }
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = batFileName;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // Read the output stream first and then wait.

            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();

            File.Delete(batFileName);

            return output;
        }
    }
}