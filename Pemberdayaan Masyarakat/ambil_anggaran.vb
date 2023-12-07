Imports MySql.Data.MySqlClient
Public Class ambil_anggaran
    Dim bit As Integer
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


    Private Sub BunifuGradientPanel_topheader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub BunifuGradientPanel_topheader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub BunifuGradientPanel_topheader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub BunifuiOSSwitch1_OnValueChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuiOSSwitch1.OnValueChange
        If BunifuiOSSwitch1.Value = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuFlatButton1.Click
        If BunifuiOSSwitch1.Value = True Then
            Try
                With ListView1.SelectedItems.Item(0)
                    lbl_id.Text = .Text
                    Dim dana As Integer = Val(.SubItems(2).Text)
                    Dim pengajuan As Integer = Val(TextBox1.Text)
                    If dana = 0 Then
                        MsgBox("Dana Kosong", MsgBoxStyle.Critical)
                    ElseIf dana < pengajuan Then
                        MsgBox("Dana lebih kecil dari yang diajukan", MsgBoxStyle.Critical)
                    Else
                        Dim hasilkurangpengajuan As Integer = dana - pengajuan
                        koneksi_open()
                        cmd = New MySqlCommand("update kas_pemmas set dana = '" & hasilkurangpengajuan & "' where id_kas='" & lbl_id.Text & "'", con)
                        cmd.ExecuteNonQuery()
                        con.Close()


                        Dim i As Integer = Form2.DataGridView1.CurrentRow.Index
                        koneksi_open()
                        Dim tglnow As Date = Date.Today
                        cmd = New MySqlCommand("update proposal set status_proposal= '" & "Diizinkan" & "', anggaran_diterima= '" & TextBox1.Text & "', tgl_acc ='" & tglnow.ToString("yyyy/MM/dd") & "', id_kas='" & lbl_id.Text & "' where id_proposal='" & Form2.DataGridView1.Item(0, i).Value & "'", con)
                        cmd.ExecuteNonQuery()
                        MsgBox("Dokumen terakusisi, data tersebut akan di kirim kan ke pihak instansi pengaju.", MsgBoxStyle.Information)
                        Form2.tampil_pengajuan_proposal()
                        'kelurahan
                        Form1.tampil_pengajuan_proposal()
                        kelurahan_btn_status_pengajuan_new()
                        Form2.kas()
                        Me.Hide()
                        Form2.AxAcroPDF1.Visible = False
                    End If
                End With

            Catch ex As Exception
                MsgBox("Pilih terlebih dahulu " & ex.Message)
            End Try
        Else
            Try
                With ListView1.SelectedItems.Item(0)
                    lbl_id.Text = .Text
                    Dim dana As Integer = Val(.SubItems(2).Text)
                    Dim pengajuan As Integer = Val(lbl_anggaran_diajukan.Text)
                    If dana = 0 Then
                        MsgBox("Dana Kosong", MsgBoxStyle.Critical)
                    ElseIf dana < pengajuan Then
                        MsgBox("Dana lebih kecil dari yang diajukan", MsgBoxStyle.Critical)
                    Else
                        Dim hasilkurangpengajuan As Integer = dana - pengajuan
                        koneksi_open()
                        cmd = New MySqlCommand("update kas_pemmas set dana = '" & hasilkurangpengajuan & "' where id_kas='" & lbl_id.Text & "'", con)
                        cmd.ExecuteNonQuery()
                        con.Close()


                        Dim i As Integer = Form2.DataGridView1.CurrentRow.Index
                        koneksi_open()
                        cmd = New MySqlCommand("update proposal set status_proposal= '" & "Diizinkan" & "', anggaran_diterima= '" & lbl_anggaran_diajukan.Text & "' where id_proposal='" & Form2.DataGridView1.Item(0, i).Value & "'", con)
                        cmd.ExecuteNonQuery()
                        MsgBox("Dokumen terakusisi, data tersebut akan di kirim kan ke pihak instansi pengaju.", MsgBoxStyle.Information)
                        Form2.tampil_pengajuan_proposal()
                        'kelurahan
                        Form1.tampil_pengajuan_proposal()
                        kelurahan_btn_status_pengajuan_new()
                        Form2.kas()
                        Me.Hide()
                    End If
                End With
            Catch ex As Exception
                MsgBox("Pilih terlebih dahulu " & ex.Message)
            End Try
        End If
        tampil()
        kecamatan_btn_proposal()
        Form1.AxAcroPDF1.Visible = False
    End Sub

    Private Sub ambil_anggaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
    End Sub
    Sub tampil()
        ListView1.Items.Clear()
        koneksi_open()
        cmd = New MySqlCommand("select * from kas_pemmas", con)
        ap = New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        ap.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1
            With ListView1
                .Items.Add(dt.Rows(i)("id_kas"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(dt.Rows(i)("ket"))
                    .Add(dt.Rows(i)("dana"))
                End With
            End With
        Next
        con.Close()
    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
    End Sub
End Class