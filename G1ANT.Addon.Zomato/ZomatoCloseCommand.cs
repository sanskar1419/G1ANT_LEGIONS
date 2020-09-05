using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using System.Threading.Tasks;
using OpenQA.Selenium;
using G1ANT.Addon.Zomato;

namespace G1ANT.Addon.Zomato
{
    [Command(Name = "zomato.close", Tooltip = "This command closes zomato opened on a web browser")]
    public class zomatocloseCommand : Command
    {
        public class Arguments : CommandArguments
        {
        }
        public zomatocloseCommand(AbstractScripter scripter) : base(scripter)
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
