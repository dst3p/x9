# X9 Framework

Framework written in C# for parsing X9 (EBCDIC) files.

## Usage

```csharp
var file = "path to file";
var processor = new X9.Processor();

using (var inputStream = new System.IO.FileStream(file, System.IO.FileMode.Open))
{
    processor.Execute(inputStream);
}
```

After successful execution, the X9 file is parsed into the `FileSpec` property of the `Processor` object.