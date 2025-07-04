using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Categories
{
   public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category { Id = Guid.NewGuid(), Name = request.name };
            await _categoryRepository.CreateAsync(category);
            return category.Id;
        }
    }
}
