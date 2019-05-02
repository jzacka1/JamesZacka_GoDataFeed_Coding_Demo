using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using JamesZacka_GoDataFeed_Coding_Demo.Controllers;
using JamesZacka_GoDataFeed_Coding_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace APIControllerTest
{
	public class APIControllerTest
	{
		private ProductsAPIController _productsAPIController;
		private ProductsController _productsController;

		private readonly DbContextOptions<Model1> _options;

		public APIControllerTest()
		{
			//Each call to the constructor must change the database name to unique names
			_options = new DbContextOptionsBuilder<Model1>()
				.UseInMemoryDatabase("ShoppingDB" + Guid.NewGuid().ToString())
				.Options;

			this.InitContext();
		}

		private void InitContext()
		{
			var _context = new Model1(_options);

			//Add Products
			_context.Products.Add(new Products { ID = 1, Name = "Fighter Jet", Manufacturer = "Lockheed Martin", Price = 350000000 });
			_context.Products.Add(new Products { ID = 2, Name = "Sedan", Manufacturer = "Honda", Price = 35000 });
			_context.Products.Add(new Products { ID = 3, Name = "Jupiter", Manufacturer = "Planetoid", Price = 10000000 });
			_context.Products.Add(new Products { ID = 4, Name = "IPhone", Manufacturer = "Apple", Price = 500 });
			_context.Products.Add(new Products { ID = 5, Name = "Bleach", Manufacturer = "Johnson and Johnson", Price = 9 });

			//Create Hashed Password
			string pass = "pass";
			string salt = Guid.NewGuid().ToString();
			Byte[] inputBytes = Encoding.UTF8.GetBytes(pass + salt);
			SHA512 shaM = new SHA512Managed();
			Byte[] hashedBytes = shaM.ComputeHash(inputBytes);

			//Add Customers
			_context.Customers.Add(new Customers
			{
				ID = 1,
				Name = "James Zacka",
				Password = hashedBytes,
				Salt = salt
			});

			_context.SaveChanges();

			_productsAPIController = new ProductsAPIController(_context);
			_productsController = new ProductsController(_context);
		}
		
		[Fact]
		public void ProductsAPI_GetProducts_IsTypeProduct()
		{
			//Arrange
			IEnumerable<Products> products;

			//Act
			products = _productsAPIController.GetProducts();

			//Assert
			Assert.IsType<Products>(products.First());
		}

		[Fact]
		public async Task Products_Index_IsNotNullAsync()
		{

			//Act
			var productIndex = await _productsController.Index();

			//Assert
			Assert.NotNull(productIndex);
		}

		[Fact]
		public async Task ProductsAPI_GetProductsByName(){
			//Act
			string name = "Sedan";

			//Assert
			var products = await _productsAPIController.GetProductsByName(name);

			//Assert
			var test = "fdsa";
			//Assert.Equals(name, products.Value[0].Name);
		}

	}
}
