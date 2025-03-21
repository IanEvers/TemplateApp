﻿using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileConverter.Models.Dto;

namespace FileConverter.Events.Models.Payload
{
    public class PollingResponse
    {
        [Display("New berries")]
        public IEnumerable<Berry> NewBerries { get; set; }
    }
}
