using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Spotify.Application.AutoMapping;
using Spotify.Application.Interfaces;
using Spotify.Domain.Entities;
using Spotify.Domain.Interfaces;
using Spotify.Infrastructure.EfCore.Repositories;
using System.Linq.Expressions;

namespace Spotify.Application.Services;

public class CrudManager<TEntity, TDto, TCreateDto, TUpdateDto> : ICrudService<TEntity, TDto, TCreateDto, TUpdateDto>
where TEntity : Entity
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public CrudManager()
    {
        _repository = new EfCoreRepository<TEntity>();

        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfile>();

        });

        _mapper = config.CreateMapper();
    }

    public TDto Add(TCreateDto createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        var addedEntity = _repository.Add(entity);

        return _mapper.Map<TDto>(addedEntity);
    }

    public TDto Delete(int id)
    {
        var exist = _repository.GetById(id);

        if (exist == null)
            throw new InvalidOperationException("Entity not found");

        var deletedEntity = _repository.Delete(exist);

        return _mapper.Map<TDto>(deletedEntity);
    }

    public TDto Get(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var entity = _repository.Get(predicate, asNoTracking, include);

        if (entity == null)
            throw new InvalidOperationException("Entity not found");

        return _mapper.Map<TDto>(entity);
    }

    public List<TDto> GetAll(Expression<Func<TEntity, bool>>? predicate = null, bool asNoTracking = false, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        var entities = _repository.GetAll(predicate, asNoTracking, include, orderBy);
        
        if (entities == null || !entities.Any())
            throw new InvalidOperationException("No entities found");

        return _mapper.Map<List<TDto>>(entities);
    }

    public TDto GetById(int id)
    {
        var entity = _repository.GetById(id);

        if (entity == null)
            throw new InvalidOperationException("Entity not found");

        return _mapper.Map<TDto>(entity);
    }

    public TDto Update(TUpdateDto updateDto)
    {
        var updatedEntity = _mapper.Map<TEntity>(updateDto);

        var existingEntity = _repository.GetById(updatedEntity.Id);

        if (existingEntity == null)
            throw new InvalidOperationException("Entity not found");

        return _mapper.Map<TDto>(_repository.Update(updatedEntity));
    }
}
