using System;
using System.Reflection;
namespace generics.reflection{
    public class ReflectionExample{

        // public static void Main(){

        //     ReflectionA obj=new ReflectionA();

        //     Type type = typeof(ReflectionA);
        //     String assemblyQualifiedName = type.AssemblyQualifiedName;
        //     var type1 = Type.GetType(assemblyQualifiedName);

        //     iSample res= Activator.CreateInstance(type1)  as iSample;
            
        //     MethodInfo[] result= type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        //     result[0].Invoke(obj,null);
            
        //     res.sample();
        // }
    }

    public interface iSample{
        void sample();
    }

    public class ReflectionA : iSample {
        public void sample(){
            Console.WriteLine("ReflectionA");
        }
    }
    public class ReflectionB : iSample {
        public void sample(){
            Console.WriteLine("ReflectionB");
        }
    }
}