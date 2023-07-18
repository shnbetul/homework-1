using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controller
{
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Kısa Kollu Tisort",
                Price = 456.99,
                Category = "Giyim",
                Brand = "Kaft"
            },
            new Product
            {
                Id = 2,
                Name = "Spor Gomlek",
                Price = 615.99,
                Category = "Giyim",
                Brand = "Koton"
            },
            new Product
            {
                Id = 3,
                Name = "S22",
                Price = 31110,
                Category = "Telefon",
                Brand = "Samsung"
            },
            new Product
            {
                Id = 4,
                Name = "J7 Prime",
                Price = 15000,
                Category = "Telefon",
                Brand = "Samsung"
            },
            new Product
            {
                Id = 5,
                Name = "Siyah Pantalon",
                Price = 410.99,
                Category = "Giyim",
                Brand = "Mavi"
            },
            new Product
            {
                Id = 6,
                Name = "Toz Deterjan",
                Price = 215.99,
                Category = "Deterjan",
                Brand = "Ariel"
            },
            new Product
            {
                Id = 7,
                Name = "Yumuşatici",
                Price = 70.99,
                Category = "Deterjan",
                Brand = "Yumos"
            },
            new Product
            {
                Id = 8,
                Name = "Ipone 15",
                Price = 60001,
                Category = "Telefon",
                Brand = "Apple"
            },
            new Product
            {
                Id = 9,
                Name = "Ipone 16",
                Price = 70010,
                Category = "Telefon",
                Brand = "Apple"
            },
            new Product
            {
                Id = 10,
                Name = "Kahve Rimel",
                Price = 156.99,
                Category = "Kozmetik",
                Brand = "Loreal"
            },
            new Product
            {
                Id = 11,
                Name = "Kırmızı Ruj",
                Price = 109.99,
                Category = "Kozmetik",
                Brand = "Loreal"
            },
            new Product
            {
                Id = 12,
                Name = "Pembe Ruj",
                Price = 215.99,
                Category = "Kozmetik",
                Brand = "Watsons"
            },
            new Product
            {
                Id = 13,
                Name = "Tukenmez Kalem",
                Price = 110.99,
                Category = "Kirtasiye",
                Brand = "Prime"
            },
            new Product
            {
                Id = 14,
                Name = "Uçlu Kalem",
                Price = 153.99,
                Category = "Kirtasiye",
                Brand = "Faber Castel"
            },
            new Product
            {
                Id = 15,
                Name = "Boya Kalemi",
                Price = 90,
                Category = "Kirtasiye",
                Brand = "Faber Castel"
            },
        };

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = Products.OrderBy(x => x.Category).ToList<Product>();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            var product = Products.SingleOrDefault(x => x.Name == newProduct.Name);

            if (product is not null)
            {
                return BadRequest();
            }
            Products.Add(newProduct);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.SingleOrDefault(x => x.Id == id);
            if (product is null)
                return BadRequest();

            product.Name = updatedProduct.Name != default ? updatedProduct.Name : product.Name;
            product.Category =
                updatedProduct.Category != default ? updatedProduct.Category : product.Category;
            product.Price = updatedProduct.Price != default ? updatedProduct.Price : product.Price;
            product.Brand = updatedProduct.Brand != default ? updatedProduct.Brand : product.Brand;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Products.Remove(product);
            return NoContent();
        }

        [HttpGet("list")]
        public IActionResult ListProducts([FromQuery] string name)
        {
            var filteredProducts = Products.Where(p => p.Name == name).ToList();
            return Ok(filteredProducts);
        }
    }
}
