using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartupInstitute.Models;

namespace StartupInstitute.ViewModels
{
    public class ViewStudentAttendence
    {
        public SelectList Class { get; set; }
        public StudentAttendence StudentAttendence { get; set; }


    }
}