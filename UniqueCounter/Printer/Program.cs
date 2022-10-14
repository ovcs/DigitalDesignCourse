using Printer.Modules;
using System.Diagnostics;
using System.Reflection;

string inputPath = Directory.GetCurrentDirectory() + @"\testBook.fb2";
string outputPath = Directory.GetCurrentDirectory();
string dllAssembly = Directory.GetCurrentDirectory() + @"\WordCountModule.dll";
int countWorking = 3;

Assembly a = Assembly.LoadFrom(dllAssembly);
var type = a.GetTypes().First(e => e.Name == "WordCount") ?? throw new ArgumentNullException("Type not found");

var service = Activator.CreateInstance(type);

string[] methods = new string[] { "CalcWordsFromFile", "CalcWordsFromFileParallel" };
BindingFlags[] flags = new BindingFlags[]
{
    BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
    BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
};

for (int c = 0; c < countWorking; c++)
{
    for (int i = 0; i < methods.Length; i++)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        var dict = (Dictionary<string, int>) type.InvokeMember(methods[i], flags[i], Type.DefaultBinder, service, new Object[] { inputPath })!;
        stopWatch.Stop();
        var elapsed = stopWatch.Elapsed;
        Console.WriteLine(String.Format("RunTime {0,7} milisec", elapsed.TotalMilliseconds));
        Serialize.SerializeDict(outputPath + @"\" + $"test{i + 1}.txt", dict);
    }
    Console.WriteLine();
    Thread.Sleep(1000);
}
    