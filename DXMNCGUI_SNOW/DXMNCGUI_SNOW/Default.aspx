<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.cs" Inherits="DXMNCGUI_SNOW._Default" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
    function add_chatinline()
    {
        var hccid = 74235997;
        var nt = document.createElement("script");
        nt.async = true;
        nt.src = "https://mylivechat.com/chatinline.aspx?hccid=" + hccid;
        var ct = document.getElementsByTagName("script")[0];
        ct.parentNode.insertBefore(nt, ct);
    }
    add_chatinline();
    </script>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
        <Items>
            <dx:LayoutGroup GroupBoxDecoration="HeadingLine" Caption="">
                <GroupBoxStyle>
                    <Caption ForeColor="SlateGray" Font-Size="Larger" Font-Bold="true"></Caption>
                </GroupBoxStyle>
                <Items>
                    <dx:LayoutGroup Caption="" GroupBoxDecoration="None" ColCount="7" Width="100%" HorizontalAlign="Left">
                        <Items>           
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>                         
                                <dx:ASPxImage ID="Image1" runat="server" ImageUrl="~/Content/Image/DefaultWall.jpg" Width="600" Height="300" ImageAlign="Middle"></dx:ASPxImage>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
</asp:Content>