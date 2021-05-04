using System;

namespace E_shop
{
    class Program
    {
        static void Main(string[] args)
        {
         

            string exitCheck = "n";
            string menu;
            string name;
            int price;     
            Shop magazin = new Shop();
            Orderer temp;
            while (exitCheck!="y")
            {
                Console.WriteLine("#-#-#-#-#-#");
                Console.WriteLine("0 - create new order and add merchandise to it");
                Console.WriteLine("1 - add new merchandise to order_name");
                Console.WriteLine("2 - return information about order_name");
                Console.WriteLine("3 - return full information about shop");
                Console.WriteLine("4 - delete merchandise from order_name");
                Console.WriteLine("5 - delete orde_name");
                Console.WriteLine("#-#-#-#-#-#");
                Console.WriteLine("Choose command");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "0"://create order and add merhandise to an order (while-true cycle)
                        Console.WriteLine("#-#-#-#-#-####"); 
                        Console.WriteLine("Enter orderer`s name:");
                        magazin.Add(Console.ReadLine());
                        var exitCheck1 = "n";
                        while (exitCheck1!="y")
                        {
                            Console.WriteLine("Enter merch name(str) and price (int)");
                            Console.WriteLine("Enter Y to leave");
                            name = Console.ReadLine();
                            if (name=="y") //При вводе имени "yes" заканчивает цикл создания заказа
                            {
                                exitCheck1 = "y";
                                break;
                            }
                            price = Convert.ToInt32(Console.ReadLine());
                            magazin.customers[magazin.counter].Enqueue(name,price);
                        }
                        magazin.Sort();
                        Console.WriteLine("#-#-#-#-#-####");
                        break;
                    case "1"://add merch to THE order
                        Console.WriteLine("#-#-#-#-#-####");
                        Console.WriteLine("Enter merch name(str) and price (int)");
                        name = Console.ReadLine();
                        price = Convert.ToInt32(Console.ReadLine());
                        var index = magazin.Search(Console.ReadLine());
                        if (index != -1)
                        {
                            Console.WriteLine("Enter name of orderer to add:");
                            magazin.customers[index].Enqueue(name, price);
                        }
                        else
                        {
                            Console.WriteLine("There is no such orderer, try to create a new one");
                        }
                        Console.WriteLine("#-#-#-#-#-####");
                        break;
                    case "2"://full information about orderer
                        Console.WriteLine("#-#-#-#-#-####");
                        Console.WriteLine("Enter orderer`s name :");
                         temp = magazin.customers[magazin.Search(Console.ReadLine())];
                        Console.WriteLine("Name : "+temp.oName);
                        Console.WriteLine("Date : " + temp.oDate);
                        Console.WriteLine("Total price : " + temp.oPrice);
                        Console.WriteLine("Merchandise list :");
                        for (Merch temp2 = temp.head.next; temp2 != null; temp2 = temp2.next)
                        {
                            Console.WriteLine(temp2.mName + ":" + temp2.mPrice);
                        }
                        Console.WriteLine("#-#-#-#-#-####");
                        break;
                    case "3"://full information about all orders
                        Console.WriteLine("#-#-#-#-#-####");
                        for (int i=0;i<magazin.counter+1;i++)
                        {
                            temp = magazin.customers[i];
                            Console.WriteLine("Name : " + temp.oName);
                            Console.WriteLine("Date : " + temp.oDate);
                            Console.WriteLine("Total price : " + temp.oPrice);
                            Console.WriteLine("Merchandise list :");
                            for (Merch temp2 = temp.head.next; temp2 != null; temp2 = temp2.next)
                            {
                                Console.WriteLine(temp2.mName+":"+ temp2.mPrice);
                            }
                        }
                        magazin.GetTotalPrice();
                        Console.WriteLine("Total shop price:" + magazin.totalPrice);
                        Console.WriteLine("#-#-#-#-#-####");
                        break;
                    case "4"://Delete merch from the order
                        Console.WriteLine("#-#-#-#-#-####");
                        Console.WriteLine("Enter orderer`s name");
                        magazin.customers[magazin.Search(Console.ReadLine())].Dequeue();
                        Console.WriteLine("Dequeued");
                        Console.WriteLine("#-#-#-#-#-####");
                        break;
                    case "5"://Delete order
                        Console.WriteLine("#-#-#-#-#-####");
                        Console.WriteLine("Enter order name to delete:");
                        magazin.Remove(magazin.Search(Console.ReadLine()));
                        Console.WriteLine("#-#-#-#-#-####");
                        break;
                   

                }

            }

        }
    }
}
