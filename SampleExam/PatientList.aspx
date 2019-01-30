<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="SampleExam.PatientList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<table class="table table-striped">
  <thead>
    <tr>
      <th scope="col">First</th>
      <th scope="col">Last</th>
      <th scope="col">Email</th>
      <th scope="col">Phone</th>
      <th scope="col">Gender</th>
      <th scope="col">Notes</th>
      <th scope="col">Action</th>
    </tr>
  </thead>
  <tbody>
    <tr>
<% foreach (var patient in PatientRecords.PatienList) { %>
  <tr>
    <td><%= patient.FirstName %></td>
    <td><%= patient.Lastname %></td>
    <td><%= patient.Email %></td>
       <td><%= patient.Phone %></td>
       <td><%= patient.Gender %></td>
       <td><%= patient.Note %></td>
       <td>
           <a class="nav-link" href="/Default.aspx?patientId=<%= patient.Id %>">Edit<span class="sr-only"></span></a>
           <a class="nav-link" href="/PatientList.aspx?patientId=<%= patient.Id %>&&isDelete=true">Delete<span class="sr-only"></span></a>
       </td>
  </tr>
<% } %>
    </tr>

  </tbody>
</table>
</asp:Content>
