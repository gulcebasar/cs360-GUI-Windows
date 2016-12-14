Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Timers
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Const radius As Integer = 10
    Const velocity As Integer = 5

    Private xC As Integer, yC As Integer, xDelta As Double = 10, yDelta As Double = 10, xSize As Integer, ySize As Integer, topC As Integer, leftC As Integer
    Private timer1 As New System.Windows.Forms.Timer()
    Private components As System.ComponentModel.IContainer

    Public Sub New()
        InitializeComponent()

        Me.ResizeRedraw = True
        timer1.Start()
        
        Form1_Resize(Me, EventArgs.Empty)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(72, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Stop"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(150, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(61, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Speed- -"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(217, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Speed++"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Enabled = True
        Me.timer1.Interval = 25
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(300, 15)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(33, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.Text = "0'"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(339, 15)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.Text = "30'"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(384, 15)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "45'"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RadioButton4.Location = New System.Drawing.Point(430, 15)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton4.TabIndex = 7
        Me.RadioButton4.Text = "60'"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(475, 15)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton5.TabIndex = 8
        Me.RadioButton5.Text = "90'"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(526, 309)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Bouncing Ball"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        AddHandler Me.timer1.Tick, New System.EventHandler(AddressOf Me.timer1_Tick)
        AddHandler Me.Resize, New System.EventHandler(AddressOf Me.Form1_Resize)
        xC = 0
        yC = 0

    End Sub

    'AddHandler Me.timer1.Tick, New System.EventHandler(AddressOf Me.timer1_Tick)
    'AddHandler Me.Resize, New System.EventHandler(AddressOf Me.Form1_Resize)

    <STAThread> _
    Private Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles MyBase.Resize
        Dim oldX As Integer, oldY As Integer
        oldX = xSize
        oldY = ySize

        xSize = Me.ClientSize.Width
        ySize = Me.ClientSize.Height

        If (xC = 0) Then
            xC = xSize / 2
            yC = ySize / 2
        ElseIf (ySize <> oldY And topC = Me.ClientRectangle.Top) Then
            yC = yC + (ySize - oldY)
        ElseIf (xSize <> oldX And leftC = Me.ClientRectangle.Left) Then
            xC = xC + (xSize - oldX)
        End If

        If (yC > ySize) Then
            yC = ySize
        ElseIf (yC < 0) Then
            yC = 0
        End If

        If (xC > xSize) Then
            xC = xSize
        ElseIf (xC < 0) Then
            xC = 0
        End If

        DrawBall()
    End Sub

    Private Sub timer1_Tick(sender As Object, e As System.EventArgs)
        topC = Me.ClientRectangle.Top
        leftC = Me.ClientRectangle.Left
        DrawBall()          
    End Sub

    Private Sub DrawBall()
        Dim g As Graphics = Me.CreateGraphics()
        Dim b As Brush = New SolidBrush(Me.BackColor)
        g.FillEllipse(b, xC - radius, yC - radius, 2 * radius, 2 * radius)
        'erase old ball
        xC += xDelta
        'move ball
        yC += yDelta
        ' next, chk for wall hits
        If (xC + radius >= ClientSize.Width) OrElse (xC - radius <= 0) Then
            xDelta = -xDelta
        End If
        If (yC + radius >= ClientSize.Height) OrElse (yC - radius <= 0) Then
            yDelta = -yDelta
        End If
        b = New SolidBrush(Color.Blue)
        ' draw new ball
        g.FillEllipse(b, xC - radius, yC - radius, 2 * radius, 2 * radius)
        b.Dispose()
        g.Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        timer1.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If (xDelta > 0) Then
            xDelta = xDelta - velocity
        ElseIf (xDelta < 0) Then
            xDelta = xDelta + velocity
        Else
            If (RadioButton5.Checked) Then
            Else
                yDelta = 0
            End If
        End If

        If (yDelta > 0) Then
            yDelta = yDelta - velocity
        ElseIf (yDelta < 0) Then
            yDelta = yDelta + velocity
        Else
            If (RadioButton1.Checked) Then
            Else
                xDelta = 0
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If (xDelta > 0) Then
            xDelta = xDelta + velocity
        ElseIf (xDelta < 0) Then
            xDelta = xDelta - velocity
        End If

        If (yDelta > 0) Then
            yDelta = yDelta + velocity
        ElseIf (yDelta < 0) Then
            yDelta = yDelta - velocity
        End If

        If yDelta = 0 And xDelta = 0 Then
            If (RadioButton1.Checked) Then
                xDelta = velocity
            ElseIf (RadioButton5.Checked) Then
                yDelta = velocity
            End If
        End If

    End Sub
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If (xDelta <> 0) Then
            yDelta = xDelta * 1.732
        Else
            xDelta = yDelta / 1.732
        End If

    End Sub
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If (yDelta = 0) Then
            yDelta = xDelta
        End If
        xDelta = 0
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If (xDelta <> 0) Then
            yDelta = xDelta
        Else
            xDelta = yDelta
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If (xDelta = 0) Then
            xDelta = yDelta
        End If
        yDelta = 0
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
       If (xDelta <> 0) Then
            yDelta = xDelta / 1.732
        Else
            xDelta = yDelta * 1.732
        End If
    End Sub
End Class

