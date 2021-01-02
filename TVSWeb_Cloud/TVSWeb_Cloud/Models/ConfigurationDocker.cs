using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public static class ConfigurationDocker
    {
        public static string MonoContainerName = "mono123";
        public static string OpenjdkContainerName = "openjdk123";

        public static string StoragePathInHost = "C:/MyData/Test";
        public static string StoragePathInContainer = "/data";
    }
}