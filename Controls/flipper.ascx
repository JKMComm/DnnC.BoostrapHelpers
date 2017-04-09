<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="flipper.ascx.vb" Inherits="DnnC.Modules.BootstrapHelpers.flipper" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagName="TextEditor" TagPrefix="dnn" Src="~/controls/TextEditor.ascx" %>

<div class="dnnForm">       
    
    <div class="dnnFormItem">            
        <dnn:label id="lblWidth" controlname="txtWidth" runat="server" />
        <asp:TextBox ID="txtWidth" runat="server" Width="80px" Text="100px"></asp:TextBox>
    </div>
    <div class="dnnFormItem">            
        <dnn:label id="lblHeight" controlname="txtHeight" runat="server" />
        <asp:TextBox ID="txtHeight" runat="server" Width="80px" Text="100px"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:label id="lblDirection" controlname="lblDirection" runat="server" />
        <asp:DropDownList ID="ddlDirection" runat="server">
            <asp:ListItem ResourceKey="optRightToLeft" Value="rl" Selected="true"></asp:ListItem>
            <asp:ListItem ResourceKey="optLeftToRight" Value="lr"></asp:ListItem>
            <asp:ListItem ResourceKey="optTopToBottom" Value="tb"></asp:ListItem>
            <asp:ListItem ResourceKey="optBottomToTop" Value="bt"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="dnnForm">            
  		<dnn:label id="lblFrtContent" controlname="txtFrtContent" runat="server" />
		<dnn:TextEditor id="txtFrtContent" runat="server" width="90%" ValidationGroup="tabs"></dnn:TextEditor>
    </div>
    <div class="dnnForm">            
  		<dnn:label id="lblBckContent" controlname="txtBckContent" runat="server" />
		<dnn:TextEditor id="txtBckContent" runat="server" width="90%" ValidationGroup="tabs"></dnn:TextEditor>
    </div>

    <div class="dnnFormItem">
        <asp:LinkButton ID="cmdSave" runat="server" resourcekey="cmdSave" CssClass="dnnPrimaryAction" ValidationGroup="tabs" />
        <asp:LinkButton ID="cmdCancel" runat="server" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" CausesValidation="false" />
    </div>

</div>