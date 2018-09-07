using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReflection
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {
                Assembly dll = Assembly.LoadFile(@"C:\Users\isht\Downloads\HelloLibrary.dll");
                Type t = dll.GetType("HelloLibrary.MagicClass");
                SetCorrectValueField(t, "hello");
                var method = t.GetMethod("Hello", BindingFlags.NonPublic | BindingFlags.Static);
                Console.Write("Write name: ");
                string strName = Console.ReadLine();

                var result = method.Invoke(null, new object[] { strName });
                Console.WriteLine(result);
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SetCorrectValueField(Type t, string fieldName)
        {
            t.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).SetValue(t, "Hello, ");
        } 
    }
}
