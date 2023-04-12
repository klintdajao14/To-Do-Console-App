using System.Reflection.Metadata;
using To_Do_Console_App;

class Program
{

    static void Main(string[] args)
    {
        var arrUsers = new user[]
        {
            new user("klint","klint"),
            new user("lalaine", "lj")
        };

        var arrTasks = new tasks[]{};

        Console.WriteLine("Welcome to Note Taking Console App");
        while (true)
        {
            Console.WriteLine("Please Login or Signup to Continue");
            Console.Write("Press [1] to Login or press [2] to Signup: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1 || choice == 2)
            {
                switch (choice)
                {
                    case 1:
                        bool isFound = false;
                        Console.Write("Username: ");
                        string promptUsername = Console.ReadLine();
                        foreach (user users in arrUsers)
                        {
                            if (promptUsername == users.UserName)
                            {
                                Console.Write("Password: ");
                                string promptPassword = Console.ReadLine();


                                if (promptPassword == users.Password)
                                {
                                    Console.WriteLine($"Welcome {users.UserName}");
                                    while (true)
                                    {
                                        Console.WriteLine("[1] View Tasks\n[2] Create task\nChoice: ");
                                        int prompt = Convert.ToInt32(Console.ReadLine());

                                        if (prompt == 1 || prompt == 2)
                                        {
                                            bool hasTasks = false;

                                            switch (prompt)
                                            {
                                                case 1:
                                                    foreach (tasks userTasks in arrTasks)
                                                    {
                                                        if (userTasks.UserId == users.UserId)
                                                        {
                                                            Console.WriteLine("========================================");
                                                            Console.WriteLine($"[[Task No.{userTasks.taskId}]]");
                                                            Console.WriteLine($"Task Name: {userTasks.Title}");
                                                            Console.WriteLine($"Description: {userTasks.Description}");
                                                            Console.WriteLine($"Completed: {userTasks.isCompleted}");
                                                            Console.WriteLine("========================================");
                                                            Console.WriteLine();
                                                            hasTasks = true;
                                                        }
                                                    }
                                                    if (!hasTasks)
                                                    {
                                                        Console.WriteLine("You have no pending tasks!");
                                                    }
                                                    break;
                                                case 2:
                                                    bool taskAdded = false;
                                                    foreach (tasks userTasks in arrTasks)
                                                    {
                                                        if (userTasks.UserId == users.UserId)
                                                        {
                                                            Console.WriteLine("New Task");
                                                            Console.Write("Title: ");
                                                            string title = Console.ReadLine();
                                                            Console.Write("Description: ");
                                                            string desc = Console.ReadLine();

                                                            var newTask = new tasks(title, desc, false, users);
                                                            arrTasks = arrTasks.Append(newTask).ToArray();
                                                            taskAdded = true;
                                                        }
                                                    }

                                                    if (!taskAdded)
                                                    {
                                                        Console.WriteLine("New Task");
                                                        Console.Write("Title: ");
                                                        string title = Console.ReadLine();
                                                        Console.Write("Description: ");
                                                        string desc = Console.ReadLine();

                                                        var newTask = new tasks(title, desc, false, users);
                                                        arrTasks = new tasks[] { newTask };
                                                    }
                                                    break;

                                            }
                                        }
                                    }
                                    isFound = true;
                                    break;
                                }

                            }
                            if (!isFound)
                            {
                                Console.WriteLine("User not Found!");
                                Environment.Exit(0);
                            }
                            break;
                        }
                        break;


                    case 2:
                        Console.WriteLine(">> PLEASE INPUT FIELDS <<");
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        bool passwordsMatch = false;

                        while (!passwordsMatch)
                        {
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            Console.Write("Confirm Password: ");
                            string confirm = Console.ReadLine();
                            if (password == confirm)
                            {
                                var newUser = new user(username, password);
                                Array.Resize(ref arrUsers, arrUsers.Length + 1);

                                arrUsers[arrUsers.Length - 1] = newUser;
                                Console.WriteLine($"Signed up Successfuly, Welcome {username}");
                                passwordsMatch = true;
                            }
                            else
                            {
                                Console.WriteLine("Passwords do not match");
                            }
                        }
                        break;

                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            else
                Environment.Exit(0);
        }

    }
}