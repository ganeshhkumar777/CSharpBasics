using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Threading.Tasks;
 
public class TestScript 
{
    public struct MyOutcome
    {
        public string Message;
    }
 
    public struct MyAwaiter : INotifyCompletion
    {
        public int Value;
 
        public void OnCompleted(Action continuation)
        {
            Console.WriteLine("OnCompleted. Value = " + Value);
            continuation();
        }
 
        public bool IsCompleted
        {
            get
            {
                Console.WriteLine("IsCompleted returning false");
                return false;
            }
        }
 
        public MyOutcome GetResult()
        {
            Console.WriteLine("GetResult. Value = " + Value);
            return new MyOutcome { Message = "You gave me: " + Value };
        }
    }
 
    public struct MyTask
    {
        public int Value;
 
        public MyAwaiter GetAwaiter()
        {
            Console.WriteLine("GetAwaiter. Value = " + Value);
            return new MyAwaiter { Value = Value };
        }
    }
 
    // public static async Task Main(string[] args)
    // {
    //     Console.WriteLine("Calling await...");
    //     MyOutcome outcome = await new MyTask { Value = 5 };
    //     Console.WriteLine("Outcome: " + outcome.Message);
    // }
}
