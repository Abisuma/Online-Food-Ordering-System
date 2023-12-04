using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Order
{
    public class OrderDTO : BaseOrderDTO,IBaseDTO
    {
        public int Id { get; set; } 
    }
}
