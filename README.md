> Created for [dev.to](https://dev.to/grontis/exploring-code-performance-testing-in-c-with-benchmarkdotnet-1l26) article.

# How to use

After cloning the repo, navigate from the terminal to the directory.
Run the following commands:
```powershell
dotnet restore
```
```powershell
dotnet build -c Release
```
```powershell
dotnet run -c Release -f net7.0 --runtimes net6.0 net7.0 
```
Let the benchmarks run and examine the results.

