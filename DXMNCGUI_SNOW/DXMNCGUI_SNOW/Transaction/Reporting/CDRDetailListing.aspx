<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="CDRDetailListing.aspx.cs" Inherits="DXMNCGUI_SNOW.Transaction.Reporting.CDRDetailListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript">
        function cplMain_EndCallback()
        {
            switch (cplMain.cpCallbackParam)
            {
                case "INQUIRY":
                    gvMain.PerformCallback();
                    break;
                case "":
                    break;
            }
            cplMain.cpCallbackParam = "";
        }
        function OnbtnInquiryClick(s, e)
        {
            if (deFrom.GetValue() != null && deTo.GetValue() != null)
            {
                cplMain.PerformCallback("INQUIRY;" + deFrom.GetValue().toString() + ";" + deTo.GetValue().toString());
            }
        }
    </script>
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
    <dx:ASPxFormLayout ID="ASPxFormLayout" runat="server" Width="100%">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800"/>
        <Items>
            <dx:LayoutGroup ShowCaption="True" Caption="CDR Detail Listing" GroupBoxDecoration="HeadingLine" ColCount="1" CellStyle-Font-Names="Calibri" CellStyle-Font-Size="Small">
                <Items>
                    <dx:LayoutItem ShowCaption="True" Caption="Periode" Width="100%">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxDateEdit runat="server" ID="deFrom" ClientInstanceName="deFrom" NullText="From..." Width="150px" Theme="Office2010Black" DisplayFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False" Caption="" Width="100%">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxDateEdit runat="server" ID="deTo" ClientInstanceName="deTo" NullText="To..." Width="150px" Theme="Office2010Black" DisplayFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False" Caption="" Width="100%">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxButton 
                                    runat="server" ID="btnInquiry" ClientInstanceName="btnInquiry" Text="Inquiry" Width="150px" Theme="Office2010Black" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s, e) { OnbtnInquiryClick(s, e); }" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False" Caption="" Width="100%">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView 
                                    runat="server" KeyFieldName="TicketNo" 
                                    ID="gvMain" 
                                    ClientInstanceName="gvMain" OnDataBinding="gvMain_DataBinding" OnCustomCallback="gvMain_CustomCallback" EnableCallbackAnimation="true"
                                    Theme="Office2010Black">
                                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" AllowOnlyOneAdaptiveDetailExpanded="True" HideDataCellsAtWindowInnerWidth="700">
                                    </SettingsAdaptivity>
                                    <Settings ShowFilterRow="false" ShowGroupPanel="True" ShowFilterRowMenu="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFooter="true"/>
                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" FilterRowMode="OnClick" EnableRowHotTrack="true" EnableCustomizationWindow="true" AllowEllipsisInText="true"/>
                                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsFilterControl ViewMode="VisualAndText" AllowHierarchicalColumns="true" ShowAllDataSourceColumns="true" MaxHierarchyDepth="1" />
                                    <SettingsLoadingPanel Mode="ShowAsPopup" />
                                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" Landscape="true" PaperKind="A4"/>
                                    <SettingsPager PageSize="20"></SettingsPager>
                                    <SettingsResizing ColumnResizeMode="Control" Visualization="Live"/>
                                    <Toolbars>
                                        <dx:GridViewToolbar ItemAlign="Right" EnableAdaptivity="true" Position="Top">
                                            <Items>
                                                <dx:GridViewToolbarItem Command="ShowCustomizationWindow" DisplayMode="ImageWithText"/>
                                                <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export to .xlsx" ToolTip="Click here to export grid data to excel"/>
                                            </Items>
                                        </dx:GridViewToolbar>
                                    </Toolbars>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Name="colCreatedUserID" FieldName="CreatedUserID" Caption="Created By ID">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colFULLNAME" FieldName="FULLNAME" Caption="Created By">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colTicketNo" FieldName="TicketNo" Caption="Ticket No.">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn Name="colTicketReqDate" FieldName="TicketReqDate" Caption="Ticket Date" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn Name="colStatus" FieldName="Status" Caption="Status">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colRefNo" FieldName="RefNo" Caption="Reference">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colSubCategory" FieldName="SubCategory" Caption="Sub Category">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colDescription" FieldName="Description" Caption="Description">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colOriginalData" FieldName="OriginalData" Caption="Original Data">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colRequestData" FieldName="RequestData" Caption="Request Data">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colReasonToChange" FieldName="ReasonToChange" Caption="Reason To Change">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colReason" FieldName="Reason" Caption="Reason">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colApprover" FieldName="Approver" Caption="Approve By">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="True"></AlternatingRow>
                                    </Styles>
                                    <Styles AdaptiveDetailButtonWidth="22" Footer-Font-Bold="true"></Styles>
                                    <SettingsDetail ShowDetailRow="false" />
                                </dx:ASPxGridView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
                <SettingsItemCaptions Location="Top" />
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <dx:ASPxCallback ID="cplMain" runat="server" ClientInstanceName="cplMain" OnCallback="cplMain_Callback">
        <ClientSideEvents EndCallback="cplMain_EndCallback" />
    </dx:ASPxCallback>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecondaryContent" runat="server">
</asp:Content>
