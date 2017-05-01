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
            // �������� ������
            context.Users.Add(new User { UserName = "admin", UserRole = UserRole.������������� });
            context.Users.Add(new User { UserName = "user", UserRole = UserRole.���������� });

            List<Post> posts = new List<Post>();
            posts.Add(context.Posts.Add(new Post { Name = "��������� ������", Salary = 100000.00m }));
            posts.Add(context.Posts.Add(new Post { Name = "����������", Salary = 30000.00m }));

            List<Department> departments = new List<Department>();
            departments.Add(context.Departments.Add(new Department { Name = "�����������" }));
            departments.Add(context.Departments.Add(new Department { Name = "����� ������"}));

            List<Employee> employees = new List<Employee>();
            employees.Add(context.Employees.Add(new Employee { FullName = "���� ������", BirthDate = new DateTime(1995, 3, 1), Gender = Gender.� }));
            employees.Add(context.Employees.Add(new Employee { FullName = "���� ������", BirthDate = new DateTime(1967, 3, 1), Gender = Gender.� }));

            context.Contracts.Add(new Contract {
                Employee = employees.Single(e => e.FullName == "���� ������"),
                Department = departments.Single(e => e.Name == "����� ������"),
                Post = posts.Single(e => e.Name == "����������"),
                ContractText = "������� � ���������� �1027",
                OrderText = "��������� � ����",
                OrderState = OrderState.��������                
            });           
            context.Contracts.Add(new Contract
            {
                Employee = employees.Single(e => e.FullName == "���� ������"),
                Department = departments.Single(e => e.Name == "����� ������"),
                Post = posts.Single(e => e.Name == "��������� ������"),
                ContractText = "������� � ���������� �1079",
                OrderText = "��������� � ����",
                OrderState = OrderState.��������
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