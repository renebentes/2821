using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Products.CreateProduct;

public record CreateProductInput
{
    [Required(ErrorMessage = "Categoria é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "O Id da categoria é inválido")]
    public int CategoryId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço é obrigatório")]
    [DataType(DataType.Currency)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Título é obrigatório")]
    [MaxLength(150, ErrorMessage = "Título deve ter no máximo 150 caracteres")]
    [MinLength(5, ErrorMessage = "Título deve ter no mínimo 5 caracteres")]
    public string Title { get; set; } = string.Empty;
}
