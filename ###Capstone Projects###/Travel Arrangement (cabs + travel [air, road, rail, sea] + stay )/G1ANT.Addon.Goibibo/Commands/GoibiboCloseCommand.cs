﻿using G1ANT.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.Goibibo
{
    [Command(Name = "Goibibo.close", Tooltip = "This command closes a web browser")]
    public class GoibiboCloseCommand : Command
    {
        public class Arguments : CommandArguments
        {
        }
        public GoibiboCloseCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.QuitCurrentWrapper();

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
