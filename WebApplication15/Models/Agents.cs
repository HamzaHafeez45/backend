using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Agents
    {
        public int agentId { get; set; }
        public string name { get; set; }
        public string agentType { get; set; }
        public string agentCnic { get; set; }
        public string agentAddress { get; set; }
        public string agentSalary { get; set; }
        public string agentPhone { get; set; }
        public DateTime DOJ { get; set; }
        public string IEMI { get; set; }
    }
}