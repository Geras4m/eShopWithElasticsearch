using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ES.WineShop.Common.Mapper;
using ES.WineShop.Core.Services.Interfaces;
using ES.WineShop.Data.Repositories.Interfaces;

namespace ES.WineShop.Core.Services
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto>
        where TDto : class
        where TEntity : class
    {
        #region Fields, Constructors
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IWsMapper _mapper;
        internal BaseService(IBaseRepository<TEntity> repository, IWsMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region GET/Select methods

        /// <summary>
        /// Returns product filtered based on predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TDto> GetAsync(Expression<Func<TDto, bool>> predicate) =>
            await OnGetAsync(predicate);

        protected async virtual Task<TDto> OnGetAsync(Expression<Func<TDto, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TDto, bool>>, Expression<Func<TEntity, bool>>>(predicate);
            return _mapper.Map<TDto>(await _repository.SelectAsync(expression));
        }

        /// <summary>
        /// Returns all prodcuts.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<TDto>> GetAllAsync() =>
            await OnGetAllAsync();

        protected async virtual Task<IList<TDto>> OnGetAllAsync() =>
            _mapper.Map<IList<TDto>>(await _repository.SelectAllAsync());

        #endregion

        public bool Any(Expression<Func<TDto, bool>> predicate) =>
            OnAny(predicate);

        protected virtual bool OnAny(Expression<Func<TDto, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            return _repository.Any(expression);
        }

        #region Add, Remove, Modify Methods

        public TDto Add(TDto dtoModel) =>
            OnAdd(dtoModel);

        protected virtual TDto OnAdd(TDto dtoModel)
        {
            var entity = _repository.Insert(_mapper.Map<TEntity>(dtoModel));
            return _mapper.Map<TDto>(entity);
        }

        public void Modify(TDto dtoModel) =>
            OnModify(dtoModel);

        protected virtual void OnModify(TDto dtoModel) =>
            _repository.Update(_mapper.Map<TEntity>(dtoModel));

        public async Task RemoveAsync(params object[] keyValues) =>
            await OnRemove(keyValues);

        protected virtual async Task OnRemove(params object[] keyValues) =>
            await _repository.DeleteAsync(keyValues);

        public void Remove(TDto dtoModel) =>
            OnRemove(dtoModel);

        protected virtual void OnRemove(TDto dtoModel) =>
            _repository.Delete(_mapper.Map<TEntity>(dtoModel));

        public async Task SaveChangesAsync() =>
            await OnSaveChangesAsync();

        protected async virtual Task OnSaveChangesAsync() =>
            await _repository.SaveChangesAsync();

        #endregion
    }
}
