namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static List<string> tasks = new List<string>(); // Store tasks
        static string filePath = "tasks.txt"; // File for saving tasks

        static void Main()
        {
            LoadTasks(); // Load tasks from file at startup
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== TO-DO LIST MANAGEMENT =====");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Update Task"); // Added update option
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ViewTasks(); break;
                    case "2": AddTask(); break;
                    case "3": DeleteTask(); break;
                    case "4": UpdateTask(); break; // Call UpdateTask() method
                    case "5": SaveTasks(); return;
                    default: Console.WriteLine("Invalid choice! Press Enter to continue."); Console.ReadLine(); break;
                }
            }
        }

        // Load tasks from file
        static void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                tasks = new List<string>(File.ReadAllLines(filePath));
            }
        }

        // Save tasks to file
        static void SaveTasks()
        {
            File.WriteAllLines(filePath, tasks);
            Console.WriteLine("Tasks saved. Exiting...");
        }

        // View all tasks
        static void ViewTasks()
        {
            Console.Clear();
            Console.WriteLine("===== Your Tasks =====");
            if (tasks.Count == 0) Console.WriteLine("No tasks found!");
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
            Console.WriteLine("\nPress Enter to return to menu...");
            Console.ReadLine();
        }

        // Add a new task
        static void AddTask()
        {
            Console.Clear();
            Console.Write("Enter the task: ");
            string newTask = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                tasks.Add(newTask);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty!");
            }
            Console.ReadLine();
        }

        // Delete a task
        static void DeleteTask()
        {
            ViewTasks();
            Console.Write("Enter task number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task deleted!");
            }
            else
            {
                Console.WriteLine("Invalid task number!");
            }
            Console.ReadLine();
        }

        // Update an existing task
        static void UpdateTask()
        {
            ViewTasks();
            Console.Write("Enter task number to update: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                Console.Write("Enter the new task description: ");
                string updatedTask = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(updatedTask))
                {
                    tasks[index - 1] = updatedTask;
                    Console.WriteLine("Task updated successfully!");
                }
                else
                {
                    Console.WriteLine("Task cannot be empty!");
                }
            }
            else
            {
                Console.WriteLine("Invalid task number!");
            }
            Console.ReadLine();
        }
    }


}
