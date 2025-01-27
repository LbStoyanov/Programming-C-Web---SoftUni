﻿using ASP.NETIntro.Core.Contracts;
using ASP.NETIntro.Core.Data;
using ASP.NETIntro.Core.Data.Models;
using ASP.NETIntro.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ASP.NETIntro.Core.Services
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        private readonly ApplicationDbContext context;
        //private readonly IRepo repo => We can create additional repo for usage, in order to prevent mistakes when we interacting with the DB!!!;

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="config">Application configuratuin</param>
        public ProductService(IConfiguration config,ApplicationDbContext context)
        {
            this.config = config;
            this.context= context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price= productDto.Price,
                Quantity= productDto.Quantity,
            };

            //Логиката се извършва тук в сървиса, запазват данните в базата, a в контролера само викаш необходимия сървис???

            await this.context.AddAsync(product);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await this.context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;

                await this.context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            //string dataPath = config.GetValue();
            //throw new NotImplementedException();

            //string dataPath = config.GetSection("DataFiles:Products").Value;
            //string data = await File.ReadAllTextAsync(dataPath);
            //return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data)!;

            return await this.context.Products
                .Where(p => p.IsActive)
                .Select(p => new ProductDto()
                {
                    Id= p.Id,
                    Name= p.Name,
                    Price= p.Price,
                    Quantity= p.Quantity
                }).ToListAsync();
        }
    }
}
