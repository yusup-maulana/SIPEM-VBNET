Imports MySql.Data.MySqlClient
Module koneksi
    Public con As MySqlConnection
    Public cmd As MySqlCommand
    Public ap As MySqlDataAdapter
    Public rd As MySqlDataReader
    Public dt As DataSet
    Sub koneksi_open()
        Try
            start.TextBox1.Text = start.TextBox2.Text
            Dim server As String = start.TextBox1.Text
            Dim userid As String = "root"
            Dim password As String = ""
            Dim database As String = "pemmas_dekstop"
            con = New MySqlConnection("server=" & server & ";" & "user id=" & userid & ";" & "password=" & password & ";" & "database=" & database & "; Convert Zero Datetime=True;")
            con.Open()
            If con.State = ConnectionState.Open Then

            Else
                MsgBox("Ip boss")
                Stop
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Declare Function SHFileOperation Lib "shell32.dll" Alias "SHFileOperationA" (ByRef lpFileOp As SHFILEOPSTRUCT) As Integer



    Structure SHFILEOPSTRUCT

        Dim hWnd As Integer

        Dim wFunc As Integer

        Dim pFrom As String

        Dim pTo As String

        Dim fFlags As Integer

        Dim fAborted As Boolean

        Dim hNameMaps As Integer

        Dim sProgress As String

    End Structure
    Enum ffAction

        FO_MOVE = &H1

        FO_COPY = &H2

        FO_DELETE = &H3

        FO_RENAME = &H4

    End Enum



    Enum ffFlags

        FOF_ALLOWUNDO = &H40 'menghapus ke recycle bin

        FOF_NOCONFIRMATION = &H10 'menghilangkan pesan konfirmasi

        FOF_NOCONFIRMMKDIR = &H200 'menghilangkan pesan pembuatan folder jika folder tidak ada

        FOF_NOERRORUI = &H400 'menghilangkan pesan kesalahan

        FOF_RENAMEONCOLLISION = &H8 'otomatis rename file jika ganda

        FOF_SILENT = &H4 'menghilangkan dialog proses

    End Enum



    Public Sub FFOperation(ByVal Source As String, ByVal Destination As String, ByVal Action As ffAction, ByVal Flags As ffFlags)

        Dim SO As SHFILEOPSTRUCT

        With SO

            .wFunc = Action

            .pFrom = Source & Chr(0) & Chr(0)

            .pTo = Destination

            .fFlags = Flags

        End With

#Disable Warning BC42108 ' Variable 'SO' is passed by reference before it has been assigned a value. A null reference exception could result at runtime. Make sure the structure or all the reference members are initialized before use
        SHFileOperation(SO)
#Enable Warning BC42108 ' Variable 'SO' is passed by reference before it has been assigned a value. A null reference exception could result at runtime. Make sure the structure or all the reference members are initialized before use

    End Sub

End Module
