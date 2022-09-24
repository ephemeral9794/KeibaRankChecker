// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using KeibaScrapingMock;
using Newtonsoft.Json;

var loginURL = "https://regist.netkeiba.com/account/?pid=login";
var baseURL = "https://race.netkeiba.com/race/shutuba.html?race_id=%RACEID%";
var race_id = "202207050411";

var url = baseURL.Replace("%RACEID%", race_id);

var config = Configuration.Default.WithJs().WithCss().WithDefaultLoader().WithDefaultCookies();
using var context = BrowsingContext.New(config);
var requester = context.GetService<DefaultHttpRequester>();
requester!.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36";

// ログイン
var document = await context.OpenAsync(loginURL);
using var reader = new StreamReader(@".\login.json");
var json = JsonConvert.DeserializeObject<LoginData>(reader.ReadToEnd());
var form = document.Forms[1];
var toppage = await form.SubmitAsync(new {
    login_id = json.MailAddress,
    pswd = json.Password
});

// 表データ取得
document = await context.OpenAsync(url);
var table = document.QuerySelector(".Shutuba_Table");
var data = new List<Horse>();

if (table != null) { 
    foreach(var tr in table.Children[1].GetElementsByTagName("tr")) {
        var td = tr.GetElementsByTagName("td");
        var s = "";
        foreach (var t in td) {
            s += $"{t.TextContent.Trim()}\t|";
        }
        Console.WriteLine(s);
    }
}
