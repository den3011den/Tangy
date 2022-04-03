using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Create(ProductDTO objDTO)
        {
            //Product category = new Product()
            //{
            //    Name = objDTO.Name, 
            //    Id = objDTO.Id,
            //    CreatedDate = DateTime.Now
            //};

            var obj = _mapper.Map<ProductDTO, Product>(objDTO);       
            var addedObj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(addedObj.Entity);

            //return new ProductDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name
            //};
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Products.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductDTO> Get(int id)
        {
            var obj = await _db.Products.Include(u=>u.Category).Include(u=>u.ProductPrices).FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                 return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u => u.Category).Include(u => u.ProductPrices));
        }

        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            var objDromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if(objDromDb!=null)
            {
                objDromDb.Name = objDTO.Name;
                objDromDb.Description = objDTO.Description;
                objDromDb.ImageUrl = objDTO.ImageUrl;
                objDromDb.CategoryId = objDTO.CategoryId;
                objDromDb.Color = objDTO.Color;
                objDromDb.ShopFavorites = objDTO.ShopFavorites;
                objDromDb.CustomerFavorites = objDTO.CustomerFavorites;

                _db.Products.Update(objDromDb);
                _db.SaveChanges();
                return _mapper.Map<Product, ProductDTO>(objDromDb);
            }
            return objDTO;
        }
    }
}
