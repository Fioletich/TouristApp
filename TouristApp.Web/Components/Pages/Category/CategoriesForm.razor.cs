using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.Categories.Commands.CreateCategory;
using TouristApp.Application.RequestAndHandler.Categories.Commands.DeleteCategory;
using TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;
using TouristApp.Application.RequestAndHandler.Categories.Queries.GetAllCategories;
using TouristApp.Application.RequestAndHandler.Categories.Queries.GetCategory;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Web.Components.Pages.Category;

public partial class CategoriesForm : ComponentBase {
    private CategoryDTO _category = new CategoryDTO
    {
        Description = string.Empty,
        Name = string.Empty
    };
    private IEnumerable<CategoryDTO> _categories = null!;
    private bool _isLoaded;
    private bool _isCategorySelected;

    async protected override Task OnInitializedAsync() {
        _categories = (await Mediator.Send(new GetAllCategoriesRequest()))
            .Select(c => Mapper.Map<CategoryDTO>(c));
        
        _isLoaded = true;
    }

    private Task CategorySelected() {
        if (_category.Id != Guid.Empty)
        {
            _isCategorySelected = true;

            return Task.CompletedTask;
        }

        _isCategorySelected = false;

        return Task.CompletedTask;
    }

    private async Task CreateCategory() {
        if (_category.Name != string.Empty && _category.Description != string.Empty)
        {
            await Mediator.Send(new CreateCategoryRequest(_category.Name, _category.Description));

            _category.Name = string.Empty;
            _category.Description = string.Empty;
        }
    }

    private async Task UpdateCategory() {
        if (_category.Name != string.Empty &&
            _category.Description != string.Empty &&
            _category.Id != Guid.Empty)
        {
            await Mediator.Send(new UpdateCategoryRequest(_category.Id, _category.Name, _category.Description));

            _category.Name = string.Empty;
            _category.Description = string.Empty;
        }
    }

    private async Task CheckCategory() {
        if (_category.Id != Guid.Empty)
        {
            var category = await Mediator.Send(new GetCategoryRequest(_category.Id));

            if (category != null)
            {
                _category.Name = category.Name;
                _category.Description = category.Description;
            }

            return;
        }
        
        _category.Name = string.Empty;
        _category.Description = string.Empty;
    }

    private async Task DeleteCategory() {
        if (_category.Id != Guid.Empty)
        {
            await Mediator.Send(new DeleteCategoryRequest(_category.Id));
        }
    }
}