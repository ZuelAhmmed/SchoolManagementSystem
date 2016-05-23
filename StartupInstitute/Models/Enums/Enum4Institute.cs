using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartupInstitute.Models.Enums
{
    public enum Enum4Institute
    {
        // Institute Catagory By Exma or Degree
        JuniorSecondary = 12,
        Secondary = 13,
        SchoolAndCollege = 30,
        TechnicalOrVocational = 99,

        // Institute Catagory By Management
        Government = 1,
        NonGovernment = 2,

        // Institute Catagory By Student Management
        BoysInstitute = 1,
        GirlsInstitute = 2,
        CommonAndCommon = 3,
        CommonButSeperate = 4,

        // Institute Catagory By Authorization
        Authorized = 1,
        Approved = 2,
        GovernmentAuth = 3

    }
}