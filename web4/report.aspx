<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="web4.WebForm2" %>
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
                        <%--<label>إسم الموظف</label>--%>
                <div class="p-5">
                    <% string role = Session["role"].ToString();
                        if (role == "a")
                        {  %>
                    <div class="form-group empName">
                        <label for="empName">:اسم الموظف</label>
                        <input type="text" class="form-control form-control-user"
                            id="empName" aria-describedby="emailHelp"
                            placeholder="إسم الموظف" runat="server">
                    </div>
                    <hr>
                    <%} %>

                        <%--<label>من تاريخ</label>--%>
                    <div class="form-group startDate">
                         <label>:من تاريخ</label>
                        <input type="date" class="form-control form-control-user"
                            id="fromDate" name="fromDate" placeholder="من تاريخ" runat="server">
                    </div>
                    <%--<label>الى تاريخ</label>--%>
                    <div class="form-group dueDate">
                        <label>:إلى تاريخ</label>
                        <input type="date" class="form-control form-control-user"
                            id="toDate" placeholder="الى تاريخ" runat="server">
                    </div>
                          <p class="newColor" id="flexRight"> <%= errMsg %> </p>
                    <div class="form-group">

                        <asp:Button type="button" ID="submit" class="btn btn-primary w-100" OnClick="submit_Click" Text="submit" runat="server" />
                    </div>
                </div>
                </div>
                        <div  id="Box" class="table-responsive" style="display: none;">
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
                                
                                <tbody>
                                    <% Print_Table(); %>
                                </tbody>
                            </table>

                        </div>
            </div>

  
        <%--<script src="js/showTable.js"></script>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="vendor/jquery/jquery.min.js" />
             <asp:ScriptReference Path="Scripts/bootstrap.bundle.min.js" />
            <asp:ScriptReference Path="js/showTable.js" />

        </Scripts> 
    </asp:ScriptManager>




    </body>


</asp:Content>
