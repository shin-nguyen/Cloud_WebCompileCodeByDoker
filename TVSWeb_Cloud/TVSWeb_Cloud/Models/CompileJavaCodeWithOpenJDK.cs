using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public class CompileJavaCodeWithOpenJDK
    {
        private string _containerOpenjdkName;
        private string _filePathInContainer;
        public CompileJavaCodeWithOpenJDK(string containerOpenjdkName, string filePathInContainer)
        {
            this._containerOpenjdkName = containerOpenjdkName;
            this._filePathInContainer = filePathInContainer;
        }
        public string Compile()
        {
            string command = "docker exec " + this._containerOpenjdkName + " javac " + this._filePathInContainer;
            string output = CommandPrompt.ExecuteCommand(command);

            return output;
        }

        public string Run()
        {
            var path = this._filePathInContainer.Substring(1, this._filePathInContainer.Length - 1).Split('/');
            var classPath = "/" + path[0];
            var fileName = path[1].Substring(0, path[1].Length - 5);

            string command = "docker exec " + this._containerOpenjdkName + " java -classpath " + classPath + " " + fileName;
            string output = CommandPrompt.ExecuteCommand(command);

            return output;
        }
    }
}