using System;

namespace generics
{
    class Program
    {
        public  delegate void del(sampleA sample);
        // public static void Main()
        // {

        //     int a = 1;
        //     long ab=32;
        //     // int a = null;
        //     // Console.WriteLine("Hello World!");
        //     // var result=sampleFunc();
        //     System.Int32 OBJ = new System.Int32();

        //      OBJ = a;
        //      a = OBJ;

        //     // OBJ=ab;

        //     var instance1=new sampleA(1,"str1");

        //     //            stack          |                Heap
        //     // A          00000001		 |          abc   NULL  

        //     // instance1  abc
        //      var instance2=instance1;
            
        //     del result=sample;
        //     Action<sampleA> result1=sample;
        //     // instance1.ToString();
        //     // instance2.ToString();

        //     // instance2.intA=2;
        //     // instance2.stringA="str2";
            
        //     // instance1.ToString();
        //     // instance2.ToString();

        //     // sample(instance2);
            
        //     // instance1.ToString();
        //     // instance2.ToString();
            
        //     MoreDerivedClass instanceB = new MoreDerivedClass();
        //     Func<LessDerivedClass> covariant = SampleFunc2;
        //     Action<MoreDerivedClass> contravariant=SampleFunc;

        //     ICovariantSample<LessDerivedClass,MoreDerivedClass> obj=new CovariantSample<MoreDerivedClass,LessDerivedClass>();
        // }

        static (string,int) sampleFunc(){
            return ("",1);
        }

        public static void sample(sampleA sample){
                sample.intA=3;
                sample.stringA="str3";
        }
        public static void SampleFunc(LessDerivedClass instanceA){

        }

//SampleFunc(instanceB);
        public static MoreDerivedClass SampleFunc2(){
        return new MoreDerivedClass();
        }

        public int func1(){
            return 0;
        }
        

    }


    class sampleA{
        public int intA;
        public string stringA;
        public sampleA(int intA,string stringA){
            (this.intA,this.stringA)=(intA,stringA);
        }

        public override String ToString(){
            Console.WriteLine( $"{intA}-{stringA}");
           return "${intA}-{stringA}";
        }
    }

   
    // less derived
class LessDerivedClass {

} 

// more derived
class MoreDerivedClass : LessDerivedClass {

}
interface ICovariantSample<out T,in U>{
T result(U input);
}

class CovariantSample<T,U>: ICovariantSample<T,U> where T: class{
public T result(U input){
return null;
}

}

class contravariant{
    
}




}
