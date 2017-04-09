<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Helpers.ascx.vb" Inherits="DnnC.Modules.BootstrapHelpers.Helpers" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>

<asp:Panel ID="pnlMessage" runat="server" Visible="false">
    <div id="lblMessage" class="dnnFormMessage dnnFormInfo"><dnn:Label ID="lblChoosehelperFromSettings" runat="server" /></div>
</asp:Panel>

<asp:literal ID="phBootStrap1" runat="server"></asp:literal>
<asp:literal ID="phBootStrap2" runat="server"></asp:literal>

