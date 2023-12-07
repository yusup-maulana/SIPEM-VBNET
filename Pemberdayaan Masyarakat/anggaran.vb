
Imports MySql.Data.MySqlClient
Public Class anggaran
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

    Private Sub anggaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kas()
        tampil()
    End Sub

    Private Sub BunifuFlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuFlatButton1.Click
        If txt_anggaran.Text = "" Then
            MsgBox("Box anggaran wajib di isi")
        Else
            koneksi_open()
            Dim tglnow As Date = Date.Today
            cmd = New MySqlCommand("insert into anggaran (id_kas, ket, anggaran, tgl) values ('" & lbl_id.Text & "','" & txt_ket.Text & "','" & txt_anggaran.Text & "','" & tglnow.ToString("yyyy/MM/dd") & "')", con)
            cmd.ExecuteNonQuery()
            tampil()
            con.Close()
            isidana()
            Form2.kas()
            Form2.tampil_anggaran()
            txt_anggaran.Text = ""
            txt_ket.Text = ""
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuFlatButton2.Click
        Try
            With ListView1.SelectedItems.Item(0)
                Dim idnya As String = .Text


                If idnya = "" Then
                    MsgBox("pilih terlebih dahulu")
                Else
                    koneksi_open()
                    Dim tglnow As Date = Now
                    cmd = New MySqlCommand("delete from anggaran where id_anggaran='" & idnya & "'", con)
                    cmd.ExecuteNonQuery()
                    tampil()
                    con.Close()
                    isidana()
                    Form2.kas()
                    Form2.tampil_anggaran()
                    txt_anggaran.Text = ""
                    txt_ket.Text = ""
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
        lbl_id.Text = ":"
    End Sub
    Sub tampil()
        ListView1.Items.Clear()
        koneksi_open()
        cmd = New MySqlCommand("select * from anggaran where id_kas='" & lbl_id.Text & "' order by id_anggaran desc", con)
        ap = New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        ap.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1
            With ListView1
                .Items.Add(dt.Rows(i)("id_anggaran"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(dt.Rows(i)("id_kas"))
                    .Add(dt.Rows(i)("ket"))
                    .Add(dt.Rows(i)("anggaran"))
                    .Add(dt.Rows(i)("tgl"))
                End With
            End With
        Next
        con.Close()
    End Sub
    Public grand As String
    Sub isidana()
        grand = 0
        Try
            koneksi_open()
            cmd = New MySqlCommand("select sum(anggaran) as totalanggaran from anggaran where id_kas ='" & lbl_id.Text & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                grand = Convert.ToString(rd("totalanggaran"))
                rd.Close()
                con.Close()
                con.Open()
                cmd = New MySqlCommand("update kas_pemmas set dana='" & grand & "' where id_kas='" & lbl_id.Text & "'", con)
                cmd.ExecuteNonQuery()
            End If
            con.Close()
            kas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub kas()
        koneksi_open()
        cmd = New MySqlCommand("select * from kas_pemmas where id_kas='" & lbl_id.Text & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            lbl_kas.Text = rd("dana")
            rd.Close()
        End If
        con.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class