<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="mngUsr.aspx.cs" Inherits="web4.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%try
        {  %>
    <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">المعاملات</h6>
            </div>
        <div class="card-body">
            <div class="p-5 flex-row-reverse">
                 <div class="form-group emailMng">
                       <label>:البريد الالكتروني</label>
                        <input type="text" class="form-control form-control-user"
                            id="email" aria-describedby="emailHelp"
                            placeholder="البريد الإلكتروني" runat="server">
                    </div>
                <div class="form-group empName">
                       <label>:اسم الموظف</label>
                        <input type="text" class="form-control form-control-user"
                            id="empName" aria-describedby="emailHelp"
                            placeholder="إسم الموظف" runat="server">
                    </div>

                 
                <div class="form-group">
                <asp:Button type="button" ID="submit" class="btn btn-primary w-100" OnClick="submit_Click" Text="إرسال" runat="server" />
                    </div>
                <%if (flag == true)
                    { %>
                <script>
                    Swal.fire({
                        icon:'<%= icon %>',
                        title: '<%= title %>',
                        text: '<%= msg %>',
                    });
                </script>
                <%} %>

                </div>
            </div>
        </div>
    <%}
         catch(HttpRequestValidationException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="vendor/jquery/jquery.min.js" />
             <asp:ScriptReference Path="Scripts/bootstrap.bundle.min.js" />
            <asp:ScriptReference Path="js/showTable.js" />

        </Scripts> 
    </asp:ScriptManager>

</asp:Content>
