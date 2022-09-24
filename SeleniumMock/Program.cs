// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumMock;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

{ 
    var baseURL = "https://race.netkeiba.com/race/shutuba.html?race_id=%RACEID%";
    var race_id = "202206040711";

    var json = JsonConvert.DeserializeObject<Config>(File.ReadAllText(@".\config.json"));

    var config = new ChromeConfig();
    var path = new DriverManager().SetUpDriver(config, VersionResolveStrategy.MatchingBrowser);
    var driverPath = Path.GetDirectoryName(path);

    using var driverService = ChromeDriverService.CreateDefaultService(driverPath);
    driverService.HideCommandPromptWindow = true;
    var options = new ChromeOptions();
    options.AddArguments("--headless", "--disable-gpu", "--user-agent=" + json.UserAgent, "--user-data-dir=" + json.ProfileDir);
    using var driver = new ChromeDriver(driverService, options);

    var url = baseURL.Replace("%RACEID%", race_id);
    driver.Navigate().GoToUrl(url);

    Console.WriteLine("取得中...");
    var horses = new List<Horse>();
    var table = driver.FindElement(By.ClassName("Shutuba_Table"));
    var tbody = table.FindElement(By.TagName("tbody"));
    foreach (var tr in tbody.FindElements(By.TagName("tr")))
    {
        var td = tr.FindElements(By.TagName("td"));
        if (td.Count > 0) { 
            var horse = new Horse
            {
                Mark = "",
                Frame = int.Parse(td[0].Text.Trim()),
                Number = int.Parse(td[1].Text.Trim()),
                Name = td[3].Text.Trim(),
                SexAge = td[4].Text.Trim(),
                Weight = double.Parse(td[5].Text.Trim()),
                Jockey = td[6].Text.Trim(),
                Odds = double.Parse(td[9].Text.Trim()),
                Popular = int.Parse(td[10].Text.Trim())
            };
            horses.Add(horse);
        }
    }

    foreach (var horse in horses)
    {
        Console.WriteLine(horse);
    }

    driver.Quit();
}