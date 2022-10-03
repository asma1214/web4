<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="web4.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <body>
    <div id="Box" style="background-color: salmon; width: 100px; height: 100px; display: none;" >
      Box 1
    </div>

    <button type="button" ID="submit" class="btn btn-primary w-100" OnClick="submit_Click" Text="Login">Hide div</button>

    <script src="js/showTable.js"></script>
  </body>
</asp:Content>
