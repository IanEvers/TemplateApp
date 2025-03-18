using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileConverter.Models.Dto;

namespace FileConverter.Events.Models.Polling
{
    public class Memory
    {
        public IEnumerable<Berry> AllBerries {  get; set; }
    }
}
