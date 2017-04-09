<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="buttonGroup.ascx.vb" Inherits="DnnC.Modules.BootstrapHelpers.buttonGroup" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="UrlControl" Src="~/controls/UrlControl.ascx"%>
<%@ Register TagName="TextEditor" TagPrefix="dnn" Src="~/controls/TextEditor.ascx" %>


<!-- Begin Button group list -->
<asp:Panel ID="pnlList" runat="server" Visible="true">
    <asp:LinkButton ID="cmdAddButton" runat="server" resourcekey="cmdAddButton" CssClass="dnnPrimaryAction" />
    <br />
    <div class="dnnForm">

        <asp:datagrid id="grdItems" 
            DataKeyField="ItemId"
            Width="98%" 
            AutoGenerateColumns="false" 
            EnableViewState="false" 
            runat="server" 
            BorderStyle="None" 
            GridLines="None" 
            CssClass="dnnGrid">

            <headerstyle cssclass="dnnGridHeader" verticalalign="Top"/>
            <itemstyle cssclass="dnnGridItem" horizontalalign="Left" />
            <alternatingitemstyle cssclass="dnnGridAltItem" />
            <edititemstyle cssclass="dnnFormInput" />
            <selecteditemstyle cssclass="dnnFormError" />
            <footerstyle cssclass="dnnGridFooter" />
            <pagerstyle cssclass="dnnGridPager" />

            <columns>
                <asp:templatecolumn ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <itemtemplate>
                        <asp:ImageButton ID="cmdEditItem" runat="server" CommandName="cmdEdit" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Edit_16X16_Standard.png" />
                    </itemtemplate>
                </asp:templatecolumn>

                <asp:templatecolumn ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <itemtemplate>
                        <asp:ImageButton ID="cmdMoveItemUp" runat="server" CommandName="cmdMoveUp" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Up_16X16_Standard.png"  />
                    </itemtemplate>
                </asp:templatecolumn>

                <asp:templatecolumn ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <itemtemplate>
                        <asp:ImageButton ID="cmdMoveItemDown" runat="server" CommandName="cmdMoveDown" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Dn_16X16_Standard.png" />
                    </itemtemplate>
                </asp:templatecolumn>

                <asp:templatecolumn>
                    <HeaderTemplate><%=LocalizeString("lblTitle")%></HeaderTemplate>
                    <itemtemplate>
                        <asp:Label ID="lblCaption" runat="server" Text='<%# System.Web.HttpUtility.HtmlDecode(Eval("ItemText1")) %>'></asp:Label>
                    </itemtemplate>
                </asp:templatecolumn>

                <asp:templatecolumn ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <itemtemplate>
                        <asp:ImageButton ID="cmdDeleteItem" runat="server" CommandName="cmdDelete" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Delete_16X16_Standard.png" />
                    </itemtemplate>
                </asp:templatecolumn>
                            
            </columns>
        </asp:datagrid>

    </div>
</asp:Panel><!-- End Button group list -->

<!-- Begin Button group input -->
<asp:Panel ID="pnlInput" runat="server" Visible="true">
    <div class="dnnForm">

        <div class="dnnFormItem">
		    <dnn:label id="lblButtonTitle" controlname="txtButtonTitle" runat="server" />
		    <asp:TextBox ID="txtButtonTitle" runat="server" />
            <asp:RequiredFieldValidator ID="rqButtonTitle" runat="server" ControlToValidate="txtButtonTitle" ErrorMessage="*" ValidationGroup="tabs"></asp:RequiredFieldValidator>
	    </div>

        <div class="dnnFormItem">
		    <dnn:label id="lblButtonLink" controlname="txtButtonTitle" runat="server" />
		    <dnn:UrlControl ID="ctrlLink" runat="server" 
                ShowFiles="false" 
                ShowLog="false" 
                ShowTrack="false" 
                ShowUpload="false" />
	    </div>
        <div class="dnnFormItem">
            <asp:LinkButton ID="cmdSaveButton" runat="server" resourcekey="cmdSaveButton" CssClass="dnnPrimaryAction" ValidationGroup="tabs" />
            <asp:LinkButton ID="cmdCancelButton" runat="server" resourcekey="cmdCancelButton" CssClass="dnnSecondaryAction" CausesValidation="false" />
        </div>
    </div>
</asp:Panel><!-- End Button group input -->