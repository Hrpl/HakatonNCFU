using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities;

public class Advance : BaseEntity
{
    public int UserId { get; set; }
    public bool TenKilometers { get; set; }
    public bool OneHundredKilometers { get; set; }
    public bool OneHundredPushUp { get; set; }
    public bool ThousandPushUp { get; set; }
}
