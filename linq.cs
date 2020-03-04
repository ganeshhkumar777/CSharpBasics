using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace generics.linq{

    public class student{
        private int _id;
        private string _name;
        public int id{
            get{
                Console.WriteLine("getting :"+_id);
                return _id;
            }
            set{
                _id=value;
            }
        }
        public string name{
            get {
                Console.WriteLine("getting :"+ _name);
                return _name;
            }
            set{
                _name=value;
            }
        }
    }
    public class linqSample{
        public static void main(){

            

            List<student> employees=new List<student>{
                new student(){
                    id=1,
                    name="aaa"
                },
                new student(){
                    id=2,
                    name="bbb"
                },
                new student(){
                    id=3,
                    name="ccc"
                }
            };
          Console.WriteLine("executing filter");
          IEnumerable<student> result=Enumerable.Empty<student>();
          try{
             result= employees.filter(x=>x.id>=1);
          
          
             Console.WriteLine("after filter");
             foreach(var i in result){
               Console.WriteLine(i.id);
                }

          }
          catch(Exception ex){
              Console.WriteLine("inside catch");
              Console.WriteLine(ex);
          }

          Console.WriteLine("take1");

          IEnumerable<student> take1Result=employees.Where(x=>x.id>=1);
            take1Result = take1Result.Take(1);
             foreach(var i in take1Result){
               Console.WriteLine("iterated result"+i.id);
                }


        //   someEnumerable obj=new someEnumerable();
          
        //   foreach(var i in obj){
        //       Console.WriteLine(i);
        //   }

        //   IEnumerator enumerator=obj.GetEnumerator();

        //   while(enumerator.MoveNext()){
        //       Console.WriteLine(enumerator.Current);
        //   }
        }
    }


    public class someEnumerable : IEnumerable{
        public int[] input=new int[]{
            10,9,8,7,6,
        };
        
       public IEnumerator GetEnumerator(){

           Console.WriteLine(nameof(GetEnumerator));
            return new someEnumerator(input);
        }

        private class someEnumerator: IEnumerator{
            public int[] result;
            int currentIndex=0;
        public someEnumerator(int[] input){
            result=input;
        }
            public bool MoveNext(){
           Console.WriteLine(nameof(MoveNext));
            return currentIndex < result.Length;
            }

            public Object Current{
                get{
                    Console.WriteLine(nameof(Current));
                    return result[currentIndex++];
                }
                
            }

            public void Reset(){
                Console.WriteLine(nameof(Reset));
                currentIndex=0;
            }

        }
        
    }

    public static class sampleExtensionMethods{
        public static IEnumerable<student> filter(this IEnumerable<student> input,Func<student,bool> predicate){
           // throw new Exception();
           // List<student> temp=new List<student>();
                foreach( var inp in input){
                    Console.WriteLine("iterating"+input);
                        if(predicate(inp)){
                            yield return inp;
                        }
                }
           //  return temp;
                
        }
    }
    

}