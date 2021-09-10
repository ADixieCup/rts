<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RTSLabs.aspx.vb" Inherits="RTSLabs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>RTS Labs Code Exercise</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
    

    <style type="text/css">
        .margin{
            margin-left: 20px; 
        }
        .padding{
            padding-top: 10px; 
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="margin">
            <p> #1 - Print the number of integers in an array that are above the given input and the number that are below, e.g. for the array [1, 5, 2, 1, 10] with input 6, print “above: 1, below: 4”.</p>
            
            
            <asp:CheckBox ID="bolUsePreDefined" AutoPostBack="true" runat="server" Text="Use Pre-defined parameters" /> 


            <table rowspan="2">
                <tr>
                    <td>Delimiter: </td>
                    <td>
                        <asp:TextBox ID="txtDelimiter" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Delimited Array:</td>
                    <td>
                        <asp:TextBox ID="txtDelimitedArray" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Compare Value:</td>
                    <td>
                        <asp:TextBox ID="txtCompareValue" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><div class="padding">
                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" /> </div></td>
                </tr>
            </table>
            <div>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

            </div>

        </div>


        <div class="margin padding">
            <p> #2 Rotate the characters in a string by a given input and have the overflow appear at the beginning, e.g. “MyString” rotated by 2 is “ngMyStri”.</p>
            
            
            <asp:CheckBox ID="bolTwoUsePredefined" AutoPostBack="true" runat="server" Text="Use Pre-defined parameters" /> 


            <table >
                <tr>
                    <td>String: </td>
                    <td>
                        <asp:TextBox ID="txtString" runat="server"></asp:TextBox></td>
                </tr>
               <tr>
                    <td>Rotate Value:</td>
                    <td>
                        <asp:TextBox ID="txtRotateValue" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><div class="padding">
                        <asp:Button ID="btnTwoSubmit" CssClass="btn btn-success" runat="server" Text="Submit" /> </div></td>
                </tr>
            </table>
            <div>
                <asp:Label ID="lblTwoError" runat="server" ForeColor="Red" Text=""></asp:Label>
                <asp:Label ID="lblTwoOutput" runat="server" Text=""></asp:Label>

            </div>

        </div>


        <div class="margin padding">
            <p>#3 If you could change 1 thing about your favorite framework/language/platform (pick one), what would it be?</p>
            <p>I would make intellisense in Visual Studio a lot better. Over the years I've realized how much I don't use it. Intellisense barely functions in Visual Studio when coding Javascript. 
                I find myself not using it at all most times. 
            </p>
         </div>

    </form>





</body>
</html>
