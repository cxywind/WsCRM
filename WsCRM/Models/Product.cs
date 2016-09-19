using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WsCRM.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name = "产品名称"), Required]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "产品价格"), Required]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "续费价格"), Required]
        public decimal RenewPrice { get; set; }
    }
}