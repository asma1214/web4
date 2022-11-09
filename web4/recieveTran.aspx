<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="recieveTran.aspx.cs" Inherits="web4.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">استلام معاملة</h6>
        </div>
        <div class="card-body">
            <div class="row flex-row-reverse px-5 py-2">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr style="text-align: right">
                                <th>رقم المعاملة</th>
                                <th>الحالة</th>
                            </tr>

                        </thead>
                        <tfoot>
                            <tr style="text-align: right">
                                <th>رقم المعاملة</th>
                                <th>الحالة</th>
                            </tr>
                        </tfoot>
                        <tbody>

                            <% Print_Table(); %>
                        </tbody>
                    </table>
                </div>
                <div>
                <hr />

                </div>
                <div class="col-6 px-4">
                    <div class="row flex-row-reverse ">
                        <label class="label-padding">:اختيار رقم المعاملة</label>
                    </div>
                    <div class="row">
                        <%print_names(); %>
                    </div>
                </div>


                <div class="col-6 pe-2">
                    <div class="row flex-row-reverse ">
                        <label class="label-padding">:ارفاق صورة</label>
                    </div>
                    <div class="row">
                        <asp:FileUpload class="form-control form-control-user"
                            name="img" id="img" aria-describedby="emailHelp"
                           style="margin-left: 50px" runat="server" required="required"/>
                        <%--<input type="file" class="form-control form-control-user"
                            name="senderAdress" id="senderAdress" aria-describedby="emailHelp"
                            placeholder="الجهة المرسل اليها" style="margin-left: 50px" >--%>
                    </div>
                </div>
                <div class="col-6 px-4">
                    <div class="row flex-row-reverse">
                        <label class="label-padding">:كتابة ملاحظة</label>
                    </div>
                    <div class="row">
                        <select id="comment" name="comment" class="form-control form-control-user" runat="server">
                            <option value="none" selected disabled hidden>اختر ملاحظة</option>
                            <option value="1">رفض الموظف الإستلام</option>
                            <option value="2">التوجيه خاطئ</option>
                            <option value="3">عدم وجود موظفين</option>
                            <option value="4">رفض الموظف التوقيع على البيان</option>
                            <option value="5">اخرى</option>

                        </select>
                    </div>
                </div>
            </div>
                <div class="form-group">
                    <asp:Button type="button" ID="submit" OnClick="submit_Click" class="btn btn-primary w-100" Text="إرسال" runat="server" />
                </div>
            <%if (flag1 == true)
              { %>
            <script>
                Swal.fire({
                    icon: '<%= icon %>',
                    title: '<%= title %>',
                    text: '<%= msg %>',
                });
                </script>
            <%} %>
        </div>
    </div>

    <div class="modal fade" id="recieveBut" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">استلام المعاملة</h1>

                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row flex-row-reverse">
                            <div class="col-6 px-4">
                                <div class="row flex-row-reverse ">
                                </div>
                                <div class="row">
                                </div>
                            </div>
                            <div class="col-6 pe-2">
                                <div class="row flex-row-reverse">
                                </div>
                                <div class="row">
                                </div>
                            </div>
                        </div>
                    </div>
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
