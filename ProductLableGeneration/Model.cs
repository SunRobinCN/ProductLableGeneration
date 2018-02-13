using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ProductLableGeneration
{
    public class Product
    {
        public string GUID { get; set; }

        public string STWPN { get; set; }

        public string PartNumber { get; set; }

        public string Receiver { get; set; }

        public string NetWeight { get; set; }

        public string GrossWeight { get; set; }

        public string NetWeightUp { get; set; }

        public string GrossWeightUp { get; set; }

        public string NetWeightDown { get; set; }

        public string GrossWeightDown { get; set; }

        public string SupplierCode { get; set; }

        public string Boxes { get; set; }

        public string QuantitySerial { get; set; }

        public string QuantiryUp { get; set; }

        public string QuantityDown { get; set; }

        public string EngineeringChange { get; set; }

        public string SupplierAddress { get; set; }

        public string Description { get; set; }

        public string QuantityForOneContainer { get; set; }

    }

    public class Label
    {
        public Product Product { get; set; }

        public string FixedQuantity { get; set; }

        public string Date { get; set; }

        public string BatchNumber { get; set; }

        public string SerialNumber { get; set; }

        public string TotalAmount { get; set; }

    }

}
