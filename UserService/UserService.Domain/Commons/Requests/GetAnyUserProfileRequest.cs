﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Requests;

public class GetAnyUserProfileRequest
{
    public string Email { get; set; }
}
