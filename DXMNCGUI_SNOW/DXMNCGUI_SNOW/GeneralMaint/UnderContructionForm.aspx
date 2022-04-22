<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="UnderContructionForm.aspx.cs" Inherits="DXMNCGUI_SNOW.GeneralMaint.UnderContructionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <dx:ASPxFormLayout runat="server" ID="DXFormLayout" Width="100%">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
        <Items>
            <dx:LayoutGroup Caption="" GroupBoxDecoration="None" ColCount="2" UseDefaultPaddings="false" Paddings-PaddingTop="10" HorizontalAlign="Center" Width="100%" Height="100%">
                    <GroupBoxStyle>
                        <Caption Font-Bold="false" Font-Size="16" />
                    </GroupBoxStyle>
                <Items>
                    <dx:LayoutItem ShowCaption="false" HorizontalAlign="Center" Width="100%">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxImage runat="server" ID="ASPxImage2" Width="100%" ImageUrl="~/Content/Image/UnderConstruction.png" Border-BorderWidth="0" ImageAlign="Middle">
                                </dx:ASPxImage>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
                <Items>
                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center" Width="100%">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
</asp:Content>
