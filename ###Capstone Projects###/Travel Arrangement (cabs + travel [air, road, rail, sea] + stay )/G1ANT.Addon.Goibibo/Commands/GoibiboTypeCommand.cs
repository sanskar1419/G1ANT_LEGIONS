using G1ANT.Language;
using System;

namespace G1ANT.Addon.Goibibo
{
    [Command(Name = "Goibibo.type", Tooltip = "This command types text into a specified element")]
    public class GoibiboTypeCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Text to be typed")]
            public TextStructure Text { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public GoibiboTypeCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.TypeText(
                    arguments.Text.Value,
                    arguments,
                    arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. Text: '{arguments.Text.Value}'. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
