using System.Threading;
using System.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;
namespace generics{
    public class asyncawaitexample{
        
        // public static async Task Main(){
        
        //      CancellationTokenSource tokenSource=new CancellationTokenSource();
        //     // tokenSource.Cancel();
            
        //     try{
        //     // Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        //     // var data =  await Test(tokenSource.Token);
        //     CustomTaskType();
        //     Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        //     // Console.WriteLine(data);
        //     Console.WriteLine("completed");
        //     }
        //     catch(Exception ex){
        //         Console.WriteLine(ex);
        //     }
            
        // }

        public static void cancel(){
             // tokenSource.Cancel();
        }

        // void
        // Task
        // Task<T>
        // GetAwaiter()

        public static async Task<String> Test(CancellationToken token){
            
                var result= await Task.Run( ()=>{
                    Task.Delay(3000);
                     Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                     return "string";
                },token);
                return result;
        }

        public static async void CustomTaskType(){
            var customTask = await  new MyTask();
            // customTask.GetAwaiter().OnCompleted(()=>{
            //         Console.WriteLine("after on completed");
            // });
            Console.WriteLine(customTask);
        }
        //  while(!IsCompleted){
        //      my thread will be suspended  
        //  }
        //  IsCompleted = true;     
        //
        // 
        // 
        public struct MyTask{
            public  MyAwaiter GetAwaiter(){
                return new MyAwaiter();
            }   
           
        }

        public struct MyAwaiter : INotifyCompletion {
                
                
                
                public void OnCompleted(Action continuation){
                    Console.WriteLine(nameof(OnCompleted));
                    continuation();
                }

                public bool IsCompleted {
                    get {
                        Console.WriteLine(nameof(IsCompleted));
                        return false;
                    }
                }

                public String GetResult(){
                     Console.WriteLine(nameof(GetResult));
                    return "sample";
                }

               
        }
        
    }
    
}