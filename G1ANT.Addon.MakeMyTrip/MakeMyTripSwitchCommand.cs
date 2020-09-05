using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.MakeMyTrip
{
    [Command(Name = "makemytrip.switch", Tooltip = "It lets you switch from one active tab to another")]
    public class MakeMyTripSwitchCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "ID of the web browser instance")]
            public IntegerStructure Id { get; set; }
        }
        public MakeMyTripSwitchCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.Switch(arguments.Id.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while switching to another selenium instance. Selenium instance id: '{arguments.Id.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}