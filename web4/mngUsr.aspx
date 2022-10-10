<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="mngUsr.aspx.cs" Inherits="web4.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link href="css/style.css" rel="stylesheet" />

    </head>
    <body>

        <div class="container-lg">
    <div class="table-responsive">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-8"><h2>Employee <b>Details</b></h2></div>
                    <div class="col-sm-4">
                        <button type="button" class="btn btn-info add-new"><i class="fa fa-plus"></i> Add New</button>
                    </div>
                </div>
            </div>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>الإسم</th>
                        <th>إسم المستخدم</th>
                        <th>رقم الهاتف</th>
                        <th>الإجراء</th>
                    </tr>
                </thead>
                <tbody>
                     <% Print_Table(); %>
                </tbody>
            </table>
        </div>
    </div>
</div>  
    </body>







 <%--   <script src="vendor/jquery/jquery.min.js"></script>
    <script src="userJS/popper.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="js/jsStyle.js"></script>--%>



    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
             <asp:ScriptReference Path="vendor/jquery/jquery.min.js" />
            <asp:ScriptReference Path="userJS/popper.min.js" />
            <%--<asp:ScriptReference Path="vendor/bootstrap/js/bootstrap.min.js" />--%>
            <asp:ScriptReference Path="js/jsStyle.js" />


          <%--  <asp:ScriptReference Path="vendor/jquery/jquery.min.js" />
            <asp:ScriptReference Path="userJS/popper.min.js" />
            <asp:ScriptReference Path="vendor/bootstrap/js/bootstrap.min.js" />
            <asp:ScriptReference Path="js/jsStyle.js" />--%>

            <%--<asp:ScriptReference Path="https://code.jquery.com/jquery-3.5.1.min.js" />
            <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" />
            <asp:ScriptReference Path="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" />     --%>
        </Scripts>
    </asp:ScriptManager>
</asp:Content>
