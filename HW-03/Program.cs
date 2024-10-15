using System;

namespace HW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInfo = GetUserData();
            ShowUserData(userInfo);

            Console.ReadKey();
        }

        private static void ShowUserData((string name, string lastName, int age, bool hasPets, string[] petsNames, string[] favColors) userInfo)
        {
            Console.WriteLine($"Вас зовут {userInfo.name} {userInfo.lastName}, Вам {userInfo.age} лет");

            if (userInfo.hasPets)
            {
                Console.WriteLine("У Вас есть питомцы с такими кличками: ");

                if (userInfo.petsNames != null)
                {
                    foreach(var pet in userInfo.petsNames)
                    {
                        Console.WriteLine($"- {pet}");
                    }
                }
            }
            else
            {
                Console.WriteLine("У Вас нет питомцев");
            }

            Console.WriteLine("У Вас есть любимые цвета: ");

            if (userInfo.favColors != null)
            {
                foreach (var color in userInfo.favColors)
                {
                    Console.WriteLine($"- {color}");
                }
            } else
            {
                Console.WriteLine("У Вас нет любимого цвета");
            }
        }

        private static (string name, string lastName, int age, bool hasPets, string[] petsNames, string[] favColors) GetUserData()
        {
            (string name, string lastName, int age, bool hasPets, string[] petsNames, string[] favColors) userData = ("", "", 0, false, null, null);

            Console.Write("Введите имя: ");
            userData.name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            userData.lastName = Console.ReadLine();

            string strage;
            int age;

            do
            {
                Console.Write("Введите возраст цифрами: ");
                strage = Console.ReadLine();
            } while (CheckNum(strage, out age));

            userData.age = age;

            string strpetsCount;
            int petsCount;

            do
            {
                Console.Write("Количество домашних питомцев?: ");
                strpetsCount = Console.ReadLine();
            } while (CheckPetsAmount(strpetsCount, out petsCount));


            if (petsCount <= 0)
            {
                userData.hasPets = false;
            }
            else
            {
                userData.hasPets = true;
                userData.petsNames = CreatePetsArray(petsCount);
            }

            string strfavColors;
            int favColorsCount;

            do
            {
                Console.Write("Количество любимых цветов (минимум один)?: ");
                strfavColors = Console.ReadLine();
            } while (CheckNum(strfavColors, out favColorsCount));

            userData.favColors = CreateColorsArray(favColorsCount);

            return userData;
        }

        private static bool CheckNum(string number, out int correctNumber)
        {
            if (int.TryParse(number, out int intnum)) 
            {
                if (intnum > 0)
                {
                    correctNumber = intnum;
                    return false;
                }
            }

            correctNumber = 0;

            return true;
        }

        private static bool CheckPetsAmount(string number, out int correctNumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum >= 0)
                {
                    correctNumber = intnum;
                    return false;
                }
            }

            correctNumber = 0;

            return true;
        }

        private static string[] CreatePetsArray(int petsCount)
        {
            string[] petsNames = new string[petsCount];

            for (int i = 0; i < petsCount; i++)
            {
                Console.Write($"Имя питомца под номером {i + 1}: ");
                petsNames[i] = Console.ReadLine();
            }

            return petsNames;
        }

        private static string[] CreateColorsArray(int colorsCount)
        {
            string[] favColors = new string[colorsCount];

            for (int i = 0; i < colorsCount; i++)
            {
                Console.Write($"Любимый цвет под номером {i + 1}: ");
                favColors[i] = Console.ReadLine();
            }

            return favColors;
        }
    }
}
