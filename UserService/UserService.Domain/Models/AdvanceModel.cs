using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Models;

public class AdvanceModel
{
    public int UserId { get; set; }
    public bool TenKilometers { get; set; } = false;
    public bool OneHundredKilometers { get; set; } = false;
    public bool OneHundredPushUp { get; set; } = false;
    public bool ThousandPushUp { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}
