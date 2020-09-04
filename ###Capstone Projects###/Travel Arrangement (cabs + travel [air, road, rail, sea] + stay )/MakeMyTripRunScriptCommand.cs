using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.MakeMyTrip
{
    [Command(Name = "makemytrip.runscript", Tooltip = "This command runs Javascript code inside the web browser")]
    public class MakeMyTripRunScriptCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Script to be executed in the web browser")]
            public TextStructure Script { get; set; }

            [Argument(Tooltip = "If set to `true`, the command should wait for a new window to appear after the script execution")]
            public BooleanStructure WaitForNewWindow { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Name of a variable where the command's result will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public MakeMyTripRunScriptCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                var result = SeleniumManager.CurrentWrapper.RunScript(arguments.Script.Value, arguments.Timeout.Value, arguments.WaitForNewWindow.Value);
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(result));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while running javascript script: '{arguments.Script.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}