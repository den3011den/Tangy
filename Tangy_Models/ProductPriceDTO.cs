using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class ProductPriceDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Выберите продукт")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Выберите размер")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Цена обязательна")]
        [Range(1, int.MaxValue, ErrorMessage = "Цена должна быть больше 1")]
        public double Price { get; set; }
    }
}
