using System;
using System.Reflection;

namespace Training6
{
    public class AssemblyReflectiator
    {
        public void GetAllAssemblyInfo()
        {
            Assembly asembly = Assembly.LoadFrom("Training2.dll");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(asembly.FullName);
                
            foreach (Module module in asembly.GetModules(true))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(module.Name);

                foreach (Type type in asembly.GetTypes())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(type.Name + " type: " + type.BaseType);

                    foreach (MemberInfo member in type.GetMembers())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Member: {member.ToString()} ----> {member.MemberType}");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (member.MemberType == MemberTypes.Method)
                        {
                            foreach (ParameterInfo parameter in ((MethodInfo)member).GetParameters())
                            {
                                Console.WriteLine($"input parametr: {parameter.Name}, type: {parameter.ParameterType}");
                            }
                        }

                        if (member.MemberType == MemberTypes.Property)
                        {
                            foreach (MethodInfo method in ((PropertyInfo)member).GetAccessors())
                            {
                                Console.WriteLine($"property accessors: {method.Name}");
                            }
                        }

                        if (member.MemberType == MemberTypes.Constructor)
                        {
                            foreach (ParameterInfo parameter in ((ConstructorInfo)member).GetParameters())
                            {
                                Console.WriteLine($"input parametr: {parameter.Name}, type: {parameter.ParameterType}");
                            }
                        }

                        if (member.MemberType == MemberTypes.Event)
                        {
                            Console.WriteLine(((EventInfo)member).EventHandlerType);
                        }
                    }
                }
            }
        }
    }
}
