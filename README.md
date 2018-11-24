# mono-wasm-demo

A demo project shows that packager.exe doesn't work for a .NET Standard 2.0 class lib which referenced a .NET Standard class lib.

The .NET Standard 2.0 class lib is built from *MonoWasmDemo.csproj*. And it referenced a .NET Standard class lib *SixLabors.ImageSharp*, which is compatible with .NET Standard 2.0.

The packager is executed in the post build event of *MonoWasmDemo.csproj*:

./MonoWasm/packager.exe --copy=ifnewer --out=.\publish --asset=index.html .\bin\debug\netstandard2.0\MonoWasmDemo.dll

*./MonoWasm* is the "mono-wasm SDK" downloaded from https://jenkins.mono-project.com/job/test-mono-mainline-wasm/label=ubuntu-1804-amd64/lastSuccessfulBuild/Azure/processDownloadRequest/1476/ubuntu-1804-amd64/sdks/wasm/mono-wasm-f30ce1cbcee.zip
