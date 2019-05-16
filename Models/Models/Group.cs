using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Group
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Admin { get; set; }
        [ForeignKey("Admin")]
        public ApplicationUser User { get; set; }

        public List<UserGroups> Users { get; set; }
    }
}
