namespace HRMWebApplication
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    public class HRMModelInitializer : CreateDatabaseIfNotExists<HRMModel>
    {
        protected override void Seed(HRMModel context)
        {
            // тестовые данные
            context.Users.Add(new User { UserName = "admin", UserRole = UserRole.Администратор });
            context.Users.Add(new User { UserName = "user", UserRole = UserRole.Специалист });

            List<Post> posts = new List<Post>();
            posts.Add(context.Posts.Add(new Post { Name = "Начальник отдела", Salary = 100000.00m }));
            posts.Add(context.Posts.Add(new Post { Name = "Специалист", Salary = 30000.00m }));

            List<Department> departments = new List<Department>();
            departments.Add(context.Departments.Add(new Department { Name = "Бухгалтерия" }));
            departments.Add(context.Departments.Add(new Department { Name = "Отдел продаж"}));

            List<Employee> employees = new List<Employee>();
            employees.Add(context.Employees.Add(new Employee { FullName = "Иван Иванов", BirthDate = new DateTime(1995, 3, 1), Gender = Gender.М }));
            employees.Add(context.Employees.Add(new Employee { FullName = "Петр Петров", BirthDate = new DateTime(1967, 3, 1), Gender = Gender.М }));

            context.Contracts.Add(new Contract {
                Employee = employees.Single(e => e.FullName == "Иван Иванов"),
                Department = departments.Single(e => e.Name == "Отдел продаж"),
                Post = posts.Single(e => e.Name == "Специалист"),
                ContractText = "Договор с работником №1027",
                OrderText = "Зачислить в штат",
                OrderState = OrderState.Подписан                
            });           
            context.Contracts.Add(new Contract
            {
                Employee = employees.Single(e => e.FullName == "Петр Петров"),
                Department = departments.Single(e => e.Name == "Отдел продаж"),
                Post = posts.Single(e => e.Name == "Начальник отдела"),
                ContractText = "Договор с работником №1079",
                OrderText = "Зачислить в штат",
                OrderState = OrderState.Подписан
            });

        }
    }

    public class HRMModel : DbContext
    {
        public HRMModel()
            : base("name=HRMModel")
        {
            Database.SetInitializer<HRMModel>(new HRMModelInitializer());
        }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Post> Posts { get; set; }
        public DbSet<Models.Contract> Contracts { get; set; }

        public bool IsValidUser(string userName, string userPassword)
        {
            User user = GetUser(userName);
            return user != null;
        }

        public User GetUser(string userName)
        {
            return Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
        }

        public List<string> GetRoles(string userName)
        {
            Models.User user = GetUser(userName);
            List<string> roles = new List<string>();

            if (user != null)
            {
                roles.Add(user.UserRole.ToString());
            }

            return roles;

        }

    }

}