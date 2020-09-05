using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using G1ANT.Language;


namespace G1ANT.Addon.MakeMyTrip
{
    [Command(Name = "makemytrip.refresh", Tooltip = "Refreshes the tab on which make my trip is opened")]
    public class MakeMyTripRefreshCommand : Command
    {
        public class Arguments : CommandArguments
        {
        }
        public MakeMyTripRefreshCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.Refresh();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while refreshing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}