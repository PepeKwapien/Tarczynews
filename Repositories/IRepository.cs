namespace Tarczynews.Repositories
{
    public interface IRepository<Model>
    {
        Model Read(Guid id);
        IEnumerable<Model> ReadAll();
        void Create(Model model);
        void Update(Model model);
        void Delete(Guid id);
        void Save();
    }
}
