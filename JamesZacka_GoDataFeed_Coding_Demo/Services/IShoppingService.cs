using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JamesZacka_GoDataFeed_Coding_Demo.Models;

namespace JamesZacka_GoDataFeed_Coding_Demo.Services
{
    interface IShoppingService
    {
        void Login(string name);
        void AddToCart(Products product);
        void RemoveFromCart();
        void MakeOrder();
        void CancelOrder();
    }
}
