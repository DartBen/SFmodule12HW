using System.Dynamic;
using System.Reflection.Metadata;

internal class Program
{

    private static void Main(string[] args)
    {

        UserList users = new UserList();

        users.AddUser();

        int nubmer = 0;
        bool parsed = false;
        while (!parsed)
        {
            Console.WriteLine("Введите порядковый номер");
            parsed = int.TryParse(Console.ReadLine(), out nubmer);
        }

        Console.WriteLine($"Приветствуем {users.GetName}!");
        if (!users.GetIsPremium(nubmer - 1))
        {
            UserList.ShowAds();
        }
    }

    public class UserList
    {
        private List<User> users;

        public UserList()
        {
            users = new List<User>();
        }

        public void AddUser()
        {
            User user = new User();

            Console.WriteLine("Введите имя");
            user.Name = Console.ReadLine();

            Console.WriteLine("Введите логин");
            user.Login = Console.ReadLine();

            bool cicleEndsHere = false;
            while (!cicleEndsHere)
            {
                Console.WriteLine("Аккаунт премиальный?");
                var strTmp = Console.ReadLine();
                if (strTmp == "Да" || strTmp == "да" || strTmp == "+")
                {
                    user.IsPremium = true;
                    cicleEndsHere = true;
                }
                else if (strTmp == "Нет" || strTmp == "нет" || strTmp == "-")
                {
                    user.IsPremium = false;
                    cicleEndsHere = true;
                }
            }

            users.Add(user);
        }
        public bool GetIsPremium(int i)
        {
            return users[i].IsPremium;
        }
        public string GetName(int i)
        {
            return users[i].Name;
        }

        public void DeleteUser(int removeItem)
        {
            users.RemoveAt(removeItem);
        }

        public static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }

    }

    public class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }
    }

}