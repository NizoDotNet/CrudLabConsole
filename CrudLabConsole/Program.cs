using CrudLabConsole.Controller;
using CrudLabConsole.Entities;
using CrudLabConsole.Service;

void Start()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("1. Teacher");
        Console.WriteLine("2. Student");
        Console.WriteLine("3. Exit");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            Controller controller;
            switch (n)
            {
                case 1:
                    controller = new TeacherController(new TeacherService());
                    Manager(controller);
                    break;
                case 2:
                    controller = new StudentController(new StudentService());
                    Manager(controller);
                    break;
                case 3:
                    return;
            }
        }
    }
}


void Manager(Controller controller)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("1. Get all");
        Console.WriteLine("2. Get with id");
        Console.WriteLine("3. Add");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Update");
        Console.WriteLine("6. Save");
        Console.WriteLine("7. Exit");

        int n = 0;

        while (!int.TryParse(Console.ReadLine(), out n));
        switch (n)
        {
            case 1:
                controller.DisplayAll();
                break;
            case 2:
                controller.DisplayOne();
                break;
            case 3:
                controller.Create();
                break;
            case 4:
                controller.Delete();
                break;
            case 5:
                controller.Update();
                break;
            case 6:
                controller.Save();
                break;
            case 7:
                return;

        }
        Console.ReadLine();
    }
}

Start();