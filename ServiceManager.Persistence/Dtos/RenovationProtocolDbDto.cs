﻿using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RenovationProtocolDbDto : ProtocolDbDto
    {

        public List<string> PartsReplaced { get; set; }
       
    }
}