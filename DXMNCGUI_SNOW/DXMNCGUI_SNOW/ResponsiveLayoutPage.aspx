<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="ResponsiveLayoutPage.aspx.cs" Inherits="DXMNCGUI_SNOW.ResponsiveLayoutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript" src="https://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0&amp;s=1"></script>
    <script type="text/javascript">
        var map = (function () {
            var bingMap = null;
            var mapElementID = "myMap";
            function getMapElement() { return document.getElementById(mapElementID); }
            function showMap() {
                if (!bingMap) {
                    createMap();
                }
            }
            function createMap() {
                if (typeof Microsoft.Maps.Map === "undefined") return;
                var mapOptions = {
                    credentials: "AtZnizoULRY3QZ8bx9uAmpHYfkyKLA-4-n9eWWiQnuLQrIwSqYko0LoTuO112RUC",
                    mapTypeId: Microsoft.Maps.MapTypeId.road,
                    zoom: 4,
                    center: new Microsoft.Maps.Location(-6.184197, 106.831435),
                    enableSearchLogo: false,
                    showScalebar: false,
                    useInertia: false,
                    disableKeyboardInput: true
                };
                bingMap = new Microsoft.Maps.Map(getMapElement(), mapOptions);
            }
            return {
                showMap: showMap,
                createMap: createMap
            };
        })();
        function onPopupShown(s, e) {
            var windowInnerWidth = window.innerWidth;
            if (popup.GetWidth() > windowInnerWidth) {
                s.SetWidth(windowInnerWidth);
                s.UpdatePosition();
            }
            map.showMap();
        }
    </script>
        <dx:ASPxPopupControl ID="Popup" runat="server" Width="400px" Height="400px" Theme="Office2010Silver"
        ShowPinButton="True" ShowRefreshButton="True" ShowCollapseButton="True" ShowMaximizeButton="True"
        ClientInstanceName="popup" PopupElementID="popupArea" ShowOnPageLoad="True"
        PopupVerticalAlign="TopSides" PopupHorizontalAlign="LeftSides"
        AllowDragging="True" AllowResize="false" CloseAction="CloseButton"
        ScrollBars="None" HeaderText="Map" ShowFooter="true" FooterText="" PopupAnimationType="Fade">
        <ContentStyle Paddings-Padding="0">
        </ContentStyle>
        <ClientSideEvents Shown="onPopupShown" EndCallback="map.createMap"></ClientSideEvents>
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div id='myMap' style="position: relative; width: 100%; height: 100%">
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
        <table style="float: left; width: 400px; height: 400px; margin-right: 50px; margin-bottom: 50px;" id="popupArea">
        <tr>
            <td style="cursor: pointer; text-align: center; white-space: nowrap;">Click here to invoke a popup window
            </td>
        </tr>
    </table>
</asp:Content>