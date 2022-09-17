using System.Net.Http.Json;
using ExchangeCli.Models;
using static System.Console;

WriteLine("Hello from Exchange Cli!");
PrnSep();

if (args.Contains("-h"))
{
    WriteLine(
@"Enter the from currency, to currency, and amount!
ex. 
- EUR USD 100
- USDC EUR 100"
    );
    return;
}

if (args.Length != 3)
{
    WriteLine("Please enter the from currency, to currency, and amount");
    return;
}

var from = args[0].Trim();
var to = args[1].Trim();
var amountIsParsed = double.TryParse(args[2], out var amount);

if (!(from is { Length: > 0 or < 5 } && to is { Length: > 0 or < 5 } && amountIsParsed && amount > 0))
{
    WriteLine("Please enter a valid from currency, to currency, and an amount that is greater than zero");
    return;
}

using var client = new HttpClient();

WriteLine($"Fetching data for from: {from}, to: {to}, and amount: {amount}...");

try
{
    var response = await client.GetAsync($"https://api.exchangerate.host/convert?from={from}&to={to}&amount={amount}");

    PrnSep();

    if (!response.IsSuccessStatusCode)
    {
        WriteLine("It appears that the API cannot be of service at this time! Try again later...");
        return;
    }

    var result = await response.Content.ReadFromJsonAsync<Response>();

    if (result.Success != true)
    {
        WriteLine($"It appears that the API does not the {from} and {to} pair! Try again with different values...");
        return;
    }

    WriteLine(
@$"From: {result.Query?.From ?? from}
To: {result.Query?.To ?? to}
Amount: {result.Query?.Amount ?? amount}
Rate: {result.Info?.Rate}
Result: {result.Result}
Date: {result.Date?.Date.ToShortDateString()}"
    );
}
catch
{
    WriteLine("Whoops, something went wrong...");
    throw;
}

static void PrnSep() => WriteLine("---------------------");