using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackGame
{

    public static class Program
    {
        public static void Main()
        {
            //Study.firstQuestText();
            Study.firstQuest();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine($"1. Магазин\t\tДенег: {Person.money}\n2. Работа\t\tСытость: {Person.satiety}\n3. \t\tРесурс Компьютера: {Person.resourceOfComputer}");
            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Shop.Menu();
                    break;

                case 2:
                    Jobs.Menu();
                    break;

                default:
                    Console.WriteLine("Не понимаю, что вы хотите");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }
    }

    public static class Jobs
    {

        public static void Menu()
        {
            Console.Clear();
            if(Person.resourceOfComputer == 0)
            {
                Console.WriteLine("Вы не можете взламывать, купите компьютер...");
                Console.ReadKey();
                Program.Menu();
            }
            Console.WriteLine("1. Взлом Соц.Сетей");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    MenuEasyLVL();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Не понимаю, что вы хотите");
                    Console.ReadKey();
                    Program.Menu();
                    break;
            }
        }

        public static void MenuEasyLVL()
        {
            Random rnd = new Random();
            int randomQuest = rnd.Next(1,4);

            if(randomQuest == 1)
            {
                Lvl_0_0();
            }

            else if(randomQuest == 2)
            {
                Lvl_0_1();
            }

            else if(randomQuest == 3)
            {
                Lvl_0_2();
            }
        }

        public static void Lvl_0_0()
        {
            Console.Clear();
            Console.WriteLine("Догадки по паролю:Ал****а* \nСведения: Математик\nСведения: Любит таблицу умножения\nСведения: Поставил двойку за пример 2+2*2");
            string answer = Console.ReadLine();
            if( answer == "Алгебра6")
            {
                Console.Clear();
                Console.WriteLine("Отлично, получилось взломать математика");
                Person.money += 500;
                Console.WriteLine("Ваша награда: 500 Рублей");
                Console.ReadKey();
                Program.Menu();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("К сожалению вы не смогли взломать пароль...");
                Program.Menu();
            }
        }

        public static void Lvl_0_1()
        {
            Console.Clear();
            Console.WriteLine("Догадки по паролю:Ов****нО*к* \nСведения: Физрук\nСведения: Любит хоккей\nСведения: Играет в 21");
            string answer = Console.ReadLine();
            if(answer == "ОвечкинОчко")
            {
                Console.Clear();
                Console.WriteLine("Отлично, получилось взломать Физрука");
                Person.money += 1000;
                Console.WriteLine("Ваша награда: 1000 Рублей");
                Console.ReadKey();
                Program.Menu();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("К сожалению вы не смогли взломать пароль...");
                Program.Menu();
            }
        }

        public static void Lvl_0_2()
        {
            Console.Clear();
            Console.WriteLine("Догадки по паролю: З**б***сь\nСведения:ЯжМать \nСведения: ребенок по имени Ангелина \nСведения: ребенку 35 лет ");
            string answer = Console.ReadLine();
            if (answer == "Заебалась")
            {
                Console.Clear();
                Console.WriteLine("Отлично, получилось взломать Мамочку");
                Person.money += 1200;
                Console.WriteLine("Ваша награда: 1200 Рублей");
                Console.ReadKey();
                Program.Menu();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("К сожалению вы не смогли взломать пароль...");
                Program.Menu();
            }
        }
    }

    public static class Shop
    {
        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("1. Технический отдел\n2. Продуктовый отдел\n3.Автосалон");
            int choice = int.Parse(Console.ReadLine());
            
            switch(choice)
            {
                case 1:
                    TechnoShop();
                    break;

                case 2:

                    break;

                case 3:

                    break;

                default:
                    Console.WriteLine("Не указанно место назначения");
                    Console.ReadKey();
                    break;
            }
        }
        

        public static void TechnoShop()
        {
            Console.WriteLine("1. Сдать компьютер в ремонт(Могут и не сделать): 2500 Рублей\n2. Новенький ноутбук(+100 к Ресурсу компьютера): 5000 Рублей\n3. Стационарный компьютер(+200 к Ресурсу компьютера): 15000 Рублей");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    if(Person.money < 2500)
                    {
                        Console.WriteLine("К сожалению у вас не хватает денег. Ждите подачек от родителей или пособие по безработице от Государства.");
                        TechnoShop();
                    }

                    else
                    {
                        Person.money -= 2500;
                        Person.resourceOfComputer = 20;
                        TechnoShop();
                    }
                    break;

                case 2:

                    break;

                case 3:

                    break;
            }
        }
    }

    public static class Person
    {
        public static int money = 2500;
        public static int satiety = 20;
        public static int eat = 0;
        public static int resourceOfComputer = 20;
        public static int cars = 0;


        public static async void ResourceOfComputer()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if(resourceOfComputer == 0)
                    {
                        continue;
                    }

                    Thread.Sleep(120000);
                    resourceOfComputer -= 1;
                }
            });
        }

        public static async void Satiety()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if(satiety == 0)
                    {
                        continue;
                    }

                    Thread.Sleep(60000);
                    satiety -= 1;
                }
            });
        }
    }
   

    public static class Study
    {
        /*public static void firstQuestText()
        {
            string text1 = "Однажды проснувшись, я понял, что так жить нельзя...\nМеня вечно мучало осознание, что я ни на что не гажусь.\nДостав старенький ноутбук, я отправился на просторы даркнета";
            for (int i = 0; i < text1.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(text1[i]);
            }

            Console.ReadKey();

            Console.Clear();

            text1 = "Я Решил попробовать заработать на взломе паролей от Соц.Сетей\nНо, в хакерских штучках, я ничего не понииал, по этому выставив объявление об услуге и найдя клиента, я принялся за работу...\n";
            for (int i = 0; i < text1.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(text1[i]);
            }

            Console.ReadKey();

            Console.Clear();

            text1 = "Первым заказчиком, оказался парень одной не очень умной девушки\nПообщавшись с ним, он дал мне, кое какие данные\n\nИмя:Настя\n23 года\nОкончание номера: 8909";
            for (int i = 0; i < text1.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(text1[i]);
            }

            Console.ReadKey();


            firstQuest();
        }*/

        public static void firstQuest()
        {
            Console.Clear();
            Console.WriteLine("Догадки по паролю: *9****я*3");
            Console.WriteLine("Имя:Настя\n23 года\nОкончание номера: 8909");
            string answer = Console.ReadLine();
            if(answer == "09Настя23")
            {
                continueText();
            }

            else
            {
                firstQuest();
            }
        }

        public static void continueText()
        {
            Console.Clear();

            string text1 = "И вот, получилось, мы взломали пароль той самой девушки, от удивления мое сердце забилось.\nНеужели я на первые вырученные деньги смогу купить себе покушать\nИ тут же задумался, долго ли продержится мой комп...";
            for (int i = 0; i < text1.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(text1[i]);
            }

            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("Приветствую, в этой игре тебе прийдётся играть за начинающего хакера, тебе прийдётся с многим столкнуться в этой игре\nТебе прийдётся лишиться компа, по скольку он сгорит\nА так же и серьезно поголодать");
            Console.WriteLine("Но, ты не бойся, ведь после первого выигрыша ты наполнен интузиазмом и думаешь, что у тебя все получится\n НО НЕ НАДЕЙСЯ!!!");

            Person.ResourceOfComputer();
            Person.Satiety();
            Program.Menu();
        }
    }

}