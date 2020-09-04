using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.GMAIL
{
    [Command(Name = "gmail.sendmails", Tooltip = "Allows user to send mails to GMAIL")]
    class GMAILSendMailsCommand : Command
    {
        public GMAILSendMailsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : GMAILCommandArguments
        {
            [Argument(Required = true, Tooltip = "Send Recipient Email ID")]
            public TextStructure to { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Enter your subject")]
            public TextStructure subject { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Enter message")]
            public TextStructure message { get; set; } = new TextStructure("");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {

                arguments.Search.Value = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div[1]/div/div/div/div[1]/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "to";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.TypeText(arguments.to.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "subjectbox";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.TypeText(arguments.subject.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = ":ou";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.TypeText(arguments.message.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = ":nh";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);

            }
        }
    }
}