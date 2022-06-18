using System;
using System.Linq;
using System.Threading.Tasks;
using lab_07;

namespace lab_07
{
    public class Program
    {
        public static void Main()
        {
            const string connectionString = @"Data Source=KOMPUTERPC\SQLCOURSE2019;Initial Catalog=todo_db;Integrated Security=True";
            
            CrudOperations.CreateRoleAsync("Admin", connectionString).Wait();
            CrudOperations.CreateRoleAsync("Basic", connectionString).Wait();
            Console.WriteLine("Created Admin and Basic Roles");
            
            CrudOperations.CreateUserAsync("Jan", "Nowak", "523133532", "Admin", connectionString).Wait();
            CrudOperations.CreateUserAsync("Tomasz", "Maj", "531665432", "Admin", connectionString).Wait();
            CrudOperations.CreateUserAsync("Piotrek", "Gierczak", "312432554", "Basic", connectionString).Wait();
            Console.WriteLine("Created three new Users");
            
            CrudOperations.CreateTaskAsync("Zrobić zakupy", 4, 1, connectionString).Wait();
            CrudOperations.CreateTaskAsync("Nakarmić ryby", 2, 2, connectionString).Wait();
            CrudOperations.CreateTaskAsync("Wyprowadzić psa", 1, 3, connectionString).Wait();
            CrudOperations.CreateTaskAsync("Pozmywać naczyncia", 3, 2, connectionString).Wait();
            Console.WriteLine("Created four new Tasks");
            
            Console.WriteLine("Jan tasks:");
            CrudOperations.ReadTaskAsync(connectionString, 1).Wait();
            Console.WriteLine("\n");
            
            CrudOperations.UpdateTaskTitleAsync("Nakarmić ryby", "Zrobić pranie", connectionString).Wait();
            Console.WriteLine("Task is updated");
            
            CrudOperations.ReadTaskAsync(connectionString).Wait();
            Console.WriteLine("\n");
            CrudOperations.DeleteTaskAsync("Nakarmić ryby", connectionString).Wait();
            CrudOperations.ReadTaskAsync(connectionString).Wait();
            Console.WriteLine("\n\n");

        }
    }
}

