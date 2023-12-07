Public Class loading
    Private mParentForm As Form
    Private mBaseHeight As Integer

    Private Shared mCurrentProgressForm As loading

    ''' <summary>
    ''' Creates a new loading and displays it to the user
    ''' </summary>
    ''' <param name="parentForm">The form from which this method is being called</param>
    ''' <returns>A loading object whose UpdateProgress method can be used to display progress to the user</returns>
    ''' <remarks></remarks>
    Public Shared Function ShowProgress(ByVal parentForm As Form) As loading
        If Not mCurrentProgressForm Is Nothing Then
            Throw New InvalidOperationException("A loading is already displayed")
        End If
        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf DoLoadProgress, parentForm)
        While mCurrentProgressForm Is Nothing OrElse mCurrentProgressForm.Visible = False
            System.Threading.Thread.Sleep(1)
        End While
        Return mCurrentProgressForm
    End Function

    Private Shared Sub DoLoadProgress(ByVal parentForm As Form)
        Dim f As New loading(parentForm)
        mCurrentProgressForm = f
        f.ShowDialog()
    End Sub

    Private Sub New(ByVal parentForm As Form)
        InitializeComponent()
        mParentForm = parentForm
        Left = mParentForm.Left + (mParentForm.Width / 2) - (Width / 2)
        Top = mParentForm.Top + (mParentForm.Height / 2) - (Height / 2)
        TopMost = True
        mBaseHeight = Height
    End Sub

    Public Shadows Sub Close()
        CloseProgress()
    End Sub

    Private Sub StatusLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StatusLabel.TextChanged

    End Sub

    Private Delegate Sub UpdateProgressDelegate(ByVal progressPercent As Integer, ByVal statusText As String)
    Private Delegate Sub CloseProgressDelegate()

    Private Sub DoCloseProgress()
        mCurrentProgressForm = Nothing
        MyBase.Close()
    End Sub

    Private Sub DoUpdateProgress(ByVal progressPercent As Integer, ByVal statusText As String)
        ProgressBar.Value = progressPercent
        StatusLabel.Text = statusText
    End Sub

    ''' <summary>
    ''' Closes the loading - Be sure to call CloseProgress() when finished with this loading instance
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseProgress()
        If InvokeRequired Then
            Invoke(New CloseProgressDelegate(AddressOf DoCloseProgress))
        Else
            DoCloseProgress()
        End If
    End Sub

    ''' <summary>
    ''' Updates the progress bar value and/or status text
    ''' </summary>
    ''' <param name="progressPercent">A value from 0 to 100 representing the precentage complete</param>
    ''' <param name="statusText">Any status text to accompany the progressbar</param>
    ''' <remarks></remarks>
    Public Sub UpdateProgress(ByVal progressPercent As Integer, ByVal statusText As String)
        If InvokeRequired Then
            Invoke(New UpdateProgressDelegate(AddressOf DoUpdateProgress), New Object() {progressPercent, statusText})
        Else
            DoUpdateProgress(progressPercent, statusText)
        End If
    End Sub



    Private Sub loading_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub
End Class