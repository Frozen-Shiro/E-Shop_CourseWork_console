using System;
using System.Collections.Generic;
using System.Text;

namespace E_shop
{
    class Shop
    {
        public Orderer[] customers { get; private set; }
        private int size;
        public int counter { get; private set; }
        public int totalPrice { get; private set; }

        public Shop()
        {
            size = 25;
            customers = new Orderer[size];
            counter = -1;
        }

        protected static bool needToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }


        public void Add(string name)//операция добавления
        {
            counter++;
            customers[counter] = new Orderer(name);
        }

        public void Sort()
        {
            if (counter > 1)
            {
                for (int i = 0; i < counter; i++)
                {
                    for (int j = 0; j < counter - 1; j++)
                    {
                        if (needToReOrder(customers[j].oName, customers[j + 1].oName))
                        {
                            var s = customers[j];
                            customers[j] = customers[j + 1];
                            customers[j + 1] = s;
                        }
                    }
                }
            }
            else
            {
                if (counter > 0)
                {


                    for (int i = 0; i < counter; i++)
                    {
                        if (needToReOrder(customers[i].oName, customers[i + 1].oName))
                        {
                            var s = customers[i];
                            customers[i] = customers[i + 1];
                            customers[i + 1] = s;
                        }
                    }
                }
            }
        }

        public void Insert(string input, int index) //вставка в заданный пользователем индекс
        {
            if (index < counter)
            {
                for (int i = counter; i >= index; i--)
                {
                    customers[i + 1] = customers[i];
                }
                customers[index] = new Orderer(input);
                counter++;
            }
            else
            {
                if (index == counter || index > counter && index < size)
                {
                    Add(input);
                    counter++;
                }
            }

        }

        public void Remove(int index) //удаление (исполнение) заказа. Удаляет выбранный заказ, после чего упорядочевает список
        {
            if (index <= counter)
            {
                customers[index] = null;
                for (int i = index; i < counter; i++)
                {
                    customers[i] = customers[i + 1];
                }
                customers[counter] = null;
                counter--;
                

            }
        }

        public int Search(string name)//Поиск по имени заказчика
        {
            for (int i = 0; i < counter+1; i++)
            {
                if (customers[i].oName == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void GetTotalPrice()//Рассчёт итоговой стоимости. Вызывается один раз, при выводе полной информации о магазине. 
        {
            totalPrice = 0;
            for (int i=0;i<=counter;i++)
            {
                totalPrice = totalPrice + customers[i].oPrice;
            }
        }





    }
}
