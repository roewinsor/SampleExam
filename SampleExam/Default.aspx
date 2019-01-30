<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleExam._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField id="patienId" runat="server" />  
  <div class="form-group">
       <label for="" id="labelResult">Full Name:</label>

    <label for="labelFullName">Full Name:</label>
        <div class="row">
            <div class="col">
              <input runat="server" type="text" class="form-control" id= "FirstName" placeholder="First name">
            </div>
            <div class="col">
              <input type="text" runat="server"  class="form-control" id= "LastName" placeholder="Last name">
            </div>
        </div>
  </div>

  <div class="form-group">
        <div class="row">
            <div class="col">
              <label for="Email">Email address:</label>
               <input type="email" runat="server"  class="form-control" id="Email" placeholder="name@example.com">
            </div>
            <div class="col">
                <label for="Phone">Phone Number:</label>
              <input type="text" runat="server"  class="form-control" id= "Phone" placeholder="Phone">
            </div>
        </div>
  </div>

<label for="GenderMale">Gender:</label>
<asp:RadioButtonList ID="GenderRadio" runat="server">
    <asp:ListItem Text="Male" Value="male" />
    <asp:ListItem Text="Female" Value="female" />
</asp:RadioButtonList>


  <div class="form-group">
    <label for="Note">Notes:</label>
    <textarea class="form-control" id="Note" rows="3" runat="server" ></textarea>
  </div>

    <asp:button type="button" Text="SAVE" ID="ButtonSave" class="btn btn-primary btn-lg btn-dark" runat="server" OnClick="ButtonSave_Click" />

</asp:Content>
