<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="web4.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <%print_names(); %>

                <asp:Button type="button" ID="submit" class="btn btn-primary w-100"  OnClick="submit_Click" Text="إرسال" runat="server" />

</asp:Content>
