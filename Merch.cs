using System;
using System.Collections.Generic;
using System.Text;

namespace E_shop
{
    public class Merch
    {
        public string mName { get; private set; }
        public int mPrice { get; private set; }
        public Merch next {get;set;}


    public Merch (string merchName, int merchPrice, Merch nextNode )
        {
            mPrice = merchPrice;
            mName = merchName;
            next = nextNode;
        }

        public void ChangePointer(Merch nextNode)
        {
            next = nextNode;
        }

    }
}
