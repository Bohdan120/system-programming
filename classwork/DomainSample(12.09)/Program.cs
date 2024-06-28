using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSample_12._09_
{
    class User : MarshalByRefObject
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public override string ToString() => $"UserId: {Id} | Name: {UserName}";
    }
    class UserProccesor : MarshalByRefObject
    {
        public User ChangeUserName(User user, string newUserName)
        {
            Console.WriteLine($"Змінюємо ім'я користувача з домену, з назвою: {AppDomain.CurrentDomain.FriendlyName}"); user.UserName = newUserName;
            return user;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

            //AppDomain secondDomain = AppDomain.CreateDomain("Second Domain");
            //Console.WriteLine(secondDomain.FriendlyName);

            //Console.WriteLine(secondDomain.IsDefaultAppDomain());



        }
    }
}
