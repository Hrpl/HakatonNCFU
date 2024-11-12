using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities;

public class Progress : BaseEntity
{
    public int UserId {  get; set; }
    public int DaysInRow { get; set; }
    public int CountPushUps { get; set; }
    public double KilometersRuns { get; set; }
}
