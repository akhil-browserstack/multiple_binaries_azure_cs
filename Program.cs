using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
public class Program {
    public static void Main(string[] args) {
      IWebDriver driver;
      string username = System.Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
      string accessKey = System.Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
      string isLocalSet = System.Environment.GetEnvironmentVariable("BROWSERSTACK_LOCAL");
      string localIdentifier = System.Environment.GetEnvironmentVariable("BROWSERSTACK_LOCAL_IDENTIFIER");
      DesiredCapabilities caps = new DesiredCapabilities();
      caps.SetCapability("browserName", "iPhone");
      caps.SetCapability("device", "iPhone 8 Plus");
      caps.SetCapability("realMobile", "true");
      caps.SetCapability("os_version", "11");
      caps.SetCapability("browserstack.user", username);
      caps.SetCapability("browserstack.key", accessKey);
      caps.SetCapability("browserstack.localIdentifier", localIdentifier);
      caps.SetCapability("browserstack.local", isLocalSet);
      caps.SetCapability("name", "Bstack-[C_sharp] Sample Test");

      driver = new RemoteWebDriver(
        new Uri("http://hub-cloud.browserstack.com/wd/hub/"), caps
      );
      driver.Navigate().GoToUrl("http://www.google.com");
      Console.WriteLine(driver.Title);

      IWebElement query = driver.FindElement(By.Name("q"));
      query.SendKeys("Browserstack");
      query.Submit();
      Console.WriteLine(driver.Title);

      driver.Quit();
    }
  }