<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs"  Inherits="web4.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
<%--           <asp:PlaceHolder ID="placeHolder" runat="server" />--%>
           <%--<asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>--%>
           <asp:PlaceHolder runat="server" ID="PlaceHolder"></asp:PlaceHolder>
     <input type="text" name="trial" value="yes" onclick="print(id)" runat="server"/>
 <%--          <table>
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
                            <%=printTable()%>
                        </tbody>
           </table>--%>

<%--           <%printint(); %>--%>
          <%-- <%int count = 1;
               for(int i=0; i<2; i++)
            {
                Response.Write("<input type=\"text\" id=count name=\"trial\" value=\"yes\" runat=\"server\"/>");
            }%>--%>
           <%--<input type="button" id="trial1" name="trial" value="yes" runat="server"/>--%>
<%--           <input type="text" id="trial" name="trial" value="yes" runat="server"/>--%>
           <%--<input type="button" id="trial"  onclick="printnum" name="trial" value="yes" runat="server"/>--%>
           <%--<asp:Button ID="save"  Text="حفظ" CommandArgument="55" value="one" OnClick="printNum" runat="server" />--%>


    <%--<asp:Button ID="save" class="btn btn-primary" Text="حفظ" value="one" OnClick="submit_Click" runat="server" />--%>
            
        </div>
    </form>
</body>
</html>
