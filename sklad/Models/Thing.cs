using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sklad.Models
{
    public class Thing
    {
        // identifier
        public int Id { get; set; }
        // property/product name
        public string Name { get; set; }
        // serial or factory nnumber
        public string SerialNumber { get; set; }
        // product/property produce date or income date
        public DateTime ProduceDate { get; set; }
        // inventory number for fixed asset
        public int InventoryNumb { get; set; }
        // measurement unit
        public MeasurementUnits MeasureUnit { get; set; }
        // amount of property/product given to save
        public int Quantity { get; set; }
        // organisation/plase/internal unit/person/internal document
        // from where/whom product/property has arrived
        public string FromWhere { get; set; }
        // document number confirming arrival
        public string DocNumber { get; set; }
        // document date
        public DateTime DocDate { get; set; }
        // document type
        public DocumentTypes DocType { get; set; }
        // product form with list of all component parts of the product/property
        public string Form { get; set; }
        // product/property type
        public PropertyTypes ProdType { get; set; }
        // for which work product/property was bought
        public string WorkName { get; set; }
        // product/property where the product/property was included
        public int? ParentThingId { get; set; }

        [ForeignKey("ParentThingId")]
        public Thing ParentThing { get; set; }

        public Thing()
        {
            ParentThingId = null;
        }
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
        Mous,
        Printer,
        Scanner,
        Other
    }
}