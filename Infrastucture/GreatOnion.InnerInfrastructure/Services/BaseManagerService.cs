using AutoMapper;
using GreatOnion.Application.DTOClasses;
using GreatOnion.Application.ServiceInterfaces;
using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using GreatOnion.Domain.Repositories;
using GreatOnion.InnerInfrastructure.Handlers.ExpressionHandlers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.InnerInfrastructure.Services
{
    public class BaseManagerService<T> : IManagerService<T> where T : BaseDTO
    {
        protected readonly IRepository<IEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseManagerService(IRepository<IEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task AddAsync(T item)
        {
            //The item parameter will come as DTO...Implement your business logic in here then map the DTO to Entity...We will do it for all of our ManagerService classes
            IEntity entity = _mapper.Map<IEntity>(item);

            await _repository.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> list)
        {
            List<IEntity> entityList = _mapper.Map<List<IEntity>>(list);
            await _repository.AddRangeAsync(entityList);

        }
        //todo:BaseManagerService Inheritance kısmında kalındı
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            //Expression<Func<IEntity, bool>> newExp =  Expression.Lambda<Func<IEntity, bool>>(exp.Body);
            //Type dto = exp.Parameters[0].Type.GetType();

            Expression<Func<IEntity, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, IEntity>(exp);
            return await _repository.AnyAsync(newExp);
        }

        public async Task DeleteAsync(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = Domain.Enums.DataStatus.Deleted;
            IEntity entity = _mapper.Map<IEntity>(item);
            await _repository.DeleteAsync(entity);
        }

        public async Task DeleteRangeAsync(List<T> list)
        {
            //Business Logic for the mentioned collection(list) should be implemented here...That would not only seperate the concerns but also create a loosely coupling system to the Manager class...
            List<IEntity> entities = _mapper.Map<List<IEntity>>(list);
            await _repository.DeleteRangeAsync(entities);


        }

        public async Task DestroyAsync(T item)
        {
            IEntity entity = _mapper.Map<IEntity>(item);
            await _repository.DestroyAsync(entity);
        }

        public async Task DestroyRangeAsync(List<T> list)
        {
            List<IEntity> entities = _mapper.Map<List<IEntity>>(list);
            await _repository.DestroyRangeAsync(entities);
        }

        public async Task<T> FindAsync(params object[] values)
        {
            IEntity foundEntity = await _repository.FindAsync(values);
            return _mapper.Map<T>(foundEntity);

        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            Expression<Func<IEntity, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, IEntity>(exp);
            IEntity foundEntity = await _repository.FirstOrDefaultAsync(newExp);
            return _mapper.Map<T>(foundEntity);
        }

        public async Task<List<T>> GetActivesAsync()
        {
            List<IEntity> foundEntities = await _repository.GetActivesAsync();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<IEntity> foundEntities = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public async Task<List<T>> GetModifiedsAsync()
        {
            List<IEntity> foundEntities = await _repository.GetModifiedsAsync();
            return _mapper.Map<List<T>>(foundEntities);

        }

        public async Task<List<T>> GetPassivesAsync()
        {
            List<IEntity> foundEntities = await _repository.GetPassivesAsync();
            return _mapper.Map<List<T>>(foundEntities);
        }

        //Aslında DTO'ların tamamen sorumluluk olarak ayrılmaı bu metodun amacını işlevsiz hale getiriyor olabilir...Bunun bir düsünülmesi lazım...Kimse gidip de BaseManagerService'ten DTO dısında bir şey döndürmek istemez..Dolayısıyla buradaki X işlevini yitiriyor...Yine de iyi bir algoritma olduğu için burada bıraktım...Fakat mantık olarak düsünüldügünde kişi buradaki Select'ten istediği dönüşü alabilecek...Bunun Entity bile olması mümkün cünkü su anda bir güvenlik kısıtlaması yok...Lakin bu güvenlik kısıtlaması oldugunda da Sadece DTO'ya kısıtlanacagı icin sonucta bu Select mantıgını yitirmiş olur.
        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            Expression<Func<IEntity, X>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, IEntity, X>(exp);
            return _repository.Select(newExp);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            Expression<Func<IEntity, object>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, IEntity>(exp);
            return _repository.Select(newExp);
        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = Domain.Enums.DataStatus.Updated;
            IEntity entity = _mapper.Map<IEntity>(item);
            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            List<IEntity> foundEntities = _mapper.Map<List<IEntity>>(list);
            await _repository.UpdateRangeAsync(foundEntities);
        }

        public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            Expression<Func<IEntity, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, IEntity>(exp);
            List<IEntity> foundEntities = await _repository.WhereAsync(newExp);
            return _mapper.Map<List<T>>(foundEntities).AsQueryable();


        }
    }
}
