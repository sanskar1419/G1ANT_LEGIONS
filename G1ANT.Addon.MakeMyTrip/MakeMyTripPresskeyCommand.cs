using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.MakeMyTrip
{
    [Command(Name = "makemytrip.presskey", Tooltip = "This command sends a keystroke to a specified element on make my trip")]
    public class MakeMyTripPresskeyCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Key to be pressed")]
            public TextStructure Key { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public MakeMyTripPresskeyCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.PressKey(
                    arguments.Key.Value,
                    arguments,
                    arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while pressing key on element. Text: '{arguments.Key.Value}'. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}