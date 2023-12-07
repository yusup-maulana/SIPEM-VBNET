Imports System.IO
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient


Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_proposal.BackColor = Color.FromArgb(64, 64, 64)
        tampil_pengajuan_proposal()
        kas()
        menu_kecamatan()
    End Sub
    Sub kas()
        koneksi_open()
        cmd = New MySqlCommand("select sum(dana) as sumdana from kas_pemmas", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Label_kas.Text = Convert.ToString(rd("sumdana"))
            rd.Close()
        End If

        con.Close()
    End Sub
    Dim bit As Integer
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
        start.Show()
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

    Private Sub txtnamalogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnamalogin.Click
        txtnamalogin.BackColor = Color.WhiteSmoke
        TabControl1.SelectedTab = tab_admin
        tampil_admin()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proposal.Click
        klik_backcolor_kecamatan()
        btn_proposal.BackColor = Color.FromArgb(64, 64, 64)
        kecamatan_btn_proposal()
        tampil_pengajuan_proposal()
        TabControl1.SelectedTab = tab_proposal
    End Sub

    Private Sub Button22222_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_notulen.Click
        klik_backcolor_kecamatan()
        btn_notulen.BackColor = Color.FromArgb(64, 64, 64)
        kecamatan_btn_notulen()
        tampil_pengajuan_notulen()
        TabControl1.SelectedTab = tab_notulen
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        klik_backcolor_kecamatan()
        Button15.BackColor = Color.FromArgb(64, 64, 64)
        tampil_anggaran()
        TabControl1.SelectedTab = tab_anggaran
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        klik_backcolor_kecamatan()
        Button3.BackColor = Color.FromArgb(64, 64, 64)
        kecamatan_btn_gambar()
        tampil_pengajuan_gambar()
        TabControl1.SelectedTab = tab_gambar
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        klik_backcolor_kecamatan()
        Button9.BackColor = Color.FromArgb(64, 64, 64)
        kecamatan_btn_data_proposal()
        tampil_data_proposal()
        TabControl1.SelectedTab = tab_data_proposal
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        klik_backcolor_kecamatan()
        kecamatan_btn_agenda()
        Button6.BackColor = Color.FromArgb(64, 64, 64)
        tampil_agenda()

        TabControl1.SelectedTab = tab_agenda
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        klik_backcolor_kecamatan()
        Button14.BackColor = Color.FromArgb(64, 64, 64)
        tampil_data_agenda()
        TabControl1.SelectedTab = tab_data_agenda
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        klik_backcolor_kecamatan()
        Button5.BackColor = Color.FromArgb(64, 64, 64)
        laporan.Show()
    End Sub






    '''''''''''''''''''''''''''''''''''''''''''tab proposal
    Private Sub BunifuMaterialTextbox2_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox2.OnValueChanged
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_proposal from proposal where status_proposal='" & "Menunggu" & "' and namakegiatan like '%" & BunifuMaterialTextbox1.Text & "%' or  kelurahan like '%" & BunifuMaterialTextbox1.Text & "%' and status_proposal='" & "Menunggu" & "'", con)
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub tampil_pengajuan_proposal()
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_proposal,anggaran_diajukan from proposal where status_proposal='" & "Menunggu" & "'", con)
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
            Me.DataGridView1.Columns(7).HeaderText = "ANGGARAN DIAJUKAN"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            If DataGridView1.Item(6, i).Value = "" Then
                AxAcroPDF1.Visible = False
            Else
                AxAcroPDF1.src = Path.Combine(My.Application.Info.DirectoryPath, "proposal/" + DataGridView1.Item(6, i).Value)
                AxAcroPDF1.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            If DataGridView1.Rows.Count = 0 Then Exit Sub


            Dim i As Integer = DataGridView1.CurrentRow.Index

            form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "proposal/" + DataGridView1.Item(6, i).Value)
            form_ukuran_penuh.Show()
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memperbesar")
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim tglnow As Date = Date.Today
            Dim i As Integer = DataGridView1.CurrentRow.Index
            koneksi_open()
            cmd = New MySqlCommand("update proposal set status_proposal= '" & "Ditolak" & "', tgl_acc='" & tglnow.ToString("yyyy/MM/dd") & "' where id_proposal='" & DataGridView1.Item(0, i).Value & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Penolakan Dokumen terakusisi, data tersebut akan di kirim kan ke pihak instansi pengaju.", MsgBoxStyle.Information)
            tampil_pengajuan_proposal()
            kecamatan_btn_proposal()
            'kelurahan
            Form1.tampil_pengajuan_proposal()
            kelurahan_btn_status_pengajuan_new()
            AxAcroPDF1.Visible = False
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memvalidasi")
        End Try

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim a As String = DataGridView1.Item(0, i).Value
            If a = "" Then
                MsgBox("Pilih terlebih dahulu")
            Else
                ambil_anggaran.lbl_anggaran_diajukan.Text = DataGridView1.Item(7, i).Value
                ambil_anggaran.lbl_namakegiatan.Text = DataGridView1.Item(1, i).Value
                ambil_anggaran.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub















    '''''''''''''''''''''''''''''''''''''''''''tab notulen
    Sub tampil_pengajuan_notulen()
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_notulen from proposal where status_notulen='" & "Menunggu" & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            dgv_notulen.DataSource = table
            Me.dgv_notulen.Columns(0).Visible = False
            Me.dgv_notulen.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.dgv_notulen.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.dgv_notulen.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.dgv_notulen.Columns(4).HeaderText = "KETERANGAN"
            Me.dgv_notulen.Columns(5).HeaderText = "KELURAHAN"
            Me.dgv_notulen.Columns(6).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_notulen from proposal where status_notulen='" & "Menunggu" & "' and namakegiatan like '%" & BunifuMaterialTextbox1.Text & "%' or  kelurahan like '%" & BunifuMaterialTextbox1.Text & "%' and status_notulen='" & "Menunggu" & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            dgv_notulen.DataSource = table
            Me.dgv_notulen.Columns(0).Visible = False
            Me.dgv_notulen.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.dgv_notulen.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.dgv_notulen.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.dgv_notulen.Columns(4).HeaderText = "KETERANGAN"
            Me.dgv_notulen.Columns(5).HeaderText = "KELURAHAN"
            Me.dgv_notulen.Columns(6).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_notulen_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_notulen.CellClick
        Try
            Dim i As Integer = dgv_notulen.CurrentRow.Index
            AxAcroPDF2_notulen.src = Path.Combine(My.Application.Info.DirectoryPath, "notulen/" + dgv_notulen.Item(6, i).Value)
            AxAcroPDF2_notulen.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub dgv_notulen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_notulen.CellContentClick

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try

            Dim i As Integer = dgv_notulen.CurrentRow.Index

            form_ukuran_penuh.TextBox1.Text = Path.Combine(My.Application.Info.DirectoryPath, "notulen/" + dgv_notulen.Item(6, i).Value)
            form_ukuran_penuh.Show()
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memperbesar")
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Dim i As Integer = dgv_notulen.CurrentRow.Index
            koneksi_open()
            cmd = New MySqlCommand("update proposal set status_notulen= '" & "Diizinkan" & "' where id_proposal='" & dgv_notulen.Item(0, i).Value & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Doc. Notulen Terakusisi", MsgBoxStyle.Information)
            tampil_pengajuan_notulen()
            kecamatan_btn_notulen()
            AxAcroPDF2_notulen.Visible = False
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memvalidasi")
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Dim i As Integer = dgv_notulen.CurrentRow.Index
            koneksi_open()
            cmd = New MySqlCommand("update proposal set status_notulen= '" & "Ditolak" & "' where id_proposal='" & dgv_notulen.Item(0, i).Value & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Pembuatan ulang notulen akan dikirimkan ke pihak instansi pembuat", MsgBoxStyle.Information)
            tampil_pengajuan_notulen()
            kecamatan_btn_notulen()
            AxAcroPDF2_notulen.Visible = False
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memvalidasi")
        End Try
    End Sub









    '''''''''''''''''''''''''''''''''''''''''''tab anggaran
    Sub tampil_anggaran()
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

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            With ListView1.SelectedItems.Item(0)
                anggaran.lbl_id.Text = .Text
                anggaran.lbl_ket.Text = .SubItems(1).Text

            End With

        Catch ex As Exception

        End Try
        If anggaran.lbl_id.Text = ":" Then
            MsgBox("pilih dahulu")
        Else
            anggaran.Show()
        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            With ListView1.SelectedItems.Item(0)
                anggaran.lbl_id.Text = .Text
                anggaran.lbl_ket.Text = .SubItems(1).Text

            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BunifuMaterialTextbox3_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox3.OnValueChanged
        ListView1.Items.Clear()
        koneksi_open()
        cmd = New MySqlCommand("select * from kas_pemmas where ket like '%" & BunifuMaterialTextbox3.Text & "%'", con)
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

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        anggaran_model.Button1.Text = "Simpan"
        anggaran_model.Button1.BackColor = Color.MediumSeaGreen
        anggaran_model.Show()

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            With ListView1.SelectedItems.Item(0)
                anggaran_model.lbl_id.Text = .Text
                anggaran_model.txt_ket.Text = .SubItems(1).Text

            End With

        Catch ex As Exception

        End Try
        If anggaran_model.lbl_id.Text = ":" Then
            MsgBox("pilih dahulu")
        Else
            anggaran_model.Button1.Text = "Simpan perubahan"
            anggaran_model.Button1.BackColor = Color.Goldenrod
            anggaran_model.Show()
        End If

    End Sub







    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB GAMBAR
    Sub tampil_pengajuan_gambar()
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select id_proposal, namakegiatan, tgl_acara, tgl_kirim, ket,kelurahan, data_notulen from proposal where status_gambar='" & "Menunggu" & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt, "proposal")
            table = dt.Tables("proposal")
            dgv_gambar.DataSource = table
            Me.dgv_gambar.Columns(0).Visible = False
            Me.dgv_gambar.Columns(1).HeaderText = "NAMA KEGIATAN"
            Me.dgv_gambar.Columns(2).HeaderText = "TANGGAL ACARA"
            Me.dgv_gambar.Columns(3).HeaderText = "TANGGAL KIRIM"
            Me.dgv_gambar.Columns(4).HeaderText = "KETERANGAN"
            Me.dgv_gambar.Columns(5).HeaderText = "KELURAHAN"
            Me.dgv_gambar.Columns(6).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_gambar_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_gambar.CellClick
        Try
            dgv_gambar_list.Visible = True
            Dim i As Integer = dgv_gambar.CurrentRow.Index
            dgv_gambar_list.Columns.Clear()
            koneksi_open()
            ap = New MySqlDataAdapter("Select gambar from notulen_gambar where id_proposal='" & dgv_gambar.Item(0, i).Value & "'", con)
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
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim i As Integer = dgv_gambar.CurrentRow.Index
            koneksi_open()
            cmd = New MySqlCommand("update proposal set status_proposal= '" & "Completed" & "', status_gambar= '" & "Diizinkan" & "' where id_proposal='" & dgv_gambar.Item(0, i).Value & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("kesan (gambar) Terakusisi", MsgBoxStyle.Information)
            kecamatan_btn_gambar()
            dgv_gambar_list.Visible = False
            tampil_pengajuan_gambar()
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memvalidasi")
        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer = dgv_gambar.CurrentRow.Index
            koneksi_open()
            cmd = New MySqlCommand("update proposal set status_gambar= '" & "Ditolak" & "' where id_proposal='" & dgv_gambar.Item(0, i).Value & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Pengulangan Kesan (gambar) succes", MsgBoxStyle.Information)
            tampil_pengajuan_gambar()
            dgv_gambar_list.Visible = False
            kecamatan_btn_gambar()
            tampil_pengajuan_gambar()
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu sebelum memvalidasi")
        End Try
    End Sub





    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB DATA PROPOSAL
    Private Sub Button19_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try
            If dgv_data_proposal.Rows.Count = Nothing Then Exit Sub
            txt_id_detail_proposal.Text = ""

            Dim i As Integer = dgv_data_proposal.CurrentRow.Index
            txt_id_detail_proposal.Text = dgv_data_proposal.Item(0, i).Value

            koneksi_open()
            cmd = New MySqlCommand("select a.*, b.ket as ket_kas from proposal as a inner join kas_pemmas as b on a.id_kas= b.id_kas where a.id_proposal='" & txt_id_detail_proposal.Text & "'", con)
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
                Label14.Text = rd("ket_kas")
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

            DataGridView4.Visible = True
            Dim u As Integer = dgv_data_proposal.CurrentRow.Index
            DataGridView4.Columns.Clear()
            koneksi_open()
            ap = New MySqlDataAdapter("Select gambar from notulen_gambar where id_proposal='" & dgv_data_proposal.Item(0, u).Value & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt)
            DataGridView4.DataSource = dt.Tables(0)
            Dim Cols As New DataGridViewImageColumn()
            DataGridView4.Columns.Add(Cols)

            For baris As Integer = 0 To DataGridView4.RowCount - 2
                DataGridView4.Rows(baris).Cells(1).Value = Image.FromFile("gambar/" + DataGridView4.Rows(baris).Cells(0).Value)
                Cols.HeaderText = "foto"

                Cols.ImageLayout = DataGridViewImageCellLayout.Zoom
            Next
            Me.DataGridView4.Columns(0).Visible = False

            TabControl1.SelectedTab = tab_data_detail_proposal
        Catch ex As Exception
            MsgBox("pilih terlebih dahulu : " & ex.Message, MsgBoxStyle.Exclamation)
            form_ukuran_penuh.TextBox1.Text = ""
        End Try
        con.Close()
        Try
            DataGridView4.Visible = True
            Dim u As Integer = dgv_data_proposal.CurrentRow.Index
            DataGridView4.Columns.Clear()
            koneksi_open()
            ap = New MySqlDataAdapter("Select gambar from notulen_gambar where id_proposal='" & dgv_data_proposal.Item(0, u).Value & "'", con)
            dt = New DataSet
            dt.Clear()
            ap.Fill(dt)
            DataGridView4.DataSource = dt.Tables(0)
            Dim Cols As New DataGridViewImageColumn()
            DataGridView4.Columns.Add(Cols)

            For baris As Integer = 0 To DataGridView4.RowCount - 2
                DataGridView4.Rows(baris).Cells(1).Value = Image.FromFile("gambar/" + DataGridView4.Rows(baris).Cells(0).Value)
                Cols.HeaderText = "foto"

                Cols.ImageLayout = DataGridViewImageCellLayout.Zoom
            Next
            Me.DataGridView4.Columns(0).Visible = False

        Catch ex As Exception

        End Try
    End Sub
    Sub tampil_data_proposal()
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select a.*, b.ket from proposal as a inner join kas_pemmas as b on a.id_kas = b.id_kas where a.status_proposal ='" & "Rejected" & "' or a.status_proposal ='" & "Completed" & "'", con)
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
            Me.dgv_data_proposal.Columns(6).HeaderText = "KELURAHAN"
            Me.dgv_data_proposal.Columns(7).Visible = False
            Me.dgv_data_proposal.Columns(8).Visible = False
            Me.dgv_data_proposal.Columns(9).Visible = False
            Me.dgv_data_proposal.Columns(10).Visible = False
            Me.dgv_data_proposal.Columns(11).Visible = False
            Me.dgv_data_proposal.Columns(12).Visible = False
            Me.dgv_data_proposal.Columns(13).Visible = False
            Me.dgv_data_proposal.Columns(14).Visible = False
            Me.dgv_data_proposal.Columns(15).HeaderText = "DIANGGARKAN"
            Me.dgv_data_proposal.Columns(16).Visible = False
            Me.dgv_data_proposal.Columns(17).HeaderText = "DARI KAS"

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BunifuMaterialTextbox5_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox5.OnValueChanged
        Try
            koneksi_open()
            Dim table As DataTable
            ap = New MySqlDataAdapter("select a.*,b.ket from proposal as a inner join kas_pemmas as b on a.id_kas = b.id_kas where  a.status_proposal ='" & "Rejected" & "' and a.namakegiatan like '%" & BunifuMaterialTextbox5.Text & "%' or a.status_proposal ='" & "Completed" & "' and a.namakegiatan like '%" & BunifuMaterialTextbox5.Text & "%'", con)
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
            Me.dgv_data_proposal.Columns(6).HeaderText = "KELURAHAN"
            Me.dgv_data_proposal.Columns(7).Visible = False
            Me.dgv_data_proposal.Columns(8).Visible = False
            Me.dgv_data_proposal.Columns(9).Visible = False
            Me.dgv_data_proposal.Columns(10).Visible = False
            Me.dgv_data_proposal.Columns(11).Visible = False
            Me.dgv_data_proposal.Columns(12).Visible = False
            Me.dgv_data_proposal.Columns(13).Visible = False
            Me.dgv_data_proposal.Columns(14).Visible = False
            Me.dgv_data_proposal.Columns(15).HeaderText = "DIANGGARKAN"
            Me.dgv_data_proposal.Columns(16).Visible = False
            Me.dgv_data_proposal.Columns(17).HeaderText = "DARI KAS"
            con.Close()
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





    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB ÁGENDA
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
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim openFileDialog1 As New OpenFileDialog
            openFileDialog1.Title = "Pilih file word atau pdf saja"
            openFileDialog1.InitialDirectory = "C:\"
            openFileDialog1.Filter = "Word or Pdf|*.doc;*.docx;*.pdf"

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                AxAcroPDF2.Visible = True
                Panel8.Size = New System.Drawing.Size(1071, 569)
                Panel8.Location = New Point(14, 11)
                t_pengajuan_lbl_browse_proposal.Text = openFileDialog1.FileName
                t_pengajuan_lbl_browse_proposal_name.Text = openFileDialog1.SafeFileName
                FFOperation(t_pengajuan_lbl_browse_proposal.Text, "agenda/", ffAction.FO_COPY, ffFlags.FOF_SILENT)
                Dim hasil As String = t_pengajuan_lbl_browse_proposal_name.Text
                Dim cekstr As String = Strings.Right(t_pengajuan_lbl_browse_proposal_name.Text, 4)
                If cekstr = "docx" Then
                    tab_agenda_name.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".docx", "")
                    Dim namatopdf As String = hasil.Replace(".docx", ".pdf")
                    Word2PDF(t_pengajuan_lbl_browse_proposal.Text, "agenda/" + namatopdf)
                    AxAcroPDF2.src = Path.Combine(My.Application.Info.DirectoryPath, "agenda/" + namatopdf)
                ElseIf cekstr = ".doc" Then
                    tab_agenda_name.Text = t_pengajuan_lbl_browse_proposal_name.Text.Replace(".doc", "")
                    Dim namatopdf As String = hasil.Replace(".doc", ".pdf")
                    Word2PDF(t_pengajuan_lbl_browse_proposal.Text, "agenda/" + namatopdf)
                    AxAcroPDF2.src = Path.Combine(My.Application.Info.DirectoryPath, "agenda/" + namatopdf)
                Else
                    tab_agenda_name.Text = t_pengajuan_lbl_browse_proposal_name.Text
                    AxAcroPDF2.src = t_pengajuan_lbl_browse_proposal.Text
                End If

                Panel8.Size = New System.Drawing.Size(51, 11)
                Panel8.Location = New Point(14, 11)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        If RichTextBox1.Text = "" Or t_pengajuan_lbl_browse_proposal_name.Text = ":" Then
            MsgBox("Semua isian harus terisi", MsgBoxStyle.Exclamation)
        Else
            ambil_anggaran_kecamatan.Show()
        End If
    End Sub
    Sub tampil_agenda()
        Try
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
            Me.DataGridView2.Columns(5).HeaderText = "ANGGARAN"
            Me.DataGridView2.Columns(6).Visible = False
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Try
            Dim i As Integer = DataGridView2.CurrentRow.Index
            If Convert.ToString(DataGridView2.Item(0, i).Value) = "" Then
                MsgBox("Pilih terlebih dahulu", MsgBoxStyle.Exclamation)
            Else
                Dim openFileDialog1 As New OpenFileDialog
                openFileDialog1.Title = "Pilih file word atau pdf saja"
                openFileDialog1.InitialDirectory = "C:\"
                openFileDialog1.Filter = "Word or Pdf|*.doc;*.docx;*.pdf"

                If openFileDialog1.ShowDialog() = DialogResult.OK Then
                    AxAcroPDF2.Visible = True
                    Panel8.Size = New System.Drawing.Size(1071, 569)
                    Panel8.Location = New Point(14, 11)
                    tab_agenda_lbl_path.Text = openFileDialog1.FileName
                    tab_agenda_lbl_name.Text = openFileDialog1.SafeFileName
                    FFOperation(tab_agenda_lbl_path.Text, "absen/", ffAction.FO_COPY, ffFlags.FOF_SILENT)
                    Dim hasil As String = tab_agenda_lbl_name.Text
                    Dim cekstr As String = Strings.Right(tab_agenda_lbl_name.Text, 4)
                    If cekstr = "docx" Then
                        tab_agenda_lbl_name.Text = tab_agenda_lbl_name.Text.Replace(".docx", "")
                        tab_agenda_namatopdf.Text = hasil.Replace(".docx", ".pdf")
                        Word2PDF(tab_agenda_lbl_path.Text, "absen/" + tab_agenda_namatopdf.Text)
                        AxAcroPDF2.src = Path.Combine(My.Application.Info.DirectoryPath, "absen/" + tab_agenda_namatopdf.Text)
                    ElseIf cekstr = ".doc" Then
                        tab_agenda_lbl_name.Text = tab_agenda_lbl_name.Text.Replace(".doc", "")
                        tab_agenda_namatopdf.Text = hasil.Replace(".doc", ".pdf")
                        Word2PDF(tab_agenda_lbl_path.Text, "absen/" + tab_agenda_namatopdf.Text)
                        AxAcroPDF2.src = Path.Combine(My.Application.Info.DirectoryPath, "absen/" + tab_agenda_namatopdf.Text)
                    Else
                        tab_agenda_namatopdf.Text = tab_agenda_lbl_name.Text
                        AxAcroPDF2.src = Path.Combine(My.Application.Info.DirectoryPath, "absen/" + tab_agenda_namatopdf.Text)
                    End If



                    koneksi_open()
                    cmd = New MySqlCommand("update agenda set data_absen='" & tab_agenda_namatopdf.Text & "' where id_agenda='" & DataGridView2.Item(0, i).Value & "'", con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data absen succes di upload, data secara otomatis di arsipkan", MsgBoxStyle.Information)
                    tampil_agenda()
                    kecamatan_btn_agenda()
                End If
            End If
        Catch ex As Exception
            MsgBox("Pilih terlebih dahulu" & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        tab_agenda_namatopdf.Text = ""
        tab_agenda_lbl_name.Text = ":"
        tab_agenda_lbl_path.Text = ":"
        Panel8.Size = New System.Drawing.Size(51, 11)
        Panel8.Location = New Point(14, 11)
    End Sub












    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_DATA_AGENDA
    Sub tampil_data_agenda()
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select a.*, b.ket from agenda as a inner join kas_pemmas as b on a.id_kas = b.id_kas where a.data_absen !='" & "" & "'", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "agenda")
        table = dt.Tables("agenda")
        DataGridView3.DataSource = table
        Me.DataGridView3.Columns(0).Visible = False
        Me.DataGridView3.Columns(1).HeaderText = "TANGGAL DIBAGIKAN"
        Me.DataGridView3.Columns(2).HeaderText = "DATA AGENDA"
        Me.DataGridView3.Columns(3).HeaderText = "KET"
        Me.DataGridView3.Columns(4).HeaderText = "DATA ABSEN"
        Me.DataGridView3.Columns(5).HeaderText = "DIANGGARKAN"
        Me.DataGridView3.Columns(6).Visible = False
        Me.DataGridView3.Columns(7).HeaderText = "DARI KAS"
        con.Close()
    End Sub


    Private Sub BunifuMaterialTextbox6_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox6.OnValueChanged
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select a.*, b.ket from agenda as a INNER JOIN kas_pemmas as b on a.id_kas = b.id_kas  where a.data_absen !='" & "" & "' and a.ket like '%" & BunifuMaterialTextbox6.Text & "%' ", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "agenda")
        table = dt.Tables("agenda")
        DataGridView3.DataSource = table
        Me.DataGridView3.Columns(0).Visible = False
        Me.DataGridView3.Columns(1).HeaderText = "TANGGAL DIBAGIKAN"
        Me.DataGridView3.Columns(2).HeaderText = "DATA AGENDA"
        Me.DataGridView3.Columns(3).HeaderText = "KET"
        Me.DataGridView3.Columns(4).HeaderText = "DATA ABSEN"
        Me.DataGridView3.Columns(5).HeaderText = "DIANGGARKAN"
        Me.DataGridView3.Columns(6).Visible = False
        Me.DataGridView3.Columns(7).HeaderText = "DARI KAS"
        con.Close()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
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
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        TabControl1.SelectedTab = tab_data_proposal
        txt_id_detail_proposal.Text = ""
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
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

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
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






    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_DETAIL_DATA_PROPOSAL
    Sub bersih_admin()
        btxt_user.Text = ""
        btxt_pass.Text = ""
        btxt_namainstansi.Text = ""
        btxt_nama.Text = ""
        btxt_nik.Text = ""
    End Sub
    Sub tampil_admin()
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select * from login", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "login")
        table = dt.Tables("login")
        dgv_admin.DataSource = table
        Me.dgv_admin.Columns(0).HeaderText = "Username"
        Me.dgv_admin.Columns(1).HeaderText = "Password"
        Me.dgv_admin.Columns(2).HeaderText = "Nama Instansi"
        Me.dgv_admin.Columns(3).HeaderText = "Akses"
        Me.dgv_admin.Columns(4).HeaderText = "Nama"
        Me.dgv_admin.Columns(5).HeaderText = "NIK"
        con.Close()
    End Sub
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        If btxt_user.Text = "" Or btxt_pass.Text = "" Or btxt_namainstansi.Text = "" Or btxt_nama.Text = "" Or btxt_nik.Text = "" Or btxt_akses.Text = "" Then
            MsgBox("Semua Isian Harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi_open()
            cmd = New MySqlCommand("insert into login (user, pass, nama_instansi, akses, nama, nik) values ('" & btxt_user.Text & "','" & btxt_pass.Text & "','" & btxt_namainstansi.Text & "','" & btxt_akses.Text & "','" & btxt_nama.Text & "','" & btxt_nik.Text & "')", con)
            cmd.ExecuteNonQuery()
            MsgBox("Pengguna baru berhasil di tambahkan", MsgBoxStyle.Information)
            tampil_admin()
            bersih_admin()
            con.Close()
        End If
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        If btxt_user.Text = "" Or btxt_pass.Text = "" Or btxt_namainstansi.Text = "" Or btxt_nama.Text = "" Or btxt_nik.Text = "" Or btxt_akses.Text = "" Then
            MsgBox("Semua Isian Harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi_open()
            cmd = New MySqlCommand("update login set pass ='" & btxt_pass.Text & "', nama_instansi='" & btxt_namainstansi.Text & "', akses='" & btxt_akses.Text & "', nama='" & btxt_nama.Text & "', nik='" & btxt_nik.Text & "' where user ='" & btxt_user.Text & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Pengupdatean pengguna berhasil dilakukan", MsgBoxStyle.Information)
            tampil_admin()
            bersih_admin()
            con.Close()
        End If
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        If btxt_user.Text = "" Or btxt_pass.Text = "" Or btxt_namainstansi.Text = "" Or btxt_nama.Text = "" Or btxt_nik.Text = "" Or btxt_akses.Text = "" Then
            MsgBox("Semua Isian Harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi_open()
            cmd = New MySqlCommand("delete from login where user ='" & btxt_user.Text & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Data user tersebut berhasil dihapus", MsgBoxStyle.Information)
            tampil_admin()
            bersih_admin()
            con.Close()
        End If
    End Sub

    Private Sub dgv_admin_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_admin.CellClick
        Try
            Dim gelo As Integer = dgv_admin.CurrentRow.Index
            btxt_user.Text = dgv_admin.Item(0, gelo).Value
            btxt_pass.Text = dgv_admin.Item(1, gelo).Value
            btxt_namainstansi.Text = dgv_admin.Item(2, gelo).Value
            btxt_akses.Text = dgv_admin.Item(3, gelo).Value
            btxt_nama.Text = dgv_admin.Item(4, gelo).Value
            btxt_nik.Text = dgv_admin.Item(5, gelo).Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub BunifuMaterialTextbox7_OnValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuMaterialTextbox7.OnValueChanged
        koneksi_open()
        Dim table As DataTable
        ap = New MySqlDataAdapter("select * from login where user like '%" & BunifuMaterialTextbox7.Text & "%' and nama like '%" & BunifuMaterialTextbox7.Text & "%' and nama_instansi like '%" & BunifuMaterialTextbox7.Text & "%'", con)
        dt = New DataSet
        dt.Clear()
        ap.Fill(dt, "login")
        table = dt.Tables("login")
        dgv_admin.DataSource = table
        Me.dgv_admin.Columns(0).HeaderText = "Username"
        Me.dgv_admin.Columns(1).HeaderText = "Password"
        Me.dgv_admin.Columns(2).HeaderText = "Nama Instansi"
        Me.dgv_admin.Columns(3).HeaderText = "Akses"
        Me.dgv_admin.Columns(4).HeaderText = "Nama"
        Me.dgv_admin.Columns(5).HeaderText = "NIK"
        con.Close()
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''TAB_DETAIL_DATA_PROPOSAL
    Private Sub BunifuTileButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuTileButton1.Click
        laporan.TabControl1.SelectedTab = tab_anggaran
        laporan.Show()
    End Sub

    Private Sub BunifuTileButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuTileButton2.Click
        laporan.TabControl1.SelectedTab = tab_proposal
        laporan.Show()
    End Sub

    Private Sub BunifuTileButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuTileButton3.Click
        laporan.TabControl1.SelectedTab = tab_agenda
        laporan.Show()
    End Sub
End Class