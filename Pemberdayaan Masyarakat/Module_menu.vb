Imports MySql.Data.MySqlClient
Module Module_menu
    Sub menu_kelurahan()
        kelurahan_btn_status_pengajuan()
        kelurahan_btn_agenda()
    End Sub
    Sub menu_kecamatan()
        kecamatan_btn_proposal()
        kecamatan_btn_notulen()
        kecamatan_btn_gambar()
        kecamatan_btn_data_proposal()
        kecamatan_btn_agenda()
    End Sub
    Sub klik_backcolor_kelurahan()
        Form1.btn_status_pengajuan.BackColor = Color.Transparent
        Form1.Button5.BackColor = Color.Transparent
        Form1.Button4.BackColor = Color.Transparent
        Form1.Button1.BackColor = Color.Transparent
        Form1.Button3.BackColor = Color.Transparent
        Form1.txtnamalogin.BackColor = Color.Transparent
        Form1.Button5.BackColor = Color.Transparent
    End Sub

    Sub klik_backcolor_kecamatan()
        Form2.btn_proposal.BackColor = Color.Transparent
        Form2.Button15.BackColor = Color.Transparent
        Form2.btn_notulen.BackColor = Color.Transparent
        Form2.Button3.BackColor = Color.Transparent
        Form2.Button9.BackColor = Color.Transparent
        Form2.Button6.BackColor = Color.Transparent
        Form2.Button14.BackColor = Color.Transparent
        Form2.txtnamalogin.BackColor = Color.Transparent
        Form2.Button5.BackColor = Color.Transparent
    End Sub






    ''' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''KELURAHAN
    Sub kelurahan_btn_status_pengajuan_new()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where  status_proposal !='" & "Rejected" & "' and status_proposal !='" & "Completed" & "' and kelurahan='" & Form1.txtinstansi.Text & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form1.btn_status_pengajuan.Text = "Status Pengajuan (" + jum + ")"
            Form1.btn_status_pengajuan.ForeColor = Color.Gold
            Form1.btn_status_pengajuan.Font = New Font(Form1.btn_status_pengajuan.Font, FontStyle.Bold)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kelurahan_btn_status_pengajuan()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where  status_proposal !='" & "Rejected" & "' and status_proposal !='" & "Completed" & "' and kelurahan='" & Form1.txtinstansi.Text & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form1.btn_status_pengajuan.Text = "Status Pengajuan (" + jum + ")"
            Form1.btn_status_pengajuan.ForeColor = Color.White
            Form1.btn_status_pengajuan.Font = New Font(Form1.btn_status_pengajuan.Font, FontStyle.Regular)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kelurahan_btn_agenda_new()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from agenda where data_absen='" & "" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form1.Button1.Text = "Status Agenda (" + jum + ")"
            Form1.Button1.ForeColor = Color.Gold
            Form1.Button1.Font = New Font(Form1.Button1.Font, FontStyle.Bold)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kelurahan_btn_agenda()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from agenda where data_absen='" & "" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form1.Button1.Text = "Status Agenda (" + jum + ")"
            Form1.Button1.ForeColor = Color.Transparent
            Form1.Button1.Font = New Font(Form1.Button1.Font, FontStyle.Regular)
            rd.Close()
        End If
        con.Close()
    End Sub









    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''KECAMATAN
    Sub kecamatan_btn_proposal_new()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where status_proposal='" & "Menunggu" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.btn_proposal.Text = "PROPOSAL (" + jum + ")"
            Form2.btn_proposal.ForeColor = Color.Gold
            Form2.btn_proposal.Font = New Font(Form2.btn_proposal.Font, FontStyle.Bold)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kecamatan_btn_proposal()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where status_proposal='" & "Menunggu" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.btn_proposal.Text = "PROPOSAL (" + jum + ")"
            Form2.btn_proposal.ForeColor = Color.Transparent
            Form2.btn_proposal.Font = New Font(Form2.btn_proposal.Font, FontStyle.Regular)
            rd.Close()
        End If
        con.Close()
    End Sub

    Sub kecamatan_btn_notulen_new()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where status_notulen='" & "Menunggu" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.btn_notulen.Text = "NOTULEN (" + jum + ")"
            Form2.btn_notulen.ForeColor = Color.Gold
            Form2.btn_notulen.Font = New Font(Form2.btn_notulen.Font, FontStyle.Bold)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kecamatan_btn_notulen()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where status_notulen='" & "Menunggu" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.btn_notulen.Text = "NOTULEN (" + jum + ")"
            Form2.btn_notulen.ForeColor = Color.Transparent
            Form2.btn_notulen.Font = New Font(Form2.btn_notulen.Font, FontStyle.Regular)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kecamatan_btn_gambar()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where status_gambar='" & "Menunggu" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.Button3.Text = "TEKKEN / KESAN (" + jum + ")"
            Form2.Button3.ForeColor = Color.Transparent
            Form2.Button3.Font = New Font(Form2.Button3.Font, FontStyle.Regular)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kecamatan_btn_gambar_new()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from proposal where status_gambar='" & "Menunggu" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.Button3.Text = "TEKKEN / KESAN (" + jum + ")"
            Form2.Button3.ForeColor = Color.Gold
            Form2.Button3.Font = New Font(Form2.Button3.Font, FontStyle.Bold)
            rd.Close()
        End If
        con.Close()
    End Sub
    Sub kecamatan_btn_data_proposal()
        Form2.Button9.ForeColor = Color.Transparent
        Form2.Button9.Font = New Font(Form2.Button9.Font, FontStyle.Bold)
    End Sub


    Sub kecamatan_btn_agenda()
        koneksi_open()
        cmd = New MySqlCommand("select COUNT(*) as jum from agenda where data_absen='" & "" & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Dim jum As String = Convert.ToString(rd("jum"))
            Form2.Button6.Text = "AGENDA (" + jum + ")"
            Form2.Button6.ForeColor = Color.Transparent
            Form2.Button6.Font = New Font(Form2.Button6.Font, FontStyle.Bold)
            rd.Close()
        End If
        con.Close()
    End Sub
End Module
