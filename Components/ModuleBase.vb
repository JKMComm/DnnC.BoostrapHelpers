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

Imports DotNetNuke.Entities.Modules


Public Class DnnC_HelpersModuleBase
    Inherits PortalModuleBase

    Public ReadOnly Property ItemId() As Integer
        Get
            Dim qs = Request.QueryString("tid")
            If qs IsNot Nothing Then
                Return Convert.ToInt32(qs)
            End If
            Return -1
        End Get
    End Property

    Public ReadOnly Property ItemAction() As String
        Get
            Dim qs = Request.QueryString("tact")
            If qs IsNot Nothing Then
                Return qs
            End If
            Return ""
        End Get
    End Property
End Class
