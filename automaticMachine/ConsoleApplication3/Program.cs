using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Buiscuits
    {

        static void Main(string[] args)
        {

            int userAnswering = 5;
            while (userAnswering != 0)//Даём возможность пользователю после завершения операции войти в главное меню заново
            {
               
                int countBuiscuits = 0;//Количество печенек,
                int countCakes = 0;//кексов
                int countWafels = 0;//вафель, который введет в итоге захочет купить пользователь
                int userAnswer = 5;//Переменная,которая отвечает за выбор соответствующего пункта меню
                while (userAnswer != 0)//Цикл выбора покупки, выполняется до тех пор, пока пользователь не введёт "0"
                {
                    Console.WriteLine("Всего вы можете взять 3 печенья, 4 кекса и 10 вафель. Для добавления печенья нажмите 1, кекса - 2, вафли - 3,для продолжения - 0 ");
                    try//Исключение неправильного типа ввода данных
                    {
                        userAnswer = int.Parse(Console.ReadLine());//Выбор соответствующего пункта меню
                    }
                    catch (Exception)//Перехват исключения
                    {
                        Console.WriteLine("Неправильный тип ввода данных");
                    }
                    if ((userAnswer == 1) | (userAnswer == 2) | (userAnswer == 3) | (userAnswer == 0))//Проверка на наличие введённого пользователем пункта меню
                    {
                        if (userAnswer == 1) countBuiscuits++;//Добавление печенек
                        if (userAnswer == 2) countCakes++;//кексов
                        if (userAnswer == 3) countWafels++;//или вафель в зависимость от того, что выбрал пользователь
                        if ((countBuiscuits > 3) | (countCakes > 4) | (countWafels > 10))//Проверка на наличие товаров на складе
                        {
                            Console.WriteLine("Выбранного вами товара нет в наличии");
                            break;
                        }
                        if ((countBuiscuits == 0) && (countCakes == 0) && (countWafels == 0))//Выход из цикла при условии, что пользователь выбрал 0 товаров
                            break;
                        Console.WriteLine("На данный момент вы выбрали:");//Вывод
                        Console.WriteLine("печений");//на консоль количество товаров,
                        Console.WriteLine(countBuiscuits);//которое на данный момент 
                        Console.WriteLine("кексов");//выбрал пользователь
                        Console.WriteLine(countCakes);
                        Console.WriteLine("вафель");
                        Console.WriteLine(countWafels);

                    }
                    else

                        Console.WriteLine("Нет такого пункта меню");
                   
                }

                if ((countBuiscuits == 0) && (countCakes == 0) && (countWafels == 0))//Случай, если пользователь не выбрал ни одного товара 
                    Console.WriteLine("Некорректное значение");
                else
                    if ((countBuiscuits <= 3) && (countCakes <= 4) && (countWafels <= 10))//Если пользователь выбрал корректное значение товаров, то создаём новый объект
                    {
                        automaticMachine person1 = new automaticMachine(countBuiscuits, countCakes, countWafels);//Создание нового объекта

                        Console.WriteLine("Вы должны внести следующую сумму");
                        Console.WriteLine(person1.lastSum());//Показывает пользователю сумму, которую он должен внести

                        int Money = person1.depositMoney();//Функция внесения пользователем денег


                        if (person1.lastSum() > Money)//Проверка на достаточность средств, введённых пользователем

                            Console.WriteLine("Вы ввели недостаточно средств");

                        else
                        {
                            Console.WriteLine("Возьмите ваш товар, спасибо за покупку!");//Сообщение о выдачи товара
                            if (Money > person1.lastSum())//В случае возможности выдачи сдачи предлагает пользователю ее вернуть
                            {
                                Console.WriteLine("Если хотите сдачу нажмите 1, если нет любую клавишу");
                                int cifr;
                                cifr = int.Parse(Console.ReadLine());
                                if (cifr == 1)
                                    person1.Change(Money);//функция выдачи сдачи
                            }

                        }
                    }
                try
                {
                    Console.WriteLine("Чтобы войти в главное меню и начать всё заново, нажмите любую клавишу,  чтобы выйти - 0");
                    userAnswering = int.Parse(Console.ReadLine());//Предложение пользователю войти опять в главное меню
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели некорректное значение");
                }

            }
        }


        public class automaticMachine//класс автомата
        {

            private int Buiscuits, Cakes, Wafels;//переменные, задействующиеся в классе, количество печенек, кексов и вафель
            //конструктор
            public automaticMachine(int buiscuits, int cakes, int wafels)
            {
                Buiscuits = buiscuits;//инициализирует количество печенек
                Cakes = cakes;//кексов
                Wafels = wafels;//и вафель, введенных пользователем
            }

            //Функция считает необходимую для покупки сумму
            public int lastSum()
            {
                int sum;
                sum = Buiscuits * 10 + Cakes * 50 + Wafels * 30;
                return sum;
            }
            //Функция внесения пользователем денег в автомат 
            public int depositMoney()
            {
                int sum = 0;//Считает сумму уже введённую пользователем
                int money;//Купюра, внесённая пользователем только что
                int userAnswer = 5;//Переменная, которая отвечает за то, хочет ли пользователь внести еще деньги в автомат
                while (userAnswer != 0)//Пока пользователь не нажал ноль, автомат предлагает внести деньги
                {


                    Console.WriteLine("Автомат принимает монеты 1, 2, 5 или 10.Обращаем ваше внимание, что сдача не может превышать 100 р");
                    try//Проверка на корректность введённого типа данных
                    {
                        money = int.Parse(Console.ReadLine());

                        if ((money != 1) && (money != 2) && (money != 5) && (money != 10))//Проверка на правильность внесённой купюры

                            Console.WriteLine("Автомат не принимает таких денег");

                        else
                        {

                            sum = sum + money;
                            if (sum > 150)// Проверка на наличие денег в кошельке у пользователя
                            {
                                Console.WriteLine("У вас кончались деньги");
                                break;
                            }
                            else
                                Console.WriteLine("Вы ввели денег:");
                            Console.WriteLine(sum);//Показывает пользователю сумму, которую он уже внёс
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Вы ввели некорректное значение типа данных");
                    }


                    try
                    {
                        Console.WriteLine(" Если не хотите больше вносить - нажмите 0, если хотите - любую клавишу");
                        userAnswer = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Вы ввели некорректное значение типа данных");
                    }


                }
                return sum;//Возвращает сумму, которую внёс пользователь
            }

            //Функция, выдающая сдачу покупателю
            public int Change(int money)
            {
                int change = money - (Buiscuits * 10 + Cakes * 50 + Wafels * 30);//Считает сдачу, которую автомат должен выдать пользователю
                int oldChange = change;//Сохраняем значение, чтобы его вернуть
                int countTen = 0, countFive = 0, countTwo = 0, countOne = 0;//Количество десяток, пятёрок, двоек и единиц, выданных автоматом пользователю
                if (change > 100) Console.WriteLine("У автомата нет монет на сдачу");//случай если у автомата нет монет на сдачу
                else
                {

                    while (change > 0)//Пока сдача не выдана, выполняем цикл
                    {
                        if (change >= 10)//Выдаём десятки
                        {
                            change = change - 10;
                            countTen++;
                        }
                        else
                            if (change >= 5)//Пятёрки
                            {
                                change = change - 5;
                                countFive++;
                            }
                            else
                                if (change >= 2)//Двойки
                                {
                                    change = change - 2;
                                    countTwo++;
                                }
                                else
                                {
                                    change = change - 1;//Кдиницы
                                    countOne++;
                                }
                    }
                }
                Console.WriteLine("Возвращаем вам");//Сообщаем пользователлю, сколько
                Console.WriteLine("десяток");//десяток
                Console.WriteLine(countTen);
                Console.WriteLine("пятерок");//пятеорк
                Console.WriteLine(countFive);
                Console.WriteLine("двоек");//двоек
                Console.WriteLine(countTwo);
                Console.WriteLine("единиц");//и единиц, выдал ему автомат
                Console.WriteLine(countOne);
                return oldChange;//Возвращаем сдачу, которую нужно выдать пользователю

            }

        }
    }
}



