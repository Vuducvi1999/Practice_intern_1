using Domain.Dtos.Pagination;
using Domain.Dtos.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.User
{
    public interface IProductServices
    {
        void Create(ProductEntity newProduct);
        ReadProduct GetById(Guid id);
        IEnumerable<ReadProduct> GetAll();
        ReadPaging GetPage(int index);
        void UpdatePatch(Guid id,PatchProduct updateProduct);
        void UpdatePut(Guid id,PutProduct updateProduct);
        void Delete(Guid id);
    }
}
