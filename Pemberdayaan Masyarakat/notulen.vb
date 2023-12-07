
Imports System.IO
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient
Public Class notulen
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
    Private Sub notulen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
    End Sub
    Private Sub Word2PDF(ByVal WordFilePath As String, ByVal PDFFilePath As String)
        Dim DestinationFile As FileInfo = New FileInfo(PDFFilePath)
        Dim DocumentO As New Word.Document
        Dim WordO As New Word.Application With {.Visible = False}

        If Not File.Exists(wordFilePath) Then Throw New Exception(wordFilePath & " doesn't exist.")

        DocumentO = WordO.Documents.Open(New FileInfo(wordFilePath).FullName)
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
                Panel1.Size = New System.Drawing.Size(639, 652)
                Panel1.Location = New Point(2, 1)
                t_pengajuan_lbl_browse_proposal.Text = openFileDialog1.FileName
                t_pengajuan_lbl_browse_proposal_name.Text = openFileDialog1.SafeFileName
                FFOperation(t_pengajuan_lbl_browse_proposal.Text, "notulen/", ffAction.FO_COPY, ffFlags.FOF_SILENT)
                Dim hasil As String = t_pengajuan_lbl_browse_proposal_name.Text
                Dim cekstr As String = Strings.Right(t_pengajuan_lbl_browse_proposal_name.Text, 4)
                If cekstr = "docx" Then

                    Dim namatopdf As String = hasil.Replace(".docx", ".pdf")
                    Word2PDF(t_pengajuan_lbl_browse_proposal.Text, "notulen/" + namatopdf)
                    AxAcroPDF1.src = Path.Combine(My.Application.Info.DirectoryPath, "notulen/" + namatopdf)
                ElseIf cekstr = ".doc" Then

                    Dim namatopdf As String = hasil.Replace(".doc", ".pdf")
                    Word2PDF(t_pengajuan_lbl_browse_proposal.Text, "notulen/" + namatopdf)
                    AxAcroPDF1.src = Path.Combine(My.Application.Info.DirectoryPath, "notulen/" + namatopdf)
                Else

                    AxAcroPDF1.src = t_pengajuan_lbl_browse_proposal.Text
                End If

                Panel1.Size = New System.Drawing.Size(87, 10)
                Panel1.Location = New Point(2, 1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If t_pengajuan_lbl_browse_proposal.Text = ":" Then
            MsgBox("Document Notulen masih belum di tentukan")
        Else
            koneksi_open()
            Try
                Dim namatopdf As String
                Dim hasil As String = t_pengajuan_lbl_browse_proposal_name.Text
                Dim cekstr As String = Strings.Right(t_pengajuan_lbl_browse_proposal_name.Text, 4)
                If cekstr = "docx" Then
                    namatopdf = hasil.Replace(".docx", ".pdf")
                ElseIf cekstr = ".doc" Then
                    namatopdf = hasil.Replace(".doc", ".pdf")
                Else
                    namatopdf = hasil
                End If
                Dim tglnow As Date = Date.Today
                cmd = New MySqlCommand("update proposal set data_notulen='" & namatopdf & "', status_notulen='" & "Menunggu" & "', tgl_notulen='" & tglnow.ToString("yyyy/MM/dd") & "' where id_proposal='" & id.Text & "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Notulen succes di upload, pihak instansi harus menunggu untuk keabsahan notulen tsb. oleh pihak instansi kecamatan", MsgBoxStyle.Information)
                t_pengajuan_lbl_browse_proposal.Text = ":"
                Form1.tampil_pengajuan_proposal()
                kecamatan_btn_notulen_new()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
            Me.Close()
        End If


    End Sub
End Class