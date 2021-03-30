using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Pagination
{
    public class ReadPaging
    {
        public int index { get; set; }
        public int totalPages { get; set; }
        public IEnumerable<ReadProduct> Data { get; set; }
    }

    public class PagingInfo
    {
        public int index { get; set; }
        public int totalItems { get; set; }
        public int size { get; set; } = 8;

        public int skip
        {
            get
            {
                if (index != 0)
                    return size * index - size;
                return 0;
            }
        }

        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling((float)totalItems / size);
            }
        }

        public IEnumerable<ReadProduct> Data { get; set; }
    }
}
