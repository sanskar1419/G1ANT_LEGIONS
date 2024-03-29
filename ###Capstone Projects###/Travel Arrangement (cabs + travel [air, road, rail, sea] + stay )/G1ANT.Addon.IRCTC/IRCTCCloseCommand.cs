﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using System.Threading.Tasks;
using OpenQA.Selenium;
using G1ANT.Addon.IRCTC;

namespace G1ANT.Addon.IRCTC
{
    [Command(Name = "irctc.close", Tooltip = "This command closes irctc opened on a web browser")]
    public class irctccloseCommand : Command
    {
        public class Arguments : CommandArguments
        {
        }
        public irctccloseCommand(AbstractScripter scripter) : base(scripter)
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
