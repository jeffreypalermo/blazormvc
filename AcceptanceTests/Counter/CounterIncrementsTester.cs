namespace AcceptanceTests.Counter;

public class CounterIncrementsTester
{
    private IWebDriver _driver = null!;
    private TestDriver _testDriver = null!;

    [SetUp]
    public void Setup()
    {
        _testDriver = new TestDriver();
        _driver = _testDriver.GetDriver();
    }

    [TearDown]
    public void Teardown()
    {
        _testDriver.Dispose();
    }

    [TestCase(1, 1)]
    public void ShouldIncrementOnPress(int numberOfButtonPresses, int expectedFinalCount)
    {
        //arrange
        var hostAddress = System.Environment.GetEnvironmentVariable("AppURL", EnvironmentVariableTarget.User); //these environmental keys get refactored out
        Console.WriteLine("url:" + $"https://{hostAddress}/counter");
        _driver.Navigate().GoToUrl($"https://{hostAddress}/counter");
        var xPathForButton = By.CssSelector("button[ref='counterButton']");

        //wait unitl screen comes up
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        var counterButton = wait.Until(driver => driver.FindElements(xPathForButton)[0]);
        _testDriver.TakeScreenshot(10, TestContext.CurrentContext.Test.FullName, "Arrange");

        var currentCountElement = _driver.FindElements(
            By.CssSelector("p[ref='currentCount']"))[0];
        currentCountElement.Text.ShouldContain("0");

        //act
        for (int i = 0; i < numberOfButtonPresses; i++)
        {
            counterButton.Click();
            _testDriver.TakeScreenshot(20+i, TestContext.CurrentContext.Test.FullName, "Act");
        }

        //assert
        currentCountElement.Text.ShouldContain(expectedFinalCount.ToString());
        _testDriver.TakeScreenshot(30, TestContext.CurrentContext.Test.FullName, "Assert");
    }
}