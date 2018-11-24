# mono-wasm-demo

A demo project shows that packager.exe doesn't work for a .NET Standard 2.0 class lib which referenced a .NET Standard class lib.

The .NET Standard 2.0 class lib is built from *MonoWasmDemo.csproj*. And it referenced a .NET Standard class lib *SixLabors.ImageSharp*, which is compatible with .NET Standard 2.0.

The packager is executed in the post build event of *MonoWasmDemo.csproj*:

```text
./MonoWasm/packager.exe --copy=ifnewer --out=.\publish --asset=index.html .\bin\debug\netstandard2.0\MonoWasmDemo.dll
```

*./MonoWasm* is the "mono-wasm SDK" downloaded from https://jenkins.mono-project.com/job/test-mono-mainline-wasm/label=ubuntu-1804-amd64/lastSuccessfulBuild/Azure/processDownloadRequest/1476/ubuntu-1804-amd64/sdks/wasm/mono-wasm-f30ce1cbcee.zip

## The problem and how to reproduce

Open the solution file in VS2017, rebuild project *MonoWasmDemo*, see error *Unhandled Exception: System.Exception: Could not resolve SixLabors.ImageSharp*:

```text
1>------ Rebuild All started: Project: MonoWasmDemo, Configuration: Debug Any CPU ------
1>MonoWasmDemo -> D:\Workspace\0_Experiment\MonoWasmDemo\bin\Debug\netstandard2.0\MonoWasmDemo.dll
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\bin\debug\netstandard2.0\MonoWasmDemo.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\Facades\netstandard.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\mscorlib.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Core.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\Mono.Security.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Xml.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Data.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Numerics.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Transactions.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Drawing.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.IO.Compression.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.IO.Compression.FileSystem.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.ComponentModel.Composition.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Net.Http.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Runtime.Serialization.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.ServiceModel.Internals.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Web.Services.dll debug False
1>Processing D:\Workspace\0_Experiment\MonoWasmDemo\MonoWasm\wasm-bcl\wasm\System.Xml.Linq.dll debug False
1>
1>Unhandled Exception: System.Exception: Could not resolve SixLabors.ImageSharp
1>   at Driver.Resolve(String asm_name, AssemblyKind& kind)
1>   at Driver.Import(String ra, AssemblyKind kind)
1>   at Driver.Run(String[] args)
1>   at Driver.Main(String[] args)
========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========
```text
