using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WsCRM.Models
{
    public enum Status { 无效, 有效, 删除 }
    public enum MarketingWay { 福步, 百度, 朋友介绍, 其它 }

    public class Order
    {

        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "域名")]
        public string Domain { get; set; }

        [Required]
        public string QQ { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "下单日期")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "订单状态")]
        public Status OrderStatus { get; set; }

        [Display(Name = "客户来源")]
        public MarketingWay MarketingWay { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "订单价格"), Required]
        public decimal Total { get; set; }

        [Display(Name = "客户来源")]
        public string Description { get; set; }


        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}