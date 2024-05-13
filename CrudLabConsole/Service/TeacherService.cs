using CrudLabConsole.Entities;
using System.Text.Json;

namespace CrudLabConsole.Service;

internal class TeacherService : Service<Teacher>
{
    public override string FileName => "./Student.json";
    private DatabaseEntity _entity;

    public TeacherService()
    {
        _entity = GetDatabaseEntity();
    }


    public override void Add(Teacher entity)
    {
        _entity.Teachers.Add(entity);
    }

    public override void Delete(int id)
    {
        var teacher = _entity.Teachers.FirstOrDefault(t => t.Id == id);
        if(teacher != null)
        {
            _entity.Teachers.Remove(teacher);
        }
    }

    public override Teacher Get(int id)
    {
        return GetDatabaseEntity().Teachers.FirstOrDefault(c => c.Id == id);
    }

    public override List<Teacher> GetAll()
    {
        return GetDatabaseEntity().Teachers;
    }

    public override void Save()
    {
        string json = JsonSerializer.Serialize(_entity);
        File.WriteAllText(FileName, json);
    }

    public override void Update(int id, Teacher entity)
    {
        var teacher = _entity.Teachers.FirstOrDefault(c => c.Id == id);
        if(teacher != null)
        {
            teacher.Surname = entity.Surname;
            teacher.Name = entity.Name;
            teacher.Subject = entity.Subject;
        }
    }
}
