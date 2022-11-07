<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="recieveTran.aspx.cs" Inherits="web4.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">

    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">استلام معاملة</h6>
        </div>
        <div class="card-body">
            <div class="row flex-row-reverse px-5 py-2 label-padding">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr style="text-align: right">
                                <th>رقم المعاملة</th>
                                <th>الحالة</th>
                                <th>استلام المعاملة</th>
                            </tr>

                        </thead>
                        <tfoot>
                            <tr style="text-align: right">
                                <th>رقم المعاملة</th>
                                <th>الحالة</th>
                                <th>استلام المعاملة</th>
                            </tr>
                        </tfoot>
                        <tbody>

                            <% Print_Table(); %>
                        </tbody>
                    </table>
                </div>
                <%--<div class="col-6 px-4">
                    <div class="row flex-row-reverse ">
                        <label>:ارفاق صورة</label>
                    </div>
                    <div class="row">
                        <input type="file" class="form-control form-control-user"
                            name="senderAdress" id="senderAdress" aria-describedby="emailHelp"
                            placeholder="الجهة المرسل اليها" style="margin-left: 50px" required>
                    </div>
                </div>--%>
                <%--<div class="col-6 pe-2">
                    <div class="row flex-row-reverse">
                        <label>:كتابة ملاحظة</label>
                    </div>
                    <div class="row">
                        <select name="comment" class="form-control form-control-user" style="margin-left: 50px">
                            <option value="none" selected disabled hidden>اختر تعليق</option>
                            <option value="1">تم التسليم بنجاح</option>
                            <option value="2">حدث خطأ</option>
                            <option value="3">مدري</option>

                        </select>
                    </div>
                </div>--%>
                <%--<div class="form-group">
                    <asp:Button type="button" ID="submit" class="btn btn-primary w-100 btn-padding" Text="إرسال" runat="server" />
                </div>--%>
            </div>
        </div>
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
        Launch demo modal
    </button>
    </div>

<!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="vendor/jquery/jquery.min.js" />
            <%--<asp:ScriptReference Path="vendor/bootstrap/js/bootstrap.bundle.min.js" />--%>
                        <asp:ScriptReference Path="Scripts/bootstrap.bundle.min.js" />

            <asp:ScriptReference Path="vendor/jquery-easing/jquery.easing.min.js" />
            <asp:ScriptReference Path="js/sb-admin-2.min.js" />
            <asp:ScriptReference Path="vendor/datatables/jquery.dataTables.min.js" />
            <asp:ScriptReference Path="vendor/datatables/dataTables.bootstrap4.min.js" />
            <asp:ScriptReference Path="js/demo/datatables-demo.js" />
        </Scripts> 
    </asp:ScriptManager>
</asp:Content>
