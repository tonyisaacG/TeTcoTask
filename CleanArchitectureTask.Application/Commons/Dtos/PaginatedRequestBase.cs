using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTask.Application.Commons.Dtos
{
    public abstract class PaginatedRequestBase
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 5;
        private int _pageNumber = 1;

        public int PageSize
        {
            set
            {
                _pageSize = value > MaxPageSize ? MaxPageSize : value;
            }
            get => _pageSize;
        }

        public int PageNumber
        {
            set
            {
                _pageNumber = value <= 1 ? 0 : value - 1;
            }
            get => _pageNumber;
        }
    }

}
