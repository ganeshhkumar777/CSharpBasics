using System;
using System.Reflection;
namespace generics.reflectionexample{
    public class ReflectionExample{

        public static void Main(){
        
        // Type type=typeof(classA);
        // Console.WriteLine(type.AssemblyQualifiedName);
        // iInterface example=new classA();
        // example.Write();


        String str = "generics.reflectionexample.ReflectionExample+classB, generics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        Type typeB = Type.GetType(str);
        iInterface temp = Activator.CreateInstance(typeB) as iInterface;

        MethodInfo[] methodsInClassB = typeB.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        methodsInClassB[0].Invoke(temp,null);

        PropertyInfo[] fieldsInClassA=typeB.GetProperties(BindingFlags.NonPublic);
        
        temp.Write();

        }
       

    public interface iInterface{
        void Write();
    }

    public class classA : iInterface{
        private int a;
        public void Write(){
            Console.WriteLine("Hii from class A");
        }

        public int A {
            get{
            return a * 10;
        }
        }
    }

    public class classB : iInterface{
        public void Write(){
            Console.WriteLine("Hii from class b");
        }
    }
    }

   

}