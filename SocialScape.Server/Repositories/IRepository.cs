namespace SocialScape.Server.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T model);
        bool Update(T model);   
        bool Delete(T model);
        bool Save();
    }
}
