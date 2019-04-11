using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JamesZacka_GoDataFeed_Coding_Demo.Services
{
  interface IProductService
  {
    void GetProducts();
    void GetProductsByID(int id);
  }
}
