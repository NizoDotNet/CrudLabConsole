using CrudLabConsole.Controller;
using CrudLabConsole.Entities;
using CrudLabConsole.Service;


int lastStudentId = 1;
int lastTeacherId = 1;

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Teacher");
    Console.WriteLine("2. Student");
    Console.WriteLine("3. Exit");
    if(int.TryParse(Console.ReadLine(), out int n))
    {
        if(n == 3)
        {
            Console.WriteLine("End");
            break;
        }
        else if(n == 1)
        {
            Controller controller = new TeacherController(new TeacherService());
            Manager(controller);
        }
        else if(n == 2)
        {
            Controller controller = new StudentController(new StudentService());
            Manager(controller);
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

        if (int.TryParse(Console.ReadLine(), out int n))
        {
            if (n == 1)
            {
                controller.DisplayAll();
            }
            else if (n == 2)
            {
                controller.DisplayOne();


            }
            else if (n == 3)
            {
                controller.Create();

            }
            else if (n == 4)
            {
                controller.Delete();
            }
            else if (n == 5)
            {
                controller.Update();
            }
            else if (n == 6)
            {
                controller.Save();
            }
            else if (n == 7) break;
            Console.ReadLine();

        }
    }
}