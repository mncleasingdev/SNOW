<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="FormTicketChangeDataRequestEntry.aspx.cs" Inherits="DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest.FormTicketChangeDataRequestEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../../../Scripts/Application.js"></script>
    <script type="text/javascript">
        function ShowAlert() {
            alert('Display Message Alert');
        }
        function ShowAlertSaveWindow() {
            lblmessage.SetValue("Apakah anda yakin ingin Simpan ?");
            cplMain.PerformCallback("SAVE");
            pcsave.Show();
        }

        var CustomErrorText = "* Value can't be empty.";
        function cplMain_EndCallback() {
            switch (cplMain.cpCallbackParam) {
                case "CATEGORY":
                    cbCategorySub.SetValue(cplMain.cpCategorySub);
                    break;
                case "OVERWRITE_CONFIRM":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                        break;
                    }
                    if (ASPxClientEdit.ValidateGroup("ValidationSave")) {
                        apcconfirm.Show();
                        lblmessage.SetText(cplMain.cplblmessage);
                    }
                    break;
                case "SAVECONFIRM":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                        break;
                    }
                    if (ASPxClientEdit.ValidateGroup("ValidationSave")) {
                        apcconfirm.Show();
                        lblmessage.SetText(cplMain.cplblmessage);
                    }
                    break;
                case "GRABCONFIRM":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                    }
                    else {
                        if (ASPxClientEdit.ValidateGroup("ValidationSave")) {
                            apcconfirm.Show();
                            lblmessage.SetText(cplMain.cplblmessage);
                            break;
                        }
                        else {
                            apcconfirm.Show();
                            lblmessage.SetText(cplMain.cplblmessage);
                        }
                    }
                    break;
                case "GRAB":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                        break;
                    }
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "HOLDCONFIRM":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                    }
                    else {
                        if (ASPxClientEdit.ValidateGroup("ValidationSave")) {
                            apcconfirm.Show();
                            lblmessage.SetText(cplMain.cplblmessage);
                            break;
                        }
                        else {
                            apcconfirm.Show();
                            lblmessage.SetText(cplMain.cplblmessage);
                        }
                    }
                    break;
                case "HOLD":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                        break;
                    }
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "REJECT":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                        break;
                    }
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "REJECTCONFIRM":
                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                    }
                    else {
                        if (ASPxClientEdit.ValidateGroup("ValidationSave")) {
                            apcconfirm.Show();
                            lblmessage.SetText(cplMain.cplblmessage);
                            break;
                        }
                        else {
                            btnReject.SetEnabled(false);
                            apcconfirm.Show();
                            lblmessage.SetText(cplMain.cplblmessage);
                        }
                    }
                    break;
                    //case "CLOSE_WINDOW_CONFIRM":
                    //    apcconfirm.Show();
                    //    lblmessage.SetText(cplMain.cplblmessage);
                    //    break;
                case "CANCELCONFIRM":

                    if (cplMain.cplblmessageError.length > 0) {
                        apcalert.SetContentHtml(cplMain.cplblmessageError);
                        apcalert.Show();
                        break;
                    }
                    if (cplMain.cpValidF == true) {
                        apcconfirm.Show();
                        lblmessage.SetText(cplMain.cplblmessage);
                    }
                    else {
                        apcalert.SetContentHtml("Can't cancel this document,document was transfered to Purchase Order...");
                        apcalert.Show();
                    }
                    break;
                case "OVERWRITE":
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "SAVE":
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "APPROVE":
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "CANCEL":
                    apcalert.SetContentHtml(cplMain.cpAlertMessage);
                    apcalert.Show();
                    break;
                case "PRINT":
                    if (cplMain.cpDocKey != "") {
                        if (cplMain.cpDocKey < 0) return;
                        var userName = "<%= Session["UserName"] %>";
                        OpenWindow("../../Shared/DocViewer.aspx?ReportType=PO&Title=Purchase Order&DocKey=" + cplMain.cpDocKey + "&ReportParam=" + userName, "DocViewer");
                    }
                    break;
            }
            cplMain.cpCallbackParam = null;
        }

        var command = "";
        function OnBeginCallback(s, e) {
            command = e.command;
        }
        function btnPrint_Click() {
            cplMain.PerformCallback("PRINT;");
        }
        function OnTextChanged(s, e) {
            s.Upload();
        }
        function onUploadControlFileUploadComplete(s, e) {
            if (e.isValid)
                alert(e.callbackData);
            CtlUpload.SetVisible(false);
            btnDownload.SetVisible(true);
        }
        function OnlinkGetAttClick(s, e) {
            if (e.isValid)
                alert(e.callbackData);
        }
        var lastCategory = null;
        function OncbCategoryChanged(cbCategory) {
            if (cbCategory.GetText() != "") {
                if (cbCategorySub.InCallback())
                    lastCategory = cbCategory.GetValue().toString();
                else
                    cbCategorySub.PerformCallback(cbCategory.GetValue().toString());
            }
        }
        function OncbCategorySub_EndCallback(s, e) {
            if (lastCategory) {
                cbCategorySub.PerformCallback(lastCategory);
                lastCategory = null;
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
    <dx:ASPxHiddenField runat="server" ID="HiddenField" ClientInstanceName="HiddenField" />
    <dx:ASPxPopupControl ID="apcconfirm" ClientInstanceName="apcconfirm" runat="server" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Alert Confirmation!" AllowDragging="True" PopupAnimationType="None" EnableViewState="False">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxFormLayout ID="ASPxFormLayout6" runat="server" ColCount="2">
                    <Items>
                        <dx:LayoutItem Caption="" ColSpan="2" ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                                    <dx:ASPxLabel ID="lblmessage" ClientInstanceName="lblmessage" runat="server" Text="">
                                    </dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                                    <dx:ASPxButton ID="btnSaveConfirm" runat="server" Text="OK" AutoPostBack="False" UseSubmitBehavior="false">
                                        <ClientSideEvents Click="function(s, e) { apcconfirm.Hide();cplMain.PerformCallback(cplMain.cplblActionButton + ';'+cplMain.cplblActionButton); }" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
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
        PopupHorizontalAlign="WindowCenter" AutoUpdatePosition="true" ShowCloseButton="true" PopupVerticalAlign="WindowCenter" HeaderText="Alert Error!" AllowDragging="True" PopupAnimationType="None" EnableViewState="False">
    </dx:ASPxPopupControl>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="PlasticBlue">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800"/>
        <Items>
            <dx:LayoutGroup Name="LayoutGroupDetailTicket" GroupBoxDecoration="HeadingLine" Caption="Ticket Change Data Request Entry">
                <GroupBoxStyle>
                    <Caption ForeColor="SlateGray" Font-Size="Larger" Font-Bold="true">
                    </Caption>
                </GroupBoxStyle>
                <Items>
                    <dx:LayoutGroup Caption="" GroupBoxDecoration="None" Name="Header" Width="100%">
                        <Items>
                            <dx:LayoutGroup GroupBoxDecoration="Default" ColCount="2" Width="100%" Caption="Ticket Detail" ShowCaption="True">
                                <Items>
                                    <dx:LayoutItem Caption="Ticket No." Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtTicketNo" runat="server" BackColor="#EBEBEB" ClientInstanceName="txtTicketNo" ForeColor="Black" ReadOnly="True" Theme="MetropolisBlue" Width="40%">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Approve" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxCheckBox ID="chkApprove" runat="server" BackColor="Transparent" ClientInstanceName="chkApprove" ForeColor="Black" ReadOnly="True" CheckState="Unchecked" ValueType="System.String" ValueChecked="T" ValueUnchecked="F" Theme="MetropolisBlue">
                                                </dx:ASPxCheckBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Request Date" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxDateEdit ID="deReqDate" runat="server" BackColor="#EBEBEB" ClientInstanceName="deReqDate" ForeColor="Black" ReadOnly="True" DisplayFormatString="dd/MM/yyyy" Theme="MetropolisBlue" Width="40%">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Status" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtStatus" runat="server" BackColor="#EBEBEB" ClientInstanceName="txtStatus" ForeColor="Black" ReadOnly="True" Theme="MetropolisBlue" Width="40%">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Category" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cbCategory" runat="server" BackColor="#FFFF99" ClientInstanceName="cbCategory" ForeColor="Black" DropDownStyle="DropDownList" IncrementalFilteringMode="Contains" OnCallback="cbCategory_Callback" OnDataBinding="cbCategory_DataBinding" EnableSynchronization="False" TabIndex="1" TextField="Category" ValueField="Category" OnSelectedIndexChanged="cbCategory_SelectedIndexChanged" Theme="MetropolisBlue" Width="40%">
                                                    <ClientSideEvents Init="function(s, e) { OncbCategoryChanged(s); }" SelectedIndexChanged="function(s, e) { OncbCategoryChanged(s); }" />
                                                    <Columns>
                                                        <dx:ListBoxColumn Caption="Category" FieldName="Category" Name="colCategory" Width="100px" />
                                                    </Columns>
                                                    <ItemStyle Wrap="True" />
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                                <dx:ASPxButton runat="server" ID="btnOverWrite" ClientInstanceName="btnOverWrite" Text="Overwrite" AutoPostBack="false" ValidationGroup="ValidationSave" Width="40%" ClientVisible="false">
                                                    <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('OVERWRITE_CONFIRM;' + 'OVERWRITE_CONFIRM'); }" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Approver" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cbApprover" runat="server" BackColor="#FFFF99" ClientInstanceName="cbApprover" ForeColor="Black" DropDownStyle="DropDownList" IncrementalFilteringMode="Contains" EnableSynchronization="False" TabIndex="2" TextField="HEADNAME" ValueField="HEAD" TextFormatString="{0};{1}" Theme="MetropolisBlue" OnDataBinding="cbApprover_DataBinding" Width="40%" DropDownWidth="30%">
                                                    <Columns>
                                                        <dx:ListBoxColumn Caption="NIK" FieldName="HEAD" Name="colNIK" Width="20px" />
                                                        <dx:ListBoxColumn Caption="Name" FieldName="HEADNAME" Name="colFULLNAME" Width="100px" />
                                                    </Columns>
                                                    <ItemStyle Wrap="True" />
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Type" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cbCategorySub" runat="server" BackColor="#FFFF99" ClientInstanceName="cbCategorySub" ForeColor="Black" DropDownStyle="DropDownList" IncrementalFilteringMode="Contains" OnCallback="cbCategorySub_Callback" OnDataBinding="cbCategorySub_DataBinding" EnableSynchronization="False" TabIndex="3" TextField="SubCategory" ValueField="SubCategory" Theme="MetropolisBlue" Width="80%">
                                                    <ClientSideEvents EndCallback=" OncbCategorySub_EndCallback" Init="function(s,e) { cplMain.PerformCallback('CATEGORY_SUB;' + cbCategorySub.GetValue()); }" />
                                                    <Columns>
                                                        <dx:ListBoxColumn Caption="CategorySub" FieldName="SubCategory" Name="colCategorySub"/>
                                                    </Columns>
                                                    <ItemStyle Wrap="True" />
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Application No " Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtContract" runat="server" ClientInstanceName="txtContract" BackColor="#FFFF99" ForeColor="Black" ReadOnly="False" Theme="MetropolisBlue" TabIndex="4" Width="40%" MaxLength="50">
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:EmptyLayoutItem Width="50%"></dx:EmptyLayoutItem>
                                    <dx:LayoutItem Caption="Reason" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cbReasonChange" runat="server" BackColor="#FFFF99" ClientInstanceName="cbReasonChange" ForeColor="Black" DropDownStyle="DropDownList" IncrementalFilteringMode="Contains" EnableSynchronization="False" TabIndex="5" Theme="MetropolisBlue" Width="40%">
                                                    <%--<Columns>
                                                            <dx:ListBoxColumn Caption="Reason Change" Name="colReasonChange" Width="100px" />
                                                        </Columns>--%>
                                                    <ItemStyle Wrap="True" />
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Additional Note" Height="100px" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer47" runat="server">
                                                <dx:ASPxMemo ID="mmDescription" TabIndex="6" runat="server" Width="80%" Height="100%" Theme="MetropolisBlue" AutoResizeWithContainer="true">
                                                    <%--<ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                            <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                        </ValidationSettings>--%>
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Original Data" Height="100px" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                                <dx:ASPxMemo ID="mmOriginalData" TabIndex="8" runat="server" Width="80%" Height="100%" Theme="MetropolisBlue">
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Name="LayoutItemReason" ShowCaption="True" Caption="IT Remarks" Height="100px" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                                <dx:ASPxMemo ID="mmReason" TabIndex="9" runat="server" Width="80%" Height="100%" ReadOnly="true" Theme="MetropolisBlue">
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Request Data" Height="100px" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                                <dx:ASPxMemo ID="mmRequestData" TabIndex="10" runat="server" Width="80%" Height="100%" Theme="MetropolisBlue">
                                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ValidationGroup="ValidationSave">
                                                        <RequiredField ErrorText="* Value can't be empty." IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Name="LayoutItemRemark1" ShowCaption="True" Caption="Internal Info" Height="100px" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                                <dx:ASPxMemo ID="mmRemark1" TabIndex="11" runat="server" Width="80%" Height="100%" ReadOnly="true" Theme="MetropolisBlue">
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Attachment" Width="50%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxUploadControl ID="CtlUpload" runat="server" ClientInstanceName="CtlUpload" FileUploadMode="OnPageLoad" UploadButton-Text="Upload" UploadMode="Auto" Width="365px" ShowUploadButton="false" OnFileUploadComplete="CtlUpload_FileUploadComplete" ShowProgressPanel="true" BrowseButton-Text="Browse" ShowTextBox="true" Theme="MetropolisBlue" TabIndex="12">
                                                    <ValidationSettings AllowedFileExtensions=".txt,.jpg,.jpe,.jpeg,.doc,.docx,.pdf,.xls,.xlsx" MaxFileSize="4000000" ErrorStyle-BackColor="Red" ShowErrors="true">
                                                        <ErrorStyle BackColor="Red"></ErrorStyle>
                                                    </ValidationSettings>
                                                    <ClientSideEvents FileUploadComplete="onUploadControlFileUploadComplete" TextChanged="OnTextChanged"></ClientSideEvents>
                                                    <AdvancedModeSettings EnableDragAndDrop="True">
                                                    </AdvancedModeSettings>
                                                </dx:ASPxUploadControl>
                                                <br />
                                                <dx:ASPxLabel ID="labellabellan" runat="server" Visible="false" ClientInstanceName="labellabellan">
                                                </dx:ASPxLabel>
                                                <br />
                                                <dx:ASPxButton ID="btnDownload" runat="server" ClientInstanceName="btnDownload" OnClick="btnDownload_Click" Text="Download Doc." ClientVisible="false">
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Name="liRejectReason" Caption="Reject Note" Height="50px" Width="50%" ClientVisible="false">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer10" runat="server">
                                                <dx:ASPxMemo ID="mmRejectReason" TabIndex="7" runat="server" Width="80%" Height="100%" Theme="MetropolisBlue" AutoResizeWithContainer="true">
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False" Width="100%">
                <Items>
                    <dx:LayoutGroup Caption="" GroupBoxDecoration="None" Name="Footer" Width="100%" ColCount="9">
                        <Items>
                            <dx:EmptyLayoutItem Width="40%"></dx:EmptyLayoutItem>
                            <dx:LayoutItem ShowCaption="False" Width="10%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer54" runat="server">
                                        <dx:ASPxButton ID="btnSave" ClientInstanceName="btnSave" runat="server" ValidationGroup="ValidationSave" Text="Submit" HorizontalAlign="Center" Width="100%" AutoPostBack="False" UseSubmitBehavior="false" TabIndex="15">
                                            <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('SAVECONFIRM;' + 'SAVECONFIRM'); }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" Width="10%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer57" runat="server">
                                        <dx:ASPxButton ID="btnCancel" ClientInstanceName="btnCancel" runat="server" Text="Cancel" HorizontalAlign="Center" Width="100%" AutoPostBack="False" UseSubmitBehavior="false" TabIndex="18">
                                            <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('CANCELCONFIRM;' + 'CANCELCONFIRM'); }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" Width="10%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer55" runat="server">
                                        <dx:ASPxButton ID="btnGrab" runat="server" ValidationGroup="ValidationSave" ClientInstanceName="btnGrab" Text="Grab" HorizontalAlign="Center" Width="100%" AutoPostBack="False" UseSubmitBehavior="false" TabIndex="16">
                                            <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('GRABCONFIRM;' + 'GRABCONFIRM'); }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" Width="10%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                        <dx:ASPxButton ID="btnReject" runat="server" ValidationGroup="ValidationSave" ClientInstanceName="btnReject" Text="Reject" HorizontalAlign="Center" Width="100%" AutoPostBack="False" UseSubmitBehavior="false" TabIndex="16">
                                            <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('REJECTCONFIRM;' + 'REJECTCONFIRM'); }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" Width="10%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                        <dx:ASPxButton ID="btnOnHold" runat="server" ValidationGroup="ValidationSave" ClientInstanceName="btnOnHold" Text="Hold" HorizontalAlign="Center" Width="100%" AutoPostBack="False" UseSubmitBehavior="false" TabIndex="16">
                                            <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('HOLDCONFIRM;' + 'HOLDCONFIRM'); }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" Width="10%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer59" runat="server">
                                        <dx:ASPxButton ID="btnCloseWindow" runat="server" Text="Back" HorizontalAlign="Center" Width="100%" AutoPostBack="False" UseSubmitBehavior="false" TabIndex="20" OnClick="btnCloseWindow_Click">
                                            <ClientSideEvents Click="function(s,e) { cplMain.PerformCallback('CLOSE_WINDOW_CONFIRM;' + 'CLOSE_WINDOW_CONFIRM'); }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <dx:ASPxCallback ID="cplMain" runat="server" ClientInstanceName="cplMain" OnCallback="cplMain_Callback">
        <ClientSideEvents EndCallback="cplMain_EndCallback" />
    </dx:ASPxCallback>
</asp:Content>
