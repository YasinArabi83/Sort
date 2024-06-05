using Sort.Model;
using Sort.Reader;
using System.Diagnostics;
using System.Reflection;

namespace Sort.Logic
{
    public class SortMethod : ISortMethod
    {
        private readonly IXmlReader reader;
        private readonly IConfiguration Configuration;

        public SortMethod(IXmlReader reader, IConfiguration configuration)
        {
            this.reader = reader;
            Configuration = configuration;
        }

        List<DllModel> ISortMethod.SortedNums()
        {

            List<DllModel> result = new();

            string? folderPath = Configuration["DllFolderPath"];


            string[] dllFiles = System.IO.Directory.GetFiles(folderPath, "*.dll");

            foreach (string dllFile in dllFiles)
            {

                List<int> Numbers = reader.Num();
                Assembly assembly = Assembly.LoadFile(dllFile);

                var types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    var instance = Activator.CreateInstance(type);

                    var methods = type.GetMethods();
                    foreach (MethodInfo method in methods)
                    {
                        if (method.Name == "SortedNum")
                        {


                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            method.Invoke(instance, new object[] { Numbers });
                            stopwatch.Stop();
                            long Timer = stopwatch.ElapsedMilliseconds;
                            DllModel dll = new DllModel()
                            {
                                Name = type.Name,
                                Time = Timer
                            };
                            result.Add(dll);
                        };

                    }
                }
            }
            return result;
        }



    }
}
