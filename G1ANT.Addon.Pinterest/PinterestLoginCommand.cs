using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.Pinterest
{
    [Command(Name = "pinterest.login", Tooltip = "This command is used to login to the server.")]
    public class pinterestLoginCommand : Command
    {
        public pinterestLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the Login e-mail ID here")]
            public TextStructure mail { get; set; }

            [Argument(Required = true, Tooltip = "Enter the password here")]
            public TextStructure password { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                        "chrome",
                        "https://in.pinterest.com/",
                        arguments.Timeout.Value,
                        false,
                        Scripter.Log,
                        Scripter.Settings.UserDocsAddonFolder.FullName);
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                arguments.Search.Value = "/html/body/div[1]/div[1]/div/div/div/div[1]/div[1]/div[2]/div[2]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "id";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.TypeText(arguments.mail.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "password";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.TypeText(arguments.password.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                var len = SeleniumManager.CurrentWrapper.RunScript("return document.getElementsByClassName(\"captcha -internal\").length");
                if (len == "1")
                {
                    RobotMessageBox.Show("Captcha detected, please solve the captcha");
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }


}