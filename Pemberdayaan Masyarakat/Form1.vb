
Imports System.IO
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient

Public Class Form1



    Dim bit As Integer
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
        start.Show()
        start.txtuser.Text = ""
        start.txtpass.Text = ""
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuGradientPanel_topheader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BunifuGradientPanel_topheader.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub BunifuGradientPanel_topheader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BunifuGradientPanel_topheader.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub BunifuGradientPanel_topheader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BunifuGradientPanel_topheader.MouseUp
        drag = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        klik_backcolor_kelurahan()
        Button1.BackColor = Color.DodgerBlue
        TabControl1.SelectedTab = tab_status_agenda
        kelurahan_btn_agenda()
        tampil_status_agenda()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        klik_backcolor_kelurahan()
        Button3.BackColor = Color.DodgerBlue
        TabControl1.SelectedTab = tab_data_agenda
        tampil_data_agenda()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_status_pengajuan.Click
        klik_backcolor_kelurahan()
        btn_status_pengajuan.BackColor = Color.DodgerBlue
        tampil_pengajuan_proposal()
        kelurahan_btn_status_pengajuan()
        TabControl1.SelectedTab = tab_status_proposal
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        klik_backcolor_kelurahan()
        Button5.BackColor = Color.DodgerBlue
        TabControl1.SelectedTab = tab_form_pengajuan
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.ForeColor = Color.White
        klik_backcolor_kelurahan()
        tampil_data_proposal()
        Button4.BackColor = Color.DodgerBlue
        TabControl1.SelectedTab = tab_data_pengajuan
    End Sub
    Private Sub txtnamalogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnamalogin.Click
        klik_backcolor_kelurahan()
        txtnamalogin.BackColor = Color.SteelBlue
        get_data_user()
        TabControl1.SelectedTab = tab_admin
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        menu_kelurahan()
        tampil_status_agenda()
        Button1.BackColor = Color.DodgerBlue
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_ADMIN
    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        koneksi_open()
        cmd = New MySqlCommand("update login set pass='" & ta_pass.Text & "', nik='" & ta_nik.Text & "', nama='" & ta_namauser.Text & "' where  nama_instansi='" & txtinstansi.Text & "' and akses='" & txtakses.Text & "'", con)
        cmd.ExecuteNonQuery()
        MsgBox("Data user berhasil di update", MsgBoxStyle.Information)
        con.Close()
    End Sub
    Sub get_data_user()
        koneksi_open()
        cmd = New MySqlCommand("select * from login where nama_instansi='" & txtinstansi.Text & "' and akses='" & txtakses.Text & "'", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            ta_nik.Text = rd("nik")
            ta_namauser.Text = rd("nama")
            ta_pass.Text = rd("pass")
            rd.Close()
        End If
        con.Close()
    End Sub









    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_STATUS_PROPOSAL
    Private Sub BunifuMaterialTextbox1_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_proposal, status_proposal,data_notulen,status_notulen,status_gambar,anggaran_diajukan,anggaran_diterima from proposal where namakegiatan like '%" & BunifuMaterialTextbox1.Text & "%' and status_proposal !='" & "Rejected" & "' and status_proposal !='" & "Completed" & "' and kelurahan='" & txtinstansi.Text & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            DataGridView1.DataSource = table
            Me.DataGridView1.Columns(0).Visible = False
            Me.DataGridView1.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.DataGridView1.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.DataGridView1.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.DataGridView1.Columns(4).HeaderText = "KETERANGAN"
            Me.DataGridView1.Columns(5).HeaderText = "KELURAHAN"
            Me.DataGridView1.Columns(6).Visible = False
            Me.DataGridView1.Columns(7).HeaderText = "STATUS PROPOSAL"
            Me.DataGridView1.Columns(8).Visible = False
            Me.DataGridView1.Columns(9).HeaderText = "STATUS NOTULEN"
            Me.DataGridView1.Columns(10).HeaderText = "STATUS GAMBAR"
            Me.DataGridView1.Columns(11).Visible = False
            Me.DataGridView1.Columns(12).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub tampil_pengajuan_proposal()
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_proposal, status_proposal,data_notulen,status_notulen,status_gambar,anggaran_diajukan,anggaran_diterima from proposal where  status_proposal !='" & "Rejected" & "' and status_proposal !='" & "Completed" & "' and kelurahan='" & txtinstansi.Text & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            DataGridView1.DataSource = table
            Me.DataGridView1.Columns(0).Visible = False
            Me.DataGridView1.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.DataGridView1.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.DataGridView1.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.DataGridView1.Columns(4).HeaderText = "KETERANGAN"
            Me.DataGridView1.Columns(5).HeaderText = "KELURAHAN"
            Me.DataGridView1.Columns(6).Visible = False
            Me.DataGridView1.Columns(7).HeaderText = "STATUS PROPOSAL"
            Me.DataGridView1.Columns(8).Visible = False
            Me.DataGridView1.Columns(9).HeaderText = "STATUS NOTULEN"
            Me.DataGridView1.Columns(10).HeaderText = "STATUS GAMBAR"
            Me.DataGridView1.Columns(11).Visible = False
            Me.DataGridView1.Columns(12).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub status_proposal_klik_cell_dgv()
        Try
            tp_st_pb_gambar.Image = Nothing
            tp_st_pb_notulen.Image = Nothing
            tp_st_pb_approve.Image = Nothing
            Dim i As Integer = DataGridView1.CurrentRow.Index
            tp_status_pengajuan_lbl_namakegiatan.Text = DataGridView1.Item(1, i).Value
            tp_status_pengajuan_keterangan.Text = DataGridView1.Item(4, i).Value
            tsp_anggaran_diajukan.Text = DataGridView1.Item(11, i).Value
            tsp_direalisasikan.Text = DataGridView1.Item(12, i).Value

            Dim statusproposal As String = DataGridView1.Item(7, i).Value
            Dim statusnotulen As String = DataGridView1.Item(9, i).Value
            Dim statusgambar As String = DataGridView1.Item(10, i).Value
            Dim pending As String = My.Application.Info.DirectoryPath & "\icon\pending.png"
            Dim ceklis As String = My.Application.Info.DirectoryPath & "\icon\ceklis.png"
            Dim cakra As String = My.Application.Info.DirectoryPath & "\icon\cakra.png"

            If statusproposal = "Menunggu" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_approve.ImageLocation = pending
            ElseIf statusproposal = "Diizinkan" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = True
                btn_tindaklanjut.Enabled = False
                tp_st_pb_approve.ImageLocation = ceklis
            ElseIf statusproposal = "Ditolak" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = True
                tp_st_pb_approve.ImageLocation = cakra
            End If

            If statusnotulen = "Menunggu" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_notulen.ImageLocation = pending
            ElseIf statusnotulen = "Diizinkan" Then
                btn_gambar.Enabled = True
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_notulen.ImageLocation = ceklis
            ElseIf statusnotulen = "Ditolak" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = True
                btn_tindaklanjut.Enabled = False
                tp_st_pb_notulen.ImageLocation = cakra
            End If

            If statusgambar = "Menunggu" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_gambar.ImageLocation = pending
            ElseIf statusgambar = "Diizinkan" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_gambar.ImageLocation = ceklis
            ElseIf statusgambar = "Ditolak" Then
                btn_gambar.Enabled = True
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_gambar.ImageLocation = cakra
            End If

            tp_st_pb_approve.SizeMode = PictureBoxSizeMode.Zoom
            tp_st_pb_notulen.SizeMode = PictureBoxSizeMode.Zoom
            tp_st_pb_gambar.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            tp_st_pb_gambar.Image = Nothing
            tp_st_pb_notulen.Image = Nothing
            tp_st_pb_approve.Image = Nothing
            Dim i As Integer = DataGridView1.CurrentRow.Index
            tp_status_pengajuan_lbl_namakegiatan.Text = DataGridView1.Item(1, i).Value
            tp_status_pengajuan_keterangan.Text = DataGridView1.Item(4, i).Value
            tsp_anggaran_diajukan.Text = DataGridView1.Item(11, i).Value
            tsp_direalisasikan.Text = DataGridView1.Item(12, i).Value

            Dim statusproposal As String = DataGridView1.Item(7, i).Value
            Dim statusnotulen As String = DataGridView1.Item(9, i).Value
            Dim statusgambar As String = DataGridView1.Item(10, i).Value
            Dim pending As String = My.Application.Info.DirectoryPath & "\icon\pending.png"
            Dim ceklis As String = My.Application.Info.DirectoryPath & "\icon\ceklis.png"
            Dim cakra As String = My.Application.Info.DirectoryPath & "\icon\cakra.png"

            If statusproposal = "Menunggu" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_approve.ImageLocation = pending
            ElseIf statusproposal = "Diizinkan" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = True
                btn_tindaklanjut.Enabled = False
                tp_st_pb_approve.ImageLocation = ceklis
            ElseIf statusproposal = "Ditolak" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = True
                tp_st_pb_approve.ImageLocation = cakra
            End If

            If statusnotulen = "Menunggu" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_notulen.ImageLocation = pending
            ElseIf statusnotulen = "Diizinkan" Then
                btn_gambar.Enabled = True
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_notulen.ImageLocation = ceklis
            ElseIf statusnotulen = "Ditolak" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = True
                btn_tindaklanjut.Enabled = False
                tp_st_pb_notulen.ImageLocation = cakra
            End If

            If statusgambar = "Menunggu" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_gambar.ImageLocation = pending
            ElseIf statusgambar = "Diizinkan" Then
                btn_gambar.Enabled = False
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_gambar.ImageLocation = ceklis
            ElseIf statusgambar = "Ditolak" Then
                btn_gambar.Enabled = True
                btn_notulen.Enabled = False
                btn_tindaklanjut.Enabled = False
                tp_st_pb_gambar.ImageLocation = cakra
            End If

            tp_st_pb_approve.SizeMode = PictureBoxSizeMode.Zoom
            tp_st_pb_notulen.SizeMode = PictureBoxSizeMode.Zoom
            tp_st_pb_gambar.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub grdMembersInfo_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim Str As String = DataGridView1.Rows(i).Cells("status_proposal").Value
            If Str = "Menunggu" Then

            ElseIf Str = "Diizinkan" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            ElseIf Str = "Ditolak" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
            End If
        Next
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index

            form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "proposal/" + DataGridView1.Item(6, i).Value)
            form_ukuran_penuh.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_notulen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_notulen.Click
        Try

            Dim i As Integer = DataGridView1.CurrentRow.Index
            notulen.id.Text = DataGridView1.Item(0, i).Value
            notulen.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_gambar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gambar.Click
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            upload_gambar.lbl_id.Text = DataGridView1.Item(0, i).Value
            upload_gambar.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_tindaklanjut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tindaklanjut.Click
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            koneksi_open()
            cmd = New MySqlCommand("update proposal set status_proposal='" & "Rejected" & "' where id_proposal='" & DataGridView1.Item(0, i).Value & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Proposal di arsipkan", MsgBoxStyle.Information)
            con.Close()
            kelurahan_btn_status_pengajuan()
            Button4.ForeColor = Color.Gold
        Catch ex As Exception

        End Try
        tampil_pengajuan_proposal()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim Str As String = DataGridView1.Item(8, i).Value

            If Str = ":" Or Str = "" Then
                MsgBox("Notulen belum di isikan", MsgBoxStyle.Exclamation)
            Else
                form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "notulen/" + DataGridView1.Item(8, i).Value)
                form_ukuran_penuh.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_FORM_PENGAJUAN

    Private Sub Word2PDF(ByVal WordFilePath As String, ByVal PDFFilePath As String)
        Dim DestinationFile As FileInfo = New FileInfo(PDFFilePath)
        Dim DocumentO As New Word.Document
        Dim WordO As New Word.Application With {.Visible = False}

        If Not File.Exists(WordFilePath) Then Throw New Exception(WordFilePath & " doesn't exist.")

        DocumentO = WordO.Documents.Open(New FileInfo(WordFilePath).FullName)
        DocumentO.ExportAsFixedFormat(DestinationFile.FullName, Word.WdExportFormat.wdExportFormatPDF)
        DocumentO.Close(SaveChanges:=False)
        WordO.Quit()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim openFileDialog1 As New OpenFileDialog
            openFileDialog1.Title = "Pilih file word atau pdf saja"
            openFileDialog1.InitialDirectory = "C:\"
            openFileDialog1.Filter = "Word or Pdf|*.doc;*.docx;*.pdf"

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                AxAcroPDF1.Visible = True
                Panel4.Size = New System.Drawing.Size(1098, 599)
                Panel4.Location = New Point(7, 22)
                t_pengajuan_lbl_browse_proposal.Text = openFileDialog1.FileName
                t_pengajuan_lbl_browse_proposal_name.Text = openFileDialog1.SafeFileName
                FFOperation(t_pengajuan_lbl_browse_proposal.Text, "proposal/", ffAction.FO_COPY, ffFlags.FOF_SILENT)
                Dim hasil As String = t_pengajuan_lbl_browse_proposal_name.Text
                Dim cekstr As String = Strings.Right(t_pengajuan_lbl_browse_proposal_name.Text, 4)
                If cekstr = "docx" Then
                    tab_pengajuan_tb_nama.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".docx", "")
                    Dim namatopdf As String = hasil.Replace(".docx", ".pdf")
                    Word2PDF(t_pengajuan_lbl_browse_proposal.Text, "proposal/" + namatopdf)
                    AxAcroPDF1.src = Path.Combine(My.Application.Info.DirectoryPath, "proposal/" + namatopdf)
                ElseIf cekstr = ".doc" Then
                    tab_pengajuan_tb_nama.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".doc", "")
                    Dim namatopdf As String = hasil.Replace(".doc", ".pdf")
                    Word2PDF(t_pengajuan_lbl_browse_proposal.Text, "proposal/" + namatopdf)
                    AxAcroPDF1.src = Path.Combine(My.Application.Info.DirectoryPath, "proposal/" + namatopdf)
                Else
                    tab_pengajuan_tb_nama.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".pdf", "")
                    AxAcroPDF1.src = t_pengajuan_lbl_browse_proposal.Text
                End If

                Panel4.Size = New System.Drawing.Size(56, 10)
                Panel4.Location = New Point(7, 22)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Panel4.Size = New System.Drawing.Size(56, 10)
            Panel4.Location = New Point(7, 22)
        End Try

    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If tab_pengajuan_tb_nama.Text = "" Or tab_pengajuan_tb_ket.Text = "" Or t_pengajuan_lbl_browse_proposal_name.Text = ":" Or fpp_bayd.Text = "" Then
            MsgBox("Semua isian harus terisi", MsgBoxStyle.Exclamation)
        Else
            Dim hasil As String = t_pengajuan_lbl_browse_proposal_name.Text
            Dim cekstr As String = Strings.Right(t_pengajuan_lbl_browse_proposal_name.Text, 4)
            Dim namatopdf As String
            If cekstr = "docx" Then
                tab_pengajuan_tb_nama.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".docx", "")
                namatopdf = hasil.Replace(".docx", ".pdf")
            ElseIf cekstr = ".doc" Then
                tab_pengajuan_tb_nama.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".doc", "")
                namatopdf = hasil.Replace(".doc", ".pdf")
            Else
                namatopdf = t_pengajuan_lbl_browse_proposal_name.Text
            End If
            koneksi_open()
            Dim tglnow As Date = Date.Today
            cmd = New MySqlCommand("insert into proposal (namakegiatan, tgl_acara, tgl_kirim, ket, kelurahan, data_proposal, status_proposal,nama_petugas, anggaran_diajukan) values ('" & tab_pengajuan_tb_nama.Text & "','" & tab_pengajuan_dtp_tgl_acara.Text & "','" & tglnow.ToString("yyyy/MM/dd") & "','" & tab_pengajuan_tb_ket.Text & "','" & txtinstansi.Text & "','" & namatopdf & "','" & "Menunggu" & "','" & txtnamalogin.Text & "','" & fpp_bayd.Text & "')", con)
            cmd.ExecuteNonQuery()
            AxAcroPDF1.Visible = False
            tab_pengajuan_tb_ket.Text = ""
            tab_pengajuan_tb_nama.Text = ""
            fpp_bayd.Text = ""
            t_pengajuan_lbl_browse_proposal_name.Text = ":"
            t_pengajuan_lbl_browse_proposal.Text = ":"
            MsgBox("Data telah dikirimkan", MsgBoxStyle.Information)
            con.Close()
            ''''''''menu
            kelurahan_btn_status_pengajuan_new()
            kecamatan_btn_proposal_new()
        End If

    End Sub












    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_DATA_PROPOSAL
    Sub tampil_data_proposal()
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select * from proposal where  status_proposal ='" & "Rejected" & "' and kelurahan='" & txtinstansi.Text & "' or status_proposal ='" & "Completed" & "' and kelurahan='" & txtinstansi.Text & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            dgv_data_proposal.DataSource = table
            Me.dgv_data_proposal.Columns(0).Visible = False
            Me.dgv_data_proposal.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.dgv_data_proposal.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.dgv_data_proposal.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.dgv_data_proposal.Columns(4).HeaderText = "TANGGAL ACC"
            Me.dgv_data_proposal.Columns(5).HeaderText = "KETERANGAN"
            Me.dgv_data_proposal.Columns(6).Visible = False
            Me.dgv_data_proposal.Columns(7).Visible = False
            Me.dgv_data_proposal.Columns(8).HeaderText = "STATUS"
            Me.dgv_data_proposal.Columns(9).Visible = False
            Me.dgv_data_proposal.Columns(10).Visible = False
            Me.dgv_data_proposal.Columns(11).Visible = False
            Me.dgv_data_proposal.Columns(12).Visible = False
            Me.dgv_data_proposal.Columns(13).Visible = False
            Me.dgv_data_proposal.Columns(14).Visible = False
            Me.dgv_data_proposal.Columns(15).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            txt_id_detail_proposal.Text = ""
            Dim i As Integer = dgv_data_proposal.CurrentRow.Index
            txt_id_detail_proposal.text = dgv_data_proposal.Item(0, i).Value

            koneksi_open()
            cmd = New MySqlCommand("select * from proposal where id_proposal='" & txt_id_detail_proposal.Text & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                tpdp_namakegiatan.Text = rd("namakegiatan")
                Label39.Text = rd("tgl_acara")
                Label47.Text = rd("tgl_kirim")
                Label44.Text = rd("tgl_acc")
                Label32.Text = rd("ket")
                Label34.Text = rd("kelurahan")
                Label51.Text = rd("data_proposal")
                Label50.Text = rd("data_notulen")
                Label48.Text = rd("tgl_notulen")
                Label45.Text = rd("nama_petugas")
                Label30.Text = rd("anggaran_diajukan")
                Label28.Text = rd("anggaran_diterima")
                Dim kas As String = Convert.ToString(rd("id_kas"))

                pcb_gambar.Image = Nothing
                pcb_notulen.Image = Nothing
                pcb_approve.Image = Nothing
                Dim statusproposal As String = Convert.ToString(rd("status_proposal"))
                Dim statusnotulen As String = Convert.ToString(rd("status_notulen"))
                Dim statusgambar As String = Convert.ToString(rd("status_gambar"))
                Dim pending As String = My.Application.Info.DirectoryPath & "\icon\pending.png"
                Dim ceklis As String = My.Application.Info.DirectoryPath & "\icon\ceklis.png"
                Dim cakra As String = My.Application.Info.DirectoryPath & "\icon\cakra.png"
                If statusproposal = "Menunggu" Then
                    pcb_approve.ImageLocation = pending
                ElseIf statusproposal = "Completed" Then
                    pcb_approve.ImageLocation = ceklis
                ElseIf statusproposal = "Rejected" Then
                    pcb_approve.ImageLocation = cakra
                End If
                If statusnotulen = "Menunggu" Then
                    pcb_notulen.ImageLocation = pending
                ElseIf statusnotulen = "Diizinkan" Then
                    pcb_notulen.ImageLocation = ceklis
                ElseIf statusnotulen = "Ditolak" Then
                    pcb_notulen.ImageLocation = cakra
                End If
                If statusgambar = "Menunggu" Then
                    pcb_gambar.ImageLocation = pending
                ElseIf statusgambar = "Diizinkan" Then
                    pcb_gambar.ImageLocation = ceklis
                ElseIf statusgambar = "Ditolak" Then
                    pcb_gambar.ImageLocation = cakra
                End If
                pcb_approve.SizeMode = PictureBoxSizeMode.Zoom
                pcb_notulen.SizeMode = PictureBoxSizeMode.Zoom
                pcb_gambar.SizeMode = PictureBoxSizeMode.Zoom
                rd.Close()
            End If
            con.Close()

            dgv_gambar_list.Visible = True
            Dim u As Integer = dgv_data_proposal.CurrentRow.Index
            dgv_gambar_list.Columns.Clear()
            koneksi_open()
            ap = New MySqlDataAdapter("Select gambar from notulen_gambar where id_proposal='" & dgv_data_proposal.Item(0, u).Value & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt)
            dgv_gambar_list.DataSource = dt.Tables(0)
            Dim Cols As New DataGridViewImageColumn()
            dgv_gambar_list.Columns.Add(Cols)

            For baris As Integer = 0 To dgv_gambar_list.RowCount - 2
                dgv_gambar_list.Rows(baris).Cells(1).Value = Image.FromFile("gambar/" + dgv_gambar_list.Rows(baris).Cells(0).Value)
                Cols.HeaderText = "foto"

                Cols.ImageLayout = DataGridViewImageCellLayout.Zoom
            Next
            Me.dgv_gambar_list.Columns(0).Visible = False

            TabControl1.SelectedTab = tab_detail_data_proposal
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu", MsgBoxStyle.Exclamation)
            form_ukuran_penuh.TextBox1.Text = ""
        End Try
        con.Close()
        Try
            dgv_gambar_list.Visible = True
            Dim u As Integer = dgv_data_proposal.CurrentRow.Index
            dgv_gambar_list.Columns.Clear()
            koneksi_open()
            ap = New MySqlDataAdapter("Select gambar from notulen_gambar where id_proposal='" & dgv_data_proposal.Item(0, u).Value & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt)
            dgv_gambar_list.DataSource = dt.Tables(0)
            Dim Cols As New DataGridViewImageColumn()
            dgv_gambar_list.Columns.Add(Cols)

            For baris As Integer = 0 To dgv_gambar_list.RowCount - 2
                dgv_gambar_list.Rows(baris).Cells(1).Value = Image.FromFile("gambar/" + dgv_gambar_list.Rows(baris).Cells(0).Value)
                Cols.HeaderText = "foto"

                Cols.ImageLayout = DataGridViewImageCellLayout.Zoom
            Next
            Me.dgv_gambar_list.Columns(0).Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuMaterialTextbox2_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox2.OnValueChanged
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select * from proposal where  status_proposal ='" & "Rejected" & "' and namakegiatan like '%" & BunifuMaterialTextbox2.Text & "%' and kelurahan='" & txtinstansi.Text & "' or status_proposal ='" & "Completed" & "' and namakegiatan like '%" & BunifuMaterialTextbox2.Text & "%' and kelurahan='" & txtinstansi.Text & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            dgv_data_proposal.DataSource = table
            Me.dgv_data_proposal.Columns(0).Visible = False
            Me.dgv_data_proposal.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.dgv_data_proposal.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.dgv_data_proposal.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.dgv_data_proposal.Columns(4).HeaderText = "TANGGAL ACC"
            Me.dgv_data_proposal.Columns(5).HeaderText = "KETERANGAN"
            Me.dgv_data_proposal.Columns(6).Visible = False
            Me.dgv_data_proposal.Columns(7).Visible = False
            Me.dgv_data_proposal.Columns(8).HeaderText = "STATUS"
            Me.dgv_data_proposal.Columns(9).Visible = False
            Me.dgv_data_proposal.Columns(10).Visible = False
            Me.dgv_data_proposal.Columns(11).Visible = False
            Me.dgv_data_proposal.Columns(12).Visible = False
            Me.dgv_data_proposal.Columns(13).Visible = False
            Me.dgv_data_proposal.Columns(14).Visible = False
            Me.dgv_data_proposal.Columns(15).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub grdMembersInfo_DataBindingComplete2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv_data_proposal.DataBindingComplete

        For i = 0 To dgv_data_proposal.Rows.Count - 1
            Dim Str As String = dgv_data_proposal.Rows(i).Cells("status_proposal").Value
            If Str = "Rejected" Then
                dgv_data_proposal.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
            End If
        Next
    End Sub









    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_STATUS_AGENDA
    Sub tampil_status_agenda()
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select * from agenda where data_absen='" & "" & "'", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "agenda")
        table = dt.Tables("agenda")
        DataGridView2.DataSource = table
        Me.DataGridView2.Columns(0).Visible = False
        Me.DataGridView2.Columns(1).HeaderText = "TANGGAL DIBAGIKAN"
        Me.DataGridView2.Columns(2).HeaderText = "DATA AGENDA"
        Me.DataGridView2.Columns(3).HeaderText = "KETERANGAN"
        Me.DataGridView2.Columns(4).Visible = False
        Me.DataGridView2.Columns(5).Visible = False
        Me.DataGridView2.Columns(6).Visible = False
        con.Close()
    End Sub
    Private Sub BunifuMaterialTextbox3_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox3.OnValueChanged
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select * from agenda where data_absen='" & "" & "' and ket like '%" & BunifuMaterialTextbox3.Text & "%'", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "agenda")
        table = dt.Tables("agenda")
        DataGridView2.DataSource = table
        Me.DataGridView2.Columns(0).Visible = False
        Me.DataGridView2.Columns(1).HeaderText = "TANGGAL DIBAGIKAN"
        Me.DataGridView2.Columns(2).HeaderText = "DATA AGENDA"
        Me.DataGridView2.Columns(3).HeaderText = "KETERANGAN"
        Me.DataGridView2.Columns(4).Visible = False
        Me.DataGridView2.Columns(5).Visible = False
        Me.DataGridView2.Columns(6).Visible = False
        con.Close()
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            form_ukuran_penuh.TextBox1.Text = ""
            Dim i As Integer = DataGridView2.CurrentRow.Index
            form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "agenda/" + DataGridView2.Item(2, i).Value)
            form_ukuran_penuh.Show()
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memperbesar")
            form_ukuran_penuh.TextBox1.Text = ""
        End Try
    End Sub



    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_STATUS_AGENDA
    Sub tampil_data_agenda()
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select * from agenda where data_absen !='" & "" & "'", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "agenda")
        table = dt.Tables("agenda")
        DataGridView3.DataSource = table
        Me.DataGridView3.Columns(0).Visible = False
        Me.DataGridView3.Columns(1).HeaderText = "TANGGAL DIBAGIKAN"
        Me.DataGridView3.Columns(2).HeaderText = "DATA AGENDA"
        Me.DataGridView3.Columns(3).HeaderText = "KETERANGAN"
        Me.DataGridView3.Columns(4).Visible = False
        Me.DataGridView3.Columns(5).Visible = False
        Me.DataGridView3.Columns(6).Visible = False
        con.Close()
    End Sub

    Private Sub BunifuMaterialTextbox4_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox4.OnValueChanged
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select * from agenda where data_absen !='" & "" & "' and ket like '%" & BunifuMaterialTextbox4.Text & "%' ", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "agenda")
        table = dt.Tables("agenda")
        DataGridView3.DataSource = table
        Me.DataGridView3.Columns(0).Visible = False
        Me.DataGridView3.Columns(1).HeaderText = "TANGGAL DIBAGIKAN"
        Me.DataGridView3.Columns(2).HeaderText = "DATA AGENDA"
        Me.DataGridView3.Columns(3).HeaderText = "KETERANGAN"
        Me.DataGridView3.Columns(4).Visible = False
        Me.DataGridView3.Columns(5).Visible = False
        Me.DataGridView3.Columns(6).Visible = False
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            form_ukuran_penuh.TextBox1.Text = ""
            Dim i As Integer = DataGridView3.CurrentRow.Index
            form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "agenda/" + DataGridView3.Item(2, i).Value)
            form_ukuran_penuh.Show()
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memperbesar")
            form_ukuran_penuh.TextBox1.Text = ""
        End Try
    End Sub










    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_DETAIL_DATA_PROPOSAL
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TabControl1.SelectedTab = tab_data_pengajuan
        txt_id_detail_proposal.Text = ""
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            form_ukuran_penuh.TextBox1.Text = ""
            Dim i As Integer = dgv_data_proposal.CurrentRow.Index
            If Convert.ToString(dgv_data_proposal.Item(7, i).Value) = "" Then
                MsgBox("pilih terlebih dahulu sebelum memperbesar")
            Else
                form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "proposal/" + dgv_data_proposal.Item(7, i).Value)
                form_ukuran_penuh.Show()
            End If
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memperbesar")
            form_ukuran_penuh.TextBox1.Text = ""
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            form_ukuran_penuh.TextBox1.Text = ""
            Dim i As Integer = dgv_data_proposal.CurrentRow.Index
            If Convert.ToString(dgv_data_proposal.Item(9, i).Value) = "" Then
                MsgBox("pilih terlebih dahulu sebelum memperbesar")
            Else
                form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "notulen/" + dgv_data_proposal.Item(9, i).Value)
                form_ukuran_penuh.Show()
            End If
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memperbesar")
            form_ukuran_penuh.TextBox1.Text = ""
        End Try
    End Sub



End Class
