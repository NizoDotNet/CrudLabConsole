using CrudLabConsole.Entities;
using CrudLabConsole.Service;

namespace CrudLabConsole.Controller;

public class TeacherController : Controller
{
    private readonly Service<Teacher> teacherService;
    private static int lastTeacherId = 1;

    public TeacherController(Service<Teacher> teacherService)
    {
        this.teacherService = teacherService;
    }

    public void DisplayAll()
    {
        Console.Clear();
        Console.WriteLine("ID\tName\tSurname");
        var all = teacherService.GetAll();
        foreach (var e in all)
        {
            Console.WriteLine($"{e.Id}\t{e.Name}\t{e.Surname}");
        }
    }

    public void DisplayOne()
    {
        Console.Clear();
        Console.WriteLine("ID?: ");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
        }
        var teacher = teacherService.Get(id);
        if(teacher != null)
        {
            Console.Clear();
            Console.WriteLine($"ID: {teacher.Id}");
            Console.WriteLine($"Name: {teacher.Name}");
            Console.WriteLine($"Surname: {teacher.Surname}");
            Console.WriteLine($"Subject: {teacher.Subject}");
        }
       

    }

    public void Create()
    {
        Console.Clear();
        Teacher entity = new Teacher();

        Console.WriteLine("Name: ");
        entity.Name = Console.ReadLine();
        Console.WriteLine("Surname: ");
        entity.Surname = Console.ReadLine();
        Console.WriteLine("Subject: ");
        entity.Subject = Console.ReadLine();
        entity.Id = lastTeacherId;

        lastTeacherId++;
        teacherService.Add(entity);
    }

    public void Delete()
    {
        Console.Clear();
        Console.WriteLine("ID?: ");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
        }
        teacherService.Delete(id);
        lastTeacherId--;
    }

    public void Update()
    {
        Console.Clear();
        Console.WriteLine("ID?: ");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
        }
        var teacher = teacherService.Get(id);
        if( teacher != null )
        {
            Console.WriteLine($"{teacher.Name} -> ");
            Console.WriteLine("Name: ");
            teacher.Name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            teacher.Surname = Console.ReadLine();
            Console.WriteLine("Subject: ");
            teacher.Subject = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("No entity with this Id.");
        }
    }

    public void Save() => teacherService.Save();
}
