using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Products.CreateProduct;

public class CreateProductInput
{
    [Required(ErrorMessage = "Categoria é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "Informe um Id da Categoria maior que 1")]
    public int CategoryId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço é obrigatório")]
    [DataType(DataType.Currency)]
    [Range(0, 9_999.99, ErrorMessage = "Preço deve estar entre 0 e 9.999,00")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Título é obrigatório")]
    [MaxLength(150, ErrorMessage = "Título deve ter no máximo 150 caracteres")]
    [MinLength(5, ErrorMessage = "Título deve ter no mínimo 5 caracteres")]
    public string Title { get; set; } = string.Empty;
}
