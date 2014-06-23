using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class GraphMapperUser : ApplicationUser
    {
        [Key]
        public int UserId { get; set; }
        public string GraphMapperUserName { get; set; }
        public virtual ICollection<Map> CreatedMaps { get; set; }
    }
}