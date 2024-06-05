
using Sort.Controler;
using System.Reflection;

namespace Sort.Reader
{
    public class XmlReader : IXmlReader
    {
        private readonly IConfiguration configuration;

        public XmlReader(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<int> Num()
        {
            var assembly = Assembly.LoadFile(configuration["DataAccessDllPath"]);
            var XmlContextType = assembly.GetType("DataAccess.CsvContext");
            var XmlContext = Activator.CreateInstance(XmlContextType);
            var XmlContextMethod = XmlContextType.GetMethod("ReadNumbers");
            return (List<int>)XmlContextMethod.Invoke(XmlContext, new object[] { configuration["DBPath"] });
        }
    }
}
