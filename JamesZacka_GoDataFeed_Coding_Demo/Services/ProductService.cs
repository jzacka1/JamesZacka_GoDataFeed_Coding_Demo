using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace JamesZacka_GoDataFeed_Coding_Demo.Services
{
  public class ProductService : BaseClient, IProductService
  {

    public string baseURL { get; set; }

    public ProductService(): base("api/ProductsAPI"){
      this.baseURL = baseURL;
    }

    public void GetProducts()
    {
      RestRequest request = new RestRequest("", Method.GET);


    }

    public void GetProductsByID(int id)
    {
      throw new NotImplementedException();
    }
  }
}
