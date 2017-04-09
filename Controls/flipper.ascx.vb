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

Public Class flipper
    Inherits DnnC_HelpersModuleBase

#Region " Event Methods"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LocalResourceFile = Localization.GetResourceFile(Me.Parent, "/flipper.ascx")
        If Not Page.IsPostBack Then
            Fill4Edit()
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If Page.IsValid Then
            Dim t As New Item()
            Dim tc As New ItemController

            If tc.GetItems(ModuleId).Count > 0 Then
                Dim items = From fbi In tc.GetItems(ModuleId)
                For Each tu As Item In items
                    t = tc.GetItem(tu.ItemId, ModuleId)
                Next
                t.ItemText3 = txtWidth.Text.Trim
                t.ItemText4 = txtHeight.Text.Trim
                t.ItemText5 = ddlDirection.SelectedValue

                t.ItemHtml1 = txtFrtContent.Text.Trim
                t.ItemHtml2 = txtBckContent.Text.Trim

            Else

                t.ItemId = 0
                t.ModuleId = ModuleId
                t.HelperType = "flipbox"
                t.ItemHtml1 = txtFrtContent.Text.Trim
                t.ItemHtml2 = txtBckContent.Text.Trim
                t.ItemText3 = txtWidth.Text.Trim
                t.ItemText4 = txtHeight.Text.Trim
                t.ItemText5 = ddlDirection.SelectedValue

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

#Region "Private methods "

    Private Sub Fill4Edit()
        Dim tc As New ItemController

        Try
            If Not tc.GetItems(ModuleId) Is Nothing Then
                Dim items = From fbi In tc.GetItems(ModuleId)

                For Each t As Item In items
                    txtWidth.Text = t.ItemText3
                    txtHeight.Text = t.ItemText4
                    ddlDirection.SelectedValue = t.ItemText5

                    txtFrtContent.Text = t.ItemHtml1
                    txtBckContent.Text = t.ItemHtml2

                Next

            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class