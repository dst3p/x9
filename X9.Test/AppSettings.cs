using System.Configuration;

namespace X9.Test
{
    public static class AppSettings
    {
        public static string RootPath
        {
            get
            {
                return ConfigurationManager.AppSettings["RootPath"];
            }
        }

        public static string InputFilesFragment
        {
            get { return ConfigurationManager.AppSettings["InputFilesFragment"]; }
        }

        public static string OutputFilesFragment
        {
            get { return ConfigurationManager.AppSettings["OutputFilesFragment"]; }
        }

        public static string InputFilesPath
        {
            get
            {
                return RootPath + InputFilesFragment;
            }
        }

        public static string OutputFilesPath
        {
            get
            {
                return RootPath + OutputFilesFragment;
            }
        }
    }
}