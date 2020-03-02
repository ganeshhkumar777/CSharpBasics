using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
namespace generics.asyncawait{
public class asyncawaitTryOne{
    // public struct MyAwaiter : INotifyCompletion{
        
    //     public void OnCompleted(Action input){
    //         Console.WriteLine(nameof(OnCompleted)+ Thread.CurrentThread.ManagedThreadId);
    //         input();
    //     }
    //     public void UnsafeOnCompleted (Action continuation){
    //         Console.WriteLine(nameof(UnsafeOnCompleted));
    //         continuation();
    //     }
    //     public bool IsCompleted{
    //         get {
    //             return false;
    //         }
    //     }

    //     public String GetResult(){
    //         Console.WriteLine(nameof(GetResult));
    //         return "";

    //     }
    // }
    // public struct MyTask{
    //    public MyAwaiter GetAwaiter(){
    //        var mine = new MyAwaiter();
    //        return mine;
    //     }
    // }

    // public static async Task Main(string[] args){
    //    //  HttpClient client=new HttpClient();
    //     // var result2 = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
    //     var result2 = await GetData();
    //     // var result3 =await result2.Content.ReadAsStringAsync();
    // //     Console.WriteLine(result3);
    // //     Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    // //    var result = await new MyTask();
    // //    CancellationTokenSource cancellation=new CancellationTokenSource();

    // //    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    // //    cancellation.Token.ThrowIfCancellationRequested(); 
    // //    cancellation.Cancel(); 
    // //   await Task.Run(()=>{
        
    // //       Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    // //    },cancellation.Token);  
    // }
    
    public static  Task<String> GetData(){
        return Task.Run(()=>{
                Task.Delay(1000);
                return "sample";
            });
    }
}
}
