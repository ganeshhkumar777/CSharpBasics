using System.Linq;
public interface IRepostiory<T>
{
    IQueryable<T> GetAll();
    void Add(T input);


    
}