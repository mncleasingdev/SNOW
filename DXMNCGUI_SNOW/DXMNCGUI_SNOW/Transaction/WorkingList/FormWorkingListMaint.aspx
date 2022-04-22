<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="FormWorkingListMaint.aspx.cs" Inherits="DXMNCGUI_SNOW.Transaction.WorkingList.FormWorkingListMaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript">
         var TicketHeaderID;
         function gvWorkingList_EndCallback(s, e)
        {
            switch (gvWorkingList.cpCallbackParam)
            {
                case "INDEX":
                    gvWorkingList.SetFocusedRowIndex(gvWorkingList.cpVisibleIndex);
                    break;
            }

             gvWorkingList.cplblmessageError = "";
             gvWorkingList.cpCallbackParam = "";
             scheduleGridUpdate(s);
        }
        function cplMain_EndCallback()
        {
            switch (cplMain.cpCallbackParam)
            {
            }

            cplMain.cpCallbackParam = "";
        }
        function btnPrint_Click()
        {
            if (gvWorkingList.GetFocusedRowIndex() < 0)
            {
                alert("Ticket belum dipilih !");
                return;
            }
            if (gvWorkingList.GetFocusedRowIndex() > -1)
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
            if (gvWorkingList.GetFocusedRowIndex() > -1)
            {
                gvWorkingList.GetRowValues(gvWorkingList.GetFocusedRowIndex(), 'Source', GetTicketHeaderID);
            }
        }
        function OnGetRowValues(Value)
        {
            alert(Value);
        }
        function gvWorkingList_CustomButtonClick(s, e)
        {
            switch (e.buttonID)
            {
                case "btnShow":
                    gvWorkingList.GetRowValues(e.visibleIndex, "DocType;Source;Source", ApprovalProcess);
                    break;
            }
        }
        function ApprovalProcess(values)
        {
            cplMain.PerformCallback("APPROVAL;" + values[2] + ";" + values[0]);
        }
        var timeout;
        function scheduleGridUpdate(grid)
        {
            window.clearTimeout(timeout);
            timeout = window.setTimeout(
                function ()
                { gvWorkingList.PerformCallback('REFRESH; REFRESH'); },
                2000
            );
        }
        function gvWorkingList_Init(s, e) {
            scheduleGridUpdate(s);
        }
        function gvWorkingList_BeginCallback(s, e) {
            window.clearTimeout(timeout);
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
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
        <Items>
            <dx:LayoutGroup GroupBoxDecoration="HeadingLine" Caption="My Working List">
                <GroupBoxStyle>
                    <Caption ForeColor="SlateGray" Font-Size="Larger" Font-Bold="true"></Caption>
                </GroupBoxStyle>
                <Items>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxGridView  
                                    ID="gvWorkingList" 
                                    ClientInstanceName="gvWorkingList" 
                                    runat="server" 
                                    KeyFieldName="Source" 
                                    Width="100%" 
                                    AutoGenerateColumns="False"
                                    EnableCallBacks="true"
                                    EnablePagingCallbackAnimation="true"
                                    OnDataBinding="gvWorkingList_DataBinding"
                                    OnFocusedRowChanged="gvWorkingList_FocusedRowChanged"  
                                    OnCustomCallback="gvWorkingList_CustomCallback" 
                                    OnCustomUnboundColumnData="gvWorkingList_CustomUnboundColumnData" 
                                    OnCustomButtonCallback="gvWorkingList_CustomButtonCallback"
                                    EnableTheming="True" 
                                    Theme="Office2010Black">
                                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" AllowOnlyOneAdaptiveDetailExpanded="True" HideDataCellsAtWindowInnerWidth="700">
                                    </SettingsAdaptivity>
                                    <ClientSideEvents 
                                        EndCallback="gvWorkingList_EndCallback" 
                                        RowDblClick="function(s, e) {gvWorkingList.PerformCallback('DOUBLECLICK;' + e.visibleIndex);}"
                                        CustomButtonClick="function(s,e) { gvWorkingList_CustomButtonClick(s,e); }"
                                        Init="gvWorkingList_Init" BeginCallback="gvWorkingList_BeginCallback"
                                        />
                                    <Settings ShowFilterRow="false" ShowGroupPanel="True" ShowFilterRowMenu="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true"/>
                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" FilterRowMode="OnClick" EnableRowHotTrack="true"/>
                                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False"/>
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsFilterControl ViewMode="VisualAndText" AllowHierarchicalColumns="true" ShowAllDataSourceColumns="true" MaxHierarchyDepth="1" />
                                    <SettingsLoadingPanel Mode="Disabled"/>
                                    <Columns>
                                            <dx:GridViewDataTextColumn FieldName="DocKey" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Source" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Ticket No." FieldName="TicketNo" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Submit By" FieldName="FULLNAME" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="5">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn Caption="Submit Date" FieldName="TransDate" ReadOnly="True" ShowInCustomizationForm="True" Visible="true" VisibleIndex="6" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                                            </dx:GridViewDataDateColumn>
                                            <dx:GridViewDataTextColumn Caption="Description" FieldName="Description" Name="colDescription" ShowInCustomizationForm="True" Visible="true" VisibleIndex="7">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="DocType" FieldName="DocType" Name="colDocType" ShowInCustomizationForm="True" Visible="false" VisibleIndex="8">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn ButtonType="Button" VisibleIndex="9">
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnShow" Text="Show" >

                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                            </dx:GridViewCommandColumn>
                                    </Columns>
                                    <Styles AdaptiveDetailButtonWidth="22"></Styles>
                                </dx:ASPxGridView>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <dx:ASPxCallback ID="cplMain" runat="server" ClientInstanceName="cplMain" OnCallback="cplMain_Callback">
        <ClientSideEvents EndCallback="cplMain_EndCallback" />
    </dx:ASPxCallback>
</asp:Content>
