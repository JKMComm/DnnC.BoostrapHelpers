<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Settings.ascx.vb" Inherits="DnnC.Modules.BootstrapHelpers.Settings" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

	<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicSettings")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblHelperType" runat="server" />

            <asp:DropDownList ID="ddlHelperType" runat="server" AutoPostBack="true">
                <asp:ListItem ResourceKey="optChoose" Value=""></asp:ListItem>
                <asp:ListItem ResourceKey="optTabs" Value="tabs"></asp:ListItem>
                <asp:ListItem ResourceKey="optColapse" Value="accordion"></asp:ListItem>
                <asp:ListItem ResourceKey="optCarousel" Value="carousel"></asp:ListItem>
                <asp:ListItem ResourceKey="optButtonGroup" Value="buttongroup"></asp:ListItem>
                <asp:ListItem ResourceKey="optFlipper" Value="flipper"></asp:ListItem>
            </asp:DropDownList>

            <asp:Panel ID="pnlTabs" runat="server" Visible="false">

                <div class="dnnFormItem">
                    <dnn:label id="lblTabType" controlname="chkUseTabFade" runat="server" />
                    <asp:RadioButtonList ID="rdoTabType" runat="server" AutoPostBack="true">
                        <asp:ListItem ResourceKey="optTab" Value="nav-tabs" Selected="true"></asp:ListItem>
                        <asp:ListItem ResourceKey="optPill" Value="nav-pills"></asp:ListItem>
                    </asp:RadioButtonList>                    
                </div>
                <div class="dnnFormItem">
                    <dnn:label id="lblTabFade" controlname="chkUseTabFade" runat="server" />
                    <asp:CheckBox ID="chkUseTabFade" runat="server" Checked="true" />
                </div>


            </asp:Panel>

            <asp:Panel ID="pnlAccordion" runat="server" Visible="false">
            </asp:Panel>

            <asp:Panel ID="pnlCarousel" runat="server" Visible="false">

                <div class="dnnFormItem">
                    <dnn:label id="lblShowCarCaptions" controlname="chkShowCarCaptions" runat="server" />
                    <asp:CheckBox ID="chkShowCarCaptions" runat="server" Checked="true" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblShowCarNavs" controlname="chkCarShowCarNav" runat="server" />
                    <asp:CheckBox ID="chkCarShowCarNav" runat="server" Checked="true" />
                </div>
                <div class="dnnFormItem">
                    <dnn:label id="lblCarStretch" controlname="chkCarStretch" runat="server" />
                    <asp:CheckBox ID="chkCarStretch" runat="server" Checked="true" />
                </div>

                <!--<div class="dnnFormItem">
                    <dnn:label id="lblCarInterval" controlname="txtcarInterval" runat="server" />
                    <asp:TextBox ID="txtCarInterval" runat="server" Width="80px" Text ="5000"></asp:TextBox>
                </div>-->


            </asp:Panel>

            <asp:Panel ID="pnlButtonGroup" runat="server" Visible="false">
                <div class="dnnFormItem">
                    <dnn:label id="lblbtnJustify" controlname="chkJustify" runat="server" />
                    <asp:CheckBox ID="chkJustify" runat="server" />
                    <asp:Label ID="Label1" runat="server" resourcekey="lblbtnJustifyNote"></asp:Label>        
                </div>
                <div class="dnnFormItem">
                    <dnn:label id="lblBtnVerticle" controlname="chkVert" runat="server" />
                    <asp:CheckBox ID="chkVert" runat="server" />
                </div>
                <div class="dnnFormItem">
                    <dnn:label id="lblBtnSize" controlname="ddlBtnSize" runat="server" />
                    <asp:DropDownList ID="ddlBtnSize" runat="server">
                        <asp:ListItem ResourceKey="optbtnSizeLg" Value=" btn-lg"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnSizeStd" Value="" Selected="true"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnSizeSm" Value=" btn-sm"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnSizeXs" Value=" btn-xs"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dnnFormItem">
                    <dnn:label id="lblBtnStyle" controlname="ddlBtnStyle" runat="server" />
                    <asp:DropDownList ID="ddlBtnStyle" runat="server">
                        <asp:ListItem ResourceKey="optbtnStyleStd" Value=" btn-default" Selected="true"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnStyleBlue" Value=" btn-primary"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnStyleGreen" Value=" btn-success"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnStyleLBlue" Value=" btn-info"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnStyleOrange" Value=" btn-warning"></asp:ListItem>
                        <asp:ListItem ResourceKey="optbtnStyleRed" Value=" btn-danger"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                


            </asp:Panel>

            <asp:Panel ID="pnlFlipper" runat="server" Visible="false">
            </asp:Panel>

        </div>

    </fieldset>


