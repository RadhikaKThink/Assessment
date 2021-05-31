using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entites
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserID { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int UpdatedUserID { get; set; }
    }
}
