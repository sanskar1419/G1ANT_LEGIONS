using G1ANT.Language;
using System;

namespace G1ANT.Addon.Goibibo
{
    [Command(Name = "Goibibo.gettext", Tooltip = "This command gets text (a value) of a specified element")]

    public class GoibiboGetTextCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }
        public GoibiboGetTextCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                arguments,
                arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(attributeValue));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
