using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
namespace  generics.linq{
    public class linqTial{
List<employee> employees;
List<employee> employees2;
    public linqTial(){
        employees  =new List<employee>(){
            new employee(){
                id=1,
                name="ganesh",
                hobbies=new List<string>{"singing","dancing"}
            },
            new employee(){
                id=2,
                name="ganesh1",
                 hobbies=new List<string>{"singing1","dancing1"}
            },
            new employee(){
                id=3,
                name="ganesh2",
                 hobbies=new List<string>{"singing3","dancing3"}
            }
        };

        employees2  =new List<employee>(){
            new employee(){
                id=1,
                name="ganesh",
                hobbies=new List<string>{"singing","dancing"}
            },
            new employee(){
                id=2,
                name="ganesh1",
                 hobbies=new List<string>{"singing1","dancing1"}
            },
            new employee(){
                id=3,
                name="ganesh2",
                 hobbies=new List<string>{"singing3","dancing3"}
            }
        };

        employees2  =new List<employee>(){
            new employee(){
                id=1,
                name="ganesh",
                hobbies=new List<string>{"singing","dancing"}
            }
        };
    }
        public void main(){
            var result = employees.filter(x=>x.id>1);;
            foreach (var item in result)
            {
                Console.WriteLine(item.name);
            }

            var result1= employees.SelectMany((x)=>x.hobbies);
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            var result3= employees.SequenceEqual(employees2);
            
            Console.WriteLine(result3);

            var result4 = employees.Any(x=>x.id==0);
            Console.WriteLine(result4);

            var result5 = employees.SingleOrDefault(x=>x.id==0);
            
           // Console.WriteLine(result5.name);
        }


        
        
    }

    public class employee : IComparable<employee>,IEquatable<employee>{
        public int id{get; set;}
        public string name{get; set;}

        public List<string> hobbies{get; set;}

        public int CompareTo(employee input){
            return name.CompareTo(input.name);
             
        }
        public bool Equals(employee input){
            Console.WriteLine("Comparing"+name+"&&"+input.name);
            return name.Equals(input.name);
             
        }
    }

    public static class extensionMethods{
        public static IEnumerable<T> filter<T>(this IEnumerable<T> collection,Func<T,bool> predicate){
            // var result=
            foreach (var item in collection)
            {
                var result=predicate(item);
                if(result)
                yield return item;
            }
        }
    }
}