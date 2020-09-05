using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.ChingariAndroid
{
    [Command(Name = "chingari.explore", Tooltip = "Clicks on the explore tab present in the application ")]
    public class ChingariAndroidExploreCommand : Command
    {
        public class Arguments : AppiumCommandArguments
        {

        }

        public ChingariAndroidExploreCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.FrameLayout[@content-desc='Explore']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }
    }
}