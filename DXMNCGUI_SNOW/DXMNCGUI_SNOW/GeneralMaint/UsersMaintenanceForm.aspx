<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="UsersMaintenanceForm.aspx.cs" Inherits="DXMNCGUI_SNOW.GeneralMaint.UsersMaintenanceForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript">
    </script>

    <dx:ASPxPopupControl ID="apcconfirm" ClientInstanceName="apcconfirm" runat="server" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Alert Confirmation!" AllowDragging="True" PopupAnimationType="None" EnableViewState="False">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2">
                    <Items>
                        <dx:LayoutItem Caption="" ColSpan="2" ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                    <dx:ASPxLabel ID="lblmessage" ClientInstanceName="lblmessage" runat="server" Text="">
                                    </dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                                    <dx:ASPxButton ID="btnSaveConfirm" runat="server" Text="OK" AutoPostBack="False" UseSubmitBehavior="false">
                                        <ClientSideEvents Click="function(s, e) { apcconfirm.Hide();gvIncidentList.PerformCallback(gvIncidentList.cplblActionButton + ';'+gvIncidentList.cplblActionButton); }" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                                    <dx:ASPxButton ID="btnCancelConfirm" runat="server" Text="Cancel" AutoPostBack="False" UseSubmitBehavior="false">
                                        <ClientSideEvents Click="function(s, e) { apcconfirm.Hide(); }" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="apcalert" ClientInstanceName="apcalert" runat="server" Modal="True"
        PopupHorizontalAlign="WindowCenter" AutoUpdatePosition="true" ShowCloseButton="true" PopupVerticalAlign="WindowCenter" HeaderText="Alert Warning!" AllowDragging="True" PopupAnimationType="None"
        EnableViewState="False" Width="400" Height="200">
    </dx:ASPxPopupControl>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
        <Items>
            <dx:LayoutGroup GroupBoxDecoration="HeadingLine" Caption="Users Maintenance">
                <GroupBoxStyle>
                    <Caption ForeColor="SlateGray" Font-Size="Larger" Font-Bold="true"></Caption>
                </GroupBoxStyle>
                <Items>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxCardView
                                    runat="server"
                                    ID="cvMain"
                                    ClientInstanceName="cvMain"
                                    Border-BorderStyle="Ridge" 
                                    DataSourceID="sdsUsers" 
                                    AutoGenerateColumns="False" 
                                    Theme="MetropolisBlue" 
                                    EnablePagingCallbackAnimation="true" 
                                    EnableCallbackAnimation="true">
                                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                    <Settings ShowHeaderPanel="False"></Settings>
                                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                                    <Columns>
                                        <dx:CardViewBinaryImageColumn Name="colImage" VisibleIndex="0" Caption="Image" PropertiesBinaryImage-EmptyImage-Url="../Content/Image/UserMtcIcon-128x128.png">
                                            <PropertiesBinaryImage ImageWidth="64px" ImageHeight="64px"/>
                                        </dx:CardViewBinaryImageColumn>
                                        <dx:CardViewTextColumn Name="colNIK" VisibleIndex="1" Caption="User ID" FieldName="NIK">
                                        </dx:CardViewTextColumn>
                                        <dx:CardViewTextColumn Name="colFULLNAME" VisibleIndex="2" Caption="Name" FieldName="FULLNAME">
                                        </dx:CardViewTextColumn>
                                    </Columns>
                                </dx:ASPxCardView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:SqlConnectionString %>" ProviderName="<%$ ConnectionStrings:SqlConnectionString.ProviderName %>" 
                    SelectCommand="SELECT NIK, UPPER(FULLNAME) AS FULLNAME FROM Users ORDER BY FULLNAME">
    </asp:SqlDataSource>
</asp:Content>
