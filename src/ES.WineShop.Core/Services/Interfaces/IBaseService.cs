using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.WineShop.Core.Services.Interfaces
{
    public interface IBaseService<TDto>
        where TDto : class
    {
        Task<TDto> GetAsync(Expression<Func<TDto, bool>> predicate);
        Task<IList<TDto>> GetAllAsync();

        bool Any(Expression<Func<TDto, bool>> predicate);

        TDto Add(TDto dtoModel);
        void Modify(TDto dtoModel);
        void Remove(TDto dtoModel);
        Task RemoveAsync(params object[] keyValue);
        Task SaveChangesAsync();
    }
}
