using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartupInstitute.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string TrackingId { get; set; }
        public string TrackingRef { get; set; }
        public byte[] ImageFile { get; set; }
    }
}