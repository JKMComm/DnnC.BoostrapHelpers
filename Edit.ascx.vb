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

Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Common.Globals
Imports DotNetNuke.Services.Localization
Imports DnnC.Modules.BootstrapHelpers.Components
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke
Imports DotNetNuke.Web.UI.WebControls

Public Class Edit
    Inherits DnnC_HelpersModuleBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then
        Try
            If (Settings.Contains("HelperType")) Then
                Dim objModule As Entities.Modules.PortalModuleBase = Nothing
                Dim myPath As String = ControlPath & "Controls/"
                Select Case LCase(Settings("HelperType"))
                    Case "tabs" : objModule = LoadControl(myPath & "tabs.ascx")
                    Case "accordion" : objModule = LoadControl(myPath & "accordion.ascx")
                    Case "carousel" : objModule = LoadControl(myPath & "carousel.ascx")
                    Case "buttongroup" : objModule = LoadControl(myPath & "buttonGroup.ascx")
                    Case "flipper" : objModule = LoadControl(myPath & "flipper.ascx")
                End Select

                objModule.LocalResourceFile = Me.LocalResourceFile
                objModule.ModuleConfiguration = ModuleConfiguration
                myPholder.Controls.Add(objModule)
            End If

        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Response.Redirect(NavigateURL(), True)
    End Sub

End Class