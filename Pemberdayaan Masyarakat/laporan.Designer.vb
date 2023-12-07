<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class laporan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(laporan))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_anggaran = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.tab_proposal = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.tab_agenda = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tab_anggaran.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tab_proposal.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tab_agenda.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_anggaran)
        Me.TabControl1.Controls.Add(Me.tab_proposal)
        Me.TabControl1.Controls.Add(Me.tab_agenda)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1209, 601)
        Me.TabControl1.TabIndex = 0
        '
        'tab_anggaran
        '
        Me.tab_anggaran.Controls.Add(Me.Panel4)
        Me.tab_anggaran.Controls.Add(Me.Panel1)
        Me.tab_anggaran.Location = New System.Drawing.Point(4, 22)
        Me.tab_anggaran.Name = "tab_anggaran"
        Me.tab_anggaran.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_anggaran.Size = New System.Drawing.Size(1201, 575)
        Me.tab_anggaran.TabIndex = 0
        Me.tab_anggaran.Text = "ANGGARAN"
        Me.tab_anggaran.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.CrystalReportViewer1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 87)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1195, 485)
        Me.Panel4.TabIndex = 1
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1195, 485)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button20)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1195, 84)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button2.Location = New System.Drawing.Point(155, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(162, 37)
        Me.Button2.TabIndex = 43
        Me.Button2.Text = "Semua Pemasukan"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(739, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Pemasukan bedasarkan / Kas"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(730, 31)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(305, 30)
        Me.ComboBox1.TabIndex = 41
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button1.Location = New System.Drawing.Point(1041, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 37)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Preview"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button20.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button20.FlatAppearance.BorderSize = 2
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button20.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button20.Location = New System.Drawing.Point(17, 27)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(132, 37)
        Me.Button20.TabIndex = 39
        Me.Button20.Text = "Kas Pemmas"
        Me.Button20.UseVisualStyleBackColor = False
        '
        'tab_proposal
        '
        Me.tab_proposal.Controls.Add(Me.Panel5)
        Me.tab_proposal.Controls.Add(Me.Panel2)
        Me.tab_proposal.Location = New System.Drawing.Point(4, 22)
        Me.tab_proposal.Name = "tab_proposal"
        Me.tab_proposal.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_proposal.Size = New System.Drawing.Size(1201, 575)
        Me.tab_proposal.TabIndex = 1
        Me.tab_proposal.Text = "PROPOSAL"
        Me.tab_proposal.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.CrystalReportViewer2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 87)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1195, 485)
        Me.Panel5.TabIndex = 2
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = -1
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(1195, 485)
        Me.CrystalReportViewer2.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.ComboBox3)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ComboBox2)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1195, 84)
        Me.Panel2.TabIndex = 1
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button7.FlatAppearance.BorderSize = 2
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button7.Location = New System.Drawing.Point(416, 27)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(124, 37)
        Me.Button7.TabIndex = 47
        Me.Button7.Text = "PROPOSAL BERJALAN"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(652, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Kategori"
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"", "Completed", "Rejected", "Diizinkan"})
        Me.ComboBox3.Location = New System.Drawing.Point(645, 31)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(134, 30)
        Me.ComboBox3.TabIndex = 45
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button6.FlatAppearance.BorderSize = 2
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button6.Location = New System.Drawing.Point(286, 27)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(124, 37)
        Me.Button6.TabIndex = 44
        Me.Button6.Text = "PROPOSAL REJECTED"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button3.Location = New System.Drawing.Point(142, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 37)
        Me.Button3.TabIndex = 43
        Me.Button3.Text = "PROPOSAL COMPLETE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(794, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Bedasarkan Kelurahan"
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(785, 31)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(233, 30)
        Me.ComboBox2.TabIndex = 41
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button4.Location = New System.Drawing.Point(1024, 27)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(132, 37)
        Me.Button4.TabIndex = 40
        Me.Button4.Text = "Preview"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button5.FlatAppearance.BorderSize = 2
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button5.Location = New System.Drawing.Point(17, 27)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(119, 37)
        Me.Button5.TabIndex = 39
        Me.Button5.Text = "SEMUA PROPOSAL"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'tab_agenda
        '
        Me.tab_agenda.Controls.Add(Me.Panel6)
        Me.tab_agenda.Controls.Add(Me.Panel3)
        Me.tab_agenda.Location = New System.Drawing.Point(4, 22)
        Me.tab_agenda.Name = "tab_agenda"
        Me.tab_agenda.Size = New System.Drawing.Size(1201, 575)
        Me.tab_agenda.TabIndex = 2
        Me.tab_agenda.Text = "AGENDA"
        Me.tab_agenda.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.CrystalReportViewer3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 84)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1201, 491)
        Me.Panel6.TabIndex = 3
        '
        'CrystalReportViewer3
        '
        Me.CrystalReportViewer3.ActiveViewIndex = -1
        Me.CrystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer3.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer3.Name = "CrystalReportViewer3"
        Me.CrystalReportViewer3.Size = New System.Drawing.Size(1201, 491)
        Me.CrystalReportViewer3.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.DateTimePicker2)
        Me.Panel3.Controls.Add(Me.DateTimePicker1)
        Me.Panel3.Controls.Add(Me.Button9)
        Me.Panel3.Controls.Add(Me.Button10)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1201, 84)
        Me.Panel3.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(924, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(707, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "RANGE TANGGAL"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(941, 40)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 42
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(830, 40)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 41
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button9.FlatAppearance.BorderSize = 2
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button9.Location = New System.Drawing.Point(1044, 33)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(132, 37)
        Me.Button9.TabIndex = 40
        Me.Button9.Text = "Preview"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.SystemColors.GrayText
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button10.FlatAppearance.BorderSize = 2
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button10.Location = New System.Drawing.Point(17, 27)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(170, 37)
        Me.Button10.TabIndex = 39
        Me.Button10.Text = "SEMUA AGENDA"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'laporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1209, 601)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "laporan"
        Me.Text = "laporan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.tab_anggaran.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tab_proposal.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tab_agenda.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_anggaran As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tab_proposal As System.Windows.Forms.TabPage
    Friend WithEvents tab_agenda As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents CrystalReportViewer3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
