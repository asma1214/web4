<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="web4.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">التقارير</h6>
                        </div>
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <%--<div class="col-lg-6 d-none d-lg-block bg-login-image"></div>--%>
                            <div class="col-lg-6">
                                <div class="p-5">
                                        <div class="form-group">
                                            <input type="email" class="form-control form-control-user"
                                                id="empName" aria-describedby="emailHelp"
                                                placeholder="أسم الموظف" runat="server">
                                        </div>
                                        <hr>
                                        <div class="form-group">
                                            <input type="date" class="form-control form-control-user"
                                                id="fromDate" name="fromDate" placeholder="من تاريخ" runat="server">
                                        </div>
                                         <div class="form-group">
                                            <input type="date" class="form-control form-control-user"
                                                id="toDate" placeholder="الى تاريخ"  runat="server">
                                        </div>
                                    <%--<button type="button" ID="submit" class="btn btn-primary w-100" OnClick="submit_Click" Text="Login" runat="server">Hide div</button>--%>
                                        <asp:Button type="button" ID="submit" class="btn btn-primary w-100" OnClick="submit_Click" Text="submit"  runat="server"/>
                                  <%--  <asp:ScriptManager runat="server" ID="sm">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:Button type="button" ID="Button1" class="btn btn-primary w-100" OnClientClick="javascript:return showTable();" OnClick="submit_Click" Text="Login" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>
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
                                </tbody>
                            </table>

                        </div>
                    </div>


            </div>

        </div>
    </div>
        <script src="js/showTable.js"></script>




    </body>


</asp:Content>
