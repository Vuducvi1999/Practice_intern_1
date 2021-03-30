using AutoMapper;
using Domain.Context;
using Domain.Dtos.Pagination;
using Domain.Dtos.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.User
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly ProductContext _context;

        public ProductServices(IMapper mapper, ProductContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Create(ProductEntity newProduct)
        {
            if (!Directory.Exists("Upload\\"))
            {
                Directory.CreateDirectory("Upload\\");
            }
            string fileExt = System.IO.Path.GetExtension(newProduct.ImageFile.FileName);
            string namePath = "Upload\\" + Guid.NewGuid().ToString() + fileExt;
            FileStream filestream = File.Create(namePath);
            newProduct.ImageFile.CopyTo(filestream);
            filestream.Flush();
            filestream.Close();
            newProduct.Image = namePath;
            _context.Add(newProduct);
            _context.SaveChanges();
        }

        public ReadPaging GetPage(int index)
        {
            var result = new PagingInfo();
            result.index = index;
            result.totalItems = GetAll().Count();
            result.Data = GetAll().Skip(result.skip).Take(result.size).ToList();
            return _mapper.Map<PagingInfo,ReadPaging>(result);
        }

        public void Delete(Guid id)
        {
            var findProduct = _context.Products.Find(id);
            _context.Remove(findProduct);
            _context.SaveChanges();
            File.Delete(findProduct.Image);
        }

        public IEnumerable<ReadProduct> GetAll()
        {
            var allProducts = _context.Products.ToList();
            return _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ReadProduct>>(allProducts);
        }

        public ReadProduct GetById(Guid id)
        {
            var findProduct = _context.Products.Find(id);
            return _mapper.Map<ProductEntity, ReadProduct>(findProduct);
        }
        

        public void UpdatePatch(Guid id,PatchProduct updateProduct)
        {
            var findProduct = _context.Products.Find(id);
            foreach(var item in updateProduct.GetType().GetProperties())
            {
                var key = item.Name;
                var value = item.GetValue(updateProduct, null);
                if(key == "ImageFile" && value!=null)
                {
                    File.Delete(findProduct.Image);
                    string fileExt = System.IO.Path.GetExtension(updateProduct.ImageFile.FileName);
                    string namePath = "Upload\\" + Guid.NewGuid().ToString() + fileExt;
                    FileStream fileStream = File.Create(namePath);
                    updateProduct.ImageFile.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                    findProduct.Image = namePath;
                    continue;
                }
                if (value!= null)
                {
                    findProduct.GetType().GetProperty(key).SetValue(findProduct, value);
                }
            }
            _context.SaveChanges();
        }

        public void UpdatePut(Guid id,PutProduct updateProduct)
        {
            var findProduct = _context.Products.Find(id);
            _mapper.Map(updateProduct, findProduct);
            _context.SaveChanges();
        }
    }
}
