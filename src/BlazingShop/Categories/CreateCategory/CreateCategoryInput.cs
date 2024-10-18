using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Categories.CreateCategory;

public class CreateCategoryInput
{
    [Required(ErrorMessage = "Título é obrigatório")]
    [MaxLength(50, ErrorMessage = "Título deve ter no máximo 50 caracteres")]
    [MinLength(5, ErrorMessage = "Título deve ter no mínimo 5 caracteres")]
    public string Title { get; set; } = string.Empty;
}
