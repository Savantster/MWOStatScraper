
' The bulk of this code is the ExpandableGroupBox code taken from the web. I have modified
' the code to facilitate our "last match" info, including picture.. but some of the changes
' I wanted to do were easier to do directly to the class than adding/overriding things in
' a derived class.. The bulk of clMechMatch is not my original code..

Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.Design
Imports System.Drawing.Drawing2D

<Designer(GetType(ExpandableGroupboxDesigner))> _
Public Class clMechMatch
    Inherits System.Windows.Forms.UserControl

#Region " Designer Generated (do not edit) "

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents pbMech As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbLastMatch As System.Windows.Forms.GroupBox
    Friend WithEvents lblCBills As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblExp As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDamage As System.Windows.Forms.Label
    Friend WithEvents lblKills As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbLived As System.Windows.Forms.PictureBox
    Friend WithEvents pbWin As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlStats As System.Windows.Forms.Panel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.ExpandButton = New System.Windows.Forms.Button()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.pbMech = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbLastMatch = New System.Windows.Forms.GroupBox()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.lblCBills = New System.Windows.Forms.Label()
        Me.lblKills = New System.Windows.Forms.Label()
        Me.pbWin = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbLived = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblExp = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDamage = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pbMech, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLastMatch.SuspendLayout()
        Me.pnlStats.SuspendLayout()
        CType(Me.pbWin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.ExpandButton)
        Me.pnlHeader.Controls.Add(Me.lblCaption)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(977, 21)
        Me.pnlHeader.TabIndex = 0
        '
        'ExpandButton
        '
        Me.ExpandButton.Location = New System.Drawing.Point(10, 2)
        Me.ExpandButton.Name = "ExpandButton"
        Me.ExpandButton.Size = New System.Drawing.Size(17, 17)
        Me.ExpandButton.TabIndex = 0
        Me.ExpandButton.UseVisualStyleBackColor = True
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(27, 3)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(0, 13)
        Me.lblCaption.TabIndex = 0
        '
        'pbMech
        '
        Me.pbMech.Location = New System.Drawing.Point(10, 27)
        Me.pbMech.Name = "pbMech"
        Me.pbMech.Size = New System.Drawing.Size(100, 100)
        Me.pbMech.TabIndex = 1
        Me.pbMech.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Win?"
        '
        'gbLastMatch
        '
        Me.gbLastMatch.BackColor = System.Drawing.Color.Transparent
        Me.gbLastMatch.Controls.Add(Me.pnlStats)
        Me.gbLastMatch.Location = New System.Drawing.Point(116, 25)
        Me.gbLastMatch.Name = "gbLastMatch"
        Me.gbLastMatch.Size = New System.Drawing.Size(469, 95)
        Me.gbLastMatch.TabIndex = 4
        Me.gbLastMatch.TabStop = False
        Me.gbLastMatch.Text = "Last Match Details"
        '
        'pnlStats
        '
        Me.pnlStats.Controls.Add(Me.lblCBills)
        Me.pnlStats.Controls.Add(Me.lblKills)
        Me.pnlStats.Controls.Add(Me.pbWin)
        Me.pnlStats.Controls.Add(Me.Label9)
        Me.pnlStats.Controls.Add(Me.pbLived)
        Me.pnlStats.Controls.Add(Me.Label3)
        Me.pnlStats.Controls.Add(Me.lblExp)
        Me.pnlStats.Controls.Add(Me.Label4)
        Me.pnlStats.Controls.Add(Me.Label2)
        Me.pnlStats.Controls.Add(Me.Label7)
        Me.pnlStats.Controls.Add(Me.Label1)
        Me.pnlStats.Controls.Add(Me.lblDamage)
        Me.pnlStats.Location = New System.Drawing.Point(6, 15)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Size = New System.Drawing.Size(457, 74)
        Me.pnlStats.TabIndex = 0
        '
        'lblCBills
        '
        Me.lblCBills.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblCBills.Location = New System.Drawing.Point(335, 32)
        Me.lblCBills.Name = "lblCBills"
        Me.lblCBills.Size = New System.Drawing.Size(104, 29)
        Me.lblCBills.TabIndex = 16
        Me.lblCBills.Text = "125,000"
        Me.lblCBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKills
        '
        Me.lblKills.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblKills.Location = New System.Drawing.Point(106, 32)
        Me.lblKills.Name = "lblKills"
        Me.lblKills.Size = New System.Drawing.Size(41, 29)
        Me.lblKills.TabIndex = 11
        Me.lblKills.Text = "12"
        Me.lblKills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbWin
        '
        Me.pbWin.Location = New System.Drawing.Point(9, 34)
        Me.pbWin.Name = "pbWin"
        Me.pbWin.Size = New System.Drawing.Size(30, 30)
        Me.pbWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbWin.TabIndex = 7
        Me.pbWin.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(368, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "C-Bills"
        '
        'pbLived
        '
        Me.pbLived.Location = New System.Drawing.Point(60, 34)
        Me.pbLived.Name = "pbLived"
        Me.pbLived.Size = New System.Drawing.Size(30, 30)
        Me.pbLived.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLived.TabIndex = 8
        Me.pbLived.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(114, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Kills"
        '
        'lblExp
        '
        Me.lblExp.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblExp.Location = New System.Drawing.Point(230, 32)
        Me.lblExp.Name = "lblExp"
        Me.lblExp.Size = New System.Drawing.Size(90, 29)
        Me.lblExp.TabIndex = 14
        Me.lblExp.Text = "1,500"
        Me.lblExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Dammage"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lived?"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(260, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "EXP"
        '
        'lblDamage
        '
        Me.lblDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblDamage.Location = New System.Drawing.Point(158, 32)
        Me.lblDamage.Name = "lblDamage"
        Me.lblDamage.Size = New System.Drawing.Size(71, 29)
        Me.lblDamage.TabIndex = 12
        Me.lblDamage.Text = "333"
        Me.lblDamage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'clMechMatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.gbLastMatch)
        Me.Controls.Add(Me.pbMech)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "clMechMatch"
        Me.Size = New System.Drawing.Size(977, 432)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.pbMech, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLastMatch.ResumeLayout(False)
        Me.pnlStats.ResumeLayout(False)
        Me.pnlStats.PerformLayout()
        CType(Me.pbWin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents ExpandButton As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label

#End Region

    ''' <summary>
    ''' Fired when the control is Expanded or Collapsed.
    ''' </summary>
    Public Event Expand As EventHandler

#Region " Properties "

    Private _Caption As String
    ''' <summary>
    ''' The text shown as the caption of the <see cref="clMechMatch" />.
    ''' </summary>
    <Browsable(True)> _
    Public Property Caption() As String
        Get
            Return _Caption
        End Get
        Set(ByVal value As String)
            _Caption = value
            Me.lblCaption.Text = value
        End Set
    End Property

    Private _BorderColor As Color
    ''' <summary>
    ''' The color of the custom-drawn rounded border.
    ''' </summary>
    <DefaultValue(GetType(Color), "214, 213, 217")> _
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    Private _Expanded As Boolean
    ''' <summary>
    ''' True when the control is expanded.
    ''' </summary>
    <DefaultValue(True)> _
    Public Property Expanded() As Boolean
        Get
            Return _Expanded
        End Get
        Set(ByVal value As Boolean)
            _Expanded = value

            'Make sure we set the size correctly
            Me.OnExpand()
        End Set
    End Property

    Private _CaptionColor As Color
    ''' <summary>
    ''' The ForeColor of the text shown as the caption of the <see cref="clMechMatch" />.
    ''' </summary>
    <DefaultValue(GetType(Color), "51, 94, 168")> _
    Public Property CaptionColor() As Color
        Get
            Return _CaptionColor
        End Get
        Set(ByVal value As Color)
            _CaptionColor = value

            Me.lblCaption.ForeColor = value
        End Set
    End Property

    Private _ExpandedSize As Size
    ''' <summary>
    ''' The Size of the <see cref="clMechMatch" /> when expanded. Should be set by resizing the control in the designer as usual.
    ''' </summary>
    <Browsable(False), _
    DefaultValue(GetType(Size), "200, 100")> _
    Public Property ExpandedSize() As Size
        Get
            Return _ExpandedSize
        End Get
        Set(ByVal value As Size)
            _ExpandedSize = value
        End Set
    End Property

    Private _CollapsedMinSize As Integer
    ''' <summary>
    ''' The minimum size to collapse too, useful if you want to force some portion of the control to remain open even when collapsed
    ''' </summary>
    <DefaultValue(0)> _
    Public Property CollapsedMinSize As Integer
        Get
            Return _CollapsedMinSize
        End Get
        Set(value As Integer)
            _CollapsedMinSize = If(value < pnlHeader.Height, pnlHeader.Height, value)
        End Set
    End Property

    Private _HeaderClickExpand As Boolean
    ''' <summary>
    ''' If True, expands / collapses the control when the header (caption) is clicked, instead of using the button only.
    ''' </summary>
    <DefaultValue(False)> _
    Public Property HeaderClickExpand() As Boolean
        Get
            Return _HeaderClickExpand
        End Get
        Set(ByVal value As Boolean)
            _HeaderClickExpand = value
        End Set
    End Property

    Public Property MechImage As Image
        Get
            Return pbMech.Image
        End Get
        Set(value As Image)
            pbMech.Image = value
        End Set
    End Property

    Private _MechId As Integer = -1
    Public Property MechId As Integer
        Get
            Return _MechId
        End Get
        Set(value As Integer)
            _MechId = value
        End Set
    End Property

    Public WriteOnly Property Win As Image
        Set(value As Image)
            pbWin.Image = value
        End Set
    End Property

    Public WriteOnly Property Lived As Image
        Set(value As Image)
            pbLived.Image = value
        End Set
    End Property

    Public WriteOnly Property Kills As Integer
        Set(value As Integer)
            lblKills.Text = value
        End Set
    End Property

    Public WriteOnly Property Damage As String
        Set(value As String)
            If value.Contains(".") Then
                lblDamage.Text = String.Format("{0:#,###.##}", value)
            Else
                lblDamage.Text = String.Format("{0:#,###}", value)
            End If
        End Set
    End Property

    Public WriteOnly Property Exp As Integer
        Set(value As Integer)
            lblExp.Text = String.Format("{0:#,###}", value)
        End Set
    End Property
    Public WriteOnly Property cBills As Integer
        Set(value As Integer)
            lblCBills.Text = String.Format("{0:###,###}", value)
        End Set
    End Property
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BorderColor = Color.FromArgb(214, 213, 217)
        Me.Expanded = False
        Me.CaptionColor = Color.FromArgb(51, 94, 168)
        Me.HeaderClickExpand = True

        Me.Size = New Size(200, 100)

        Me.lblCaption.Text = Me.Caption
        Me.lblCaption.ForeColor = Me.CaptionColor
    End Sub

#Region " Methods "

    ''' <summary>
    ''' Changes the Size property of the control when it is expanded/collapsed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub OnExpand()
        If Me.Expanded Then
            Me.Size = Me.ExpandedSize
        Else
            Me.Size = New Size(pnlHeader.Width, _CollapsedMinSize)
        End If
    End Sub

    Public Sub ClearHighlight()
        pnlStats.BackColor = Color.Transparent
    End Sub

    Public Sub SetHighlight()
        pnlStats.BackColor = Color.BlueViolet
    End Sub

#End Region

#Region " Events "

    Private Sub ExpandButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandButton.Click, pbMech.Click
        'Toggle the expansion
        Me.Expanded = Not Me.Expanded

        'Repaint the button
        ExpandButton.Invalidate()

        'Repaint the header
        pnlHeader.Invalidate()

        RaiseEvent Expand(Me, EventArgs.Empty)
    End Sub

    'Makes sure we can't drag the control out when it is collapsed
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        If Me.Expanded Then
            Me.ExpandedSize = Me.Size
        Else
            If Me.DesignMode Then
                Me.Size = pnlHeader.Size
                Me.ExpandedSize = New Size(Me.Size.Width, Me.ExpandedSize.Height)
            End If
        End If

        gbLastMatch.Width = (Me.Size.Width - gbLastMatch.Location.X)

    End Sub

    Private Sub pnlHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlHeader.Click
        If Me.HeaderClickExpand Then ExpandButton.PerformClick()
    End Sub

    Private Sub lblCaption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCaption.Click
        If Me.HeaderClickExpand Then ExpandButton.PerformClick()
    End Sub

#End Region

#Region " Drawing "

    Private Sub pnlHeader_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlHeader.Paint
        Using borderPen As New Pen(Me.BorderColor, 1)
            'Right of button/text
            'e.Graphics.DrawLine(borderPen, Me.lblCaption.Left + Me.lblCaption.Width + 10, 11, Me.Width - 4, 11)
            If Me.Expanded Then
                e.Graphics.DrawLine(borderPen, Me.Width - 4, 12, Me.Width - 3, 12)
                e.Graphics.DrawLine(borderPen, Me.Width - 3, 13, Me.Width - 2, 13)
                e.Graphics.DrawLine(borderPen, Me.Width - 2, 14, Me.Width - 2, Me.Height)
            End If

            'Left of button
            'e.Graphics.DrawLine(borderPen, 4, 11, 7, 11)
            If Me.Expanded Then
                e.Graphics.DrawLine(borderPen, 3, 12, 4, 12)
                e.Graphics.DrawLine(borderPen, 2, 13, 3, 13)
                e.Graphics.DrawLine(borderPen, 2, 14, 2, Me.Height)
            End If
        End Using
    End Sub

    Private Sub pnlContainer_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Using borderPen As New Pen(Me.BorderColor, 1)

            e.Graphics.DrawLine(borderPen, 2, 0, 2, Me.Height - 4)
            e.Graphics.DrawLine(borderPen, Me.Width - 2, 0, Me.Width - 2, Me.Height - 4)

            e.Graphics.DrawLine(borderPen, 4, Me.Height - 1, Me.Width - 4, Me.Height - 1)

            e.Graphics.DrawLine(borderPen, 3, Me.Height - 2, 4, Me.Height - 2)
            e.Graphics.DrawLine(borderPen, 2, Me.Height - 3, 3, Me.Height - 3)

            e.Graphics.DrawLine(borderPen, Me.Width - 4, Me.Height - 2, Me.Width - 3, Me.Height - 2)
            e.Graphics.DrawLine(borderPen, Me.Width - 3, Me.Height - 3, Me.Width - 2, Me.Height - 3)
        End Using
    End Sub

    Private Sub ExpandButton_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ExpandButton.Paint
        e.Graphics.DrawLine(Pens.Black, 5, ExpandButton.Height \ 2, ExpandButton.Width - 6, ExpandButton.Height \ 2)
        If Not Me.Expanded Then
            e.Graphics.DrawLine(Pens.Black, ExpandButton.Width \ 2, 5, ExpandButton.Width \ 2, ExpandButton.Height - 6)
        End If
    End Sub

#End Region

End Class

''' <summary>
''' Designer class that enables the user to expand/collapse the <see cref="clMechMatch" /> control during Design-Time.
''' </summary>
''' <remarks></remarks>
Public Class ExpandableGroupboxDesigner
    Inherits ParentControlDesigner

    Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)

        'Add an event handler for the button click event so we can update the control
        Dim btnExpand As Button = CType(Me.Control, clMechMatch).ExpandButton
        AddHandler btnExpand.Click, AddressOf ExpandButtonClicked
    End Sub

    Public Sub ExpandButtonClicked(ByVal sender As Object, ByVal ev As EventArgs)
        'Tell the designer to update the control
        'If we don't do this, the selection rectangle would not update
        Me.RaiseComponentChanged(TypeDescriptor.GetProperties(Me.Control)("Size"), Nothing, Nothing)
    End Sub

    'This function enables us to click the button during design-time
    Protected Overrides Function GetHitTest(ByVal point As System.Drawing.Point) As Boolean
        Dim btnExpand As Button = CType(Me.Control, clMechMatch).ExpandButton
        If (btnExpand.Bounds.Contains(Me.Control.PointToClient(point))) Then
            Return True
        End If
        Return MyBase.GetHitTest(point)
    End Function

End Class
