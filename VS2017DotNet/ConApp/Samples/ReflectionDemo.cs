using ConApp.Model;
using System;
using System.Reflection;

namespace ConApp
{
    public class ReflectionDemo
    {
        public static void ReflectionDemo1()
        {
            object player = Activator.CreateInstance(Type.GetType("反射和特性.Player"));
            Player p = player as Player;
            p.Play();
        }

        public static void ReflectionDemo2()
        {
            //从文件中导入一个程序集
            Assembly ass = Assembly.LoadFrom(@"MyLibs.dll");
            //动态创建一个对象
            object obj = ass.CreateInstance("MyLibs.Person");
            Type t = obj.GetType();
            t.InvokeMember("Name", BindingFlags.SetProperty, null, obj, new object[] { "张三" });
            t.InvokeMember("Work", BindingFlags.InvokeMethod, null, obj, null);

            Console.WriteLine(ass.FullName);

            Type[] types = ass.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine("\t" + types[i].FullName);
                MethodInfo[] members = types[i].GetMethods();
                for (int j = 0; j < members.Length; j++)
                {
                    members[j].GetParameters();
                    Console.WriteLine("\t\t" + members[j].Name);
                }
            }
        }

        public static void ReflectionDemo3()
        {
            Type t = typeof(MyTester5);
            MemberInfo[] mems = t.GetMembers();
            foreach (MemberInfo item in mems)
            {
                MethodInfo itemMethod = item as MethodInfo;
                Console.WriteLine(item.Name.PadRight(20, ' ') + item.DeclaringType.Name + "  " + item.ReflectedType.Name + "  " + item.MemberType + " " + itemMethod?.ReturnType.Name);
            }

            object obj = Activator.CreateInstance(typeof(MyTester5));
            MethodInfo method = t.GetMethod("Method", new Type[] { typeof(string), typeof(string) });
            Console.WriteLine($"Method方法的声明类:{method.GetBaseDefinition().DeclaringType.Name}");
            object result = method.Invoke(obj, new object[] { "A", "B" });
            Console.WriteLine(result);
        }

        public static void ReflectionDemo4()
        {   //获取参数列表
            Type t = typeof(MyTester5);
            MethodInfo method = t.GetMethod("Method", new Type[] { typeof(string), typeof(string) });
            ParameterInfo[] parms = method.GetParameters();
            foreach (ParameterInfo item in parms)
            {
                Console.WriteLine($"是否有默认值:{item.HasDefaultValue}");
                Console.WriteLine($"默认值:{item.DefaultValue}");
                Console.WriteLine($"参数类型{item.ParameterType}");
                Console.WriteLine($"参数名:{item.Name}");
                Console.WriteLine();
            }
        }

        public static void ReflectionDemo5()
        {
            //调用无参构造函数,实例化MyTester5类
            Type t = typeof(MyTester5);
            ConstructorInfo con0 = t.GetConstructor(Type.EmptyTypes);
            object obj0 = con0.Invoke(null);
            MyTester5 tc0 = obj0 as MyTester5;
            if (obj0 != null && tc0 != null)
            {
                tc0.TestMethod0();
            }
        }

        public static void ReflectionDemo6()
        {
            //调用有参构造函数初始化MyTester5
            Type t = typeof(MyTester5);
            ConstructorInfo con1 = t.GetConstructor(new Type[] { typeof(int) });
            object obj1 = con1.Invoke(new object[] { 123 });
            MyTester5 tc1 = obj1 as MyTester5;
            if (obj1 != null && tc1 != null)
            {
                tc1.TestMethod0();
            }
        }

        public static void ReflectionDemo7()
        {
            //调用有参构造函数初始化MyTester5
            Type t = typeof(MyTester5);
            ConstructorInfo con2 = t.GetConstructor(new Type[] { typeof(string) });
            object obj2 = con2.Invoke(new object[] { "123" });
            MyTester5 tc2 = obj2 as MyTester5;
            if (obj2 != null && tc2 != null)
            {
                tc2.TestMethod0();
            }
        }
    }
}