

Public Class testing

    Private Sub DoHeavyWork()
        System.Threading.Thread.Sleep(100)
    End Sub

    Private Sub cancelAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelAsyncButton.Click
        If BackgroundWorker1.WorkerSupportsCancellation = True Then
            BackgroundWorker1.CancelAsync()
        End If
    End Sub

    Private Sub startAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startAsyncButton.Click
        If Not BackgroundWorker1.IsBusy = True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For i = 0 To 100
            If BackgroundWorker1.CancellationPending = True Then
                e.Cancel = True
                Exit For
            Else
                'DO HEAVY WORK
                DoHeavyWork()
                BackgroundWorker1.ReportProgress(i)

            End If
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged1(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label1.Text = e.ProgressPercentage.ToString() + " %"
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted1(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'CHECKED IF CANCELLED,ERROR OR FINISHED
        If e.Cancelled = True Then
            MessageBox.Show("cancelled")
            ProgressBar1.Value = 0
            Label1.Text = ""
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show(e.Error.Message)
        Else
            MessageBox.Show("finished")
        End If
    End Sub
End Class 'FibonacciForm