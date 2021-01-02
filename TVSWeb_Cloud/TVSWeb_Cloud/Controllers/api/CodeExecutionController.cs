using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TVSWeb_Cloud.Models;

namespace TVSWeb_Cloud.Controllers.api
{
    public class CodeExecutionController : ApiController
    {
        [HttpGet]
        public string RunCSharpCode(string namespaces, string codeContent) {

            string className = "a" + string.Format(@"{0}", Math.Abs(Guid.NewGuid().GetHashCode()));
            string fileName = className + ".cs";
            
            var lines = codeContent.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = "\t" + lines[i];
            }

            codeContent = String.Join("\n", lines);
            

            string fileContent = namespaces + "\npublic class " + className + "\n{\n" + codeContent + "\n}";

            FileCode.Create(fileName, ConfigurationDocker.StoragePathInHost, fileContent);

            CompileCSharpCodeWithMono compile = new CompileCSharpCodeWithMono(ConfigurationDocker.MonoContainerName, ConfigurationDocker.StoragePathInContainer + "/" + fileName);

            var outputCompile = compile.Compile();
            if (outputCompile != "")
                return outputCompile;

            var outputRun = compile.Run();

            FileCode.Delete(fileName, ConfigurationDocker.StoragePathInHost);

            var fileNameExe = fileName.Substring(0, fileName.Length - 2) + "exe";
            FileCode.Delete(fileNameExe, ConfigurationDocker.StoragePathInHost);

            return outputRun;
        }

        [HttpGet]
        public string RunJavaCode(string namespaces, string codeContent)
        {
            string className = "a" + string.Format(@"{0}", Math.Abs(Guid.NewGuid().GetHashCode()));
            string fileName = className + ".java";

            var lines = codeContent.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = "\t" + lines[i];
            }

            codeContent = String.Join("\n", lines);

            string fileContent = namespaces + "\nclass " + className + "\n{\n" + codeContent + "\n}";

            FileCode.Create(fileName, ConfigurationDocker.StoragePathInHost, fileContent);

            CompileJavaCodeWithOpenJDK compile = new CompileJavaCodeWithOpenJDK(ConfigurationDocker.OpenjdkContainerName, ConfigurationDocker.StoragePathInContainer + "/" + fileName);

            var outputCompile = compile.Compile();
            if (outputCompile != "")
                return outputCompile;

            var outputRun = compile.Run();

            FileCode.Delete(fileName, ConfigurationDocker.StoragePathInHost);

            var fileNameClass = fileName.Substring(0, fileName.Length - 4) + "class";
            FileCode.Delete(fileNameClass, ConfigurationDocker.StoragePathInHost);

            return outputRun;
        }
    }
}
