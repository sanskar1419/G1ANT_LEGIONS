using G1ANT.Language;
using System;

namespace G1ANT.Addon.Goibibo
{
    [Command(Name = "Goibibo.alertaction", Tooltip = "Waits for an alert and performs a specified action")]
    public class GoibiboAlertActionCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Specifies an action: `accept` or `dismiss`")]
            public TextStructure Action { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public GoibiboAlertActionCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.AlertPerformAction(arguments.Action.Value, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while performing alert action. Message: {ex.Message}", ex);
            }
        }
    }
}
