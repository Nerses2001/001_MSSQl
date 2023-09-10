using _001_MSSQl;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

var random = new Random(); 


using (var context = new ApplicationContext())
{
    
    /*for (int i = 0; i < 1000; ++i) 
    {
        var user = new Users
        {
            Name = $"Name{i + 1}",
            SUrname = $"Surname{i + 1}",
            Age = random.Next(5, 91)
        };
        context.Users.Add(user);
        context.SaveChanges();
    }*/
    Console.WriteLine("User added to the database.");
    var users = context.Users.ToList(); 

    Console.WriteLine("Users in the database:");
    foreach (var user in users)
    {
        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Surname: {user.SUrname}, Age: {user.Age}");
    }
    var queryAge = from u in context.Users
                   where u.Age == 18
                   select u;
    Console.WriteLine(new string('-',50));
    foreach (var user in queryAge)
    {
        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Surname: {user.SUrname}, Age: {user.Age}");
        user.Age = 19;
    }
    context.SaveChanges();
    Console.WriteLine("Ages updated for users with age 18.");
    var queryAgeNew = from u in context.Users
                   where u.Age == 19
                   select u;
    foreach (var user in queryAgeNew)
    {
        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Surname: {user.SUrname}, Age: {user.Age}");

    }

}


Console.Read();