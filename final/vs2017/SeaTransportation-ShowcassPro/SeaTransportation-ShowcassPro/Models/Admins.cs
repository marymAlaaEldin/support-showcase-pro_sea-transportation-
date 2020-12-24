using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeaTransportation_ShowcassPro.Models
{
    [MetadataType(typeof(AdminMetadata))]
    public partial class Admin
    {
    }
    public class AdminMetadata
    {
        [Required]
        public string AdminName { get; set; }
        [Required]
        public string AdminPassword { get; set; }
    }
    public static class Adminloggedin
    {

        public static string AdminName { get; set; }
        public static string AdminPassword { get; set; }
    }
}