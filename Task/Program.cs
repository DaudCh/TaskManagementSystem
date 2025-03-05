using System;
using System.Collections.Generic;
using System.Globalization;
using Task.Models;

namespace Task
{
    class Program
    {
        static DataService<User> userservice = new DataService<User> ("users.json");
        static DataService<TaskItem> taskservice = new DataService<TaskItem>("tasks.json");
        static void AddUser()
        {
            Console.WriteLine("Enter Userid:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Email :");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role");
            string role = Console.ReadLine();

            List<User> user = userservice.GetData();
            user.Add(new User { UserID = id, Username = username, Email = email, Password = password, Role = role });
            userservice.SaveData(user);
            Console.WriteLine("User Added SuccessFully");
            Console.ReadLine();
        }
        static void ViewUser()
        {
            List<User> users = userservice.GetData();
            Console.WriteLine("---Users---");
            foreach(var us in users)
            {
                Console.WriteLine($" ID: {us.UserID}, Name : {us.Username}");
            }
            Console.WriteLine("continue");
            Console.ReadLine();
        }
        static void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Enter Task id :");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string Desc = Console.ReadLine();
            Console.WriteLine("Enter priority ");
            string priority = Console.ReadLine();
            Console.WriteLine("Enter Status: ");
            string status = Console.ReadLine();
            Console.WriteLine("Enter Created By (UserID)");
            string createdby = Console.ReadLine();
            Console.WriteLine("Enter Deadline: ");
            DateTime deadline = DateTime.Parse(Console.ReadLine());
            
            List<TaskItem> tasks = taskservice.GetData();
            tasks.Add(new TaskItem { TaskID = id, Title = title, Description = Desc,Priority=priority,Status = status,CreatedBy=createdby,Deadline=deadline });
            taskservice.SaveData(tasks);
            Console.WriteLine("Task Added Successfully");
            Console.ReadLine();
        }
        static void ViewTasks()
        {
            List<TaskItem> tasks = taskservice.GetData();
            Console.WriteLine("---Tasks---");
            
            foreach(var ta in tasks)
            {
                Console.WriteLine($"ID : {ta.TaskID},Title :{ta.Title},Status : {ta.Status},Deadline:{ta.Deadline.ToShortDateString()}");
            }
            Console.WriteLine("Continue");
            Console.ReadLine();
        }
        static void Main(string[] args) {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Task MAnagement System");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. View User");
                Console.WriteLine("3. Add Task");
                Console.WriteLine("4. View Task");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                       ViewUser();
                        break;
                    case "3":
                      AddTask();
                       break;
                    case "4":
                        ViewTasks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid Option ");
                        Console.ReadLine();
                        break;



                }
            }
           

        }
        
    }
}
