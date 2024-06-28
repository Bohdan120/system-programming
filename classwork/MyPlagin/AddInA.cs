
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace HostAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pluginsPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) +
                ConfigurationManager.AppSettings["pluginsDirectory"];

            string[] pluginLibs = Directory.GetFiles(pluginsPath);

            var addInTypes = new List<IAddIn>();

            AppDomain secondDomain = AppDomain.CreateDomain("PluginAD");

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;

            foreach (Assembly assembly in pluginLibs.Select(Assembly.ReflectionOnlyLoadFrom))
            {
                foreach (TypeInfo type in assembly.DefinedTypes)
                {
                    if (type.IsClass
                        && type.IsAbstract == false
                        && type.ImplementedInterfaces.Any(it => it.GUID == typeof(IAddIn).GUID)
                        && type.BaseType == typeof(MarshalByRefObject))
                    {
                        IAddIn proxy = secondDomain.CreateInstanceFromAndUnwrap(type.Assembly.CodeBase, type.FullName) as IAddIn;
                        addInTypes.Add(proxy);
                    }
                }
            }

            foreach (IAddIn module in addInTypes)
            {
                Console.WriteLine($"Module {0} is aliable by {1}", module,
                    RemotingServices.IsTransparentProxy(module) ? "Reference" : "Value");
                Console.WriteLine(module.DoSomthing(5));
            }

            AppDomain.Unload(secondDomain);
        }

        private static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            string strTempAssmbPath = "";
            Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencesAssmbNumes = objExecutingAssemblies.GetReferencedAssemblies();

            if (arrReferencesAssmbNumes.Any(strAssmbName =>
                strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) ==
                args.Name.Substring(0, args.Name.IndexOf(","))))
            {
                strTempAssmbPath = Path.GetDirectoryName(objExecutingAssemblies.Location) + "\\" +
                    args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
            }
            Assembly myAssembly = Assembly.ReflectionOnlyLoadFrom(strTempAssmbPath);
            return myAssembly;
        }
    }
}