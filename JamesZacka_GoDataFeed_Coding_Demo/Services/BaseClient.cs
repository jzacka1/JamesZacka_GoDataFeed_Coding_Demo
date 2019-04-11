using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace JamesZacka_GoDataFeed_Coding_Demo.Services
{
  public class BaseClient : RestClient
  {
      public BaseClient(string baseUrl){
          BaseUrl = new Uri(baseUrl);
      }
  }
}
