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

Imports DotNetNuke
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.UI.Utilities
Imports DnnC.Modules.BootstrapHelpers.Components

Partial Class Helpers
    Inherits DnnC_HelpersModuleBase
    Implements IActionable

#Region " Event methods"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Not Settings("HelperType") = Nothing Then

                Select Case LCase(Settings("HelperType"))
                    Case "tabs" : SetUpTabs()
                    Case "accordion" : SetUpAccordion()
                    Case "carousel" : SetUpCarousel()
                    Case "buttongroup" : SetUpButtonGroup()
                    Case "flipper" : SetUpButtonFlipBox()

                End Select
            Else
                pnlMessage.Visible = True
            End If

        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub

#End Region

#Region " Private methods"

    Private Function rndId() As Integer
        Dim retVal As Integer = 0
        retVal = CInt(Int((9000 * Rnd()) + 1))
        Return retVal
    End Function

    Private Sub SetUpTabs()
        Dim tc As New ItemController
        Dim count As Integer = 0
        Dim ctrlId As String = "tabUL-" & rndId() & "-" & ModuleId

        Dim strTabs As New StringBuilder
        Dim strContent As New StringBuilder
        Dim tType As String = String.Empty
        If Settings.Contains("HelperTabType") Then tType = Settings("HelperTabType") Else tType = "nav-tabs"

        Dim fadetabCss As String = String.Empty
        Dim fadeContCss As String = String.Empty

        If Settings.Contains("HelperTabFade") Then
            If CBool(Settings("HelperTabFade")) = True Then
                fadetabCss = " fade in"
                fadeContCss = " fade"
            End If
        End If

        strTabs.AppendLine("<ul id=""" & ctrlId & """  class=""nav " & tType & """>")
        strContent.AppendLine("<div class=""tab-content"">")

        Dim items = From t In tc.GetItems(ModuleId) Order By t.ItemOrder Ascending Select t

        For Each t As Item In items
            count = count + 1
            If t.ItemCheck1 Then
                strTabs.AppendLine("<li class=""active""><a href=""#" & ctrlId & "-" & count & """ data-toggle=""tab"">" & t.ItemText1 & "</a></li>")
                strContent.AppendLine("<div class=""tab-pane" & fadetabCss & " active"" id=""" & ctrlId & "-" & count & """>" & System.Web.HttpUtility.HtmlDecode(t.ItemHtml1) & "</div>")
            Else
                strTabs.AppendLine("<li><a href=""#" & ctrlId & "-" & count & """ data-toggle=""tab"">" & t.ItemText1 & "</a></li>")
                strContent.AppendLine("<div class=""tab-pane" & fadeContCss & """ id=""" & ctrlId & "-" & count & """>" & System.Web.HttpUtility.HtmlDecode(t.ItemHtml1) & "</div>")
            End If
        Next

        strTabs.AppendLine("</ul>")
        strContent.AppendLine("</div>")

        'strContent.AppendLine("<script>")
        'strContent.AppendLine("$('#" & ctrlId & "').click(function (e) {")
        'strContent.AppendLine("e.preventDefault()")
        'strContent.AppendLine("$(this).tab('show')")
        'strContent.AppendLine("})")
        'strContent.AppendLine("</script>")


        phBootStrap1.Text = strTabs.ToString
        phBootStrap2.Text = strContent.ToString
    End Sub

    Private Sub SetUpAccordion()
        Dim tc As New ItemController
        Dim count As Integer = 0
        Dim ctrlId As String = "accordion-" & rndId() & "-" & ModuleId

        Dim strItems As New StringBuilder
        Dim accordionId As String = "accordion" & rndId()
        Dim items = From t In tc.GetItems(ModuleId) Order By t.ItemOrder Ascending Select t

        strItems.AppendLine("<div class=""panel-group"" id=""" & accordionId & """>")
        For Each t As Item In items
            Dim isActive As String = ""
            If t.ItemCheck1 Then isActive = " in"

            count = count + 1

            strItems.AppendLine("<div class=""panel panel-default"">")

            strItems.AppendLine("    <div class=""panel-heading"">")
            strItems.AppendLine("        <h4 class=""panel-title""><a data-toggle=""collapse"" data-parent=""#" & accordionId & """ href=""#" & accordionId & "-" & count & """>" & t.ItemText1 & "</a></h4>")
            strItems.AppendLine("    </div>")

            strItems.AppendLine("    <div id=""" & accordionId & "-" & count & """ class=""panel-collapse collapse" & isActive & """>")
            strItems.AppendLine("        <div class=""panel-body"">" & System.Web.HttpUtility.HtmlDecode(t.ItemHtml1) & "</div>")
            strItems.AppendLine("    </div>")

            strItems.AppendLine("</div>")

        Next
        strItems.AppendLine("</div>")

        phBootStrap1.Text = strItems.ToString
    End Sub

    Private Sub SetUpCarousel()
        Dim tc As New ItemController
        Dim ctrlId As String = "carousel-" & rndId() & "-" & ModuleId
        Dim count As Integer = 0

        Dim strInds As New StringBuilder
        Dim strItems As New StringBuilder
        Dim items = From t In tc.GetItems(ModuleId) Order By t.ItemOrder Ascending Select t
        Dim itemCss As String = String.Empty

        Dim strImageStyle As New StringBuilder
        strImageStyle.AppendLine("<style>")
        strImageStyle.AppendLine("    .carousel-inner>.item>img, .carousel-inner>.item>a>img {")
        strImageStyle.AppendLine("        top: 0;")
        strImageStyle.AppendLine("        left: 0;")
        strImageStyle.AppendLine("        width: 100%;")
        strImageStyle.AppendLine("        height: auto;")
        strImageStyle.AppendLine("    }")
        strImageStyle.AppendLine("</style>")

        If Settings.Contains("HelperCarouselStretch") Then
            If CBool(Settings("HelperCarouselStretch")) Then strInds.AppendLine(strImageStyle.ToString)
        Else
            strInds.AppendLine(strImageStyle.ToString)
        End If

        strInds.AppendLine("<!-- Begin carousel -->")
        strInds.AppendLine("<div id=""" & ctrlId & """ class=""carousel slide"" data-ride=""carousel"">")
        strInds.AppendLine("<!-- Begin Indicators -->")
        strInds.AppendLine("<ol class=""carousel-indicators"">")

        strItems.AppendLine("   <!-- Begin carousel inner -->")
        strItems.AppendLine("   <div class=""carousel-inner"">")


        For Each t As Item In items
            If t.ItemCheck1 Then
                If Not count > 0 Then
                    strInds.AppendLine("<li data-target=""#" & ctrlId & """ data-slide-to=""" & count & """ class=""active""></li>")
                    itemCss = " active"
                Else
                    strInds.AppendLine("<li data-target=""#" & ctrlId & """ data-slide-to=""" & count & """></li>")
                    itemCss = String.Empty
                End If

                strItems.AppendLine("       <div class=""item" & itemCss & """>")
                strItems.AppendLine("           <img src=""" & PortalSettings.HomeDirectory & t.ItemText2 & """ alt=""..."">")
                strItems.AppendLine("           <div class=""carousel-caption"">" & System.Web.HttpUtility.HtmlDecode(t.ItemHtml1) & "</div>")
                strItems.AppendLine("       </div>")

                count = count + 1
            End If
        Next
        strInds.AppendLine("</ol><!-- End Indicators -->")
        strItems.AppendLine("   </div><!-- End carousel inner -->")

        Dim strNav As New StringBuilder
        strNav.AppendLine("   <!-- BEGIN Controls -->")
        strNav.AppendLine("   <a class=""left carousel-control"" href=""#" & ctrlId & """ data-slide=""prev"">")
        strNav.AppendLine("       <span class=""glyphicon glyphicon-chevron-left""></span>")
        strNav.AppendLine("   </a>")
        strNav.AppendLine("   <a class=""right carousel-control"" href=""#" & ctrlId & """ data-slide=""next"">")
        strNav.AppendLine("       <span class=""glyphicon glyphicon-chevron-right""></span>")
        strNav.AppendLine("   </a><!-- End Controls -->")

        If Settings.Contains("HelperCarouselNav") Then
            If CBool(Settings("HelperCarouselNav")) Then strItems.AppendLine(strNav.ToString)
        Else
            strItems.AppendLine(strNav.ToString)
        End If

        strItems.AppendLine("</div><!-- End carousel -->")

        phBootStrap1.Text = strInds.ToString
        phBootStrap2.Text = strItems.ToString
    End Sub

    Private Sub SetUpButtonGroup()
        Dim tc As New ItemController
        Dim items = From t In tc.GetItems(ModuleId) Order By t.ItemOrder Ascending Select t
        Dim strItems As New StringBuilder

        Dim grpAtts As String = String.Empty

        If Settings.Contains("HelperButtonsStack") Then
            If Settings("HelperButtonsStack") Then grpAtts = "btn-group-vertical" Else grpAtts = "btn-group"
        End If

        If Settings.Contains("HelperButtonsJustify") Then
            If Settings("HelperButtonsJustify") Then grpAtts = grpAtts & " btn-group-justified"
        End If

        strItems.AppendLine("<!-- Begin button group -->")
        strItems.AppendLine("<div class=""" & grpAtts & """>")
        For Each t As Item In items


            Dim strUrl As String = String.Empty
            If t.ItemText2 = "U" Then
                strUrl = t.ItemHtml1
            Else
                strUrl = DotNetNuke.Common.Globals.NavigateURL(CInt(t.ItemHtml1.Trim))
            End If


            Dim btnAtts As String = String.Empty

            If Settings.Contains("HelperButtonStyle") Then
                btnAtts = Settings("HelperButtonStyle")
            Else
                btnAtts = " btn-default"
            End If

            If Settings.Contains("HelperButtonSize") Then
                btnAtts = btnAtts & Settings("HelperButtonSize")
            End If


            strItems.AppendLine("<a class=""btn" & btnAtts & """ role=""button"" href=""" & strUrl & """>")




            'If t.ItemText2 = "U" Then
            'strItems.AppendLine("<a class=""btn btn-default"" role=""button"" href=""" & t.ItemHtml1 & """>")
            'End If
            'If t.ItemText2 = "T" Then

            'strItems.AppendLine("<a class=""btn btn-default"" role=""button"" href=""" & strUrl & """>")
            'End If


            strItems.AppendLine(t.ItemText1)
            strItems.AppendLine("</a>")

        Next




        strItems.AppendLine("</div><!-- End button group -->")
        phBootStrap1.Text = strItems.ToString

    End Sub

    Private Sub SetUpButtonFlipBox()
        Dim tc As New ItemController
        Dim ctrlId As String = "flipbox-" & rndId() & "-" & ModuleId
        Dim strFB As New StringBuilder
        Dim strScript As New StringBuilder

        Try
            If Not tc.GetItems(ModuleId) Is Nothing Then

                Dim dir As String = "lr"
                Dim items = From fbi In tc.GetItems(ModuleId)
                For Each t As Item In items
                    If Not t.ItemText5 = String.Empty Then dir = t.ItemText5
                    strFB.AppendLine("<!-- Begin " & ctrlId & " -->")
                    strFB.AppendLine("<div id=""" & ctrlId & """ class=""flip"" style=""width:" & t.ItemText3 & "; height:" & t.ItemText4 & ";"">")
                    strFB.AppendLine("  <div class=""card"" style=""width:" & t.ItemText3 & "; height:" & t.ItemText4 & ";"">")
                    strFB.AppendLine("      <div class=""face front"">" & System.Web.HttpUtility.HtmlDecode(t.ItemHtml1) & "</div>")
                    strFB.AppendLine("      <div class=""face back-" & dir & """>" & System.Web.HttpUtility.HtmlDecode(t.ItemHtml2) & "</div>")
                    strFB.AppendLine("  </div>")
                    strFB.AppendLine("</div><!-- End " & ctrlId & " -->")
                Next

                strScript.AppendLine("<script type=""text/javascript"">")
                strScript.AppendLine("  jQuery(function ($) {")
                strScript.AppendLine("      $(""#" & ctrlId & """).hover(function () {")
                strScript.AppendLine("          $(this).find("".card"").toggleClass(""flipped-" & dir & ";"")")
                strScript.AppendLine("          return false;")
                strScript.AppendLine("      });")
                strScript.AppendLine("  });")
                strScript.AppendLine("</script>")


                phBootStrap1.Text = strFB.ToString
                phBootStrap2.Text = strScript.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

     Public ReadOnly Property ModuleActions() As ModuleActionCollection Implements IActionable.ModuleActions
        Get
            Dim Actions As New ModuleActionCollection
            Actions.Add(GetNextActionID, Localization.GetString("EditModule", LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
            Return Actions
        End Get
    End Property
    
End Class