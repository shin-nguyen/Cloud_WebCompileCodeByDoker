using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public class CompileCSharpCodeWithMono
    {
        private string _containerMonoName;
        private string _filePathInContainer;
        public CompileCSharpCodeWithMono(string containerMonoName, string filePathInContainer)
        {
            this._containerMonoName = containerMonoName;
            this._filePathInContainer = filePathInContainer;
        }
        public string Compile()
        {
            string command = "docker exec " + this._containerMonoName + " mcs " + this._filePathInContainer;
            string output = CommandPrompt.ExecuteCommand(command);
            
            return output;
        }

        public string Run()
        {
            var newFilePath = this._filePathInContainer.Substring(0, this._filePathInContainer.Length - 2) + "exe";

            string command = "docker exec " + this._containerMonoName + " mono " + newFilePath;
            string output = CommandPrompt.ExecuteCommand(command);

            return output;
        }
    }
}