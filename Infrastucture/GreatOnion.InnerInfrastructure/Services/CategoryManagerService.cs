using AutoMapper;
using GreatOnion.Application.DTOClasses;
using GreatOnion.Domain.Entities.Concretes;
using GreatOnion.Domain.Entities.Interfaces;
using GreatOnion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.InnerInfrastructure.Services
{
    public class CategoryManagerService : BaseManagerService<CategoryDTO,Category>
    {
        ICategoryRepository _categoryRepository;
        public CategoryManagerService(ICategoryRepository categoryRepository,IMapper mapper):base(categoryRepository,mapper)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
