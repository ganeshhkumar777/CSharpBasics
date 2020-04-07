using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
public class Repository<T> : IRepostiory<T> where T: class{
    DbContext dbcontext;
    DbSet<T> entites;
    public Repository(DbContext context){
        dbcontext=context;
        entites = this.dbcontext.Set<T>();
    }

    // IEnumerable
    //    ^   
    //    |    
    // Iqueryable
    public IQueryable<T> GetAll(){
        return entites.AsQueryable();
    }

    public void Add(T input){
        entites.Add(input);
    }

}