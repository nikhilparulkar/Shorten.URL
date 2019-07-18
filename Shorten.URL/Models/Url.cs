using System;
using System.Collections.Generic;

namespace Shorten.URL.Models
{
    public partial class Url
    {
        public long Id { get; set; }
        public string Url1 { get; set; }
        public string HashValue { get; set; }
    }
}
