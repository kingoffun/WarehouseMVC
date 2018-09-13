using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sklad.Models
{
    public class Thing
    {
        // identifier
        public int Id { get; set; }
        //accounting account
        public int Account { get; set; }
        // property/product name
        public string Name { get; set; }
        // product/property produce/buy/incom date
        [Display(Name = "Produce date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime ProduceDate { get; set; }
        // serial or factory nnumber
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }
        // product form/passport with list of all component parts of the product/property
        [Display(Name = "Form number")]
        public string PassportNumber { get; set; }
        // inventory number for fixed asset
        [Display(Name = "Inventory number")]
        public int InventoryNumb { get; set; }
        // measurement unit
        [Display(Name = "Measure unit")]
        public MeasurementUnits MeasureUnit { get; set; }
        // amount of property/product given to save
        public int Quantity { get; set; }
        //product price
        public int Price { get; set; }
        // organisation/plase/internal unit/person/internal document
        // from where/whom product/property has arrived
        [Display(Name = "From where")]
        public string FromWhere { get; set; }
        // document number confirming arrival
        [Display(Name = "Document number")]
        public string DocNumber { get; set; }
        // document date
        [Display(Name = "Document date")]
        public DateTime DocDate { get; set; }
        // document type
        [Display(Name = "Document type")]
        public DocumentTypes DocType { get; set; }
        // product/property type
        [Display(Name = "Product type")]
        public PropertyTypes ProdType { get; set; }
        // for which work product/property was bought
        [Display(Name = "Work name")]
        public string WorkName { get; set; }
        // product/property where the product/property was included
        //[Display(Name = "Main thing")]
        //public int? ParentThingId { get; set; }

        //[ForeignKey("ParentThingId")]
        //public Thing ParentThing { get; set; }
        public virtual ICollection<Thing> Includes { get; set; }

        [NotMapped]
        public ICollection<string> SelIncludes { get; set; }

        public Thing()
        {
            Includes = new HashSet<Thing>();
        }

        //public void IncludesSelection()
        //{

        //}
    }

    public enum MeasurementUnits
    {
        Shtuky = 1,
        Komplekt,
        Metr,
        Kilogram
    }

    public enum DocumentTypes
    {
        Invoice = 1,
        AktZminyYakStanu,
        AktPryiomuPeredachi
    }

    public enum PropertyTypes
    {
        Computer = 1,
        Display,
        HDD,
        SSD,
        VideoCard,
        Keyboard,
        Mouse,
        Printer,
        Scanner,
        Other
    }
}