using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class LopHoc
    {
        [Key]
        public int CID { get; set; }
        public string cName { get; set; }
        public bool cStatus { get; set; }
    }
}