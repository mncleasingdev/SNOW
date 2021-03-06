<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="FormTicketMaint.aspx.cs" Inherits="DXMNCGUI_SNOW.Transaction.TicketTrans.FormTicketMaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript">
        var TicketHeaderID;
        function gvIncidentList_EndCallback(s, e)
        {
            switch (gvIncidentList.cpCallbackParam)
            {
                case "INDEX":
                    gvIncidentList.SetFocusedRowIndex(gvIncidentList.cpVisibleIndex);
                    break;
            }

            gvIncidentList.cplblmessageError = "";
            gvIncidentList.cpCallbackParam = "";
            scheduleGridUpdate(s);
        }
        function cplMain_EndCallback()
        {
        }
        function btnPrint_Click()
        {
            if (gvIncidentList.GetFocusedRowIndex() < 0)
            {
                alert("Ticket belum dipilih !");
                return;
            }
            if (gvIncidentList.GetFocusedRowIndex() > -1)
            {
                var userName = "<%= Session["UserName"] %>";
                OpenWindow("../../Shared/DocViewer.aspx?ReportType=PO&Title=Purchase Order&DocKey=" + POHeaderID + "&ReportParam=" + userName, "DocViewer");
            }
        }       
        function GetTicketHeaderID(values)
        {
            TicketHeaderID = values;
        }
        window.onload = function ()
        {
            if (gvIncidentList.GetFocusedRowIndex() > -1)
            {
                gvIncidentList.GetRowValues(gvIncidentList.GetFocusedRowIndex(), 'DocKey', GetTicketHeaderID);
            }
        }
        function FocusedRowChanged(s)
        {
            if (gvIncidentList.GetFocusedRowIndex() > -1)
            {
                gvIncidentListDetail.PerformCallback('DetailLoad;' + s.GetRowKey(s.GetFocusedRowIndex()));
            }
        }
        function OnGetRowValues(Value)
        {
            alert(Value);
        }
        var timeout;
        function scheduleGridUpdate(grid) {
            //window.clearTimeout(timeout);
            //timeout = window.setTimeout(
            //    function ()
            //    { gvIncidentList.PerformCallback('REFRESH; REFRESH'); },
            //    60000
            //);
        }
        function gvIncidentList_Init(s, e) {
            scheduleGridUpdate(s);
        }
        function gvIncidentList_BeginCallback(s, e) {
            window.clearTimeout(timeout);
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
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
        <Items>
            <dx:LayoutGroup GroupBoxDecoration="HeadingLine" Caption="Incident Ticket List">
                <GroupBoxStyle>
                    <Caption ForeColor="SlateGray" Font-Size="Larger" Font-Bold="true"></Caption>
                </GroupBoxStyle>
                <Items>
                    <dx:LayoutGroup Caption="" GroupBoxDecoration="None" ColCount="10" Width="100%">
                        <Items>
                             <dx:LayoutItem ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxButton ID="btnNew" ClientInstanceName="btnNew" runat="server" Text="New Incident" BackColor="LightGray" OnClick="btnNew_Click" Width="100px">
                                                    </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                       <dx:ASPxButton ID="btnView" ClientInstanceName="btnView" runat="server" Text="View" BackColor="LightGray" OnClick="btnView_Click" Width="100px"></dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                        <dx:ASPxButton ID="btnRefresh" ClientInstanceName="btnRefresh" runat="server" Text="Refresh" BackColor="LightGray" OnClick="btnRefresh_Click" Width="100px">
                                                    </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem> 
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem> 
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem> 
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem> 
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>          
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView  
                                    ID="gvIncidentList" 
                                    ClientInstanceName="gvIncidentList" 
                                    runat="server" 
                                    KeyFieldName="TicketNo" 
                                    Width="100%" 
                                    AutoGenerateColumns="False"
                                    EnableCallBacks="true"
                                    EnablePagingCallbackAnimation="true"
                                    OnDataBinding="gvIncidentList_DataBinding" 
                                    OnFocusedRowChanged="gvIncidentList_FocusedRowChanged"  
                                    OnCustomCallback="gvIncidentList_CustomCallback" 
                                    OnCustomUnboundColumnData="gvIncidentList_CustomUnboundColumnData" OnHtmlRowPrepared="gvIncidentList_HtmlRowPrepared"
                                    EnableTheming="True" 
                                    Theme="Office2010Black">
                                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" AllowOnlyOneAdaptiveDetailExpanded="True" HideDataCellsAtWindowInnerWidth="700">
                                    </SettingsAdaptivity>
                                    <ClientSideEvents 
                                        EndCallback="gvIncidentList_EndCallback" 
                                        RowDblClick="function(s, e) {gvIncidentList.PerformCallback('DOUBLECLICK;' +e.visibleIndex);}"
                                        FocusedRowChanged="FocusedRowChanged" Init="gvIncidentList_Init" BeginCallback="gvIncidentList_BeginCallback"
                                        />
                                    <Settings ShowFilterRow="false" ShowGroupPanel="True" ShowFilterRowMenu="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true"/>
                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" FilterRowMode="OnClick" EnableRowHotTrack="true"/>
                                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False"/>
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsFilterControl ViewMode="VisualAndText" AllowHierarchicalColumns="true" ShowAllDataSourceColumns="true" MaxHierarchyDepth="1" />
                                    <SettingsLoadingPanel Mode="Disabled"/>
                                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" Landscape="false" PaperKind="A4"/>
                                    <Toolbars>
                                        <dx:GridViewToolbar ItemAlign="Right" EnableAdaptivity="true">
                                            <Items>
                                                <dx:GridViewToolbarItem Command="ExportToPdf"/>
                                                <dx:GridViewToolbarItem Command="ExportToXlsx" />
                                            </Items>
                                        </dx:GridViewToolbar>
                                    </Toolbars>
                                    <Columns>
                                            <dx:GridViewDataTextColumn FieldName="DocKey" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Ticket No." FieldName="TicketNo" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn Caption="Create Date" FieldName="TicketReqDate" ReadOnly="True" ShowInCustomizationForm="True" Visible="true" VisibleIndex="5" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                                            </dx:GridViewDataDateColumn>
                                            <dx:GridViewDataTextColumn Caption="Urgent Type" FieldName="UrgentType" ReadOnly="True" ShowInCustomizationForm="True" Visible="false" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Category" FieldName="Category" Name="colCategory" ReadOnly="True" ShowInCustomizationForm="True" Visible="false" VisibleIndex="7">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Sub Category" FieldName="SubCategory" Name="colSubCategory" ReadOnly="True" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="8">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Description" FieldName="Description" Name="colDescription" ShowInCustomizationForm="True" Visible="false" VisibleIndex="9">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Creator" FieldName="IDFULLNAME" Name="colIDFULLNAME" ShowInCustomizationForm="True" VisibleIndex="10">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" Name="colStatus" ShowInCustomizationForm="True" VisibleIndex="11">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Grab By" FieldName="GrabByUser" Name="colGrabByUser" Visible="false" ShowInCustomizationForm="True" VisibleIndex="12">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn Caption="Grab Date" FieldName="GrabDate" Name="colGrabDate" Visible="false" ShowInCustomizationForm="True" VisibleIndex="13" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy hh:mm:ss">
                                            </dx:GridViewDataDateColumn>
                                            <dx:GridViewDataTextColumn Caption="Close By" FieldName="CloseByUser" Name="colCloseByUser" Visible="false" ShowInCustomizationForm="True" VisibleIndex="14">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn Caption="Close Date" FieldName="CloseDate" Name="colCloseDate" Visible="false" ShowInCustomizationForm="True" VisibleIndex="15" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy hh:mm:ss">
                                            </dx:GridViewDataDateColumn>
                                    </Columns>
                                    <Styles AdaptiveDetailButtonWidth="22">
                                        <AlternatingRow Enabled="True"></AlternatingRow>
                                    </Styles>
                                </dx:ASPxGridView>

                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxLabel ID ="lblHistory" runat="server" Text="History :" Font-Bold="true" ForeColor="SlateGray"></dx:ASPxLabel>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView ID="gvIncidentListDetail" runat="server" ClientInstanceName="gvIncidentListDetail" KeyFieldName="DtlKey"
                                    EnableTheming="True" 
                                    Theme="Office2010Black" 
                                    OnDataBinding="gvIncidentListDetail_DataBinding"
                                    EnableCallBacks="true"
                                    EnableCallbackAnimation="true" 
                                    OnCustomCallback="gvIncidentListDetail_CustomCallback"
                                    EndCallback="gvIncidentListDetail_EndCallback">
                                    <SettingsBehavior AllowCellMerge="true" AllowFocusedRow="true" AllowSelectByRowClick="True" EnableRowHotTrack="true" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Ticket No." FieldName="TicketNo" Name="colTicketNo" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="16" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Action" FieldName="Action" Name="colAction" ShowInCustomizationForm="True" VisibleIndex="17">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn Caption="Action Date" FieldName="ActionDateTime" Name="colActionDate" ShowInCustomizationForm="True" VisibleIndex="18" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn Caption="Action By" FieldName="IDFULLNAME" Name="colActionByID" ShowInCustomizationForm="True" VisibleIndex="19">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataMemoColumn Caption="Remarks IT" FieldName="Reason" Name="colReason" ShowInCustomizationForm="True" VisibleIndex="20">
                                        </dx:GridViewDataMemoColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutGroup Caption="" GroupBoxDecoration="None" ColCount="3" Width="100%" HorizontalAlign="Right">
                        <Items>

                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <dx:ASPxCallback ID="cplMain" runat="server" ClientInstanceName="cplMain" OnCallback="cplMain_Callback">
        <ClientSideEvents EndCallback="cplMain_EndCallback" />
    </dx:ASPxCallback>
    <asp:SqlDataSource ID="sdsTicketHeader" runat="server" ConnectionString="<%$ ConnectionStrings:SqlConnectionString %>" ProviderName="<%$ ConnectionStrings:SqlConnectionString.ProviderName %>"
        SelectCommand="select * from dbo.IncidentList3"></asp:SqlDataSource>
        <dx:ASPxHiddenField ID="hf" ClientInstanceName="hiddenField" runat="server">
    </dx:ASPxHiddenField>
</asp:Content>
