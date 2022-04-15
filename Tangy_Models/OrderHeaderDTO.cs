﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class OrderHeaderDTO
    {

        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Итого в заказе")]
        public double OrderTotal { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ShippingDate { get; set; }
        [Required]
        public string Status { get; set; }

        //stripe payment
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Телефон")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Улица")]
        [Required]
        public string StreetAddress { get; set; }

        [Display(Name = "Область")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Город")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Индекс")]
        [Required]
        public string PostalCode { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        public string? Tracking { get; set; }
        public string? Carrier { get; set; }
    }
}
