using SSG.Data;
using SSGMVC.Helper;
using SSGMVC.Interface;
using SSGMVC.Models;
using SSGMVC.Provider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SSGMVC.Controllers
{
    public class HomeController : Controller
    {
        //CommonFunctions objCommonFunction = new CommonFunctions();
        //JavaScriptSerializer js = new JavaScriptSerializer();
        ISSGMVCF objprovider = new SSGMVCF();
        IMemberOpen objMember = new MemberOpenOperationcs();
        SqlCommand cmd; SqlCommand cmd1;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult SuperAdminsignIn()
        {

            return View();
        }

        public ActionResult EmployeeRegistration()
        {


            return View();
        }

        public ActionResult MemberDetail()
        {
            return View();
        }

        public ActionResult MemberRegistration()
        {

            return View();
        }
        public ActionResult TabForm()
        {

            return View();
        }
        public ActionResult MembershipOpen()
        {

            return View();
        }
        public ActionResult MemberOpeningBalance()
        {

            return View();
        }



        public ActionResult logout()
        {


            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult insertRegionalOfficeMaster(sp_select_RegionalOfficebySnoResult ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.InsertIntoRegionalMaster(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InsertIntoZonalOfficeMaster(sp_select_ZonalOfficebySnoResult ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.InsertIntoZonalMaster(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertIntoBranchMaster(InsertBranch ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.InsertIntoBrachMaster(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertIntoofficeBranchMaster(sp_select_OfficeBranchbySnoResult ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.InsertIntoofficeBranchMaster(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopulateDropDownList(string prefixText)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();

            if (prefixText == null)
            {
                prefixText = "0";
            }
            returndbml<sp_GetDistIdDistNamefromDistrictbyStateIdResult> objResult = new returndbml<sp_GetDistIdDistNamefromDistrictbyStateIdResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.PopulateDropDownList(prefixText);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;

            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillDropdownListGender()
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_select_Gander_Master_TBResult> objResult = new returndbml<sp_select_Gander_Master_TBResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillDropdownListGender();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FillDropdownListDepartment()
        {

            returndbml<FILLDepartmentComboResult> objResult = new returndbml<FILLDepartmentComboResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillDropdownListDepartment();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillEmpDesinnation(string prefixText)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<FILLEmpDesignationComboResult> objResult = new returndbml<FILLEmpDesignationComboResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillEmpDesinnation(prefixText);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;

            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult FillOfficeBranch(string prefixText)
        {

            returndbml<FILLOfficeBranchComboResult> objResult = new returndbml<FILLOfficeBranchComboResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillOfficeBranch(prefixText);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult FillDropdownListState()
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_select_StatesResult> objResult = new returndbml<sp_select_StatesResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillDropdownListState();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillDropdownListUnderEmployee(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_GetUnderEmployeebycompIdStateIdResult> objResult = new returndbml<sp_GetUnderEmployeebycompIdStateIdResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillDropdownListUnderEmployee(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillDropdownListUserType(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_GetUserTypebycompIdStateIdResult> objResult = new returndbml<sp_GetUserTypebycompIdStateIdResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.FillDropdownListUserType(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMaxVNo(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_GetMaxVNofromEmployeeRegistrationbycompidBranchIDResult> objResult = new returndbml<sp_GetMaxVNofromEmployeeRegistrationbycompidBranchIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetMaxVNo(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetEmployeeDetail(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            RootEmployeeDetail objResult = new RootEmployeeDetail();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetEmployeeDetail(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult getbyID(string Srno)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_GetEmployeeDetailbySrnoResult> objResult = new returndbml<sp_GetEmployeeDetailbySrnoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetEmployeeDetailbySrno(Srno);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InsertIntoDatabase(InsertEmployee ObjList)
        {
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.InsertEmployeeDetail(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }



        //[HttpPost]
        //public ActionResult CheckLoginPassword(string UserName, string Password)
        //{

        //    string Action = "";


        //    //if (Session["UserId"] == null)
        //    //{
        //    //    return RedirectToAction("Login1", "Home");
        //    //}
        //    //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
        //    returndbml<sp_GetloginpasswordResult> objResult = new returndbml<sp_GetloginpasswordResult>();
        //    List<FormLogin> objDept = new List<FormLogin>();
        //    int intStatusId = 99;
        //    string strStatus = "Unhandled error";
        //    try
        //    {

        //        objResult = objprovider.CheckLoginPassword(UserName, Password);
        //        strStatus = objResult.Status;
        //        intStatusId = objResult.StatusId;

        //        Session["UserName"] = objResult.returndbmllist[0].UserName;
        //        Session["Usertype1"] = objResult.returndbmllist[0].UserType;
        //        Session["Id"] = objResult.returndbmllist[0].Id;
        //        Session["UserId"] = objResult.returndbmllist[0].UserName;
        //        Session["Name"] = objResult.returndbmllist[0].Name;
        //        Session["MobileNo"] = objResult.returndbmllist[0].MobileNo;
        //        // Session["UserType1"] = objResult.returndbmllist[0].UserType1;
        //        Session["CompId"] = objResult.returndbmllist[0].compid;
        //        Session["EmpBranchId"] = objResult.returndbmllist[0].BranchID;
        //        Session["BranchId"] = objResult.returndbmllist[0].BranchID;
        //        Session["Fyid"] = objResult.returndbmllist[0].compid;
        //        Session["CompanyName"] = objResult.returndbmllist[0].CompanyName1;
        //        Session["Logo"] = objResult.returndbmllist[0].Logo;
        //        Session["EmpID"] = objResult.returndbmllist[0].Sno;
        //        Session["CheckDayCloseStatus"] = objResult.returndbmllist[0].CheckDayCloseStatus;


        //        if (objResult.returndbmllist[0].LocStateID == null)
        //        {
        //            Session["LocStateID"] = "0";
        //        }
        //        else
        //        {
        //            Session["LocStateID"] = objResult.returndbmllist[0].LocStateID;
        //        }
        //        if (objResult.returndbmllist[0].LocCityID == null)
        //        {
        //            Session["LocCityID"] = "0";
        //        }
        //        else
        //        {
        //            Session["LocCityID"] = objResult.returndbmllist[0].LocCityID;
        //        }
        //        // Action= objResult.returndbmllist[0].UserType1;


        //        if (objResult.returndbmllist[0].UserType1 == "User" || objResult.returndbmllist[0].UserType1 == "Admin" || objResult.returndbmllist[0].UserType1 == "Supervisor" || objResult.returndbmllist[0].UserType1 == "Manager" || objResult.returndbmllist[0].UserType1 == "Collection Agent")
        //        {
        //            Action = "DashBoard";
        //            intStatusId = 1;
        //        }
        //        else
        //        { 
        //            if (objResult.returndbmllist[0].UserType1 == "SuperAdmin")
        //            {

        //                Action = "Index";
        //                intStatusId = 2;
        //            }
        //        }

        //        for (int i = 0; i < objResult.returndbmllist.Count; i++)
        //        {
        //            objDept.Add(new FormLogin
        //            {

        //                RedirectPage = Action

        //            });
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        strStatus = ex.Message + " " + ex.StackTrace;
        //    }
        //    return Json(new { StatusId = intStatusId, Status = strStatus, Result = objDept }, JsonRequestBehavior.AllowGet);

        //}
        //kunal 07/09/2024

        [HttpPost]
        public ActionResult CheckLoginPassword(string UserName, string Password)
        {
            string Action = "";
            returndbml<sp_GetloginpasswordResult> objResult = null;  // Initialize to null
            List<FormLogin> objDept = new List<FormLogin>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";

            try
            {
                // Log the input parameters to see what's being passed
                Console.WriteLine("CheckLoginPassword called with Username: " + UserName + " and Password: " + Password);

                // Attempt to get login result from the provider
                objResult = objprovider.CheckLoginPassword(UserName, Password);

                // Log the result to see if it's null
                if (objResult == null)
                {
                    Console.WriteLine("objResult is null");
                    strStatus = "Login failed: Invalid credentials.";
                    intStatusId = 0;
                }
                else if (objResult.returndbmllist == null || objResult.returndbmllist.Count == 0)
                {
                    // Log if returndbmllist is null or empty
                    Console.WriteLine("objResult.returndbmllist is null or empty");
                    strStatus = "Login failed: No user found.";
                    intStatusId = 0;
                }
                else
                {
                    // At this point, objResult and objResult.returndbmllist are not null
                    var userInfo = objResult.returndbmllist[0];

                    // Log if userInfo is null
                    if (userInfo == null)
                    {
                        Console.WriteLine("userInfo is null");
                        strStatus = "Login failed: User information is null.";
                        intStatusId = 0;
                    }
                    else
                    {
                        // Set session variables
                        Session["UserName"] = userInfo.UserName;
                        Session["Usertype1"] = userInfo.UserType;
                        Session["Id"] = userInfo.Id;
                        Session["UserId"] = userInfo.UserName;
                        Session["Name"] = userInfo.Name;
                        Session["MobileNo"] = userInfo.MobileNo;
                        Session["CompId"] = userInfo.compid;
                        Session["EmpBranchId"] = userInfo.BranchID;
                        Session["BranchId"] = userInfo.BranchID;
                        Session["Fyid"] = userInfo.compid;
                        Session["CompanyName"] = userInfo.CompanyName1;
                        Session["Logo"] = userInfo.Logo;
                        Session["EmpID"] = userInfo.Sno;
                        Session["CheckDayCloseStatus"] = userInfo.CheckDayCloseStatus;

                        // Handle null values for LocStateID and LocCityID
                        Session["LocStateID"] = userInfo.LocStateID ?? "0";
                        Session["LocCityID"] = userInfo.LocCityID ?? "0";

                        // Determine the action based on UserType
                        if (userInfo.UserType1 == "User" || userInfo.UserType1 == "Admin" || userInfo.UserType1 == "Supervisor" || userInfo.UserType1 == "Manager" || userInfo.UserType1 == "Collection Agent")
                        {
                            Action = "DashBoard";
                            intStatusId = 1;
                        }
                        else if (userInfo.UserType1 == "SuperAdmin")
                        {
                            Action = "Index";
                            intStatusId = 2;
                        }

                        // Add the action to the objDept list for return
                        objDept.Add(new FormLogin
                        {
                            RedirectPage = Action
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception message and stack trace
                Console.WriteLine("Error: " + ex.Message + " " + ex.StackTrace);
                strStatus = "Error: " + ex.Message;
            }

            // Return the result as JSON
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objDept }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult subGroupMaster()
        {

            return View();
        }

        public ActionResult selectIDsubgroup()
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            var obj = objprovider.selectIDsubgroup();
            foreach (selectIDsubgroupResult ob in obj.returndbmllist.ToList())
            {
                SelectListItem objselect = new SelectListItem();
                objselect.Value = ob.ID.ToString();
                objselect.Text = ob.SubGroupName;
                SubBranchName.Add(objselect);
            };
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetSubgroups(string CompID, string BranchId)
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            var obj = objprovider.GetSubgroups(CompID, BranchId);
            foreach (selectIDsubgroupResult ob in obj.returndbmllist.ToList())
            {
                SelectListItem objselect = new SelectListItem();
                objselect.Value = ob.ID.ToString();
                objselect.Text = ob.SubGroupName;
                SubBranchName.Add(objselect);
            };
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetAllLedgerAoutoComplete(string prefixText, string CompID, string BranchId)
        {
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            var obj = objprovider.GetAllLedgerAoutoComplete(prefixText, CompID, BranchId);
            foreach (GetLedgerDetailbySnoResult ob in obj.returndbmllist.ToList())
            {
                SelectListItem objselect = new SelectListItem();
                objselect.Value = ob.AccNo.ToString();
                objselect.Text = ob.LdName.ToString();
                SubBranchName.Add(objselect);
            };
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult insertSubGroupMaster(GetSubGroupDetailbySnoResult ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.insertSubGroupMaster(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubGroupDetail(string prefixText, string CompID, string BranchId)
        {

            returndbml<GetSubGroupDetailbySnoResult> objResult = new returndbml<GetSubGroupDetailbySnoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetSubGroupDetail(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckDublicateSubGroupName(string SubGroupName, string CompID, string BranchId)
        {
            returndbml<CheckDublicateSubGroupNameResult> objResult = new returndbml<CheckDublicateSubGroupNameResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.CheckDublicateSubGroupName(SubGroupName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult selectSubgroupNature(string SubGroupName)
        {
            returndbml<selectSubgroupNatureResult> objResult = new returndbml<selectSubgroupNatureResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.selectSubgroupNature(SubGroupName);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult selectSubgroupNatureBySubgroupID(string SubGroupName)
        {
            returndbml<selectSubgroupNatureResult> objResult = new returndbml<selectSubgroupNatureResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.selectSubgroupNatureBySubgroupID(SubGroupName);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckDublicateSubGroupPrefix(string GroupPrefix, string CompID, string BranchId)
        {

            returndbml<CheckDublicateSubGroupPrefixResult> objResult = new returndbml<CheckDublicateSubGroupPrefixResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.CheckDublicateSubGroupPrefix(GroupPrefix, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult CheckDublicateUserName(string UserName, string CompID, string BranchId)
        {
            returndbml<CheckDublicateSubGroupNameResult> objResult = new returndbml<CheckDublicateSubGroupNameResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.CheckDublicateUserName(UserName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CheckDublicateEmpMobileNo(string MobileNo, string CompID, string BranchId)
        {
            returndbml<CheckDublicateSubGroupNameResult> objResult = new returndbml<CheckDublicateSubGroupNameResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.CheckDublicateEmpMobileNo(MobileNo, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LedgerCreation()
        {

            return View();
        }


        #region MemberOpen
        public ActionResult MemberOpen()
        {


            return View();
        }




        public ActionResult InsertLedger(InsertMemberRegistration objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLedger(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetMaxVNoMemberOpen(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetMaxSNIdMemberOpenResult> objResult = new returndbml<GetMaxSNIdMemberOpenResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoMemberOpen(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetMemberAccIntrestRate(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetMemberACCIntrestRateResult> objResult = new returndbml<GetMemberACCIntrestRateResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberAccIntrestRate(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SP_SelectLedgerByLdName(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<SP_SelectLedgerByLdNameResult> objResult = new returndbml<SP_SelectLedgerByLdNameResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SP_SelectLedgerByLdName(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetPosting(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetPostingResult> objResult = new returndbml<GetPostingResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPosting(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetRelation(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetRelationResult> objResult = new returndbml<GetRelationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetRelation(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SelectCategory(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<SelectCategoryResult> objResult = new returndbml<SelectCategoryResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectCategory(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CheckLoginPasswordNew(string UserName, string Password)
        {

            returndbml<sp_GetloginpasswordResult> objResult = new returndbml<sp_GetloginpasswordResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckLoginPasswordNew(UserName, Password);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SelectEducatioin(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<SP_SelectEducatioinResult> objResult = new returndbml<SP_SelectEducatioinResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectEducatioin(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SelectOccupation(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<SelectOccupationResult> objResult = new returndbml<SelectOccupationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectOccupation(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SelectDesgnation(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectDesgnation(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SelectAjent(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<SelectAjentResult> objResult = new returndbml<SelectAjentResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectAjent(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SelectState(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_select_StatesResult> objResult = new returndbml<sp_select_StatesResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectState(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetLedgerDetail(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetLedgerDetailbySnoResult> objResult = new returndbml<GetLedgerDetailbySnoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerDetail(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetNonMemberLedgerDetail(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetLedgerDetailbySnoResult> objResult = new returndbml<GetLedgerDetailbySnoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetNonMemberLedgerDetail(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAllBranchID(string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetLedgerDetailbySnoResult> objResult = new returndbml<GetLedgerDetailbySnoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetAllBranchID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAllBranchIDForOpening(string CompID, string BranchId, string FyId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetLedgerDetailbySnoResult> objResult = new returndbml<GetLedgerDetailbySnoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetAllBranchIDForOpening(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckDublicateLedger(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<CheckDublicateLedgerResult> objResult = new returndbml<CheckDublicateLedgerResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckDublicateLedger(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckDublicateMemberMaxNo(string prefixText, string CompID, string BranchId)
        {

            returndbml<CheckDublicateMemberNoResult> objResult = new returndbml<CheckDublicateMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckDublicateMemberNo(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult fetchLedgerId(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<fetchLedgerIdResult> objResult = new returndbml<fetchLedgerIdResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.fetchLedgerId(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult FetchClosingBalance(string CompID, string LedgerId, string FyId, string amt, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<Department> objResult = new returndbml<Department>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FetchClosingBalance(CompID, LedgerId, FyId, amt, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FetchClosingBalanceNonMember(string CompID, string LedgerId, string FyId, string amt, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<Department> objResult = new returndbml<Department>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FetchClosingBalanceNonMember(CompID, LedgerId, FyId, amt, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FetchClosingBalanceDateBetween(string CompID, string LedgerId, string FyId, string amt, string BranchId, string FromDate, string ToDate)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<Department> objResult = new returndbml<Department>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FetchClosingBalanceDateBetween(CompID, LedgerId, FyId, amt, BranchId, FromDate, ToDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetLedgerMemberShipDetail(string prefixText, string CompID, string BranchId)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerMemberShipDetail(prefixText, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetNextMemberID(string Prefix, string CompID, string BranchId, string FyID)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetNextMemberID(Prefix, CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        //public ActionResult InsertMemberDetail(string MemberNo, string MaxVNo, string NextNo, string MemberID, string OpeningDate, string AccCategoryID,
        //  string AgentID, string IntroducerNo, string IntroducerName, string FirstName, string LastName, string FHName, string Email, string DOB, string Gender,
        //  string CategoryID, string EducationID, string OccupationID, string PANNo, string AdharNo, string EmpID, string PresentState, string PresentDistrict, string PresentAddress,
        //  string PresentMobile, string ParmanantState, string ParmanantDistrict, string ParmanantAddress, string ParmanantMobile, string DesignationID, string PostingID, string RelativeName,
        //  string JoiningDate, string RetirementDate, string RelationID, int NoofShare, string ShareAmt, string ShareTotal, string CompulsoryCBXValue, string CompulsoryOPAmt,
        //  string ShavingOpeningAmt, string GrandTotalAmt, string CustomerBankName, string BankACNo, string BranchName, string IFSC, string NomineeName, string NomineeRelationID, string NomineeDOB,
        //  string TransTypeID, string TransTypeText, string DetucteeBankID, string DetucteeBankText, string NomineeBankName, string NomineeBranch, string ChequeNo, string CompId,
        //  string BranchId, string Fyid, string UserId, string UId, string AppTransNo, int TblRowNo, string GetTblChargesType, string GetTblChargesAmt, string GetTblChargesLedID, string MemberPhoto,
        //  string MemberSignature, string ShavingIntrest, string CoumpolseryIntrest, string TotalTblCharges, string ChargesClosingBal, string ChargesClosingNature, string TblRowCount)
        //{
        //    //if (Session["UserId"] == null)
        //    //{
        //    //    return RedirectToAction("Login1", "Home");
        //    //}
        //    //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
        //    List<FormSubmision> objResult = new List<FormSubmision>();
        //    int intStatusId = 99;
        //    string strStatus = "Unhandled error";
        //    try
        //    {
        //        objResult = objMember.InsertMemberDetail(MemberNo, MaxVNo, NextNo, MemberID, OpeningDate, AccCategoryID,
        //   AgentID, IntroducerNo, IntroducerName, FirstName, LastName, FHName, Email, DOB, Gender,
        //   CategoryID, EducationID, OccupationID, PANNo, AdharNo, EmpID, PresentState, PresentDistrict, PresentAddress,
        //   PresentMobile, ParmanantState, ParmanantDistrict, ParmanantAddress, ParmanantMobile, DesignationID, PostingID, RelativeName,
        //   JoiningDate, RetirementDate, RelationID, NoofShare, ShareAmt, ShareTotal, CompulsoryCBXValue, CompulsoryOPAmt,
        //   ShavingOpeningAmt, GrandTotalAmt, CustomerBankName, BankACNo, BranchName, IFSC, NomineeName, NomineeRelationID, NomineeDOB,
        //   TransTypeID, TransTypeText, DetucteeBankID, DetucteeBankText, NomineeBankName, NomineeBranch, ChequeNo, CompId,
        //   BranchId, Fyid, UserId, UId, AppTransNo, TblRowNo, GetTblChargesType, GetTblChargesAmt, GetTblChargesLedID, MemberPhoto,
        //   MemberSignature, ShavingIntrest, CoumpolseryIntrest, TotalTblCharges, ChargesClosingBal, ChargesClosingNature, TblRowCount);

        //        //strStatus = objResult.Status;
        //        // intStatusId = objResult.StatusId;
        //    }
        //    catch (Exception ex)
        //    {
        //        strStatus = ex.Message + " " + ex.StackTrace;
        //    }
        //    return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        //}



        public ActionResult InsertMemberDetail(InsertMemberOpen objlist)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertMemberDetail(objlist);

                //strStatus = objResult.Status;
                // intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult InsertMemberDetailOpeningBal(InsertMemberOpen objlist)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertMemberDetailOpeningBal(objlist);

                //strStatus = objResult.Status;
                // intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ImageUpload(File_Upload model)
        {

            int imgId = 0;
            string ImagePath = "";
            var file = model.ImageFile;
            byte[] imagebyte = null;
            byte[] ImgByte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("../images/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                File_Upload img = new File_Upload();
                img.UniqueID = "";
                img.ImageTitle = file.FileName;
                img.ImageByte = imagebyte;
                img.ImagePath = "../images/" + file.FileName;
                ImagePath = img.ImagePath;
                ImgByte = img.ImageByte;

                //List<File_Upload> objDept = new List<File_Upload>();
                //objDept.Add(new File_Upload
                //{
                //    ImagePath = img.ImagePath,
                //    ImageByte = img.ImageByte,

                //});

            }
            return Json(ImagePath, JsonRequestBehavior.AllowGet);


        }

        public JsonResult UploadSignature(File_Upload model)
        {

            int imgId = 0;
            string ImagePath = "";
            var file = model.ImageFile;
            byte[] imagebyte = null;
            byte[] ImgByte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("/images/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                File_Upload img = new File_Upload();

                img.ImageTitle = file.FileName;
                img.ImageByte = imagebyte;
                img.ImagePath = "/images/" + file.FileName;
                ImagePath = img.ImagePath;
                ImgByte = img.ImageByte;

                //List<File_Upload> objDept = new List<File_Upload>();
                //objDept.Add(new File_Upload
                //{
                //    ImagePath = img.ImagePath,
                //    ImageByte = img.ImageByte,

                //});

            }
            return Json(ImagePath, JsonRequestBehavior.AllowGet);


        }


        #endregion
        #region PlanMaster
        public ActionResult PlanMaster()
        {


            return View();
        }
        #endregion


        public ActionResult FillLedger(string CompID, string BranchId)
        {
            returndbml<SP_SelectNonMemberLedgerResult> objResult = new returndbml<SP_SelectNonMemberLedgerResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectPlaneLedger(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillProduct(string CompID, string BranchId)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectProduct(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillBranchCombo(string CompID, string BranchId, string EmpID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillBranchCombo(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillMemberAccount(string CompID, string BranchId, string EmpID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillMemberAccount(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillLoanTypeUnderLoanAcc(string CompID, string BranchId, string EmpID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillLoanTypeUnderLoanAcc(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }

            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);
            }



        }
        public ActionResult FillRigionalOfficeCombo(string CompID, string BranchId, string EmpID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillRigionalOfficeCombo(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillRigionalOfficeComboForManager(string CompID, string BranchId, string EmpID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillRigionalOfficeComboForManager(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillUnderEmployeebyCombiCode(string CompID, string BranchId, string EmpID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillUnderEmployeebyCombiCode(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult FillUnderBranchbyRO(string CompID, string BranchId, string EmpID, string RegionalID)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillUnderBranchbyRO(CompID, BranchId, EmpID, RegionalID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillFYYearCombo(string CompID, string BranchId)
        {
            returndbml<SP_SelectProductResult> objResult = new returndbml<SP_SelectProductResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillFYYearCombo(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult UpdateSessionBranchIDFyID(string BranchId, string FyID, string BranchName, string FinancialYear, string FyFromDate, string FyToDate)
        {
            returndbml<GetMemberDetail> objResult = new returndbml<GetMemberDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpdateSessionBranchIDFyID(BranchId, FyID, BranchName, FinancialYear, FyFromDate, FyToDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
                Session["BranchId"] = BranchId;
                Session["Fyid"] = FyID;
                Session["BranchName"] = BranchName;
                Session["FinancialYear"] = FinancialYear;
                Session["FyFromDate"] = FyFromDate;
                Session["FyToDate"] = FyToDate;


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult FillPlanScheme(string CompID, string BranchId)
        {
            returndbml<SP_SelectSchemeResult> objResult = new returndbml<SP_SelectSchemeResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SelectPlanScheme(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillIntrestType(string CompID, string BranchId)
        {
            returndbml<SP_SelectSchemeResult> objResult = new returndbml<SP_SelectSchemeResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillIntrestType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult insertPlan(SelectPlaneByPlanIDResult ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.insertPlan(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPlan(string CompID, string BranchId)
        {

            returndbml<SelectAllPlaneResult> objResult = new returndbml<SelectAllPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetAllPlan(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetPlanDetailforUpdate(string PlanID, string CompID, string BranchId)
        {

            returndbml<SelectPlaneByIDResult> objResult = new returndbml<SelectPlaneByIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetPlanDetailforUpdate(PlanID, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult FillAccCategory(string CompID, string BranchId)
        {
            returndbml<FillComboAccCategoryResult> objResult = new returndbml<FillComboAccCategoryResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillComboAccCategory(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillEducation(string CompID, string BranchId)
        {
            returndbml<SP_SelectEducatioinResult> objResult = new returndbml<SP_SelectEducatioinResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillEducation();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillCategory(string CompID, string BranchId)
        {
            returndbml<SelectCategoryResult> objResult = new returndbml<SelectCategoryResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillCategory();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillOccupation(string CompID, string BranchId)
        {
            returndbml<SelectOccupationResult> objResult = new returndbml<SelectOccupationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillOccupation();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillState(string CompID, string BranchId)
        {
            returndbml<sp_select_StatesResult> objResult = new returndbml<sp_select_StatesResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillState();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillDesignation(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillDesignation();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult FillDocsType(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillDocsType();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        //public ActionResult FillFinancialYearCombo(string CompID)
        //{
        //    returndbml<GetFinencialYearResult> objResult = new returndbml<GetFinencialYearResult>();
        //    int intStatusId = 99;
        //    string strStatus = "Unhandled error";
        //    try
        //    {
        //        objResult = objMember.FillFinancialYearCombo(CompID);
        //        strStatus = objResult.Status;
        //        intStatusId = objResult.StatusId;
        //    }
        //    catch (Exception ex)
        //    {
        //        strStatus = ex.Message + " " + ex.StackTrace;
        //    }
        //    return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        //}

        public ActionResult FillFinancialYearCombo(string CompID)
        {
            returndbml<GetFinencialYearResult> objResult = new returndbml<GetFinencialYearResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";

            try
            {
                // Call the service method to get financial years
                objResult = objMember.FillFinancialYearCombo(CompID);

                // Log the result for debugging
                Console.WriteLine("FillFinancialYearCombo Result:");
                Console.WriteLine(JsonConvert.SerializeObject(objResult));

                // Check if result contains data
                if (objResult != null && objResult.returndbmllist != null && objResult.returndbmllist.Any())
                {
                    strStatus = objResult.Status;
                    intStatusId = objResult.StatusId;
                }
                else
                {
                    strStatus = "No financial year data found.";
                    intStatusId = -1;
                    objResult.returndbmllist = new List<GetFinencialYearResult>();
                }
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }

            // Log the JSON result being returned
            Console.WriteLine("Returning JSON:");
            Console.WriteLine(JsonConvert.SerializeObject(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }));

            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);
        }






        public ActionResult FillFinancialYearForFyOpen(string CompID, string BranchId)
        {
            returndbml<GetFinencialYearResult> objResult = new returndbml<GetFinencialYearResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillFinancialYearForFyOpen(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GetFinancialYearDetailByFyID(string CompID, string BranchId, string Fyid)
        {
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFinancialYearDetailByFyID(CompID, BranchId, Fyid);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GetFinancialYearDetailByFyIDBranchID(string CompID, string BranchId, string Fyid)
        {
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFinancialYearDetailByFyIDBranchID(CompID, BranchId, Fyid);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult ProfitandLossForInterestRecieve(string CompID, string BranchId, string Fyid, string FromDate, string Todate)
        {
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.ProfitandLossForInterestRecieve(CompID, BranchId, Fyid, FromDate, Todate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);
            }



        }
        public ActionResult ProfitandLossForInterestIndirect(string CompID, string BranchId, string Fyid, string FromDate, string Todate)
        {
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.ProfitandLossForInterestIndirect(CompID, BranchId, Fyid, FromDate, Todate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }

            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

            }


        }


        public ActionResult ProfitandLossForIncomeANDExpanse(string CompID, string BranchId, string Fyid, string FromDate, string Todate)
        {
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.ProfitandLossForIncomeANDExpanse(CompID, BranchId, Fyid, FromDate, Todate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);
            }



        }
        public ActionResult FillPosting(string CompID, string BranchId)
        {
            returndbml<GetPostingResult> objResult = new returndbml<GetPostingResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillPosting();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillRelation(string CompID, string BranchId)
        {
            returndbml<GetRelationResult> objResult = new returndbml<GetRelationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillRelation();
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillCashBank(string CompID, string BranchId)
        {
            returndbml<SP_SelectLedgerByLdNameResult> objResult = new returndbml<SP_SelectLedgerByLdNameResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillCashBank(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GetNextMemberIDCustom(string Prefix, string CompID, string BranchId, string FyID, string NextMemberNo)
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetNextMemberIDCustom(Prefix, CompID, BranchId, FyID, NextMemberNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #region Member Charges

        public ActionResult MembershipCharges()
        {


            return View();
        }

        public ActionResult InsertIntoMembershipCharge(GetMembershipChargesDetailbyIDResult ObjList)
        {
            // ObjList.CurrentDate = DateTime.Now;
            returndbml objResult = new returndbml();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertIntoMembershipCharge(ObjList);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMembershipChargesDetail(string AccNoCategory, string CompID, string BranchId)
        {

            returndbml<GetMembershipChargesDetailbyIDResult> objResult = new returndbml<GetMembershipChargesDetailbyIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMembershipChargesDetail(AccNoCategory, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetMembershipChargesDetailbyID(string Member_Id, string CompID, string BranchId)
        {

            returndbml<GetMembershipChargesDetailbyIDResult> objResult = new returndbml<GetMembershipChargesDetailbyIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMembershipChargesDetailbyID(Member_Id, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult selectLNNameAccNo(string CompID, string BranchId)
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            var obj = objMember.selectLNNameAccNo(CompID, BranchId);
            foreach (selectLNNameAccNoResult ob in obj.returndbmllist.ToList())
            {
                SelectListItem objselect = new SelectListItem();
                objselect.Value = ob.AccNo.ToString();
                objselect.Text = ob.LdName;
                SubBranchName.Add(objselect);
            };
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }


        public ActionResult selectSubgroupNameSrNo()
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            var obj = objMember.selectSubgroupNameSrNo();
            if (obj != null)
            {
                foreach (selectSubgroupNameSrNoResult ob in obj.returndbmllist.ToList())
                {
                    SelectListItem objselect = new SelectListItem();
                    objselect.Value = ob.Sno.ToString();
                    objselect.Text = ob.SubgroupName;
                    SubBranchName.Add(objselect);
                };
            }
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult selectSubgroupCodePrefix(string Sno)
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            returndbml<selectSubgroupCodePrefixResult> SubBranchName = new returndbml<selectSubgroupCodePrefixResult>();

            var obj = objMember.selectSubgroupCodePrefix(Sno);
            if (obj != null)
            {
                SubBranchName = obj;
                strStatus = obj.Status;
                intStatusId = obj.StatusId;
            }
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }


        public ActionResult CheckDublicateChargeName(string ChargeName, string CompID, string BranchId)
        {
            returndbml<CheckDublicateChargeNameResult> objResult = new returndbml<CheckDublicateChargeNameResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckDublicateChargeName(ChargeName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }



        #endregion


        #region Loan Account
        public ActionResult LoanGurantor()
        {

            return View();
        }
        public ActionResult FillAllMemberID(string CompID, string BranchId)
        {
            returndbml<GetAllMemberIDResult> objResult = new returndbml<GetAllMemberIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillAllMemberID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetLedgerGenralInfo(string MemberId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerGenralInfo(MemberId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetLedgerAccountDetailForBulkReciept(string MemberId, string CompID, string BranchId, string RecieptDate)
        {

            returndbml<FetchLedgerAllAccountDetail> objResult = new returndbml<FetchLedgerAllAccountDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerAccountDetailForBulkReciept(MemberId, CompID, BranchId, RecieptDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetMemberAccountSummary(string MemberId, string CompID, string BranchId, string FyId, string FromDate, string ToDate)
        {

            returndbml<FetchLedgerAllAccountDetail> objResult = new returndbml<FetchLedgerAllAccountDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberAccountSummary(MemberId, CompID, BranchId, FyId, FromDate, ToDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMemberAllAccountSummary(string MemberId, string CompID, string BranchId, string FyId, string FromDate, string ToDate)
        {

            returndbml<FetchLedgerAllAccountDetail> objResult = new returndbml<FetchLedgerAllAccountDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberAllAccountSummary(MemberId, CompID, BranchId, FyId, FromDate, ToDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetBankRecancellation(string LedgerId, string CompID, string BranchId, string Status)
        {

            returndbml<FetchLedgerAllAccountDetail> objResult = new returndbml<FetchLedgerAllAccountDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetBankRecancellation(LedgerId, CompID, BranchId, Status);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetVoucherDetailByAppTransNo(string AppTransNo, string CompID, string BranchId)
        {

            returndbml<FetchLedgerAllAccountDetail> objResult = new returndbml<FetchLedgerAllAccountDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetVoucherDetailByAppTransNo(AppTransNo, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetGurantorsTotal(string MemberId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetGurantorsTotal(MemberId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetGurantorsName(string MemberId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerGenralInfo(MemberId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetGurantorDetail(string MemberId, string CompID, string BranchId, string FyID)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetGurantorDetail(MemberId, CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FillLoanPlan(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillLoanPlan(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult FillLoanExtentionID(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillLoanExtentionID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }


        public ActionResult GetAllMembarAoutocomplete(string CompID, string BranchId)
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            var obj = objprovider.GetAllMembarAoutocomplete(CompID, BranchId);
            foreach (GetAllMemberIDResult ob in obj.returndbmllist.ToList())
            {
                SelectListItem objselect = new SelectListItem();
                objselect.Value = ob.MEMBER_ACCNO.ToString();
                objselect.Text = ob.MEMBER_ACCNO.ToString();
                SubBranchName.Add(objselect);
            };
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetFemalePlanIntrest(string PlaneName, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFemalePlanIntrest(PlaneName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult FetchPlanTypeBySubGroupID(string PlaneName, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FetchPlanTypeBySubGroupID(PlaneName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetFDReserveForLoan(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<GetLedgerAccountMasterResult> objResult = new returndbml<GetLedgerAccountMasterResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFDReserveForLoan(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetRateofInstFD(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetRateofInstFD(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetFyStatusByFyID(string CompID, string BranchId, string FyID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFyStatusByFyID(CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetPlaneDetailByPlanID(string CompID, string BranchId, string PlanID, string AccType)
        {
            returndbml<SelectPlaneByPlanIDResult> objResult = new returndbml<SelectPlaneByPlanIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPlaneDetailByPlanID(CompID, BranchId, PlanID, AccType);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckPenaltyAmount(string CompID, string BranchId)
        {
            returndbml<SelectPlaneByPlanIDResult> objResult = new returndbml<SelectPlaneByPlanIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckPenaltyAmount(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckSMSChargesDetail(string CompID, string BranchId)
        {
            returndbml<GetSMSChargesResult> objResult = new returndbml<GetSMSChargesResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckSMSChargesDetail(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetDayCloseDate(string CompID, string BranchId, string FyID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetDayCloseDate(CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetSMSChargeDate(string CompID, string BranchId, string FyID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetSMSChargeDate(CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckIntGiven(string CompID, string BranchId, string FyID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckIntGiven(CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult InsertInterestSave(string CompID, string BranchId, string FyID, string Date)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertInterestSave(CompID, BranchId, FyID, Date);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult SaveDayClose(string CompID, string BranchId, string FyID, string Date)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.SaveDayClose(CompID, BranchId, FyID, Date);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult Rdinterest(string CompID, string BranchId, string FyID, string Date)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.Rdinterest(CompID, BranchId, FyID, Date);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult InsertSmsChargesDetails(string CompID, string BranchId, string FyID, string ChargeName, string ChargeType, string smsChargeDate, string LedgerName, string SmsChargeAmt, string DayCloseDatePlusOne)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertSmsChargesDetails(CompID, BranchId, FyID, ChargeName, ChargeType, smsChargeDate, LedgerName, SmsChargeAmt, DayCloseDatePlusOne);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult BindsharedividentDetails(string CompID, string BranchId, string FyID, string FirstDayMonth, string LastDayMonth, string DayCloseMonthNo, string LastDateofCurrentMonth)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.BindsharedividentDetails(CompID, BranchId, FyID, FirstDayMonth, LastDayMonth, DayCloseMonthNo, LastDateofCurrentMonth);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult LoanPenalityDetails(string CompID, string BranchId, string FyID, string FirstDayMonth, string LastDayMonth, string DayCloseMonthNo, string LastDateofCurrentMonth, string FirstDateofCurrentMonth)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.LoanPenalityDetails(CompID, BranchId, FyID, FirstDayMonth, LastDayMonth, DayCloseMonthNo, LastDateofCurrentMonth, FirstDateofCurrentMonth);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetRateofInstCP(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetRateofInstCP(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FetchLoanPercentage(string PlaneName, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FetchLoanPercentage(PlaneName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetPlanIdByPlaneName(string PlaneName, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPlanIdByPlaneName(PlaneName, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLoanRequestID(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanRequestID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }



        public ActionResult InsertLoanGurantor(InsertLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanGurantor(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertLoanGurantorBulk(InsertLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanGurantorBulk(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertLoanBreak(InsertLoanBreak objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanBreak(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetRateofInstByPlanID(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetRateofInstByPlanID(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }



        public ActionResult GetPlanTypePlanID(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPlanTypePlanID(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetPlanTypeBySubGroupCode(string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPlanTypeBySubGroupCode(CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetInterestTotal(string CompID, string BranchId, string SubGroupCode, string FyID, string AccType, string ctr)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetInterestTotal(CompID, BranchId, SubGroupCode, FyID, AccType, ctr);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult GetPenaltyTotal(string CompID, string BranchId, string SubGroupCode, string FyID, string AccType, string ctr)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPenaltyTotal(CompID, BranchId, SubGroupCode, FyID, AccType, ctr);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult GetInterest(string CompID, string BranchId, string SubGroupCode, string FyID, string AccType, string ctr)
        {
            returndbml<GetLoan> objResult = new returndbml<GetLoan>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetInterest(CompID, BranchId, SubGroupCode, FyID, AccType, ctr);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult GetInstAmtByComIntPer(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetInstAmtByComIntPer(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetInstNoByComIntPer(string PlaneName, string CompID, string BranchId, string SubGroupCode)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetInstNoByComIntPer(PlaneName, CompID, BranchId, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult LoanApproved()
        {

            return View();
        }

        public ActionResult GetLoanRequestforApproved(string CompID, string BranchId)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanRequestforApproved(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetLoanStatistics(string CompID, string BranchId, string FyID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanStatistics(CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetLoanRequiredByRequestID(string ReqID, string CompID, string BranchId, string MemberID, string FyID)
        {
            returndbml<FechDetail> objResult = new returndbml<FechDetail>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanRequiredByRequestID(ReqID, CompID, BranchId, MemberID, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult UpadateLoanStatus(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpadateLoanStatus(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpadateFyStatus(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpadateFyStatus(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpadateFyStatusForBranch(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpadateFyStatusForBranch(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteOpeningBalance(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.DeleteOpeningBalance(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CloseLastMeetingID(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CloseLastMeetingID(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpadateLoanAmount(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpadateLoanAmount(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpadateLoanInstallmentAMT(ApproveLoan objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpadateLoanInstallmentAMT(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetFinencialYearByFyID(string CompID, string FyID)
        {

            returndbml<GetFinencialYearResult> objResult = new returndbml<GetFinencialYearResult>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFinencialYearByFyID(CompID, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLoanRequestByStatus(string CompID, string BranchId, string Status, string FyID, string FromDate, string ToDate)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanRequestByStatus(CompID, BranchId, Status, FyID, FromDate, ToDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult LoanDisbursement()
        {

            return View();
        }
        public ActionResult GetPendingLoanRequest(string CompID, string BranchId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPendingLoanRequest(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAllLoadnRequestAoutocomplete(string CompID, string BranchId)
        {
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            List<SelectListItem> SubBranchName = new List<SelectListItem>();

            var obj = objprovider.GetAllLoadnRequestAoutocomplete(CompID, BranchId);
            foreach (GetAllMemberIDResult ob in obj.returndbmllist.ToList())
            {
                SelectListItem objselect = new SelectListItem();
                objselect.Value = ob.MEMBER_ACCNO.ToString();
                objselect.Text = ob.MEMBER_ACCNO.ToString();
                SubBranchName.Add(objselect);
            };
            //  ViewBag.SubGroup = SubBranchName;
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = SubBranchName }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetLoanReqByStatus(string Status, string CompID, string BranchId, string FyID)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanReqByStatus(Status, CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMultipleLoanNagainst(string CompID, string BranchId, string LoanId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMultipleLoanNagainst(CompID, BranchId, LoanId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetLoanDisbursementDetailByLoanReqID(string CompID, string BranchId, string LoanId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanDisbursementDetailByLoanReqID(CompID, BranchId, LoanId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillTransBy(string Memberid, string CompID, string BranchId, string SetChargeAmt)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillTransBy(Memberid, CompID, BranchId, SetChargeAmt);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillMemberDCAcc(string Memberid, string CompID, string BranchId, string SetChargeAmt)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillMemberDCAcc(Memberid, CompID, BranchId, SetChargeAmt);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillMemberCombo(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillMemberCombo(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillPayType(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillPayType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult FillSHGCredit(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillSHGCredit(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult FillSHGDebit(string CompID, string BranchId, string FedTransType)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillSHGDebit(CompID, BranchId, FedTransType);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillTransByWithSuspanseLed(string Memberid, string CompID, string BranchId, string SetChargeAmt)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillTransByWithSuspanseLed(Memberid, CompID, BranchId, SetChargeAmt);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLoanCharges(string CompID, string BranchId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanCharges(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetDailyCollectionCharges(string CompID, string BranchId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetDailyCollectionCharges(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAccNoByMemberID(string CompID, string BranchId, string MemberID, string SubGroupCode)
        {
            returndbml<GetLoan> objResult = new returndbml<GetLoan>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetAccNoByMemberID(CompID, BranchId, MemberID, SubGroupCode);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLoanDisID(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanDisID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLastDayCloseDate(string CompID, string BranchId)
        {
            returndbml<GetLoan> objResult = new returndbml<GetLoan>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLastDayCloseDate(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult InsertLoanDisbursemant(InsertLoanDis objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanDisbursemant(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InsertLoanDisWithoutMultipaleLoanWithCharges(InsertLoanDis objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanDisWithoutMultipaleLoanWithCharges(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InsertBulkLoanDisbursemant(InsertLoanDis objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertBulkLoanDisbursemant(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertLoanOeningBallance(InsertLoanDis objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanOeningBallance(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult InsertLoanDisWithoutMultipaleLoanOeningBall(InsertLoanDis objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanDisWithoutMultipaleLoanOeningBall(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetSubGroupCodeByProductID(string ProductID, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetSubGroupCodeByProductID(ProductID, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult ChkCummulativeDate(string ProductID, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.ChkCummulativeDate(ProductID, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetLoanDisByLoanID(string CompID, string BranchId, string AccNo)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanDisByLoanID(CompID, BranchId, AccNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult LoanOpening()
        {

            return View();
        }
        public ActionResult GetMemberDetailForSearch(string CompID, string BranchId)
        {

            returndbml<GetMemberDetail> objResult = new returndbml<GetMemberDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberDetailForSearch(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Loan Break
        public ActionResult LoanBreak()
        {

            return View();
        }
        #endregion

        #region Reciept
        public ActionResult Reciept()
        {

            return View();
        }
        public ActionResult GetMemberAccountDetail(string MemberId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberAccountDetail(MemberId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMemberAccountDetailForOpening(string MemberId, string CompID, string BranchId, string FyID)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberAccountDetailForOpening(MemberId, CompID, BranchId, FyID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetRecieptDataByVoucherNo(string VNo, string CompID, string BranchId, string FyID, string AppTransNo)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetRecieptDataByVoucherNo(VNo, CompID, BranchId, FyID, AppTransNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetRDDetail(string AccNo, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetRDDetail(AccNo, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetNonMemberAccountDetailByAccNo(string AccNo, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetNonMemberAccountDetailByAccNo(AccNo, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMaxVNoandRNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandRNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMaxMeetingNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxMeetingNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteVoucherByAppTransNo(string CompID, string BranchId, string FyId, string AppTransNo)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.DeleteVoucherByAppTransNo(CompID, BranchId, FyId, AppTransNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        //public ActionResult InsertReciept(InsertReciept objlist)
        //{

        //    List<FormSubmision> objResult = new List<FormSubmision>();

        //    string resultstr = "";
        //    int intStatusId = 99;
        //    string strStatus = "Unhandled error";
        //    try
        //    {
        //        objResult = objMember.InsertReciept(objlist);


        //    }
        //    catch (Exception ex)
        //    {
        //        strStatus = ex.Message + " " + ex.StackTrace;
        //    }
        //    return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult InsertReciept(InsertReciept objlist)
        {
            List<FormSubmision> objResult = new List<FormSubmision>();
            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";

            try
            {
                // Log the received data for debugging
                System.Diagnostics.Debug.WriteLine($"RecieptNo: {objlist.RecieptNo}");
                // Log other properties similarly

                objResult = objMember.InsertReciept(objlist);
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }

            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult InsertBankRecancellation(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertBankRecancellation(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult InsertRecieptFedration(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertRecieptFedration(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InsertRecieptFedrationNew(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertRecieptFedrationNew(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertLoanRequestAmtFedration(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanRequestAmtFedration(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateOpeningBalanceData(UpdateOpeningBalance objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.UpdateOpeningBalance(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertRecieptBulk(InsertRecieptBulk objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertRecieptBulk(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertImportExcelRecieptBulk(InsertRecieptBulk objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertImportExcelRecieptBulk(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Withdrawl
        public ActionResult WithDrawl()
        {

            return View();
        }
        public ActionResult LoanTopup()
        {

            return View();
        }
        public ActionResult GetMaxVNoandWNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandWNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMaxImpDeductionNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxImpDeductionNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMaxVNoandJNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandJNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InsertWithDrawl(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertWithDrawl(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertLoanTopup(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertLoanTopup(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Contra Voucher
        public ActionResult ContraVoucher()
        {

            return View();
        }

        public ActionResult InsertContra(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertContra(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMaxVNoandCNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandCNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region Journal Voucher
        public ActionResult JournalVoucher()
        {

            return View();
        }
        public ActionResult InsertJournal(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertJournal(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region FD
        public ActionResult FDOpen()
        {

            return View();
        }
        public ActionResult GetMaxVNoandFDNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandFDNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillFDType(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillFDType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult FillAgent(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillAgent(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetFDPlanPeriod(string PlaneId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFDPlanPeriod(PlaneId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetDCPlanPeriod(string PlaneId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetDCPlanPeriod(PlaneId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertFD(InsertFD objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertFD(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region RD
        public ActionResult RDOpen()
        {

            return View();
        }
        public ActionResult GetMaxVNoandRDNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandRDNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillRDType(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillRDType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }


        public ActionResult GetRDPlanPeriod(string PlaneId, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFDPlanPeriod(PlaneId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertRD(InsertFD objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertRD(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region Daily Collection
        public ActionResult DailyCollectionOpen()
        {

            return View();
        }
        public ActionResult GetMaxVNoandDCNo(string CompID, string BranchId, string FyId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMaxVNoandDCNo(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FillDCType(string CompID, string BranchId)
        {
            returndbml<GetNextMemberNoResult> objResult = new returndbml<GetNextMemberNoResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillDCType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult InsertDC(InsertDC objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertDC(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertDCOpening(InsertDC objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertDCOpening(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region Federation

        public ActionResult MeetingAmountApproval()
        {

            return View();
        }
        public ActionResult BulkLoanDisbursement()
        {

            return View();
        }
        public ActionResult AddFinancialYear()
        {

            return View();
        }
        public ActionResult PreApplyInterest()
        {

            return View();
        }
        public ActionResult ApplyInterest()
        {

            return View();
        }

        public ActionResult GetMeetingAmountforApproval(string CompID, string BranchId, string RegionalID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingAmountforApproval(CompID, BranchId, RegionalID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMeetingAmountforUpdate(string CompID, string BranchId)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingAmountforUpdate(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMeetingLoanAmtforApproval(string CompID, string BranchId, string RegionalID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingLoanAmtforApproval(CompID, BranchId, RegionalID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMeetingDepositeAmountDetail(string CompID, string BranchId, string AppTransNo)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingDepositeAmountDetail(CompID, BranchId, AppTransNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMemberDataforBulkUpdate(string CompID, string BranchId, string AppTransNo)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberDataforBulkUpdate(CompID, BranchId, AppTransNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMeetingLoanRequestAmountDetail(string CompID, string BranchId, string AppTransNo, string RequestDate)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingLoanRequestAmountDetail(CompID, BranchId, AppTransNo, RequestDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMeetingLoanRequestDetailByLoanID(string CompID, string BranchId, string LoanID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingLoanRequestDetailByLoanID(CompID, BranchId, LoanID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMeetingLoanApprovedAmountDetail(string CompID, string BranchId, string AppTransNo, string RequestDate)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingLoanApprovedAmountDetail(CompID, BranchId, AppTransNo, RequestDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetLoanApprovedAmountDetail(string CompID, string BranchId, string AppTransNo, string RequestDate)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanApprovedAmountDetail(CompID, BranchId, AppTransNo, RequestDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult MeetingLoanApproval()
        {

            return View();
        }
        public ActionResult GetMeetingLoanApprovedRequest(string CompID, string BranchId)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMeetingLoanApprovedRequest(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }


        #endregion
        #region Reports
        public ActionResult ViewLedgerGroup()
        {

            return View();
        }
        public ActionResult MasterAccountDetails()
        {

            return View();
        }
        public ActionResult MasterDetailReport()
        {

            return View();
        }
        public ActionResult ProductTypeReport()
        {

            return View();
        }
        public ActionResult DailyReport()
        {

            return View();
        }
        public ActionResult FillMemberAccType(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillMemberAccType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult FillUnderEmployeeByLoginEmpID(string CompID, string BranchId, string EmpID)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillUnderEmployeeByLoginEmpID(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

            }


        }
        public ActionResult FillLoginEmployee(string CompID, string BranchId, string EmpID)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillLoginEmployee(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);


            }

        }


        public ActionResult FillUnderBranchByUnderEmpID(string CompID, string BranchId, string EmpID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillUnderBranchByUnderEmpID(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            if (objResult == null)
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult FillExcelImportMatchData(string CompID, string BranchId, string ReportNo)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillExcelImportMatchData(CompID, BranchId, ReportNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FillUnMatchExcelImportMatchData(string CompID, string BranchId, string ReportNo)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillUnMatchExcelImportMatchData(CompID, BranchId, ReportNo);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult MasterDetailReporgt(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillMemberAccType(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GetMemberDetailForByBranchID(string CompID, string BranchId)
        {

            returndbml<GetMemberDetail> objResult = new returndbml<GetMemberDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberDetailForByBranchID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetEmployeeStatistics(string CompID, string BranchId, string EmpID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetEmployeeStatistics(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetFedrationStatistics(string CompID, string BranchId, string EmpID, string RegionalID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFedrationStatistics(CompID, BranchId, EmpID, RegionalID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetBulkRecieptStatistics(string CompID, string BranchId, string EmpID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetBulkRecieptStatistics(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetFedrationLoanStatistics(string CompID, string BranchId, string EmpID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFedrationLoanStatistics(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetLoanpprovedStatistics(string CompID, string BranchId, string EmpID)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanpprovedStatistics(CompID, BranchId, EmpID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FillUnderBranchByUnderEmpIDMeetingDays(string CompID, string BranchId, string EmpID, string Days)
        {

            returndbml<FechDetail> objResult = new returndbml<FechDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillUnderBranchByUnderEmpIDMeetingDays(CompID, BranchId, EmpID, Days);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FillAllLedgerCombo(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillAllLedgerCombo(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult FillAllLedgerComboWithouBankCash(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillAllLedgerComboWithouBankCash(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult FillAllLedgerWithdrawl(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillAllLedgerWithdrawl(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult FillLoanAccComboforTopup(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillLoanAccComboforTopup(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GettAllSearchMember(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GettAllSearchMember(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }

        public ActionResult FillLoanNo(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillLoanNo(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GettAllLoanReuest(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GettAllLoanReuest(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult FillAllLedgerMember(string CompID, string BranchId)
        {
            returndbml<SelectDesgnationResult> objResult = new returndbml<SelectDesgnationResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.FillAllLedgerMember(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);




        }
        public ActionResult ViewLedgerGroupRpt(string LedgerId, string FromDate, string Todate, string FyId, string Date, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.ViewLedgerGroup(LedgerId, FromDate, Todate, FyId, Date, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        //public ActionResult ViewLedgerGroupNonMemberRpt(string LedgerId, string FromDate, string Todate, string FyId, string Date, string CompID, string BranchId)
        //{

        //    returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

        //    int intStatusId = 99;
        //    string strStatus = "Unhandled error";
        //    try
        //    {
        //        objResult = objMember.ViewLedgerGroupNonMemberRpt(LedgerId, FromDate, Todate, FyId, Date, CompID, BranchId);
        //        strStatus = objResult.Status;
        //        intStatusId = objResult.StatusId;
        //    }
        //    catch (Exception ex)
        //    {
        //        strStatus = ex.Message + " " + ex.StackTrace;
        //    }
        //    return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        //}
        //kunal 
        public ActionResult ViewLedgerGroupNonMemberRpt(string LedgerId, string FromDate, string Todate, string FyId, string Date, string CompID, string BranchId)
        {
            // Initialize the return object
            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            // Initialize status variables
            int intStatusId = 99;
            string strStatus = "Unhandled error";

            try
            {
                // Call the method to get data
                objResult = objMember.ViewLedgerGroupNonMemberRpt(LedgerId, FromDate, Todate, FyId, Date, CompID, BranchId);

                // Ensure objResult is not null before accessing its properties
                if (objResult != null)
                {
                    strStatus = objResult.Status;
                    intStatusId = objResult.StatusId;
                }
                else
                {
                    // Handle case where objResult is null
                    strStatus = "No data returned from service.";
                    intStatusId = -1; // Set error status
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions and log the error message
                strStatus = ex.Message + " " + ex.StackTrace;
                intStatusId = -1; // Set error status
            }

            // Return the JSON result with status and data
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLoanDetailForCloseByLoanNo(string LoanNo, string CompID, string BranchId, string FyId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanDetailForCloseByLoanNo(LoanNo, CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetLoanDetailForCloseByMemberNo(string MemberNo, string CompID, string BranchId, string FyId)
        {

            returndbml<GetLoan> objResult = new returndbml<GetLoan>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLoanDetailForCloseByMemberNo(MemberNo, CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetCashBook(string LedgerId, string FromDate, string Todate, string FyId, string Date, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetCashBook(LedgerId, FromDate, Todate, FyId, Date, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetDayBook(string LedgerId, string FromDate, string Todate, string FyId, string Date, string CompID, string BranchId)
        {

            returndbml<FechLedgerDetail> objResult = new returndbml<FechLedgerDetail>();

            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetDayBook(LedgerId, FromDate, Todate, FyId, Date, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetLedgerMinDate(string CompID, string BranchId, string LedgerID, string MemberID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerMinDate(CompID, BranchId, LedgerID, MemberID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult CheckProfitLosssSub(string CompID, string BranchId, string FyId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckProfitLosssSub(CompID, BranchId, FyId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckFinancialYear(string CompID, string BranchId, string FyId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckFinancialYear(CompID, BranchId, FyId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetProfitLosssLed(string CompID, string BranchId, string FyId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetProfitLosssLed(CompID, BranchId, FyId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetPNDLLed(string CompID, string BranchId, string FyId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPNDLLed(CompID, BranchId, FyId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetVNoForDelete(string CompID, string BranchId, string FyId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetVNoForDelete(CompID, BranchId, FyId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLedgerNatueByAccNo(string CompID, string BranchId, string LedgerID, string MemberID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerNatueByAccNo(CompID, BranchId, LedgerID, MemberID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetMemberDOB(string CompID, string BranchId, string MemberID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberDOB(CompID, BranchId, MemberID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetSubGroupIDByPlanID(string CompID, string BranchId, string PlanID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetSubGroupIDByPlanID(CompID, BranchId, PlanID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckDublicateMembershipCharges(string CompID, string BranchId, string ChargeName)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckDublicateMembershipCharges(CompID, BranchId, ChargeName);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetBranchSubgroupLedID(string CompID, string BranchId, string LedgerId, string ChargesType)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetBranchSubgroupLedID(CompID, BranchId, LedgerId, ChargesType);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLedgeraGander(string CompID, string BranchId, string MemberID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgeraGander(CompID, BranchId, MemberID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetGPNameByLed(string CompID, string BranchId, string AccNo)
        {

            if (AccNo == "0")
            {
                return Json(new { StatusId = "0", Status = "O", Result = "na" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
                int intStatusId = 99;
                string strStatus = "Unhandled error";
                try
                {
                    objResult = objMember.GetGPNameByLed(CompID, BranchId, AccNo);
                    strStatus = objResult.Status;
                    intStatusId = objResult.StatusId;
                }
                catch (Exception ex)
                {
                    strStatus = ex.Message + " " + ex.StackTrace;
                }
                return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult GetSeniorCitizenAge(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetSeniorCitizenAge(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetFemalePlanInterest(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetFemalePlanInterest(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }


        public ActionResult GetSeniorCitizenInterest(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetSeniorCitizenInterest(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetPlanDetailByPlanID(string PlanID, string CompID, string BranchId)
        {

            returndbml<SelectPlaneByIDResult> objResult = new returndbml<SelectPlaneByIDResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objprovider.GetPlanDetailByPlanID(PlanID, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetLedgerIntrestLedByBranchIDLdName(string CompID, string BranchId, string LdName)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLedgerIntrestLedByBranchIDLdName(CompID, BranchId, LdName);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetMemberIDByAccNo(string CompID, string BranchId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetMemberIDByAccNo(CompID, BranchId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLdNameByAccNo(string CompID, string BranchId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLdNameByAccNo(CompID, BranchId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetPlaneNameLoanNo(string CompID, string BranchId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetPlaneNameLoanNo(CompID, BranchId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetStatusByAccNo(string CompID, string BranchId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetStatusByAccNo(CompID, BranchId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckMeetingSubmitedStatus(string CompID, string BranchId, string MemberID, string MeetingDate)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckMeetingSubmitedStatus(CompID, BranchId, MemberID, MeetingDate);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult CheckMeetingLastStatus(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.CheckMeetingLastStatus(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetLastMeetingID(string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetLastMeetingID(CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetSHGLoanAccNo(string CompID, string BranchId, string SHGBranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetSHGLoanAccNo(CompID, BranchId, SHGBranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult GetTotalMemberByAccountType(string Date, string AccountName, string AccType, string FyId, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetTotalMemberByAccountType(Date, AccountName, AccType, FyId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult GetTotalMemberAmountByAccountType(string Date, string AccountName, string AccType, string FyId, string CompID, string BranchId)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetTotalMemberAmountByAccountType(Date, AccountName, AccType, FyId, CompID, BranchId);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }

        public ActionResult PNLClose(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.PNLClose(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult PNLCloseOpeningBal(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.PNLCloseOpeningBal(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult InsertOpeningBalPNDL(List<InsertPNDL> objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertOpeningBalPNDL(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        //public JsonResult InsertOpeningBalPNDL(List<InsertPNDL> customers)
        //{
        //    if (customers == null)
        //    {
        //        customers = new List<InsertPNDL>();
        //    }
        //    foreach (InsertPNDL customer in customers)
        //    {
        //        var abc = customer.AccNo;

        //    }
        //    int insertedRecords = 1;
        //    return Json(insertedRecords);
        //}
        public ActionResult InsertApplyInterest(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertApplyInterest(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult InsertFinancialYear(InsertReciept objlist)
        {

            List<FormSubmision> objResult = new List<FormSubmision>();

            string resultstr = "";
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.InsertFinancialYear(objlist);


            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CashBook()
        {

            return View();
        }

        public ActionResult GetCashLed(string CompID, string BranchId, string LedgerID)
        {
            returndbml<sp_FetchLoanPlaneResult> objResult = new returndbml<sp_FetchLoanPlaneResult>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {
                objResult = objMember.GetCashLed(CompID, BranchId, LedgerID);
                strStatus = objResult.Status;
                intStatusId = objResult.StatusId;
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objResult.returndbmllist }, JsonRequestBehavior.AllowGet);



        }
        [HttpPost]
        public ActionResult UploadExcelsheet()
        {

            string Action = "";
            int RowInst = 0;
            int RowIn = 0;

            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login1", "Home");
            //}
            //List<dbmlVendorView> objVendorList = new List<dbmlVendorView>();
            returndbml<sp_GetloginpasswordResult> objResult = new returndbml<sp_GetloginpasswordResult>();
            List<FormLogin> objDept = new List<FormLogin>();
            int intStatusId = 99;
            string strStatus = "Unhandled error";
            try
            {

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    var SendCompID = Request.Params["CompID"];
                    var SendBranchID = Request.Params["BranchId"];
                    var SendRepImportNo = Request.Params["RepImportNo"];
                    var SendImpNo = Request.Params["ImpNo"];

                    List<ImportToExcel> _lstProductMaster = new List<ImportToExcel>();
                    string filePath = string.Empty;
                    if (Request.Files != null)
                    {
                        string path = Server.MapPath("~/Uploads/Product/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        filePath = path + Path.GetFileName("ProductUploadSheet-" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss-ff") + Path.GetExtension(file.FileName));
                        string extension = Path.GetExtension("ProductUploadSheet-" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss-ff") + Path.GetExtension(file.FileName));
                        file.SaveAs(filePath);

                        string conString = string.Empty;
                        switch (extension)
                        {
                            case ".xls": //Excel 97-03.
                                conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                                break;
                            case ".xlsx": //Excel 07 and above.
                                conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                                break;
                        }
                        int total = 0;
                        int entered = 0;
                        int failed = 0;
                        DataTable dtt = new DataTable();

                        conString = string.Format(conString, filePath);
                        List<ImportToExcel> _lstImpExcel = new List<ImportToExcel>();
                        using (OleDbConnection connExcel = new OleDbConnection(conString))
                        {
                            using (OleDbCommand cmdExcel = new OleDbCommand())
                            {
                                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                                {
                                    DataTable dt = new DataTable();
                                    cmdExcel.Connection = connExcel;

                                    //Get the name of First Sheet.
                                    connExcel.Open();
                                    DataTable dtExcelSchema;
                                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                    connExcel.Close();

                                    //Read Data from First Sheet.
                                    connExcel.Open();
                                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                    odaExcel.SelectCommand = cmdExcel;
                                    odaExcel.Fill(dt);
                                    connExcel.Close();


                                    string GetEmpID;
                                    string GetMemberName;
                                    string GetMemberID;
                                    string GetLoanAccNo;
                                    string GetLoanInstAccNo;
                                    string GetLoanInstLdName;
                                    string GetCPAccNo;
                                    string GetLoanAmt;
                                    string GetLoanInstAmt;
                                    string GetLoanInstallmentAmt;
                                    string GetCPAmt;

                                    if (dt.Rows.Count > 0)
                                    {

                                        foreach (DataRow row in dt.Rows)
                                        {
                                            total++;



                                            GetEmpID = row["EmpID"].ToString();
                                            GetLoanAmt = row["Loan Amount"].ToString();
                                            GetLoanInstAmt = row["INTEREST"].ToString();
                                            GetMemberName = row["EmployeeName"].ToString();
                                            GetCPAmt = row["CP Amount"].ToString();

                                            string Connection = ConfigurationManager.ConnectionStrings["CollageManagement"].ConnectionString;
                                            using (SqlConnection CN = new SqlConnection(Connection))
                                            {

                                                using (SqlConnection co = new SqlConnection(Connection))
                                                {

                                                    if (GetEmpID == "")
                                                    {

                                                    }
                                                    else
                                                    {
                                                        dtt.Rows.Clear();
                                                        cmd1 = new SqlCommand("SELECT NMA.FirstName+' '+NMA.LastName AS NAME,MEMBER_ACCNO,PFD.BatchNo,(select top 1 AccNo from Ledger where MemberId = NMA.MEMBER_ACCNO and Compid = @CompID and BranchID = @BranchID  and AccNo like '%105%' )AS LoanAccount,(SELECT TOP 1 InstallmentAmount FROM LoanDis WHERE  Compid = @CompID and BranchID = @BranchID and  LedgerId = (select top 1 AccNo from Ledger where  Compid = @CompID and BranchID = @BranchID and  MemberId = NMA.MEMBER_ACCNO and AccNo like '%105%'))AS LoanInstallmentAmt,  (select top 1 InterestLedger from PlaneMaster where  Compid = @CompID and BranchID = @BranchID and PlaneId = ( select top 1 LoanType from LedgerAccountMaster where  Compid = @CompID and BranchID = @BranchID and  AccNo = (select top 1 AccNo from Ledger where  Compid = @CompID and BranchID = @BranchID and  MemberId = NMA.MEMBER_ACCNO and AccNo like '%105%'))) as LoanIstLedger,(select top 1 LdName from Ledger where  Compid = @CompID and BranchID = @BranchID and AccNo = (select top 1 InterestLedger from PlaneMaster where  Compid = @CompID and BranchID = @BranchID and  PlaneId = ( select top 1 LoanType from LedgerAccountMaster where  Compid = @CompID and BranchID = @BranchID and  AccNo = (select top 1 AccNo from Ledger where  Compid = @CompID and BranchID = @BranchID and  MemberId = NMA.MEMBER_ACCNO and AccNo like '%105%'))))AS LoanInstLdName,(select top 1 AccNo from Ledger where MemberId = NMA.MEMBER_ACCNO and AccNo like '%103%' )AS CPAccount FROM NewMemberaccount NMA JOIN ProfessionalDetail PFD ON NMA.MEMBER_ACCNO = PFD.nmId and NMA.Compid = PFD.CompID and NMA.BranchID = PFD.BranchID WHERE NMA.Compid = @CompID AND NMA.BranchID = @BranchID and PFD.BatchNo=@BatchNo", co);
                                                        cmd1.Parameters.AddWithValue("@BatchNo", GetEmpID);
                                                        cmd1.Parameters.AddWithValue("@CompID", SendCompID);
                                                        cmd1.Parameters.AddWithValue("@BranchID", SendBranchID);
                                                        SqlDataAdapter ad = new SqlDataAdapter(cmd1);

                                                        ad.Fill(dtt);

                                                    }

                                                }

                                                using (SqlConnection con = new SqlConnection(Connection))
                                                {
                                                    try
                                                    {
                                                        con.Open();

                                                        if (dtt.Rows.Count > 0)
                                                        {
                                                            GetMemberName = dtt.Rows[0]["NAME"].ToString();
                                                            GetMemberID = dtt.Rows[0]["MEMBER_ACCNO"].ToString();
                                                            GetLoanAccNo = dtt.Rows[0]["LoanAccount"].ToString();
                                                            GetLoanInstAccNo = dtt.Rows[0]["LoanIstLedger"].ToString();
                                                            GetLoanInstLdName = dtt.Rows[0]["LoanInstLdName"].ToString();
                                                            GetCPAccNo = dtt.Rows[0]["CPAccount"].ToString();
                                                            GetLoanInstallmentAmt = dtt.Rows[0]["LoanInstallmentAmt"].ToString();

                                                            SqlTransaction objTrans = null;





                                                            cmd = new SqlCommand("INSERT INTO TempDeduction(MemberName,EmpID,MemberId ,LoanAccNo,LoanIntrestAccNo ,CPAccNo,LoanInstAmt,LoanDepoAmt ,LoanIntrestDepoAmt,CPDepoAmt,ReportId,ReportNo,Status,SubmisionDate,ReportStatus,ReportCloseDate,CompID,BranchID)VALUES (@MemberName,@EmpID,@MemberId,@LoanAccNo ,@LoanIntrestAccNo,@CPAccNo,@LoanInstAmt,@LoanDepoAmt,@LoanIntrestDepoAmt,@CPDepoAmt,@ReportId,@ReportNo ,@Status,@SubmisionDate,@ReportStatus,@ReportCloseDate,@CompID,@BranchID)", con);
                                                            cmd.CommandType = CommandType.Text;
                                                            cmd.Parameters.AddWithValue("@MemberName", GetMemberName);
                                                            cmd.Parameters.AddWithValue("@EmpID", GetEmpID);
                                                            cmd.Parameters.AddWithValue("@MemberId", GetMemberID);
                                                            cmd.Parameters.AddWithValue("@LoanAccNo", GetLoanAccNo);
                                                            cmd.Parameters.AddWithValue("@LoanIntrestAccNo", GetLoanInstAccNo);
                                                            cmd.Parameters.AddWithValue("@CPAccNo", GetCPAccNo);
                                                            cmd.Parameters.AddWithValue("@LoanInstAmt", GetLoanInstallmentAmt);
                                                            cmd.Parameters.AddWithValue("@LoanDepoAmt", GetLoanAmt);
                                                            cmd.Parameters.AddWithValue("@LoanIntrestDepoAmt", GetLoanInstAmt);
                                                            cmd.Parameters.AddWithValue("@CPDepoAmt", GetCPAmt);
                                                            cmd.Parameters.AddWithValue("@ReportId", SendImpNo);
                                                            cmd.Parameters.AddWithValue("@ReportNo", SendRepImportNo);
                                                            cmd.Parameters.AddWithValue("@Status", "O");
                                                            cmd.Parameters.AddWithValue("@SubmisionDate", DateTime.Now);
                                                            cmd.Parameters.AddWithValue("@ReportStatus", "O");
                                                            cmd.Parameters.AddWithValue("@ReportCloseDate", DateTime.Now);
                                                            cmd.Parameters.AddWithValue("@CompID", SendCompID);
                                                            cmd.Parameters.AddWithValue("@BranchID", SendBranchID);
                                                            RowInst = cmd.ExecuteNonQuery();
                                                            RowIn = RowIn + RowInst;

                                                        }
                                                        else
                                                        {

                                                            cmd = new SqlCommand("INSERT INTO TempDeduction(MemberName,EmpID,MemberId ,LoanAccNo,LoanIntrestAccNo ,CPAccNo,LoanInstAmt,LoanDepoAmt ,LoanIntrestDepoAmt,CPDepoAmt,ReportId,ReportNo,Status,SubmisionDate,ReportStatus,ReportCloseDate,CompID,BranchID)VALUES (@MemberName,@EmpID,@MemberId,@LoanAccNo ,@LoanIntrestAccNo,@CPAccNo,@LoanInstAmt,@LoanDepoAmt,@LoanIntrestDepoAmt,@CPDepoAmt,@ReportId,@ReportNo ,@Status,@SubmisionDate,@ReportStatus,@ReportCloseDate,@CompID,@BranchID)", con);
                                                            cmd.CommandType = CommandType.Text;
                                                            cmd.Parameters.AddWithValue("@MemberName", GetMemberName);
                                                            cmd.Parameters.AddWithValue("@EmpID", GetEmpID);
                                                            cmd.Parameters.AddWithValue("@MemberId", "");
                                                            cmd.Parameters.AddWithValue("@LoanAccNo", "");
                                                            cmd.Parameters.AddWithValue("@LoanIntrestAccNo", "");
                                                            cmd.Parameters.AddWithValue("@CPAccNo", "");
                                                            cmd.Parameters.AddWithValue("@LoanInstAmt", "");
                                                            cmd.Parameters.AddWithValue("@LoanDepoAmt", GetLoanAmt);
                                                            cmd.Parameters.AddWithValue("@LoanIntrestDepoAmt", GetLoanInstAmt);
                                                            cmd.Parameters.AddWithValue("@CPDepoAmt", GetCPAmt);
                                                            cmd.Parameters.AddWithValue("@ReportId", SendImpNo);
                                                            cmd.Parameters.AddWithValue("@ReportNo", SendRepImportNo);
                                                            cmd.Parameters.AddWithValue("@Status", "O");
                                                            cmd.Parameters.AddWithValue("@SubmisionDate", DateTime.Now);
                                                            cmd.Parameters.AddWithValue("@ReportStatus", "O");
                                                            cmd.Parameters.AddWithValue("@ReportCloseDate", DateTime.Now);
                                                            cmd.Parameters.AddWithValue("@CompID", SendCompID);
                                                            cmd.Parameters.AddWithValue("@BranchID", SendBranchID);
                                                            RowInst = cmd.ExecuteNonQuery();
                                                            RowIn = RowIn + RowInst;

                                                        }



                                                    }
                                                    catch (Exception ex)
                                                    {

                                                    }

                                                }

                                            }




                                        }
                                    }
                                    if (dt.Rows.Count == RowIn)
                                    {
                                        intStatusId = 1;

                                        objDept.Add(new FormLogin
                                        {
                                            ReturnStatus = "Yes",
                                            ReportNo = SendRepImportNo,

                                        });
                                    }
                                    else
                                    {
                                        objDept.Add(new FormLogin
                                        {
                                            ReturnStatus = "Yes",
                                            ReportNo = SendRepImportNo,
                                        });
                                        intStatusId = 0;
                                    }
                                    //return Json(objDept, JsonRequestBehavior.AllowGet);
                                }


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strStatus = ex.Message + " " + ex.StackTrace;
            }
            return Json(new { StatusId = intStatusId, Status = strStatus, Result = objDept }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DayBook()
        {

            return View();
        }
        public ActionResult MemberwiseAccountSummary()
        {

            return View();
        }
        public ActionResult ImportDeduction()
        {

            return View();
        }
        public ActionResult BulkReciept()
        {

            return View();
        }
        public ActionResult MemberAllAcountSummary()
        {

            return View();
        }
        public ActionResult ProfitNLoss()
        {

            return View();
        }
        public ActionResult BalanceSheet()
        {

            return View();
        }
        public ActionResult BalanceSheetDetail()
        {

            return View();
        }
        public ActionResult BankRecancellation()
        {

            return View();
        }
        public ActionResult UpdateOpeningBalance()
        {

            return View();
        }
        public ActionResult BulkRecieptUpdate()
        {

            return View();
        }
        public ActionResult DailyCollectionOpening()
        {

            return View();
        }
        public ActionResult OfficeBranchDetail()
        {

            return View();
        }
        public ActionResult OldFinencialYearOpen()
        {

            return View();
        }

        public ActionResult ProfitNLossClose()
        {

            return View();
        }
        public ActionResult ClustorwiseMemberDetailReport()
        {

            return View();
        }

        #endregion




    }
}