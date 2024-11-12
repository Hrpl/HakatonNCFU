using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Models;

public class ProgressModel
{
    public int UserId { get; set; }
    public int DaysInRow { get; set; } = 0;
    public int CountPushUps { get; set; } = 0;
    public double KilometersRuns { get; set; } = 0.0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}
