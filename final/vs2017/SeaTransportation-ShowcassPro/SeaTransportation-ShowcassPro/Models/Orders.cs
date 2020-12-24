using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeaTransportation_ShowcassPro.Models
{
    [MetadataType(typeof(OderMetadata))]
    public partial class Order
    {
    }

    public class OderMetadata
    {
        public int OrderID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int PhoneNumber { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [DataType(DataType.CreditCard)]
        public string SecurityCode { get; set; }
        public int TotalDistance { get; set; }
        public int ContainersNumber { get; set; }
        public int Weight { get; set; }
        public int TotalPrice { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int ShipID { get; set; }
        public int ID { get; set; }

        public virtual User User { get; set; }
        public virtual Ship Ship { get; set; }

        public float calcuateTotalDistance()
        {

            return this.TotalDistance;
        }
    }
    public enum Places
    {
        Abbeville_france ,
        Belfort_france,
        Bonifacio_france,
        Bordeaux_france,
        Boulogne_france,
        Bourges_france,
        Brest_france,
        Albert_india , 
        Alewadi ,
        Allepey ,
        Belekeri  ,
        Bhavnagar,
        Bhusawal,
        Bombay
    }
}