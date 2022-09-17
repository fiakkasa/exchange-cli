# Exchange CLI

Simple console app that fetches the current exchange rate for a specified from currency, to currency, and amount.

## Run

```bash
# Gets the weather
dotnet run -- <from> <to> <amount>
# Help!
dotnet run -- -h
```

## Create a package

```bash
dotnet pack
```

## Install a local package as global tool

```bash
dotnet tool install --global --add-source ./nupkg exchange-cli
```

## Uninstall a local package installed as a global tool

```bash
dotnet tool uninstall exchange-cli --global
```

## Running once installed

```bash
# Help
dotnet-exchange -h
# Gets the Rate!
dotnet-exchange EUR USD 100
```
