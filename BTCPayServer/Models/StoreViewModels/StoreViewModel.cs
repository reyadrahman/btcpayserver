﻿using BTCPayServer.Services.Invoices;
using BTCPayServer.Validations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTCPayServer.Models.StoreViewModels
{
    public class StoreViewModel
    {
        class Format
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public StoreViewModel()
        {
            var btcPay = new Format { Name = "BTCPay", Value = "BTCPay" };
            DerivationSchemeFormat = btcPay.Value;
            DerivationSchemeFormats = new SelectList(new Format[]
            {
                btcPay,
                new Format { Name = "Electrum", Value = "Electrum" },
            }, nameof(btcPay.Value), nameof(btcPay.Name), btcPay);
        }
        public string Id { get; set; }
        [Display(Name = "Store Name")]
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string StoreName
        {
            get; set;
        }

        [Url]
        [Display(Name = "Store Website")]
        [MaxLength(500)]
        public string StoreWebsite
        {
            get;
            set;
        }

        public string DerivationScheme
        {
            get; set;
        }

        [Display(Name = "Derivation Scheme format")]
        public string DerivationSchemeFormat
        {
            get;
            set;
        }

        public SelectList DerivationSchemeFormats { get; set; }

        [Display(Name = "Payment invalid if transactions fails to confirm after ... minutes")]
        [Range(10, 60 * 24 * 31)]
        public int MonitoringExpiration
        {
            get;
            set;
        }

        [Display(Name = "Consider the invoice confirmed when the payment transaction...")]
        public SpeedPolicy SpeedPolicy
        {
            get; set;
        }

        [Display(Name = "Add network fee to invoice (vary with mining fees)")]
        public bool NetworkFee
        {
            get; set;
        }

        public List<(string KeyPath, string Address)> AddressSamples
        {
            get; set;
        } = new List<(string KeyPath, string Address)>();

        public string StatusMessage
        {
            get; set;
        }
    }
}
