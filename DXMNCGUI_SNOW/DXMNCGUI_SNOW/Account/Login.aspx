<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DXMNCGUI_SNOW.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, maximum-scale=1.0, minimum-scale=1.0" />
    <title>SNOW Helpdesk Management</title>
    <link rel="icon" type="image/png" href="../Content/Image/favicon.png"/>
    <link rel="stylesheet" type="text/css" href="Content/Site.css"  />
    <style type="text/css">
        .auto-style1 {
            height: 120px;
            width: 166px;
        }
        .auto-style7 {
            height: 22px;
        }
        .auto-style8 {
            height: 31px;
        }
        .auto-style9 {
            height: 12px;
        }
        .auto-style10 {
            height: 15px;
        }
        .auto-style11 {
            height: 13px;
            width: 166px;
        }
        .auto-style12 {
            color: #FFFFFF;
        }
        </style>
</head>
<script type="text/javascript">
          function upper(ustr)
          {
              var str = ustr.value;
              ustr.value = str.toUpperCase();
          }
</script>
<body runat="server" id="Body" style=" margin-top: 0; margin-bottom: 0; margin-left: 0; margin-right: 0;height:100%;)">
    <form id="form1" runat="server">
        
        <dx:ASPxPanel ID="MainPane" runat="server" CssClass="mainContentPane" Collapsible="True" Height="100%" Width="100%" Border-BorderColor="#112e5e" >
            <SettingsAdaptivity CollapseAtWindowInnerWidth="350"/>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent2" runat="server" SupportsDisabledAttribute="True">
                     <div class="headerTop">
                            
                            <div class="templateTitle">
                                <table><tr><td>
                                                                    <a id="A1" runat="server"><dx:ASPxImage ID="ASPxImage1" runat="server" Height="45px" ImageUrl=""></dx:ASPxImage> </a>

                                           </td></tr>
                                    <tr><td>
                                                                        <a id="A3" runat="server"> </a>

                                        </td></tr>
                                </table>

                                 </div></div>
                     <div style="width:99%; min-height: 98%; height:98%; ">
        <table cellpadding="0" cellspacing="0" width="100%" border="0" style="height: 100%;">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" width="400px" style=" height: 400px; border: solid 1px silver; background-color:#112e5e;">
                        <tr>
                            <td align="center">
                                <table>
                                        <tr><td class="auto-style11" style="text-align:center" align="center">                                        
                                        <asp:HyperLink  Font-Bold="true" ID="HyperLink1" NavigateUrl="~/Account/RegisterSuccess.aspx" runat="server" ForeColor="White"></asp:HyperLink>
                                        
                                        </td></tr>
                                    <tr><td class="auto-style11">
                                        
                                        <asp:HyperLink ID="RegisterHyperLink" Font-Bold="true" NavigateUrl="~/Account/Register.aspx" runat="server" ViewStateMode="Disabled" Visible="False">Register as a new user</asp:HyperLink>
                                        
                                        </td></tr>
                                    <tr>
                                        <td align="center" class="auto-style1">
                                                                            <a id="A2" href="http://www.mnc-leasing.com/" runat="server"><dx:ASPxImage ID="ASPxImage2" runat="server" Height="50px" ImageUrl="~/Content/Image/SnowLogo.png" Width="220px"></dx:ASPxImage> </a>

                                                                             <span class="auto-style12">Helpdesk Management</span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="auto-style7">
                                <dx:ASPxTextBox ID="txtUserName" runat="server" CssClass="TextBox"  style="text-transform: uppercase" Width="200px" Caption="Username" Theme="BlackGlass"> 
                                    <CaptionSettings Position="Top"/>
                                    <CaptionStyle ForeColor="WhiteSmoke"></CaptionStyle>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>                       
                            <td align="center" class="auto-style8">                                                              
                                <dx:ASPxTextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password" Width="200px" Password="true" Caption="Password" Theme="BlackGlass">
                                    <CaptionSettings Position="Top"/>
                                    <CaptionStyle ForeColor="WhiteSmoke"></CaptionStyle>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr height="5px">
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="auto-style10">
                                <dx:ASPxButton ID="btnLogin" runat="server" Font-Bold="true" OnClick="btnLogin_Click" Text="Login" Width="200px" Height="30px"></dx:ASPxButton>
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="center">
                                <asp:Label ID="lblMessage" runat="server" CssClass="ValidationMessage" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                         <tr height="50px">
                            <td align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="ValidationMessage" ForeColor="Snow" Text-="" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="30px">
                <td align="center" style="font-family: Calibri, Arial; font-size: 8pt; color: steelblue;">
                    <asp:Label ID="lblVersion" runat="server" ForeColor="White"></asp:Label>
                </td>
            </tr>
        </table>
                         </td>
                         </tr>
                         </table>
    </div>

                </dx:PanelContent>
            </PanelCollection>
            <BackgroundImage HorizontalPosition="center" Repeat="NoRepeat" VerticalPosition="center" />

<Border BorderColor="Transparent"></Border>
        </dx:ASPxPanel>
     
<%-- DXCOMMENT: Configure a datasource for the header menu --%>
<asp:XmlDataSource ID="XmlDataSourceHeader" runat="server" DataFile="~/App_Data/TopMenu.xml"
    XPath="/items/*"></asp:XmlDataSource>

    
    </form>
</body>  
</html>
