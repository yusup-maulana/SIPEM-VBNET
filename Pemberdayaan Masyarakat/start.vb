Imports MySql.Data.MySqlClient
Public Class start
    Dim bit As Integer
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p As loading = loading.ShowProgress(Me)
        koneksi_open()
        For i As Integer = 1 To 100
            p.UpdateProgress(i, "Mohon menunggu....")
            If i = 5 Then
                If con.State = ConnectionState.Closed Then
                    TextBox2.Text = My.Settings.konek
                    TextBox1.Text = My.Settings.konek
                    koneksi_open()

                End If
            ElseIf i = 20 Then
                If con.State = ConnectionState.Open Then
                    TextBox2.Text = My.Settings.konek
                    TextBox1.Text = My.Settings.konek
                    lbl_koneksi.ForeColor = Color.Green
                    lbl_koneksi.Text = "Connected"
                ElseIf con.State = ConnectionState.Closed Then
                    TextBox2.Text = My.Settings.konek
                    TextBox1.Text = My.Settings.konek
                    lbl_koneksi.ForeColor = Color.Red
                    lbl_koneksi.Text = "Connectio Failed"
                End If

            ElseIf i = 50 Then
                p.UpdateProgress(50, "Process is 50% complete...")
                'lakukan tugas apa aja disini

            End If
            If i = 100 Then
                p.UpdateProgress(100, "Process is complete.")
                p.CloseProgress()
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Visible = True
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then

            Dim p As loading = loading.ShowProgress(Me)
            For i As Integer = 1 To 100
                p.UpdateProgress(i, "Mohon menunggu....")

                If i = 1 Then
                    koneksi_open()
                    TextBox1.Text = TextBox2.Text
                    My.Settings.konek = TextBox1.Text
                    My.Settings.Save()

                ElseIf i = 100 Then
                    If con.State = ConnectionState.Open Then
                        TextBox2.Visible = False
                        lbl_koneksi.ForeColor = Color.Green
                        lbl_koneksi.Text = "Connected"
                    ElseIf con.State = ConnectionState.Closed Then
                        lbl_koneksi.ForeColor = Color.Red
                        lbl_koneksi.Text = "Connectio Closed"
                    ElseIf con.State = ConnectionState.Broken Then
                        lbl_koneksi.ForeColor = Color.Red
                        lbl_koneksi.Text = "Connectio Broken"
                    End If
                    p.UpdateProgress(i, "Process is complete.")
                    p.CloseProgress()
                End If
            Next



        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        End
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub BunifuFlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuFlatButton1.Click
        If txtpass.Text = "" Or txtuser.Text = "" Then
            MsgBox("Tidak boleh kosong", MsgBoxStyle.Exclamation)
        Else
            koneksi_open()
            cmd = New MySqlCommand("select * from login where user ='" & txtuser.Text & "' and pass='" & txtpass.Text & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                Dim namainstansi As String = Convert.ToString(rd("nama_instansi"))
                Dim akses As String = Convert.ToString(rd("akses"))
                Dim namalogin As String = Convert.ToString(rd("nama"))

                If akses = "Kecamatan" Then
                    Form2.txtakses.Text = akses.ToUpper
                    Form2.txtinstansi.Text = namainstansi.ToUpper
                    Form2.txtnamalogin.Text = namalogin.ToUpper
                    Me.Hide()
                    Form2.Show()
                Else
                    Form1.txtakses.Text = akses.ToUpper
                    Form1.txtinstansi.Text = namainstansi.ToUpper
                    Form1.txtnamalogin.Text = namalogin.ToUpper
                    Me.Hide()
                    Form1.Show()
                End If

                rd.Close()
            Else
                MsgBox("Periksa kembali user dan password anda", MsgBoxStyle.Exclamation)
            End If
            con.Close()
        End If
    End Sub

    Private Sub start_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub start_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub start_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
End Class