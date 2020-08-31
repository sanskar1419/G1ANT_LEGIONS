using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Goibibo.Properties;
using G1ANT.Language;
using System.IO;

namespace G1ANT.Addon.Goibibo
{
    [Addon(Name = "Goibibo",
         Tooltip = "Goibibo Commands")]
    [Copyright(Author = "G1ANT LTD", Copyright = "G1ANT LTD", Email = "hi@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "Goibibo", Tooltip = "Commands to work with web pages via supported web browsers.", IconName = "seleniumicon")]
    public class GoibiboAddon : Language.Addon
    {
        public override void LoadDlls()
        {
            UnpackDrivers();
            base.LoadDlls();
        }

        private void UnpackDrivers()
        {
            var unpackFolder = AbstractSettingsContainer.Instance.UserDocsAddonFolder.FullName;
            var embeddedResourceDictionary = new Dictionary<string, byte[]>()
            {
                { "chromedriver.exe", Resources.chromedriver },
                { "geckodriver.exe", Resources.geckodriver },
                { "IEDriverServer.exe", Resources.IEDriverServer }
            };
            foreach (var embededResource in embeddedResourceDictionary.Where(e => !DoesFileExist(unpackFolder, e.Key) || !AreFilesOfTheSameLength(e.Value.Length, unpackFolder, e.Key)))
            {
                try
                {
                    using (FileStream stream = File.Create(Path.Combine(unpackFolder, embededResource.Key)))
                    {
                        stream.Write(embededResource.Value, 0, embededResource.Value.Length);
                    }
                }
                catch (Exception ex) { RobotMessageBox.Show(ex.Message); }
            }
        }

        private bool DoesFileExist(string folder, string fileName)
        {
            return File.Exists(Path.Combine(folder, fileName));
        }

        private bool AreFilesOfTheSameLength(int length, string folder, string fileName)
        {
            return length == new FileInfo(Path.Combine(folder, fileName)).Length;
        }
    }
}
