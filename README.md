## Description

An ongoing collection of C# utilities.

### How to create local Nuget

Clone this repository then using terminal `cd` into the repository, execute the following command changing `your_project_root` to the root of your project you wish to create the nuget package for;

```sh
dotnet pack -o ~/your_project_root . --include-source /p:PackageVersion=1.0.0
```

Include a reference in your project `.csproj` file
```sh
<PackageReference Include="NET.Utilities" Version="1.0.0" />
```
