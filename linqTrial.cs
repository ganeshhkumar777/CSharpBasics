using System.Collections;
using System.Collections.Generic;
using System;
namespace  generics.linq{
    public class linqTial{
List<employee> employees;
    public linqTial(){
        employees  =new List<employee>(){
            new employee(){
                id=1,
                name="ganesh"
            },
            new employee(){
                id=2,
                name="ganesh1"
            },
            new employee(){
                id=3,
                name="ganesh2"
            }
        };
    }
        public void main(){
            var result = employees.filter(x=>x.id>1);;
            foreach (var item in result)
            {
                Console.WriteLine(item.name);
            }
        }

        
        
    }

    public class employee{
        public int id{get; set;}
        public string name{get; set;}
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