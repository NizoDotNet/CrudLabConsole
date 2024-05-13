using CrudLabConsole.Entities;
using System.Text.Json;

namespace CrudLabConsole.Service;

public abstract class Service<T> where T : Entity
{
    public abstract string FileName { get; }
    public abstract List<T> GetAll();
    public abstract T Get(int id);
    public abstract void Delete(int id);
    public abstract void Update(int id, T entity);
    public abstract void Add(T entity);
    public abstract void Save();
    public DatabaseEntity GetDatabaseEntity()
    {
        string json = File.ReadAllText(FileName);
        DatabaseEntity db = JsonSerializer.Deserialize<DatabaseEntity>(json);
        return db;
    }
}
