<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="web4.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">  
        .style1  
        {  
            width: 258px;  
        }  
        .style2  
        {  
            width: 239px;  
        }  
    </style> 
</head>
<body>
    <form id="form1" runat="server">
        <div>  
      
        <table style="width:100%;">  
            <tr>  
                <td class="style1">  
                    Enter Your Username:</td>  
                <td class="style2">  
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
                </td>  
                <td>  
                    <asp:Label ID="Label2" runat="server"></asp:Label>  
                </td>  
            </tr>  
            <tr>  
                <td class="style1">  
                    Enter Your Password:   
                </td>  
                <td class="style2">  
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
                </td>  
                <td>  
                    <asp:Label ID="Label1" runat="server"></asp:Label>  
                </td>  
            </tr>  
            <tr>  
                <td class="style1">  
                     </td>  
                <td class="style2">  
                     </td>  
                <td>  
                     </td>  
            </tr>  
            <tr>  
                <td class="style1">  
                     </td>  
                <td class="style2">  
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />  
                </td>  
                <td>  
                     </td>  
            </tr>  
        </table>  
      
    </div>  
    </form>
</body>
</html>
