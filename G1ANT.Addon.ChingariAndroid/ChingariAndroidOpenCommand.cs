﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.ChingariAndroid
{
    [Command(Name = "chingari.open", Tooltip = "This command initialises chingari application.")]
    public class ChingariAndroidOpenCommand : Language.Command
    {
        private static AndroidDriver<AndroidElement> driver;

        public class Arguments : CommandArguments
        {
            [Argument(DefaultVariable = "app activity", Tooltip = "AppActivity")]
            public TextStructure AppActivity { get; set; } = new TextStructure(".Activity.ViewPagerActivity");

            [Argument(DefaultVariable = "app package", Tooltip = "App Package")]
            public TextStructure AppPackage { get; set; } = new TextStructure("io.chingari.app");

            [Argument(Required = false, Tooltip = "Automation Name")]
            public TextStructure AutomationName { get; set; } = new TextStructure("UiAutomator2");

            [Argument(Required = false, Tooltip = "Device Name")]
            public TextStructure DeviceName { get; set; } = new TextStructure("Android");

            [Argument(Required = false, Tooltip = "Platform Name")]
            public TextStructure PlatformName { get; set; } = new TextStructure("Android");

            [Argument(Required = false, Tooltip = "Platform version")]
            public TextStructure PlatformVersion { get; set; } = new TextStructure("");
        }

        public ChingariAndroidOpenCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            Initialize(arguments);
        }

        private AppiumOptions CreateAppiumOptions(Arguments arguments)
        {
            var desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, arguments.DeviceName.Value);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, arguments.AppPackage.Value);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, arguments.PlatformName.Value);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, arguments.AppActivity.Value);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.FullReset, false);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            if (!string.IsNullOrEmpty(arguments.PlatformVersion.Value))
            {
                desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, arguments.PlatformVersion.Value);
            }
            return desiredCapabilities;
        }
        private void Initialize(Arguments arguments)
        {
            try
            {
                var appiumServiceBuilder = new AppiumServiceBuilder().UsingAnyFreePort();
                var appiumOptions = CreateAppiumOptions(arguments);
                driver = new AndroidDriver<AndroidElement>(appiumServiceBuilder, appiumOptions);
            }
            catch (Exception ex)
            {
                InstallAppiumWhenExceptionOccured(ex);
            }
        }

        private void InstallAppiumWhenExceptionOccured(Exception ex)
        {
            if (ex.Message.StartsWith("Invalid"))
            {
                var result = RobotMessageBox.Show("It seems you have no Appium driver installed. Would you like to install it now?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Process.Start("\"C:\\Program Files\\nodejs\\npm.cmd\"", "install -g appium");
                }
            }
            else { throw ex; }
        }

        public static AndroidDriver<AndroidElement> GetDriver()
        {
            return driver;
        }
    }
}

