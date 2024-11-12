using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Response;

public class RatingResponse
{
    public int UserId { get; set; }
    public double Points { get; set; } = 0.0;
}
