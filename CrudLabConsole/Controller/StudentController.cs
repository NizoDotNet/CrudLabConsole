using CrudLabConsole.Entities;
using CrudLabConsole.Service;

namespace CrudLabConsole.Controller;

public class StudentController : Controller
{
    private readonly Service<Student> studentService;
    private static int lastStudentId = 1;

    public StudentController(Service<Student> studentService)
    {
        this.studentService = studentService;
    }

    public void DisplayAll()
    {
        Console.Clear();
        Console.WriteLine("ID\tName\tSurname");
        var all = studentService.GetAll();
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
        var student = studentService.Get(id);
        if(student != null)
        {
            Console.Clear();
            Console.WriteLine($"ID: {student.Id}");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Surname: {student.Surname}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"GPA: {student.GPA}");
        }
        

    }

    public void Create()
    {
        Console.Clear();
        Student entity = new Student();

        Console.WriteLine("Name: ");
        entity.Name = Console.ReadLine();
        Console.WriteLine("Surname: ");
        entity.Surname = Console.ReadLine();
        Console.WriteLine("Age: ");
        entity.Age = int.Parse(Console.ReadLine());
        Console.WriteLine("GPA: ");
        entity.GPA = int.Parse(Console.ReadLine());
        entity.Id = lastStudentId;

        lastStudentId++;
        studentService.Add(entity);
    }

    public void Delete()
    {
        Console.Clear();
        Console.WriteLine("ID?: ");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
        }
        studentService.Delete(id);
        lastStudentId--;
    }

    public void Update()
    {
        Console.Clear();
        Console.WriteLine("ID?: ");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
        }
        var student = studentService.Get(id);
        if (student != null)
        {
            Console.WriteLine($"{student.Name} -> ");
            Console.WriteLine("Name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            student.Surname = Console.ReadLine();
            Console.WriteLine("Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("GPA: ");
            student.GPA = int.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("No entity with this Id.");
        }
    }

    public void Save() => studentService.Save();
}
