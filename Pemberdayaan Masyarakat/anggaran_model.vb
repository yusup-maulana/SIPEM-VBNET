Imports MySql.Data.MySqlClient
Public Class anggaran_model
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

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt_ket.Text = "" Then
            MsgBox("Box isian tidak boleh kosong")
        Else
            If Button1.Text = "Simpan" Then
                koneksi_open()
                cmd = New MySqlCommand("insert into kas_pemmas (ket) values ('" & txt_ket.Text & "')", con)
                cmd.ExecuteNonQuery()
                MsgBox("Nama alokasi anggaran baru berhasil di tambahkan", MsgBoxStyle.Information)
                Form2.tampil_anggaran()
                con.Close()
            Else
                koneksi_open()
                cmd = New MySqlCommand("update kas_pemmas set ket = '" & txt_ket.Text & "' where id_kas='" & lbl_id.Text & "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Nama alokasi anggaran baru berhasil di ubah", MsgBoxStyle.Information)
                Form2.tampil_anggaran()
                con.Close()
            End If
        End If
    End Sub


End Class