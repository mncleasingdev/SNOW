<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="iTicketReporting.aspx.cs" Inherits="DXMNCGUI_SNOW.Transaction.Chart.iTicketReporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript">
        function OncbMonthChanged(cbMonth)
        {
            if (cbMonth.GetText() != "")
            {
                cplMain.PerformCallback("CBMONTH_CHANGED;" + cbMonth.GetValue().toString());
            }
        }
        function OncbYearChanged(cbYear)
        {
            if (cbYear.GetText() != "")
            {
                cplMain.PerformCallback("CBYEAR_CHANGED;" + cbYear.GetValue().toString());
            }
        }
        function OncbMonthMasterChanged(cbMonthMaster)
        {
            if (cbMonthMaster.GetText() != "") {
                cplMain.PerformCallback("CBMONTH_MASTER_CHANGED;" + cbMonthMaster.GetValue().toString());
            }
        }
        function OncbYearMasterChanged(cbYearMaster)
        {
            if (cbYearMaster.GetText() != "")
            {
                cplMain.PerformCallback("CBYEAR_MASTER_CHANGED;" + cbYearMaster.GetValue().toString());
            }
        }
        function cplMain_EndCallback()
        {
            switch (cplMain.cpCallbackParam)
            {
                case "CBMONTH_CHANGED":
                    gvIN.PerformCallback();
                    gvRQ.PerformCallback();
                    gvCDR.PerformCallback();
                    break;
                case "CBYEAR_CHANGED":
                    gvIN.PerformCallback();
                    gvRQ.PerformCallback();
                    gvCDR.PerformCallback();
                    break;
                case "CBMONTH_MASTER_CHANGED":
                    vgMain.PerformCallback();
                    break;
                case "CBYEAR_MASTER_CHANGED":
                    vgMain.PerformCallback();
                    break;
            }
            cplMain.cpCallbackParam = "";
        }
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
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800"/>
        <Items>
            <dx:LayoutGroup ShowCaption="True" Caption="Reporting" GroupBoxDecoration="HeadingLine" ColCount="3">
                <Items>
                    <dx:LayoutItem Width="100%" ShowCaption="True" Caption="Month" Visible="false">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxComboBox ID="cbMonthMaster" ClientInstanceName="cbMonthMaster" runat="server" Width="10%" OnInit="cbMonthMaster_Init" NullText="Month...">
                                    <ClientSideEvents Init="function(s, e) { OncbMonthMasterChanged(s); }" SelectedIndexChanged="function(s, e) { OncbMonthMasterChanged(s); }" />
                                    <Items>
                                        <dx:ListEditItem Text="1" Value="1" Selected="true"/>
                                        <dx:ListEditItem Text="2" Value="2"/>
                                        <dx:ListEditItem Text="3" Value="3"/>
                                        <dx:ListEditItem Text="4" Value="4"/>
                                        <dx:ListEditItem Text="5" Value="5"/>
                                        <dx:ListEditItem Text="6" Value="6"/>
                                        <dx:ListEditItem Text="7" Value="7"/>
                                        <dx:ListEditItem Text="8" Value="8"/>
                                        <dx:ListEditItem Text="9" Value="9"/>
                                        <dx:ListEditItem Text="10" Value="10"/>
                                        <dx:ListEditItem Text="11" Value="11"/>
                                        <dx:ListEditItem Text="12" Value="12"/>
                                    </Items>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Width="100%" ShowCaption="True" Caption="Year" Visible="false">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxComboBox ID="cbYearMaster" ClientInstanceName="cbYearMaster" runat="server" Width="10%" OnInit="cbYearMaster_Init" NullText="Year...">
                                    <ClientSideEvents Init="function(s, e) { OncbYearMasterChanged(s); }" SelectedIndexChanged="function(s, e) { OncbYearMasterChanged(s); }" />
                                    <Items>
                                        <dx:ListEditItem Text="2019" Value="2019" Selected="true"/>
                                        <dx:ListEditItem Text="2020" Value="2020"/>
                                        <dx:ListEditItem Text="2021" Value="2021"/>
                                        <dx:ListEditItem Text="2022" Value="2022"/>
                                        <dx:ListEditItem Text="2023" Value="2023"/>
                                        <dx:ListEditItem Text="2024" Value="2024"/>
                                        <dx:ListEditItem Text="2025" Value="2025"/>
                                    </Items>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False" Width="100%" ColSpan="3">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxVerticalGrid
                                    runat="server"
                                    ID="vgMain"
                                    ClientInstanceName="vgMain"
                                    Width="100%"
                                    Theme="Office2010Black" OnDataBinding="vgMain_DataBinding" OnCustomCallback="vgMain_CustomCallback">
                                    <Rows>
                                        <dx:VerticalGridCategoryRow Caption="Ticket Summary" CategoryStyle-BackColor="WhiteSmoke">
                                            <Rows>
                                                <dx:VerticalGridDataRow FieldName="TicketTipe" Caption="Ticket Type" Settings-AllowSort="False" Settings-AllowHeaderFilter="False" RecordStyle-Font-Bold="true" RecordStyle-HorizontalAlign="Center" />
                                                <dx:VerticalGridDataRow FieldName="TicketCount" Caption="Ticket Count" />
                                                <dx:VerticalGridDataRow FieldName="OpenStatus" Caption="Open" />
                                                <dx:VerticalGridDataRow FieldName="NeedApprovalStatus" Caption="Need Approval" />
                                                <dx:VerticalGridDataRow FieldName="OnProgressStatus" Caption="On Progress" />
                                                <dx:VerticalGridDataRow FieldName="HoldStatus" Caption="On Hold" />
                                                <dx:VerticalGridDataRow FieldName="CompleteStatus" Caption="Complete" />
                                                <dx:VerticalGridDataRow FieldName="RejectStatus" Caption="Reject" />
                                            </Rows>
                                        </dx:VerticalGridCategoryRow>
                                        <dx:VerticalGridCategoryRow Caption="Service Level Agreement (SLA)" CategoryStyle-BackColor="WhiteSmoke">
                                            <Rows>
                                                <dx:VerticalGridDataRow FieldName="Open to Grab < 15 MENIT" Caption="OTG < 15 Minutes" RecordStyle-Font-Bold="true" RecordStyle-ForeColor="Green" />
                                                <dx:VerticalGridDataRow FieldName="Open to Grab > 15 MENIT" Caption="OTG > 15 Minutes" RecordStyle-Font-Bold="true" RecordStyle-ForeColor="Red" />
                                            </Rows>
                                        </dx:VerticalGridCategoryRow>
                                    </Rows>
                                    <Settings ShowHeaderFilterButton="true" />
                                    <SettingsExport EnableClientSideExportAPI="true" />
                                    <SettingsBehavior EnableRowHotTrack="true" />
                                    <SettingsPager EnableAdaptivity="true" />
                                    <SettingsPopup>
                                        <HeaderFilter MinWidth="250">
                                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
                                        </HeaderFilter>
                                    </SettingsPopup>
                                    <Toolbars>
                                        <dx:VerticalGridToolbar ItemAlign="Right">
                                            <Items>
                                                <dx:VerticalGridToolbarItem Command="ExportToPdf" />
                                                <dx:VerticalGridToolbarItem Command="ExportToXlsx" />
                                            </Items>
                                        </dx:VerticalGridToolbar>
                                    </Toolbars>
                                </dx:ASPxVerticalGrid>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:EmptyLayoutItem Width="100%"></dx:EmptyLayoutItem>
                    <dx:LayoutItem Width="100%" ShowCaption="True" Caption="Month">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxComboBox ID="cbMonth" ClientInstanceName="cbMonth" runat="server" Width="10%" OnInit="cbMonth_Init">
                                    <ClientSideEvents Init="function(s, e) { OncbMonthChanged(s); }" SelectedIndexChanged="function(s, e) { OncbMonthChanged(s); }" />
                                    <Items>
                                        <dx:ListEditItem Text="1" Value="1" Selected="true"/>
                                        <dx:ListEditItem Text="2" Value="2"/>
                                        <dx:ListEditItem Text="3" Value="3"/>
                                        <dx:ListEditItem Text="4" Value="4"/>
                                        <dx:ListEditItem Text="5" Value="5"/>
                                        <dx:ListEditItem Text="6" Value="6"/>
                                        <dx:ListEditItem Text="7" Value="7"/>
                                        <dx:ListEditItem Text="8" Value="8"/>
                                        <dx:ListEditItem Text="9" Value="9"/>
                                        <dx:ListEditItem Text="10" Value="10"/>
                                        <dx:ListEditItem Text="11" Value="11"/>
                                        <dx:ListEditItem Text="12" Value="12"/>
                                    </Items>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Width="100%" ShowCaption="True" Caption="Year">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxComboBox ID="cbYear" ClientInstanceName="cbYear" runat="server" Width="10%" OnInit="cbYear_Init">
                                    <ClientSideEvents Init="function(s, e) { OncbYearChanged(s); }" SelectedIndexChanged="function(s, e) { OncbYearChanged(s); }" />
                                    <Items>
                                        <dx:ListEditItem Text="2019" Value="2019" Selected="true"/>
                                        <dx:ListEditItem Text="2020" Value="2020"/>
                                        <dx:ListEditItem Text="2021" Value="2021"/>
                                        <dx:ListEditItem Text="2022" Value="2022"/>
                                        <dx:ListEditItem Text="2023" Value="2023"/>
                                        <dx:ListEditItem Text="2024" Value="2024"/>
                                        <dx:ListEditItem Text="2025" Value="2025"/>
                                    </Items>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView ID="gvIN" ClientInstanceName="gvIN" runat="server" Caption="INCIDENTAL" KeyFieldName="FULLNAME" OnDataBinding="gvIN_DataBinding" OnCustomCallback="gvIN_CustomCallback">
                                    <Settings ShowFooter="false" ShowGroupPanel="false"/>
                                    <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" EnableRowHotTrack="true" AllowSort="false"/>
                                    <SettingsLoadingPanel Mode="ShowOnStatusBar"/>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="PIC" FieldName="FULLNAME" Width="50%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Close ticket count" FieldName="TicketCount" Width="50%"></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView ID="gvRQ" ClientInstanceName="gvRQ" runat="server" Caption="REQUEST" KeyFieldName="FULLNAME" OnDataBinding="gvRQ_DataBinding" OnCustomCallback="gvRQ_CustomCallback">
                                    <Settings ShowFooter="false" ShowGroupPanel="false"/>
                                    <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" EnableRowHotTrack="true" AllowSort="false"/>
                                    <SettingsLoadingPanel Mode="ShowOnStatusBar"/>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="PIC" FieldName="FULLNAME" Width="50%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Close ticket count" FieldName="TicketCount" Width="50%"></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView ID="gvCDR" ClientInstanceName="gvCDR" runat="server" Caption="CDR" KeyFieldName="FULLNAME" OnDataBinding="gvCDR_DataBinding" OnCustomCallback="gvCDR_CustomCallback">
                                    <Settings ShowFooter="false" ShowGroupPanel="false"/>
                                    <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" EnableRowHotTrack="true" AllowSort="false"/>
                                    <SettingsLoadingPanel Mode="ShowOnStatusBar"/>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="PIC" FieldName="FULLNAME" Width="50%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Close ticket count" FieldName="TicketCount" Width="50%"></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
                <SettingsItemCaptions Location="Left" />               
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <asp:SqlDataSource ID="sdsTicketSummary" runat="server" ConnectionString="<%$ ConnectionStrings:SqlConnectionString %>"
        SelectCommand="SELECT * FROM vTicketSummary" SelectCommandType="Text">
    </asp:SqlDataSource>
    <dx:ASPxCallback ID="cplMain" runat="server" ClientInstanceName="cplMain" OnCallback="cplMain_Callback">
        <ClientSideEvents EndCallback="cplMain_EndCallback" />
    </dx:ASPxCallback>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecondaryContent" runat="server">
</asp:Content>
