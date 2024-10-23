using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductLog
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public string Action { get; set; } // "Created", "Updated", "Deleted"
        public DateTime Timestamp { get; set; } // Thời gian thực hiện thay đổi
        public string Changes { get; set; } // Ghi c
    }
}
