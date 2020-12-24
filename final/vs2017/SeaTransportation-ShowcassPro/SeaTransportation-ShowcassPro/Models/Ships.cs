using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeaTransportation_ShowcassPro.Models
{
    [MetadataType(typeof(ShipMetadata))]
    public partial class Ship
    {
    }
    public class ShipMetadata
    {
        [Required]
        public Nullable<int> maxWeight { get; set; }
        public Boolean availability { get; set; }
        //public virtual Order Order { get; set; }
    }
}