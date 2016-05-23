//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using StartupInstitute.Models;
//using StartupInstitute.Models.DbModels;

//namespace StartupInstitute.Controllers
//{
//    public class AddressController : Controller
//    {
//        private InstituteDbContext db = new InstituteDbContext();

//        public int Create(AddressViewModel address)
//        {
//            int addressId;
//            Address aAddress = new Address();
//            aAddress.NidOrBirthRegNo = address.NidOrBirtgRegNo;
//            aAddress.AddressRefCode = address.Division + address.District + address.Rmo + address.PoliceStation + address.UnionOrWord +
//                                   address.PostOffice + address.Village;
//            aAddress.HoldingBlockSector = address.HoldingBlockSector;
//                try
//                {
//                    db.Addresses.Add(aAddress);
//                    db.SaveChanges();
//                    addressId = GetAddress(aAddress., aAddress.CatagoryId).Id;
//                }
//                catch (Exception)
//                {
//                    addressId = 0;
//                }
//            return addressId;
//        }

//        public Address GetAddress(int addressId)
//        {
//            Address address = db.Addresses.Find(addressId);
//            return address;
//        }

//        public Address GetAddress(string userName, int addressCatagoryId)
//        {
//            Address address = null;
//            try
//            {
//                address = db.Addresses.Where(a => a.UserName == userName && a.CatagoryId == addressCatagoryId)
//                    .FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                address = new Address();
//            }
//            return address;

//        }

//        public List<AddressViewModel> GetAddress(string userName)
//        {
//            List<AddressViewModel> addressList = new List<AddressViewModel>();



//            return addressList;
//        }
//    }
//}