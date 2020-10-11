using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WealthMaxApiClient.Models
{
    public class ReponseObject
    {

        public int Status { get; set; }
        public int CustomerId { get; set; }
        public string[] Warnings { get; set; }
        public string[] Errors { get; set; }
    }
}