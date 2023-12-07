Imports MySql.Data.MySqlClient
Public Class upload_gambar
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            Dim strlist, strlist2 As New List(Of String)
            Dim file, file2 As String
            Dim openFiles As New OpenFileDialog
            openFiles.Multiselect = True
            openFiles.Filter = ("Jpg files (*.jpg)|*.jpg|png files (*.png)|*.png")

            If openFiles.ShowDialog = DialogResult.OK Then
                For Each file In openFiles.FileNames
                    strlist.Add(file)
                    ListBox1.Items.Add(file)
                Next
                For Each file2 In openFiles.SafeFileNames
                    strlist2.Add(file2)
                    ListBox2.Items.Add(file2)
                Next
                lbl_count.Text = ListBox2.Items.Count & " Gambar siap di upload"
                Button2.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub





    Public persentase As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If lbl_count.Text = ":" Then
            MsgBox("Anda belum memasukan gambar")
        Else
            ''run
            Label2.Text = 0 & " %"
            Button1.Enabled = False
            Button2.Enabled = False
            Dim tglnow As Date = Date.Today
            koneksi_open()
            Dim hasilbagi As Double = Val(100) / Val(ListBox2.Items.Count)
            persentase = hasilbagi
            Try
                For x = 0 To ListBox2.Items.Count - 1
                    ListBox2.SelectedIndex = x
                    ListBox1.SelectedIndex = x
                    cmd = New MySqlCommand("INSERT INTO notulen_gambar (id_proposal, gambar, tgl) VALUES ('" & lbl_id.Text & "','" & ListBox2.SelectedItem.ToString & "','" & tglnow.ToString("yyyy/MM/dd") & "')", con)
                    cmd.ExecuteNonQuery()
                    FFOperation(ListBox1.SelectedItem.ToString, "gambar/", ffAction.FO_COPY, ffFlags.FOF_SILENT)

                    Label2.Text = persentase & " %"
                    BunifuProgressBar1.Value = persentase
                    persentase = persentase + hasilbagi

                Next
                cmd = New MySqlCommand("update proposal set status_gambar='" & "Menunggu" & "' where id_proposal='" & lbl_id.Text & "'", con)
                cmd.ExecuteNonQuery()
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                Button1.Enabled = True
                Button2.Enabled = False
                lbl_count.Text = ":"
                con.Close()
                Form1.tampil_pengajuan_proposal()
                Form1.status_proposal_klik_cell_dgv()
            Catch ex As Exception

            End Try
            ''endrun
            MsgBox("uploading berhasil")
            Me.Close()
        End If

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.Close()
    End Sub
End Class