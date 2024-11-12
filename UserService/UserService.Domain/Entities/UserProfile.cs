using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities;

public class UserProfile : BaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string SecondName { get; set; }
}
