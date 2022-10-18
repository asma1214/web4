<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="web4.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <div class="form-group">
                        <input type="text" class="form-control form-control-user"
                            id="empName" aria-describedby="emailHelp"
                            placeholder="إسم الموظف" runat="server">
                    </div>
                    <hr>
                    <%} %>

                        <%--<label>من تاريخ</label>--%>
                    <div class="form-group">
                        <input type="date" class="form-control form-control-user"
                            id="fromDate" name="fromDate" placeholder="من تاريخ" runat="server">
                    </div>
                    <%--<label>الى تاريخ</label>--%>
                    <div class="form-group">
                        <input type="date" class="form-control form-control-user"
                            id="toDate" placeholder="الى تاريخ" runat="server">
                    </div>
                          <p class="newColor" id="flexRight"><%= errMsg %></p>
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

  
        <script src="js/showTable.js"></script>




    </body>


</asp:Content>
