using CrudLabConsole.Entities;
using System.Text.Json;

namespace CrudLabConsole.Service;

public class StudentService : Service<Student>
{
    public override string FileName => "./Student.json";
    private DatabaseEntity _entity;
    public StudentService()
    {
        _entity = GetDatabaseEntity();
    }
    public override void Add(Student entity)
    {
        _entity.Students.Add(entity);
    }

    public override void Delete(int id)
    {
        var student = _entity.Students.Where(c => c.Id == id).FirstOrDefault();
        if(student != null)
        {
            _entity.Students.Remove(student);
        }
    }

    public override Student Get(int id)
    {
        return GetDatabaseEntity().Students.Where(c => c.Id == id).FirstOrDefault();
    }

    public override List<Student> GetAll()
    {
        return GetDatabaseEntity().Students;
    }

    public override void Save()
    {
        string json = JsonSerializer.Serialize<DatabaseEntity>(_entity);
        File.WriteAllText(FileName, json);
    }

    public override void Update(int id, Student entity)
    {
        var student = _entity.Students.Where(c => c.Id == id).FirstOrDefault();
        if(student != null)
        {
            student.Surname = entity.Surname;
            student.Age = entity.Age;
            student.Name = entity.Name;
            student.GPA = entity.GPA;
        }
    }

    

}
