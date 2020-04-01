using System.Collections.Generic;
using System;
public class IOCContainerBuilder{

private IOCContainer iocContainer;

// step 1
// we will registering the types in the beginning
// Whenever you someone requests for an instance of iclassA, 
// please provide classA

// in the code, iclassA will be mapped to classA using dictionary
// iclassA --> classA

// step 2:
// when someone requests an instance for iclassA,
// i will whether iclassA is present in dictionary which has the mapping.

// usage
// addTransient<iclassA, classA>()
// addTransient<iclassA, classB>()
public IOCContainerBuilder addTransient<source,result>() where result:source{
if(iocContainer == null){
    iocContainer=new IOCContainer();
}
if(!iocContainer.map.ContainsKey(typeof(source))){
    iocContainer.map.Add(typeof(source),typeof(result));
} else {
    iocContainer.map[typeof(source)]=typeof(result);
}

return this;
}

public Type Get(Type source){
if(iocContainer.map.ContainsKey(source)){
   return   iocContainer.map[source];
}
else{
throw new InvalidOperationException("type"+source+"is not registered in the IOC container");
}
}

private class IOCContainer{
public Dictionary<Type,Type> map;
public IOCContainer(){
    map=new Dictionary<Type, Type>();
}
}


}

