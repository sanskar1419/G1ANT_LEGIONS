using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using System.Threading.Tasks;
using OpenQA.Selenium;
using G1ANT.Addon.Instagram;

namespace G1ANT.Addon.Instagram
{
    [Command(Name = "instagram.close", Tooltip = "This command closes instagram opened on a web browser")]
    public class InstagramCloseCommand : Command
    {
        public class Arguments : CommandArguments
        {
        }
        public InstagramCloseCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.QuitCurrentWrapper();

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
