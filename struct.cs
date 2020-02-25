using System;

public class sample{
    
    public struct Name
    {
        public int x;
        public string y;
    }

    // public static void Main() {

    //     // Name name;
    //     // name.x=10;
    //     // name.y="";

    //     // logger.log<int>(2);
    //     // logger.log<char>('c');

    //     int? nullableint = null;

    //     Nullable<int> nullableint1=new Nullable<int>();
    //     Console.WriteLine(nullableint.HasValue);
    //     Console.WriteLine(nullableint.Value);
        
    //     Nullable<int> temp1 = new Nullable<int>(2);
    //     Console.WriteLine(temp1.hasValue);
    //     Console.WriteLine(temp1.Value);

    //     Nullable<int> temp = new Nullable<int>();
    //     Console.WriteLine(temp.hasValue);
    //     Console.WriteLine(temp.Value);
        
    // }


    // public static  class logger{
    //     public static void log<T>(T obj) where T: struct{
    //         Console.WriteLine(obj);
    //     }
    // }

    public struct  Nullable<T>{
        private T _Value;
        private bool _hasValue;
        public Nullable(T input){
                _Value = input;
                _hasValue = true;
        }
        
        public T Value {
            get {
             return   _hasValue ? _Value : throw new Exception();
            }
        } 

        public bool hasValue => _hasValue;

    }

    
}


