using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SampleExam.Business;
using SampleExam.Model;

namespace SampleExam
{
    public partial class PatientList : Page
    {
        protected PatientRecord PatientRecords { get; set;  }

        protected void Page_Load(object sender, EventArgs e)
        {
         

            var editParentId = Request.QueryString["patientId"];
            var deleteRecord = Request.QueryString["isDelete"];

            if (Page.IsPostBack)
            {

            }
            else
            {
                if (!String.IsNullOrEmpty(editParentId) && !String.IsNullOrEmpty(deleteRecord))
                {
                    DeletePatientRecord(editParentId, deleteRecord);
                }
            }

            var records = new PatientRecord();
             records.PatienList = PatientManagementService.GetAllPatientRecord().PatienList.Where(p => p.IsDeleted == false).ToList();
        
            PatientRecords = records;
        }

        private void DeletePatientRecord(string idString, string deleteRecord)
        {
            int id = Int32.Parse(idString);
            bool isDelete = Convert.ToBoolean(deleteRecord);
            var patientDelete = PatientManagementService.GetPatientById(id);

            patientDelete.IsDeleted = true;


            if (PatientManagementService.AddUpdatePatient(patientDelete))
            {
                Response.Write("<script>alert('Patient has been successfully deleted');</script>");
            }
            else
            {
                Response.Write("<script>alert('Failed deleting patient, please try again');</script>");
            }

        }


    }
}