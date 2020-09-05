using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.ZoomAndroid
{
    [Command(Name = "zoom.setting", Tooltip = "Clicks on the setting tab present in the application ")]
    public class ZoomAndroidSettingCommand : Command
    {
        public class Arguments : AppiumCommandArguments
        {

        }

        public ZoomAndroidSettingCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.RelativeLayout[@content-desc='Settings tab.']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }
    }
}