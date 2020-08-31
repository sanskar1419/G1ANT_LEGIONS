using G1ANT.Language;
using System;

namespace G1ANT.Addon.Goibibo
{
    [Command(Name = "Goibibo.gettitle", Tooltip = "This command gets the title of the currently active web browser instance")]
    public class GoibiboGetTitleCommand : Command
    {
        public class Arguments : CommandArguments
        {

            [Argument(Tooltip = "Name of a variable where the title will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }
        public GoibiboGetTitleCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new Language.TextStructure(SeleniumManager.CurrentWrapper.Title));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while getting title of currently active selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
