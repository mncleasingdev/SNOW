<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="CategoryMaintEntry.aspx.cs" Inherits="DXMNCGUI_SNOW.GeneralMaint.CategoryMaintEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <script type="text/javascript" src="../../Scripts/Application.js"></script>
    <script type="text/javascript">
        function OnDeleteCategoryClick(s, e)
        {
            var index = gvCategory.GetFocusedRowIndex();
            gvCategory.DeleteRow(index);
        }
        function OnDeleteCategorySubClick(s, e)
        {
            var indexSub = gvCategorySub.GetFocusedRowIndex();
            gvCategorySub.DeleteRow(indexSub);
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
     <dx:ASPxFormLayout runat="server" ID="DXFormLayout" Width="100%">
        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
        <Items>
            <dx:LayoutGroup 
                ShowCaption="True" 
                Caption="Category" 
                GroupBoxDecoration="HeadingLine" 
                ColCount="1" 
                UseDefaultPaddings="true"  
                HorizontalAlign="Left" 
                Width="100%" 
                Height="100%">
                    <GroupBoxStyle>
                        <Caption Font-Bold="true" Font-Size="10" />
                    </GroupBoxStyle>
                        <Items>
                            <dx:LayoutItem ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxButton 
                                            ID="btnNew" 
                                            runat="server" 
                                            Text="Add New" 
                                            Width="50px"
                                            AutoPostBack="False">
                                            <ClientSideEvents Click="function(s, e) {gvCategory.AddNewRow();}"/>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton 
                                            ID="btnDelete" 
                                            runat="server" 
                                            Text="Delete" 
                                            Width="50px"
                                            AutoPostBack="False">
                                            <ClientSideEvents Click="OnDeleteCategoryClick"/>
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxGridView ID="gvCategory" ClientInstanceName="gvCategory" runat="server" DataSourceID="sdsCategory" KeyFieldName="DocKey">
                                            <Settings   />
                                            <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom"></SettingsEditing>
                                            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="true"/>
                                            <SettingsText CommandBatchEditUpdate="Save" CommandBatchEditCancel="Cancel" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="DocType" FieldName="DocType" Name="colDocType" ShowInCustomizationForm="True" VisibleIndex="1" Width="100px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Category" FieldName="Category" Name="colCategory" ShowInCustomizationForm="True" VisibleIndex="2" Width="300px">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup             
                    ShowCaption="True" 
                    Caption="Category Sub" 
                    GroupBoxDecoration="HeadingLine" 
                    ColCount="1" 
                    UseDefaultPaddings="true"  
                    HorizontalAlign="Left" 
                    Width="100%" 
                    Height="100%">
                    <GroupBoxStyle>
                        <Caption Font-Bold="true" Font-Size="10" />
                    </GroupBoxStyle>
                    <Items>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton 
                                        ID="btnNewSub" 
                                        runat="server" 
                                        Text="Add New" 
                                        Width="50px"
                                        AutoPostBack="False">
                                        <ClientSideEvents Click="function(s, e) {gvCategorySub.AddNewRow();}"/>
                                    </dx:ASPxButton>
                                    <dx:ASPxButton 
                                        ID="btnDeleteSub" 
                                        runat="server" 
                                        Text="Delete" 
                                        Width="50px"
                                        AutoPostBack="False">
                                        <ClientSideEvents Click="OnDeleteCategorySubClick"/>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView ID="gvCategorySub" ClientInstanceName="gvCategorySub" runat="server" DataSourceID="sdsCategorySub" KeyFieldName="DocKey">
                                        <Settings   />
                                        <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom"></SettingsEditing>
                                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="true"/>
                                        <SettingsText CommandBatchEditUpdate="Save" CommandBatchEditCancel="Cancel" />
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="Category" Name="colCategory" ShowInCustomizationForm="True" VisibleIndex="1" Width="100px">
                                                <PropertiesComboBox DataSourceID="sdsCategory" ValueField="Category" TextField="Category">
                                                </PropertiesComboBox>                         
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn Caption="Category Sub" FieldName="SubCategory" Name="colSubCategory" ShowInCustomizationForm="True" VisibleIndex="2" Width="300px">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
         <asp:SqlDataSource ID="sdsCategory" runat="server" ConnectionString="<%$ ConnectionStrings:SqlConnectionString %>" ProviderName="<%$ ConnectionStrings:SqlConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM Category" 
             UpdateCommand="UPDATE Category SET DocType=@DocType, Category=@Category WHERE DocKey=@DocKey" 
             InsertCommand="INSERT INTO Category VALUES (@DocType, @Category)" 
             DeleteCommand="DELETE Category WHERE DocKey=@DocKey">
             <InsertParameters>
                 <asp:Parameter Name="DocType" />
                 <asp:Parameter Name="Category" />
             </InsertParameters>
             <UpdateParameters>
                 <asp:Parameter Name="DocKey" />
                 <asp:Parameter Name="DocType" />
                 <asp:Parameter Name="Category" />
             </UpdateParameters>
             <DeleteParameters>
                 <asp:Parameter Name="DocKey" />
             </DeleteParameters>
         </asp:SqlDataSource>
         <asp:SqlDataSource ID="sdsCategorySub" runat="server" ConnectionString="<%$ ConnectionStrings:SqlConnectionString %>" ProviderName="<%$ ConnectionStrings:SqlConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM CategorySub ORDER BY Category" 
             UpdateCommand="UPDATE CategorySub SET Category=@Category, SubCategory=@SubCategory WHERE DocKey=@DocKey" 
             InsertCommand="INSERT INTO CategorySub VALUES (@Category, @SubCategory)" 
             DeleteCommand="DELETE CategorySub WHERE DocKey=@DocKey">
             <InsertParameters>
                 <asp:Parameter Name="Category" />
                 <asp:Parameter Name="SubCategory" />
             </InsertParameters>
             <UpdateParameters>
                 <asp:Parameter Name="DocKey" />
                 <asp:Parameter Name="Category" />
                 <asp:Parameter Name="SubCategory" />
             </UpdateParameters>
             <DeleteParameters>
                 <asp:Parameter Name="DocKey" />
             </DeleteParameters>
         </asp:SqlDataSource>
</asp:Content>
