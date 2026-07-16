using KalkitechProductCatalogService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalkitechProductCatalogService.Controllers
{
    // GET http://localhost:5000/api/ProductsCatalog // example of how to call this API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCatalogController : ControllerBase
    {
        [HttpGet] // https://localhost:44347/api/ProductsCatalog
        public List<Product> GetAllProducts() // Successfully created an endpoint that returns a string message when accessed via HTTP GET request
        {
            // Fetch the data from db and return it to the client
            return GetProductFromDatabase();
        }

        //Get http://localhost:5000/api/ProductsCatalog/1 // example of how to call this API endpoint
        [HttpGet]
        [Route("{id}")] // the extra placeholder is the id
        public IActionResult GetProductById( int id)
        {
            var product = from p in GetProductFromDatabase() where p.ProductId == id select p;
            if(product == null)
            { // return 404 - not found status code
                return NotFound("Product not found");
            }
            //return status code 200 - OK with the product data
            return Ok(product.FirstOrDefault());

        }
        [HttpGet] 
        //Get http://localhost:5000/api/ProductsCatalog/category/Mobile
        [Route("category/{category}")] // the extra placeholder is the category
        public List<Product> GetProductsByCategory(string category)
        {
            var products = from p in GetProductFromDatabase() where p.Category == category select p;
            return products.ToList();
        }
        [HttpGet] //Get http://localhost:5000/api/ProductsCatalog/costly
        [Route("costly")]
        public Product GetTheCostliestProdust()
        {
            var product = from p in GetProductFromDatabase() orderby p.Price descending select p;
            return product.FirstOrDefault();
        }

        private List<Product> GetProductFromDatabase()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop Pro", Price = 89999, Category = "Electronics", Brand = "TechBrand", Country = "USA" },
                new Product { ProductId = 2, Name = "Wireless Headphones", Price = 5999, Category = "Audio", Brand = "SoundMax", Country = "China" },
                new Product { ProductId = 3, Name = "USB-C Cable", Price = 799, Category = "Accessories", Brand = "ConnectTech", Country = "India" },
                new Product { ProductId = 4, Name = "Gaming Mouse", Price = 3499, Category = "Gaming", Brand = "ProGamer", Country = "USA" },
                new Product { ProductId = 5, Name = "Mechanical Keyboard", Price = 8999, Category = "Gaming", Brand = "ProGamer", Country = "China" },
                new Product { ProductId = 6, Name = "4K Monitor", Price = 34999, Category = "Electronics", Brand = "DisplayTech", Country = "Japan" },
                new Product { ProductId = 7, Name = "Webcam HD", Price = 2499, Category = "Accessories", Brand = "ClearVision", Country = "China" },
                new Product { ProductId = 8, Name = "Laptop Stand", Price = 1999, Category = "Accessories", Brand = "ErgoDesk", Country = "India" },
                new Product { ProductId = 9, Name = "External SSD 1TB", Price = 12999, Category = "Storage", Brand = "QuickStore", Country = "USA" },
                new Product { ProductId = 10, Name = "Phone Mount", Price = 499, Category = "Accessories", Brand = "MobileGrip", Country = "China" }
            };
        }
    }
}
