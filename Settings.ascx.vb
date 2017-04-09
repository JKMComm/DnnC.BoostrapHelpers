Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions

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

Public Class Settings
    Inherits SettingsBase

#Region "Base Method Implementations"

    Public Overrides Sub LoadSettings()
        Try
            If (Page.IsPostBack = False) Then

                If (Settings.Contains("HelperType")) Then
                    If Settings("HelperType") = "tabs" Then
                        ddlHelperType.SelectedValue = Settings("HelperType").ToString()
                        ClearPanels(pnlTabs)
                    End If

                    If Settings("HelperType") = "accordion" Then
                        ddlHelperType.SelectedValue = Settings("HelperType").ToString()
                        ClearPanels(pnlTabs)
                    End If

                    If Settings("HelperType") = "carousel" Then
                        ddlHelperType.SelectedValue = Settings("HelperType").ToString()
                        ClearPanels(pnlCarousel)
                    End If

                    If Settings("HelperType") = "buttongroup" Then
                        ddlHelperType.SelectedValue = Settings("HelperType").ToString()
                        ClearPanels(pnlButtonGroup)
                    End If

                    If Settings("HelperType") = "flipper" Then
                        ddlHelperType.SelectedValue = Settings("HelperType").ToString()
                        ClearPanels(pnlFlipper)
                    End If

                End If

                If (Settings.Contains("HelperTabFade")) Then chkUseTabFade.Checked = CBool(Settings("HelperTabFade"))
                If (Settings.Contains("HelperTabType")) Then rdoTabType.SelectedValue = Settings("HelperTabType").ToString

                If (Settings.Contains("HelperCarouselCaptions")) Then chkShowCarCaptions.Checked = CBool(Settings("HelperCarouselCaptions"))
                If (Settings.Contains("HelperCarouselInterval")) Then txtCarInterval.Text = Settings("HelperCarouselInterval").ToString
                If (Settings.Contains("HelperCarouselNav")) Then chkCarShowCarNav.Checked = CBool(Settings("HelperCarouselNav"))
                If (Settings.Contains("HelperCarouselStretch")) Then chkCarStretch.Checked = CBool(Settings("HelperCarouselStretch"))

                If (Settings.Contains("HelperButtonsStack")) Then chkVert.Checked = CBool(Settings("HelperButtonsStack"))
                If (Settings.Contains("HelperButtonsJustify")) Then chkJustify.Checked = CBool(Settings("HelperButtonsJustify"))
                If (Settings.Contains("HelperButtonSize")) Then ddlBtnSize.SelectedValue = Settings("HelperButtonSize")
                If (Settings.Contains("HelperButtonStyle")) Then ddlBtnStyle.SelectedValue = Settings("HelperButtonStyle")

            End If
        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    Public Overrides Sub UpdateSettings()
        Try
            Dim objModules As New Entities.Modules.ModuleController
            objModules.UpdateModuleSetting(ModuleId, "HelperType", ddlHelperType.SelectedValue)

            objModules.UpdateModuleSetting(ModuleId, "HelperTabFade", chkUseTabFade.Checked)
            objModules.UpdateModuleSetting(ModuleId, "HelperTabType", rdoTabType.SelectedValue)

            objModules.UpdateModuleSetting(ModuleId, "HelperCarouselCaptions", chkShowCarCaptions.Checked)
            objModules.UpdateModuleSetting(ModuleId, "HelperCarouselInterval", txtCarInterval.Text.Trim)
            objModules.UpdateModuleSetting(ModuleId, "HelperCarouselNav", chkCarShowCarNav.Checked)
            objModules.UpdateModuleSetting(ModuleId, "HelperCarouselStretch", chkCarStretch.Checked)


            objModules.UpdateModuleSetting(ModuleId, "HelperButtonsStack", chkVert.Checked)
            objModules.UpdateModuleSetting(ModuleId, "HelperButtonsJustify", chkJustify.Checked)
            objModules.UpdateModuleSetting(ModuleId, "HelperButtonSize", ddlBtnSize.SelectedValue)
            objModules.UpdateModuleSetting(ModuleId, "HelperButtonStyle", ddlBtnStyle.SelectedValue)


        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

#End Region

    Private Sub ddlHelperType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlHelperType.SelectedIndexChanged
        Select Case LCase(ddlHelperType.SelectedValue)
            Case "tabs"
                ClearPanels(pnlTabs)
            Case "accordion"
                ClearPanels(pnlAccordion)
            Case "carousel"
                ClearPanels(pnlCarousel)
            Case "buttongroup"
                ClearPanels(pnlButtonGroup)
        End Select
    End Sub

    Private Sub ClearPanels(pnl As Panel)
        pnlTabs.Visible = False
        pnlAccordion.Visible = False
        pnlCarousel.Visible = False
        pnlButtonGroup.Visible = False

        pnl.Visible = True
    End Sub

End Class