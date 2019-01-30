using System.Xml.Serialization;
using System;
using System.Collections.Generic;

namespace SampleExam.Model
{
    [XmlRoot(ElementName = "patientrecord")]
    public class PatientRecord
    {
        [XmlElement(ElementName = "patient")]
        public List<PatientModel> PatienList { get; set; }
    }

    [XmlRoot(ElementName = "patient")]
    public class PatientModel
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "firstname")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "lastname")]
        public string Lastname { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; }
        [XmlElement(ElementName = "note")]
        public string Note { get; set; }
        [XmlElement(ElementName = "createddate")]
        public DateTime CreatedDate { get; set; }
        [XmlElement(ElementName = "lastupdateddate")]
        public DateTime? LastUpdatedDate { get; set; }
        [XmlElement(ElementName = "isdeleted")]
        public bool IsDeleted { get; set; }
    }
}