using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_07
{
    internal class CrudOperations
    {
        public static async Task CreateRoleAsync(string roleTitle, string connectionString) 
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                db.Add(new Role {Title = roleTitle});
                await db.SaveChangesAsync();
            }
        }

        public static async Task CreateUserAsync(string name, string surname, string phoneNumber, string roleTitle, string connectionString)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var roleId = db.Roles.Where(r => r.Title == roleTitle).Single().Id;

                db.Add(new User
                {
                    Name = name,
                    Surname = surname,
                    PhoneNumber = phoneNumber,
                    RoleId = roleId
                });
                await db.SaveChangesAsync();
            }
        }

        public static async Task CreateTaskAsync(string title, int priority, int userId, string connectionString)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                db.Add(new TaskToDo
                {
                    Title = title,
                    Priority = priority,
                    AssignedUserId = userId
                });
                await db.SaveChangesAsync();
            }
        }

        public static async Task ReadTaskAsync(string connectionString, int assingedId = 0)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                if (assingedId != 0)
                {
                    var user = db.User.Where(i => i.Id == assingedId).Single();

                    await Task.Run(() => db.Tasks.Where<TaskToDo>(t => t.AssignedUserId == user.Id).ToList<TaskToDo>());

                    foreach(var task in user.Tasks)
                        Console.WriteLine(task.Title + " ");
                }
                else
                {
                    foreach(var task in db.Tasks)
                        Console.WriteLine(task.Title + " ");
                }
            }
        }

        public static async Task UpdateTaskTitleAsync(string previousTaskTitle, string newTaskTitle, string connectionString)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var taskId = db.Tasks.Where(t => t.Title == previousTaskTitle).Single().Id;

                db.Roles.Find(taskId).Title = newTaskTitle;
                await db.SaveChangesAsync();
            }
        }

        public static async Task DeleteTaskAsync(string taskTitle, string connectionString)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var taskId = db.Tasks.Where(t => t.Title == taskTitle).Single().Id;

                db.Remove(db.Tasks.Find(taskId));
                await db.SaveChangesAsync();
            }
        }
    }
}


