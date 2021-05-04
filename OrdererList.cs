using System;
using System.Collections.Generic;
using System.Text;

namespace E_shop
{
    public class Orderer
    {
        public string oName { get; private set; }
        public string oDate { get; private set; }
        private Merch tail { get; set; } 
        public Merch head { get; private set; } 

        public int oPrice { get; private set; }

        public int Count
        {
            get
            {
                int result = 0;
                var pointer = head;
                while (pointer.next != null)
                {
                    pointer = pointer.next;
                    result++;
                }
                return result;
            }
        }

        public Orderer(string ordererName)
        {
            oName = ordererName;
            oDate = DateTime.Now.ToString();
            tail = new Merch("", 0, null);
            head = tail;
            oPrice = 0;
        }

       



        public void Enqueue(string merchName, int merchPrice) //добавление товара в заказ
        {
            Merch newMerch = new Merch(merchName, merchPrice, null); 
            tail.ChangePointer(newMerch);
            tail = newMerch;
            oPrice = oPrice+ merchPrice;

        }



        public void Dequeue()//удаляет товар 
        {
            var result = head.next;
            head.ChangePointer(head.next.next == default(Merch) ? null : result.next);

        }

       





    }
}
