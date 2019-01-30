using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SampleExam.Model;
using SampleExam.Utils;


namespace SampleExam.Business
{
    public class PatientManagementService
    {
        private static string XmlFilePath = HttpContext.Current.Server.MapPath(@"~\Data\PatientRecords.xml");
        private static string SharedKey = WebConfigurationManager.AppSettings["secretKey"];

        public static bool AddUpdatePatient(PatientModel patient)
        {
            var result = GetAllPatientRecord();
            var serializerRec = new XmlSerializer(typeof(PatientRecord));
            TextWriter writer = new StreamWriter(XmlFilePath);

            result.PatienList.ForEach(i => {
                i.FirstName = SampleExamEncrypt.EncryptStringAES(i.FirstName, SharedKey);
                i.Lastname = SampleExamEncrypt.EncryptStringAES(i.Lastname, SharedKey);
                i.Email = SampleExamEncrypt.EncryptStringAES(i.Email, SharedKey);
                i.Gender = SampleExamEncrypt.EncryptStringAES(i.Gender, SharedKey);
                i.Phone = SampleExamEncrypt.EncryptStringAES(i.Phone, SharedKey);
                i.Note = i.Note;
                i.IsDeleted = i.IsDeleted;
            }
           );


            try
            {       //Edit if record exist
                    if (result.PatienList.Any(ptnt => ptnt.Id == patient.Id && ptnt.IsDeleted == false))
                    {
                        result.PatienList.Where(p => p.Id == patient.Id).ToList().ForEach(i => {
                                i.FirstName = SampleExamEncrypt.EncryptStringAES(patient.FirstName, SharedKey);
                                i.Lastname = SampleExamEncrypt.EncryptStringAES(patient.Lastname, SharedKey);
                            i.Email = SampleExamEncrypt.EncryptStringAES(patient.Email, SharedKey);
                            i.Gender = SampleExamEncrypt.EncryptStringAES(patient.Gender, SharedKey);
                            i.Phone = SampleExamEncrypt.EncryptStringAES(patient.Phone, SharedKey);
                            i.Note = patient.Note;
                                i.LastUpdatedDate = DateTime.Now;
                                i.IsDeleted = patient.IsDeleted;
                            }
                         );

                    }
                    else //add as new record
                    {
                     patient.Id = result.PatienList.Count + 1; 

                    patient.FirstName = SampleExamEncrypt.EncryptStringAES(patient.FirstName, SharedKey);
                    patient.Lastname = SampleExamEncrypt.EncryptStringAES(patient.Lastname, SharedKey);
                    patient.Email = SampleExamEncrypt.EncryptStringAES(patient.Email, SharedKey);
                    patient.Gender = SampleExamEncrypt.EncryptStringAES(patient.Gender, SharedKey);
                    patient.Phone = SampleExamEncrypt.EncryptStringAES(patient.Phone, SharedKey);
                    result.PatienList.Add(patient);

                    }

                serializerRec.Serialize(writer, result);

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
 
        }


        public static PatientRecord GetAllPatientRecord()
        {
            var serializerRec = new XmlSerializer(typeof(PatientRecord));
            var recordList = new PatientRecord();
            using (var reader = new StreamReader(XmlFilePath))
            {
                recordList = (PatientRecord)serializerRec.Deserialize(reader);
            };

            recordList.PatienList.ForEach(i => {
                i.FirstName = SampleExamEncrypt.DecryptStringAES(i.FirstName, SharedKey);
                i.Lastname = SampleExamEncrypt.DecryptStringAES(i.Lastname, SharedKey);
                i.Email = SampleExamEncrypt.DecryptStringAES(i.Email, SharedKey);
                i.Gender = SampleExamEncrypt.DecryptStringAES(i.Gender, SharedKey);
                i.Phone = SampleExamEncrypt.DecryptStringAES(i.Phone, SharedKey);

            });

            return recordList;
        }

        public static PatientModel GetPatientById(int id)
        {
            var getRecord = GetAllPatientRecord().PatienList.Where(p => p.Id == id && p.IsDeleted == false).SingleOrDefault();
          
            return getRecord;

        }
    }
}