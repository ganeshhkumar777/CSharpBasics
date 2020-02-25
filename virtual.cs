using System;
using System.Reflection;
namespace generics{
    public class baseclass{
        public virtual int sampleFun(){
            
            Console.WriteLine("hii from base class");
            return 0;
        }
    }

    public class derivedA: baseclass{

    }

    public class derivedB: baseclass{

    }

    public class derivedC: baseclass{
         public override int sampleFun(){
             base.sampleFun();
            Console.WriteLine("hii from derivedC");
            return 1;
        }
    }

    public class virtualExample{
        // public static void Main(){
        //     // derivedC c=new derivedC();
        //     // c.sampleFun();
        //     // derivedA a=new derivedA();
        //     // a.sampleFun();
        //     // derivedB b=new derivedB();
        //     // b.sampleFun();

        //     var baseclass = Activator.CreateInstance(typeof(derivedC));

        //     // baseclass baseclass=new derivedC();
        //     var instance=(baseclass)baseclass;
        //     instance.sampleFun();
        
        // }
    }
}
    