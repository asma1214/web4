<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="userInbox.aspx.cs" Inherits="web4.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">

    <body>
<div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">المعاملات</h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>اسم الموظف</th>
                                            <th>تاريخ الاستلام</th>
                                            <th>المستلم</th>
                                            <th>الجهة المرسل اليها</th>
                                            <th>الجهة الواردة</th>
                                            <th>رقم المعاملة</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>اسم الموظف</th>
                                            <th>تاريخ الاستلام</th>
                                            <th>المستلم</th>
                                            <th>الجهة المرسل اليها</th>
                                            <th>الجهة الواردة</th>
                                            <th>رقم المعاملة</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                        
                                        <% Print_Table(); %>
                                    </tbody>
                                </table>

                            </div>
                        </div>
                    </div>
     
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="vendor/jquery/jquery.min.js" />
            <%--<asp:ScriptReference Path="vendor/bootstrap/js/bootstrap.bundle.min.js" />--%>
            <asp:ScriptReference Path="vendor/jquery-easing/jquery.easing.min.js" />
            <asp:ScriptReference Path="js/sb-admin-2.min.js" />
            <asp:ScriptReference Path="vendor/datatables/jquery.dataTables.min.js" />
            <asp:ScriptReference Path="vendor/datatables/dataTables.bootstrap4.min.js" />
            <asp:ScriptReference Path="js/demo/datatables-demo.js" />
        </Scripts> 
    </asp:ScriptManager>

        <%--<script src='<%=ResolveClientUrl("vendor/jquery/jquery.min.js") %>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("vendor/bootstrap/js/bootstrap.bundle.min.js") %>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("vendor/jquery-easing/jquery.easing.min.js") %>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("js/sb-admin-2.min.js") %>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("vendor/datatables/jquery.dataTables.min.js") %>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("vendor/datatables/dataTables.bootstrap4.min.js") %>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("js/demo/datatables-demo.js") %>' type="text/javascript"></script>--%>


        </body>

</asp:Content>
