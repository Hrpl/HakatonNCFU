using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Response;

public class AdvanseResponse
{
    public bool TenKilometers { get; set; } = false;
    public bool OneHundredKilometers { get; set; } = false;
    public bool OneHundredPushUp { get; set; } = false;
    public bool ThousandPushUp { get; set; } = false;
}
