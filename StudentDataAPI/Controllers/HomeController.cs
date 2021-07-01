using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



namespace StudentDataAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region Table data return And CRUD Operations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilterData"></param>
        /// <returns></returns>
        public ActionResult GetStudentData(CFilterData FilterData) {
            List<StudentDetail> lstStudentDetail = new List<StudentDetail>();

            StudentDetail aStudentDetail = new StudentDetail();


            lstStudentDetail = GetAllStudentData();

            // Filter Data
            if (FilterData.FilterQuery != "" && FilterData.FilterQuery != null)
            {

                List<StudentDetail> TemplstStudentDetail = new List<StudentDetail>();


                if (FilterData.FilterType == 1)
                {
                    for(int i = 0; i < lstStudentDetail.Count;i++)
                    {
                        if (lstStudentDetail[i].FirstName == FilterData.FilterQuery)
                        {

                            TemplstStudentDetail.Add(lstStudentDetail[i]);
                        }

                    }
                }
                else if (FilterData.FilterType == 2)
                {
                    for (int i = 0; i < lstStudentDetail.Count; i++)
                    {
                        if (lstStudentDetail[i].LastName == FilterData.FilterQuery)
                        {

                            TemplstStudentDetail.Add(lstStudentDetail[i]);
                        }

                    }
                }
                else if (FilterData.FilterType == 3)
                {
                    for (int i = 0; i < lstStudentDetail.Count; i++)
                    {
                        if (lstStudentDetail[i].Class == FilterData.FilterQuery)
                        {

                            TemplstStudentDetail.Add(lstStudentDetail[i]);
                        }

                    }
                }
                else if (FilterData.FilterType == 4)
                {
                    for (int i = 0; i < lstStudentDetail.Count; i++)
                    {
                        for (int x = 0; x < lstStudentDetail[i].SubjectDataList.Count; x++)
                        {
                            if (lstStudentDetail[i].SubjectDataList[x].SubjectName == FilterData.FilterQuery)
                            {
                                TemplstStudentDetail.Add(lstStudentDetail[i]);
                            }


                        }


                    }
                }

                lstStudentDetail = TemplstStudentDetail;
            }





            var DataContainerOfStatusAndRowData = new {data = lstStudentDetail, recordsFiltered = lstStudentDetail.Count};
            return Json(DataContainerOfStatusAndRowData);
        }


        /// <summary>
        /// Updates StudentData
        /// </summary>
        /// <param name="FilterData"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateStudentData( StudentDetail oStudentDetail )
        {
            List<StudentDetail> lstStudentDetail = new List<StudentDetail>();


            lstStudentDetail = GetAllStudentData();

            //if (FilterData != null && FilterData.FilterQuery != "") {
            //     lstStudentDetail = GetFilteredSudentData(FilterData);
            //}
            //else {
            //    lstStudentDetail = GetAllStudentData();
            //}

            var DataContainerOfStatusAndRowData = new { data = lstStudentDetail, recordsFiltered = lstStudentDetail.Count };
            return Json(DataContainerOfStatusAndRowData);
        }

        /// <summary>
        /// Create a student
        /// </summary>
        /// <param name="oStudentDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateStudentData(StudentDetail oStudentDetail)
        {
            List<StudentDetail> lstStudentDetail = new List<StudentDetail>();


            lstStudentDetail = GetAllStudentData();

            //if (FilterData != null && FilterData.FilterQuery != "") {
            //     lstStudentDetail = GetFilteredSudentData(FilterData);
            //}
            //else {
            //    lstStudentDetail = GetAllStudentData();
            //}

            var DataContainerOfStatusAndRowData = new { data = lstStudentDetail, recordsFiltered = lstStudentDetail.Count };
            return Json(DataContainerOfStatusAndRowData);
        }


        
        [HttpPost]
        public ActionResult DeleteStudentData(int StudentId)
        {
            List<StudentDetail> lstStudentDetail = new List<StudentDetail>();


            lstStudentDetail = GetAllStudentData();

            //if (FilterData != null && FilterData.FilterQuery != "") {
            //     lstStudentDetail = GetFilteredSudentData(FilterData);
            //}
            //else {
            //    lstStudentDetail = GetAllStudentData();
            //}

            var DataContainerOfStatusAndRowData = new { data = lstStudentDetail, recordsFiltered = lstStudentDetail.Count };
            return Json(DataContainerOfStatusAndRowData);
        }
        #endregion

        #region Hard Coded Data
        /// <summary>
        /// Return list of 5 students Hard Coded. 
        /// Retrieve  from Database Later
        /// </summary>
        /// <param name="FilterData"></param>
        /// <returns></returns>
        public List<StudentDetail> GetAllStudentData()
        {
            string E = "English";
            string M = "Maths";
            string S = "Science";


            List<StudentDetail> lstStudentDetail = new List<StudentDetail>();

            #region StudentData Hard Coded

            StudentDetail StudentDetail1 = new StudentDetail();


            //////////////////////////////////////////////////////////////////
            SubjectData SubjectData1 = new SubjectData();


            List<SubjectData> StudentDetailList = new List<SubjectData>();
            SubjectData1.StudentId = 1;
            SubjectData1.SubjectMarks = 53;
            SubjectData1.SubjectName = E;
            StudentDetailList.Add(SubjectData1);

            SubjectData SubjectData2 = new SubjectData();
            SubjectData2.StudentId = 1;
            SubjectData2.SubjectMarks = 73;
            SubjectData2.SubjectName = M;
            StudentDetailList.Add(SubjectData2);

            SubjectData SubjectData3 = new SubjectData();
            SubjectData3.StudentId = 1;
            SubjectData3.SubjectMarks = 23;
            SubjectData3.SubjectName = S;
            StudentDetailList.Add(SubjectData3);



            StudentDetail1.StudentId = 1;
            StudentDetail1.FirstName = "Tom";
            StudentDetail1.LastName = "Kerry";
            StudentDetail1.Class = "1";
            StudentDetail1.SubjectDataList = StudentDetailList;



            //////////////////////////////////////////////////////////////////
            StudentDetail StudentDetail2 = new StudentDetail();

            List<SubjectData> StudentDetailList2 = new List<SubjectData>();

            SubjectData SubjectData5 = new SubjectData();
            SubjectData5.StudentId = 2;
            SubjectData5.SubjectMarks = 63;
            SubjectData5.SubjectName = E;
            StudentDetailList2.Add(SubjectData5);

            SubjectData SubjectData4 = new SubjectData();
            SubjectData4.StudentId = 2;
            SubjectData4.SubjectMarks = 23;
            SubjectData4.SubjectName = S;
            StudentDetailList2.Add(SubjectData4);



            StudentDetail2.StudentId = 2;
            StudentDetail2.FirstName = "Jim";
            StudentDetail2.LastName = "Harper";
            StudentDetail2.Class = "5";
            StudentDetail2.SubjectDataList = StudentDetailList2;

            //////////////////////////////////////////////////////////////////
            StudentDetail StudentDetail3 = new StudentDetail();


            List<SubjectData> StudentDetailList3 = new List<SubjectData>();

            SubjectData SubjectData6 = new SubjectData();
            SubjectData6.StudentId = 3;
            SubjectData6.SubjectMarks = 66;
            SubjectData6.SubjectName = E;
            StudentDetailList3.Add(SubjectData6);

            SubjectData SubjectData7 = new SubjectData();
            SubjectData7.StudentId = 3;
            SubjectData7.SubjectMarks = 35;
            SubjectData7.SubjectName = M;
            StudentDetailList3.Add(SubjectData7);



            StudentDetail3.StudentId = 3;
            StudentDetail3.FirstName = "Karen";
            StudentDetail3.LastName = "Core";
            StudentDetail3.Class = "3";
            StudentDetail3.SubjectDataList = StudentDetailList3;

            //////////////////////////////////////////////////////////////////
            StudentDetail StudentDetail4 = new StudentDetail();


            List<SubjectData> StudentDetailList4 = new List<SubjectData>();

            SubjectData SubjectData8 = new SubjectData();
            SubjectData8.StudentId = 4;
            SubjectData8.SubjectMarks = 67;
            SubjectData8.SubjectName = S;
            StudentDetailList4.Add(SubjectData6);

            SubjectData SubjectData9 = new SubjectData();
            SubjectData9.StudentId = 4;
            SubjectData9.SubjectMarks = 45;
            SubjectData9.SubjectName = M;
            StudentDetailList4.Add(SubjectData7);



            StudentDetail4.StudentId = 4;
            StudentDetail4.FirstName = "Karen";
            StudentDetail4.LastName = "Core";
            StudentDetail4.Class = "3";
            StudentDetail4.SubjectDataList = StudentDetailList4;
            //////////////////////////////////////////////////////////////////
            StudentDetail StudentDetail5 = new StudentDetail();


            List<SubjectData> StudentDetailList5 = new List<SubjectData>();

            SubjectData SubjectData10 = new SubjectData();
            SubjectData10.StudentId = 5;
            SubjectData10.SubjectMarks = 67;
            SubjectData10.SubjectName = S;
            StudentDetailList5.Add(SubjectData10);

            SubjectData SubjectData11 = new SubjectData();
            SubjectData11.StudentId = 5;
            SubjectData11.SubjectMarks = 45;
            SubjectData11.SubjectName = M;
            StudentDetailList5.Add(SubjectData11);



            StudentDetail5.StudentId = 5;
            StudentDetail5.FirstName = "Alice";
            StudentDetail5.LastName = "Glass";
            StudentDetail5.Class = "3";
            StudentDetail5.SubjectDataList = StudentDetailList5;


            //////////////////////////////////////////////////////////////////
            StudentDetail StudentDetail6 = new StudentDetail();


            List<SubjectData> StudentDetailList6 = new List<SubjectData>();

            SubjectData SubjectData12 = new SubjectData();
            SubjectData12.StudentId = 6;
            SubjectData12.SubjectMarks = 62;
            SubjectData12.SubjectName = E;
            StudentDetailList6.Add(SubjectData12);

            SubjectData SubjectData13 = new SubjectData();
            SubjectData13.StudentId = 6;
            SubjectData13.SubjectMarks = 15;
            SubjectData13.SubjectName = M;
            StudentDetailList6.Add(SubjectData13);



            StudentDetail6.StudentId = 6;
            StudentDetail6.FirstName = "Ali";
            StudentDetail6.LastName = "Glass";
            StudentDetail6.Class = "3";
            StudentDetail6.SubjectDataList = StudentDetailList6;


            //////////////////////////////////////////////////////////////////
            StudentDetail StudentDetail7 = new StudentDetail();


            List<SubjectData> StudentDetailList7 = new List<SubjectData>();

            SubjectData SubjectData14 = new SubjectData();
            SubjectData14.StudentId = 7;
            SubjectData14.SubjectMarks = 67;
            SubjectData14.SubjectName = S;
            StudentDetailList5.Add(SubjectData14);

            SubjectData SubjectData15 = new SubjectData();
            SubjectData15.StudentId = 7;
            SubjectData15.SubjectMarks = 45;
            SubjectData15.SubjectName = M;
            StudentDetailList5.Add(SubjectData15);



            StudentDetail7.StudentId = 5;
            StudentDetail7.FirstName = "James";
            StudentDetail7.LastName = "Mcvoy";
            StudentDetail7.Class = "3";
            StudentDetail7.SubjectDataList = StudentDetailList7;


            #endregion

            lstStudentDetail.Add(StudentDetail1);
            lstStudentDetail.Add(StudentDetail2);
            lstStudentDetail.Add(StudentDetail3);
            lstStudentDetail.Add(StudentDetail4);
            lstStudentDetail.Add(StudentDetail5);
            lstStudentDetail.Add(StudentDetail6);
            lstStudentDetail.Add(StudentDetail7);

            return lstStudentDetail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFilteredSudentData(CFilterData FilterData)
        {
            List<StudentDetail> lstStudentDetail = new List<StudentDetail>();

            if (FilterData != null)
            {
                //lstStudentDetail = GetFilteredSudentData(FilterData);
            }
            else
            {
                lstStudentDetail = GetAllStudentData();
            }


            return Json(lstStudentDetail);
        }



        #endregion

        #region Unused
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }

}