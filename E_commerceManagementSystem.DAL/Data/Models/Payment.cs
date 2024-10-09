﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceManagementSystem.DAL.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentIntentId {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public double TotalAmount { get; set; }
       
        public string PaymentMethod { get; set; }
        public string   Status{ get; set; }
        public string Currency { get; set; }  
        public int OrderId { get; set; }          //Foreign Key  // one to one reltion
        public Order Orders { get; set; } // Navigation prop
    }
}
