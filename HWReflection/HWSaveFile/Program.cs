using HWReflection;
using HWSaveFile;
using System.Reflection;

string inputPath = Directory.GetCurrentDirectory() + @"\testBook.fb2";
string outputPath = Directory.GetCurrentDirectory() + @"\test.txt";
string dllAssembly = Directory.GetCurrentDirectory() + @"\LoadFileAndCount.dll";
Serialize ser = new Serialize();

Assembly a = Assembly.LoadFrom(dllAssembly);
var type = a.GetTypes().First(e => e.Name == "СountWords");

var service = Activator.CreateInstance(type);
var predict = type.InvokeMember("CalcWordsFromFile", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, service, new Object[] { inputPath });
Dictionary<string, int> dict = (Dictionary<string, int>) predict;

ser.SerializeDict(outputPath, dict);