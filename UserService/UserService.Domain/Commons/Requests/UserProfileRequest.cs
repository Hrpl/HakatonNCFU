using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Requests;

public class UserProfileRequest
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string SecondName { get; set; }
    public string Photo { get; set; } = "";
    public string HomeAddress { get; set; }
}
