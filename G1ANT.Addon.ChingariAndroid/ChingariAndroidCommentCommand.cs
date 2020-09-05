using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.ChingariAndroid
{
    [Command(Name = "chingari.comment", Tooltip = "Clicks on the comment section to read the comments on a particular video")]
    public class ChingariAndroidCommentCommand : Command
    {
        public class Arguments : AppiumCommandArguments
        {

        }

        public ChingariAndroidCommentCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "io.chingari.app:id/comment_icon";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }
    }
}