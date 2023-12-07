<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class notulen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(notulen))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.t_pengajuan_lbl_browse_proposal_name = New System.Windows.Forms.Label()
        Me.t_pengajuan_lbl_browse_proposal = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.Label()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        't_pengajuan_lbl_browse_proposal_name
        '
        Me.t_pengajuan_lbl_browse_proposal_name.AutoSize = True
        Me.t_pengajuan_lbl_browse_proposal_name.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_pengajuan_lbl_browse_proposal_name.Location = New System.Drawing.Point(109, 17)
        Me.t_pengajuan_lbl_browse_proposal_name.Name = "t_pengajuan_lbl_browse_proposal_name"
        Me.t_pengajuan_lbl_browse_proposal_name.Size = New System.Drawing.Size(10, 14)
        Me.t_pengajuan_lbl_browse_proposal_name.TabIndex = 22
        Me.t_pengajuan_lbl_browse_proposal_name.Text = ":"
        '
        't_pengajuan_lbl_browse_proposal
        '
        Me.t_pengajuan_lbl_browse_proposal.AutoSize = True
        Me.t_pengajuan_lbl_browse_proposal.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_pengajuan_lbl_browse_proposal.Location = New System.Drawing.Point(93, 17)
        Me.t_pengajuan_lbl_browse_proposal.Name = "t_pengajuan_lbl_browse_proposal"
        Me.t_pengajuan_lbl_browse_proposal.Size = New System.Drawing.Size(10, 14)
        Me.t_pengajuan_lbl_browse_proposal.TabIndex = 21
        Me.t_pengajuan_lbl_browse_proposal.Text = ":"
        Me.t_pengajuan_lbl_browse_proposal.Visible = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Gray
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(12, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 20
        Me.Button7.Text = "Browse.."
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(607, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 22)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "X"
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(12, 62)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(615, 566)
        Me.AxAcroPDF1.TabIndex = 25
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button8.FlatAppearance.BorderSize = 2
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button8.Location = New System.Drawing.Point(439, 9)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(150, 39)
        Me.Button8.TabIndex = 26
        Me.Button8.Text = "Upload Notulen"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(87, 10)
        Me.Panel1.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(161, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(291, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mohon Menunggu, Sedang Mengkonversi Data..."
        '
        'id
        '
        Me.id.AutoSize = True
        Me.id.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.id.Location = New System.Drawing.Point(608, 35)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(15, 13)
        Me.id.TabIndex = 28
        Me.id.Text = "id"
        '
        'notulen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(640, 644)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.t_pengajuan_lbl_browse_proposal_name)
        Me.Controls.Add(Me.t_pengajuan_lbl_browse_proposal)
        Me.Controls.Add(Me.Button7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "notulen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "notulen"
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents t_pengajuan_lbl_browse_proposal_name As System.Windows.Forms.Label
    Friend WithEvents t_pengajuan_lbl_browse_proposal As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.Label
End Class
