public class mailbuilder{

private mail obj;

public mailbuilder(string sender, string receiver){
    obj=new mail();
    obj.sender=sender;
    obj.receiver=receiver;
}

public mailbuilder addSubject(string subject){
    obj.subject=subject;
    return this;
}
public mailbuilder addContent(string content){
    obj.content=content;
    return this;
}

private class mail{
    public string sender{get; set;}
    public string receiver{get; set;}
    public string subject{get; set;}
    public string content{get; set;}
}

// public static void main(){
//     mail obj=new mail();
//     obj.subject="";
//     obj.sender="";
//     obj.receiver="";
//     obj.content="";
// }
}

public class consumer{

    public static void main(){
    mailbuilder obj=new mailbuilder("aaa","bbb");
    obj.addSubject("my subject").addContent("my content");
}

}



