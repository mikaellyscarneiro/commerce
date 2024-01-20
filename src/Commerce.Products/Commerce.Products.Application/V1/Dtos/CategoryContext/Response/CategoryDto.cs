﻿using Commerce.Products.Domain.Models;

namespace Commerce.Products.Application.V1.Dtos.CategoryContext.Response
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public CategoryDto(Guid id, string name, DateTimeOffset createdAt, DateTimeOffset? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static CategoryDto? Convert(Category? category)
        {
            if (category == null)
                return null;

            var dto = new CategoryDto(category.Id,
                category.Name,
                category.CreatedAt,
                category.UpdatedAt);

            return dto;
        }
    }
}
