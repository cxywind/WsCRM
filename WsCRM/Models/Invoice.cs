using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WsCRM.Models
{
    public enum Bank { 企业建行, 中国银行, 建设银行, 工商银行, 农业银行, 邮政储蓄, 招商银行, 支付宝, Paypal }
    public enum PaymentType { 定金, 尾款, 全款 };
    public enum PaymentStatus { 已审核, 未审核, 无效付款, 删除 }

    public class Invoice
    {
        public int InvoiceID { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "已款金额"), Required]
        public decimal PaidMoney { get; set; }

        public PaymentType Type { get; set; }
        public Bank Bank { get; set; }
        public PaymentStatus Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "付款日期")]
        public DateTime PaidDate { get; set; }
    }
}