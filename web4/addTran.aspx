<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="addTran.aspx.cs" Inherits="web4.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card shadow mb-4">
        <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">إضافة معاملة</h6>
            </div>
        <div class="card-body">
            <div class="row flex-row-reverse px-5 py-2">
                <div class="col-6 px-4">
                    <div class="row flex-row-reverse">
                        <label>:اسم الموظف</label>
                    </div>
                    <div class="row">

                        <%print_names(); %>
                        
                    </div>
                </div>

                <div class="col-6 pe-2">
                    <div class="row flex-row-reverse">
                        <label>:تاريخ الاستلام</label>
                    </div>
                    <div class="row">
                            <input type="date" class="form-control form-control-user"
                            name="reciveDate" id="reciveDate" aria-describedby="emailHelp"
                            placeholder="تاريخ الإستلام" runat="server">
                    </div>
                </div>
            </div>

            <div class="row flex-row-reverse px-5 py-2">
                <div class="col-6 px-4">
                    <div class="row flex-row-reverse">
                        <label>:المستلم</label>
                    </div>
                    <div class="row">
                        <input type="text" name="reciever" class="form-control form-control-user"
                            id="reciever" aria-describedby="emailHelp"
                            placeholder="المستلم" runat="server">
                    </div>
                </div>

                <div class="col-6 pe-2">
                    <div class="row flex-row-reverse">
                        <label>:الجهة المرسل إليها</label>
                    </div>
                    <div class="row">
                            <input type="text" class="form-control form-control-user"
                            name="senderAdress" id="senderAdress" aria-describedby="emailHelp"
                            placeholder="الجهة المرسل اليها" runat="server">
                    </div>
                </div>
            </div>
            
            <div class="row flex-row-reverse px-5 py-2">
                <div class="col-6 px-4">
                    <div class="row flex-row-reverse">
                        <label>:الجهة الواردة</label>
                    </div>
                    <div class="row">
                        <input type="text" class="form-control form-control-user"
                            name="recieverAdress" id="recieverAdress" aria-describedby="emailHelp"
                            placeholder="الجهة الواردة" runat="server">
                    </div>
                </div>

                <div class="col-6 pe-2">
                    <div class="row flex-row-reverse">
                        <label>:رقم المعاملة</label>
                    </div>
                    <div class="row">
                            <input type="text" class="form-control form-control-user"
                            name="tranID" id="tranID" aria-describedby="emailHelp"
                            placeholder="رقم المعاملة" runat="server">
                    </div>
                </div>
            </div>
           

            <div class="form-group">
            <asp:Button type="button" ID="submit" class="btn btn-primary w-100"  OnClick="submit_Click" Text="إرسال" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>
