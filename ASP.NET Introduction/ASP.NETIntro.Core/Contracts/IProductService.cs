﻿using ASP.NETIntro.Core.Models;

namespace ASP.NETIntro.Core.Contracts
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAll();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        Task Add(ProductDto productDto);
    }
}
