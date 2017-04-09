' --- Copyright (c) notice DnnConsulting.nl ---
'  Copyright (c) 2014 DnnConsulting.nl.  www.DnnConsulting.nl. BSD License.
' Author: G. M. Barlow
' ------------------------------------------------------------------------
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' ------------------------------------------------------------------------
' This copyright notice may NOT be removed, obscured or modified without written consent from the author.
' --- End copyright notice --- 

Imports DotNetNuke.Common.Globals
Imports DotNetNuke.Services.Localization
Imports DnnC.Modules.BootstrapHelpers.Components

Public Class tabs
    Inherits DnnC_HelpersModuleBase

#Region " Event Methods"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LocalResourceFile = Localization.GetResourceFile(Me.Parent, "/tabs.ascx")
        BindList()
        If Not Page.IsPostBack Then
            SetupTabs()
        End If
    End Sub

    Private Sub cmdAddTab_Click(sender As Object, e As EventArgs) Handles cmdAddTab.Click
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & moduleid, "tact=new"))
    End Sub

    Private Sub cmdCancelTab_Click(sender As Object, e As EventArgs) Handles cmdCancelTab.Click
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & moduleid))
    End Sub

    Private Sub cmdSaveTab_Click(sender As Object, e As EventArgs) Handles cmdSaveTab.Click
        If Page.IsValid Then
            Dim t As New Item()
            Dim tc As New ItemController
            Dim sc As New SharedFunctions

            If ItemId > 0 Then
                t = tc.GetItem(ItemId, moduleid)
                t.ItemText1 = txtTabTitle.Text.Trim
                t.ItemHtml1 = txtTabContent.Text.Trim

                If chkIsActiveTab.Checked Then sc.ClearActiveTab(moduleid)
                t.ItemCheck1 = chkIsActiveTab.Checked
            Else
                t.ModuleId = moduleid
                t.HelperType = "tabs"
                t.ItemOrder = sc.SetOrder(moduleid)
                t.ItemText1 = txtTabTitle.Text.Trim
                t.ItemHtml1 = txtTabContent.Text.Trim

                If chkIsActiveTab.Checked Then sc.ClearActiveTab(moduleid)
                t.ItemCheck1 = chkIsActiveTab.Checked
                t.CreatedByUserId = UserId
                t.CreatedOnDate = DateTime.Now
            End If

            If t.ItemId > 0 Then
                tc.UpdateItem(t)
            Else
                tc.CreateItem(t)
            End If
            Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
        End If
    End Sub

#End Region

#Region " Private methods"

    Private Sub BindList()
        Dim tc As New ItemController
        Try
            If Not tc.GetItems(ModuleId) Is Nothing Then
                Dim items = From t In tc.GetItems(ModuleId) Order By t.ItemOrder Ascending Select t
                grdItems.DataSource = items
                grdItems.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetupTabs()
        If ItemId > 0 Then
            Fill4Edit()
            pnlList.Visible = False
            pnlInput.Visible = True

        Else

            If ItemAction = "" Then
                'FillTabList()
                pnlList.Visible = True
                pnlInput.Visible = False
            End If
            If ItemAction = "new" Then
                pnlList.Visible = False
                pnlInput.Visible = True
            End If
        End If
    End Sub

    Private Sub Fill4Edit()
        Dim tc As New ItemController
        Dim t As New Item
        t = tc.GetItem(ItemId, ModuleId)
        txtTabTitle.Text = t.ItemText1
        chkIsActiveTab.Checked = t.ItemCheck1
        txtTabContent.Text = t.ItemHtml1
    End Sub

#End Region

#Region " Grid Methods"

    Private Sub grdItems_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles grdItems.ItemCommand
        Select Case e.CommandName.ToLower
            Case "cmdmovedown"
                Dim sc As New SharedFunctions
                sc.MoveItemDown(e.CommandArgument, ModuleId)
                Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))

            Case "cmdmoveup"
                Dim sc As New SharedFunctions
                sc.MoveItemUp(e.CommandArgument, ModuleId)
                Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))

            Case "cmdedititem"
                Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId, "tId=" & e.CommandArgument))

            Case "cmddeleteitem"
                Dim tc As New ItemController
                Dim t As New Item
                Try
                    tc.DeleteItem(CInt(e.CommandArgument), ModuleId)
                    Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
                Catch ex As Exception

                End Try

        End Select
    End Sub

    Private Sub grdItems_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles grdItems.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim cmdDeleteItem As ImageButton = DirectCast(e.Item.FindControl("cmdDeleteItem"), ImageButton)
            cmdDeleteItem.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("WarningDeletetabText", Me.LocalResourceFile) & "');")

            Dim imgActive As Image = DirectCast(e.Item.FindControl("imgActive"), Image)
            If DataBinder.Eval(e.Item.DataItem, "ItemCheck1") Then
                imgActive.ImageUrl = "~/icons/sigma/Checked_16x16_Standard_2.png"
            Else
                imgActive.ImageUrl = "~/icons/sigma/Unchecked_16x16_Standard.png"
            End If

            Dim sc As New SharedFunctions
            Dim cmdMoveItemUp As ImageButton = DirectCast(e.Item.FindControl("cmdMoveItemUp"), ImageButton)
            Dim cmdMoveItemDown As ImageButton = DirectCast(e.Item.FindControl("cmdMoveItemDown"), ImageButton)
            If sc.IsFirstItem(DataBinder.Eval(e.Item.DataItem, "ItemId"), ModuleId) Then cmdMoveItemUp.Visible = False
            If sc.IsLastItem(DataBinder.Eval(e.Item.DataItem, "ItemId"), ModuleId) Then cmdMoveItemDown.Visible = False

        End If
    End Sub

#End Region
    
End Class