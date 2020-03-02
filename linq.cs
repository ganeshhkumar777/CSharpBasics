using System;
using System.Collections;
using System.Collections.Generic;
namespace generics.linq{
    public class linq{
        public static void Main(string[] args){
          someEnumerable obj=new someEnumerable();
          foreach(var i in obj){
              Console.WriteLine(i);
          }
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

     
    

}