using System.Configuration;

namespace ShellDemo
{
    public static class EncryptConnection
    {
        /// <summary>
        /// 加密app.config
        /// </summary>
        /// <param name="encrypt"></param>
        public static void EncryptConnectionString(bool encrypt)
        {
            Configuration configFile = null;
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection configSection = configFile.GetSection("connectionStrings") as ConnectionStringsSection;
                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    //encrypt is false to unencrypt
                    {
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }
                    if (!encrypt && configSection.SectionInformation.IsProtected)
                    //encrypt is true so encrypt
                    {
                        configSection.SectionInformation.UnprotectSection();
                    }
                    //re-save the configuration file section
                    configSection.SectionInformation.ForceSave = true;
                    // Save the current configuration.
                    configFile.Save();
                }
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
        }
    }
}