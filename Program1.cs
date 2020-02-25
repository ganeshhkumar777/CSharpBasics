using System;

public class Program
{
    public delegate void delegatename(lessDerived input);
    public static Action<moreDerived> delegateAsAction;
    public static Func<lessDerived> covariance;
    // public static void Main()
    // {
    //     lessDerived instance=new moreDerived();
    //     IA sampleInstance=new A();


    //     ICovarianceContravarianceSample<lessDerived,moreDerived>  interfaceInstance= new classA<moreDerived,lessDerived>();
       
    //     lessDerived lessDerivedInstance=moreDerivedInstance();
        
    //     // covariance

    // //       lessDerived                lessDerived
    // //            ^                          ^
    // //            |                          |
    // //        morederived                morederived

    //     // contravariance

    // //       moreDerived                lessDerived
    // //            ^                          ^
    // //            |                          |
    // //        lessDerived                morederived

    //     contraVarianceSample(new moreDerived());

    //     delegateAsAction = contraVarianceSample;

    //     covariance = moreDerivedInstance;
    // }

    // public static void contraVarianceSample(lessDerived instance){

    // }


    public static moreDerived moreDerivedInstance(){
        return new  moreDerived();
    }



   public interface ICovarianceContravarianceSample<out T,in U>{
       T sample(U input);

      // U sample();
   } 

   public class classA<T,U> : ICovarianceContravarianceSample<T,U> where T:class{
      public T sample(U input){
           return null;
       }

   }

    public class lessDerived{

    }

    public class moreDerived: lessDerived{

    }

    public interface IA{

    }

    public class A: IA{

    }

}
