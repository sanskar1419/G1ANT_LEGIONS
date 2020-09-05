using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.ZoomAndroid
{
    [Command(Name = "zoom.setting", Tooltip = "Clicks on the setting tab present in the application ")]
    public class ZoomAndroidJoinCommand : Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the the meeting ID")]
            public TextStructure ID { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Enter the password")]
            public TextStructure Password { get; set; } = new TextStructure(string.Empty);
        }

        public ZoomAndroidJoinCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {   
            arguments.Search.Value = "//android.widget.LinearLayout[@content-desc='Join, button']/android.widget.RelativeLayout";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            arguments.Search.Value = "us.zoom.videomeetings:id/edtConfNumber";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.ID.Value);

            arguments.Search.Value = "us.zoom.videomeetings:id/btnJoin";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();


        }
    }
}