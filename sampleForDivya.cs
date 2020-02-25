using System.Collections.Generic;
namespace generics{
    public class sampleForDivya{

        public static void Main(){
            usecaseUrlResponse result=new usecaseUrlResponse();
        result.classA=
        result.cat=
        return result
        }

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