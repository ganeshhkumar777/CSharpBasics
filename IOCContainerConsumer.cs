using System;
public class IOCCOntainerConsumer{

    public  static void main(){
        IOCContainerBuilder builder=new IOCContainerBuilder();
        
        // This code will go in to startup class
        builder.addTransient<iclassA,classA>()
                .addTransient<classB,classB>();

        // whoever creates an instance of your class will use this method
        // controller(iclassA classa)
        Type result= builder.Get(typeof(iclassA));
        // new classA();

        var obj= Activator.CreateInstance(result);

        // 
    }


}

public interface iclassA{
void print();
}

public class classA: iclassA{
public void print(){
    Console.WriteLine("hi i am classA");
}
}

public class iclassB{

}
public class classB: iclassB{

}