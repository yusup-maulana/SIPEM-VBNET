<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loading
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loading))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar = New Bunifu.Framework.UI.BunifuCircleProgressbar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'StatusLabel
        '
        Me.StatusLabel.BackColor = System.Drawing.Color.Transparent
        Me.StatusLabel.ForeColor = System.Drawing.Color.White
        Me.StatusLabel.Location = New System.Drawing.Point(0, 333)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(1050, 22)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Please wait.."
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ProgressBar.animated = True
        Me.ProgressBar.animationIterval = 1
        Me.ProgressBar.animationSpeed = 100
        Me.ProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.ProgressBar.BackgroundImage = CType(resources.GetObject("ProgressBar.BackgroundImage"), System.Drawing.Image)
        Me.ProgressBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!)
        Me.ProgressBar.ForeColor = System.Drawing.Color.White
        Me.ProgressBar.LabelVisible = True
        Me.ProgressBar.LineProgressThickness = 8
        Me.ProgressBar.LineThickness = 5
        Me.ProgressBar.Location = New System.Drawing.Point(425, 86)
        Me.ProgressBar.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.ProgressBar.MaxValue = 100
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.ProgressBackColor = System.Drawing.Color.DimGray
        Me.ProgressBar.ProgressColor = System.Drawing.Color.OrangeRed
        Me.ProgressBar.Size = New System.Drawing.Size(196, 196)
        Me.ProgressBar.TabIndex = 7
        Me.ProgressBar.Value = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 291)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1050, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Sedang Membuka"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'loading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1050, 495)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.ProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "loading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "loading"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As Bunifu.Framework.UI.BunifuCircleProgressbar
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
