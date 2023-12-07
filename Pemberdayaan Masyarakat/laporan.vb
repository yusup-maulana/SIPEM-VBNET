Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
Public Class laporan

    Private Sub laporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Clear()
        koneksi_open()
        cmd = New MySqlCommand("select * from login", con)
        rd = cmd.ExecuteReader
        While rd.Read
            If Convert.ToString(rd("nama_instansi")) = "Bandung Kulon" Then

            Else
                ComboBox2.Items.Add(rd("nama_instansi"))
            End If

        End While
        rd.Close()
        con.Close()
        ComboBox1.Items.Clear()
        koneksi_open()
        cmd = New MySqlCommand("select * from kas_pemmas", con)
        rd = cmd.ExecuteReader
        While rd.Read
            ComboBox1.Items.Add(rd("ket"))
        End While
        rd.Close()
        con.Close()
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            Dim str As String = "anggaran_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim str As String = "anggaran_pemasukan_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim str As String = "anggaran_pemasukan.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("FILTER", ComboBox1.Text)
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim str As String = "proposal_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("FILTER", "")
            CrystalReportViewer2.Refresh()
            CrystalReportViewer2.ReportSource = rpt
            CrystalReportViewer2.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim str As String = "proposal_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("FILTER", "Completed")
            CrystalReportViewer2.Refresh()
            CrystalReportViewer2.ReportSource = rpt
            CrystalReportViewer2.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim str As String = "proposal_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("FILTER", "Rejected")
            CrystalReportViewer2.Refresh()
            CrystalReportViewer2.ReportSource = rpt
            CrystalReportViewer2.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim str As String = "proposal_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("FILTER", "Diizinkan")
            CrystalReportViewer2.Refresh()
            CrystalReportViewer2.ReportSource = rpt
            CrystalReportViewer2.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim str As String = "proposal_kelurahan.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("KEL", ComboBox2.Text)
            rpt.SetParameterValue("FILL", ComboBox3.Text)
            CrystalReportViewer2.Refresh()
            CrystalReportViewer2.ReportSource = rpt
            CrystalReportViewer2.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim str As String = "agenda_all.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            CrystalReportViewer3.Refresh()
            CrystalReportViewer3.ReportSource = rpt
            CrystalReportViewer3.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim str As String = "agenda_range.rpt"
            Dim rpt As New ReportDocument()
            rpt.Load(str)
            rpt.SetParameterValue("AWAL", DateTimePicker1.Text)
            rpt.SetParameterValue("AKHIR", DateTimePicker2.Text)
            CrystalReportViewer3.Refresh()
            CrystalReportViewer3.ReportSource = rpt
            CrystalReportViewer3.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CrystalReportViewer3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer3.Load

    End Sub
End Class