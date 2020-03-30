using IronPython.Hosting;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string SourceCodePy = "x = 5+4"; 
            
            string v1 = @"import sys

def Simple():
	print ""Hello from Python""
	print ""Call Dir(): ""
	print dir()
	print ""Print the Path: "" 
	print sys.path

Simple()";
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var source = engine.CreateScriptSourceFromString(SourceCodePy, Microsoft.Scripting.SourceCodeKind.Statements);
            var compiled = source.Compile();

            var result = compiled.Execute(scope);
            bool isAvailable = scope.TryGetVariable("x", out dynamic output);

            if(isAvailable)
                Console.WriteLine(output);
        }
    }
}
