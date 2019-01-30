using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SampleExam.Business;
using SampleExam.Model;

namespace SampleExam
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var editParentId = Request.QueryString["patientId"];
 

            if (Page.IsPostBack)
            {
 
            }
            else
            {
                if (!String.IsNullOrEmpty(editParentId))
                {
                    SetPatientValues(editParentId);
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int getId = 0;

            if(!String.IsNullOrEmpty(patienId.Value))
            {
                getId = Int32.Parse(patienId.Value);
            }

            var patient = new PatientModel()
            {
                Id = getId,
                FirstName = FirstName.Value,
                Lastname = LastName.Value,
                Email = Email.Value,
                Phone = Phone.Value,
                Gender = GenderRadio.SelectedValue,
                Note = Note.Value,
                CreatedDate = DateTime.Now,
                IsDeleted = false

            };

            if (PatientManagementService.AddUpdatePatient(patient))
            {
                Response.Write("<script>alert('Patient has been added/updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Failed adding patient, please try again');</script>");
            }

        }

        private void SetPatientValues(string idString)
        {
            int id = Int32.Parse(idString);
            var patientEdit = PatientManagementService.GetPatientById(id);
            patienId.Value = idString;
            FirstName.Value = patientEdit.FirstName;
            LastName.Value = patientEdit.Lastname;
            Email.Value = patientEdit.Email;
            Phone.Value = patientEdit.Phone;
            GenderRadio.SelectedValue = patientEdit.Gender;
            Note.Value = patientEdit.Note;
        }
    }
}