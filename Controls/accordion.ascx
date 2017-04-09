<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="accordion.ascx.vb" Inherits="DnnC.Modules.BootstrapHelpers.accordion" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagName="TextEditor" TagPrefix="dnn" Src="~/controls/TextEditor.ascx" %>

<!-- Begin Accordion list -->
<asp:Panel ID="pnlList" runat="server" Visible="true">
    <asp:LinkButton ID="cmdAddTab" runat="server" resourcekey="cmdAddTab" CssClass="dnnPrimaryAction" />
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
                        <asp:ImageButton ID="cmdEditItem1" runat="server" CommandName="cmdEdit" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Edit_16X16_Standard.png" />
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

                <asp:templatecolumn ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate><%=LocalizeString("lblActiveTab")%></HeaderTemplate>
                    <itemtemplate>
                        <asp:Image ID="imgActive" runat="server" />
                    </itemtemplate>
                </asp:templatecolumn>

                <asp:templatecolumn>
                    <HeaderTemplate><%=LocalizeString("lblTitle")%></HeaderTemplate>
                    <itemtemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ItemText1")%>'></asp:Label>
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
</asp:Panel><!-- Begin Accordion list -->

<!-- Begin accordion input -->
<asp:Panel ID="pnlInput" runat="server" Visible="true">
    <div class="dnnForm">

        <div class="dnnFormItem">
		    <dnn:label id="lblTitle" controlname="txtTitle" runat="server" />
		    <asp:TextBox ID="txtTitle" runat="server" />
            <asp:RequiredFieldValidator ID="rqTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" ValidationGroup="tabs"></asp:RequiredFieldValidator>
	    </div>
        <div class="dnnFormItem">
		    <dnn:label id="lblIsActiveTab" controlname="chkIsActiveTab" runat="server" />
            <asp:CheckBox ID="chkIsActiveTab" runat="server" />
        </div>
        <div class="dnnFormItem">
		    <dnn:label id="lblContent" controlname="txtContent" runat="server" />
		    <dnn:TextEditor id="txtContent" runat="server" width="90%" ValidationGroup="tabs"></dnn:TextEditor>
	    </div>

        <asp:LinkButton ID="cmdSave" runat="server" resourcekey="cmdSave" CssClass="dnnPrimaryAction" ValidationGroup="tabs" />
        <asp:LinkButton ID="cmdCancel" runat="server" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" CausesValidation="false" />

    </div>
</asp:Panel><!-- End accordion input -->