using System.Collections.Generic;
using System;
namespace generics{
    public class sampleForDivya{

        // public static void Main(){
        //    for(int i=0;i<10;i++){
        //        if(i<5){
        //            continue;
        //        }
        //        Console.WriteLine(i);
        //    }
       
        // }

        public class usecaseUrlResponse{
            List<classA> classA=new List<classA>();
            List<category> cat=new List<category>();
        }


        public class classA{
            int key;
            List<object> value; // master
        }

        public class category{
            string name;
            Guid categoryUid;
        }
    }
}