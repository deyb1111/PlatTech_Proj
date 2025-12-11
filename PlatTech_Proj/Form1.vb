Imports System.Runtime.InteropServices
Imports System.IO

Public Class Form1
    Private Function RunPython(scriptName As String, Optional args As String = "") As String
        Try
            Dim scriptPath As String = Path.Combine(Application.StartupPath, scriptName)

            Dim psi As New ProcessStartInfo()
            psi.FileName = "python"
            psi.Arguments = $"""{scriptPath}"" {args}"
            psi.WorkingDirectory = Application.StartupPath
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True
            psi.EnvironmentVariables("PYTHONIOENCODING") = "utf-8"

            Dim p As Process = Process.Start(psi)
            Dim output As String = p.StandardOutput.ReadToEnd()
            Dim err As String = p.StandardError.ReadToEnd()
            p.WaitForExit()

            Dim stdoutTrim As String = output.Trim()
            Dim stderrTrim As String = err.Trim()

            If p.ExitCode <> 0 Then
                If stderrTrim <> "" Then
                    Return "ERROR: " & stderrTrim
                Else
                    Return "ERROR: Python exited with code " & p.ExitCode.ToString()
                End If
            End If

            Return stdoutTrim

        Catch ex As Exception
            Return "EXCEPTION: " & ex.Message
        End Try
    End Function
    Private Sub LoadImageNoLock(pb As PictureBox, path As String)
        If pb.Image IsNot Nothing Then
            pb.Image.Dispose()
            pb.Image = Nothing
        End If

        Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Using imgTemp As Image = Image.FromStream(fs)
                pb.Image = New Bitmap(imgTemp)
            End Using
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cream As Color = ColorTranslator.FromHtml("#EFECE3")
        Dim blue As Color = ColorTranslator.FromHtml("#4A75A9")
        Dim navy As Color = Color.Black

        Me.BackColor = cream

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim b As Button = CType(ctrl, Button)
                b.BackColor = blue
                b.FlatStyle = FlatStyle.Flat
                b.FlatAppearance.BorderSize = 0
                b.ForeColor = Color.White
                b.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            End If
        Next

        For Each grp As GroupBox In Me.Controls.OfType(Of GroupBox)()
            grp.BackColor = cream
            grp.ForeColor = navy
        Next

        txtSummary.Font = New Font("Consolas", 10)
    End Sub

    Private Sub btnLoadSummary_Click(sender As Object, e As EventArgs) Handles btnLoadSummary.Click

        RunPython("data_analytics.py")

        Dim summaryFile As String = Path.Combine(Application.StartupPath, "output\summary.txt")

        If File.Exists(summaryFile) Then
            txtSummary.Text = File.ReadAllText(summaryFile)
        Else
            txtSummary.Text = "Summary file not found."
        End If
    End Sub
    Private Sub btnShowCharts_Click(sender As Object, e As EventArgs) Handles btnShowCharts.Click

        RunPython("data_visualization.py")

        Dim outputDir As String = Path.Combine(Application.StartupPath, "output")

        Dim workloadPath As String = Path.Combine(outputDir, "workload_distribution.png")
        Dim scatterPath As String = Path.Combine(outputDir, "study_vs_sleep.png")
        Dim cmPath As String = Path.Combine(outputDir, "confusion_matrix.png")

        If File.Exists(workloadPath) Then
            LoadImageNoLock(picWorkloadDist, workloadPath)
        End If

        If File.Exists(scatterPath) Then
            LoadImageNoLock(picScatterPlot, scatterPath)
        End If

        If File.Exists(cmPath) Then
            LoadImageNoLock(picConfusionMatrix, cmPath)
        End If

    End Sub
    Private Sub btnTrainModel_Click(sender As Object, e As EventArgs) Handles btnTrainModel.Click

        Dim msg As String = RunPython("classification_project.py")

        txtAccuracy.Text = "Model Trained (Random Forest)"
        txtF1Score.Text = "See Python output"

        MsgBox(msg, MsgBoxStyle.Information, "Training Complete")
    End Sub

    Private Sub btnPredict_Click(sender As Object, e As EventArgs) Handles btnPredict.Click
        Dim sleep As String = nudSleep.Value.ToString()
        Dim study As String = nudStudy.Value.ToString()
        Dim subjects As String = nudSubjects.Value.ToString()
        Dim stress As String = nudStress.Value.ToString()

        Dim args As String = sleep & " " & study & " " & subjects & " " & stress

        Dim result As String = RunPython("predict.py", args).Trim()

        If result.StartsWith("ERROR:") OrElse result.StartsWith("EXCEPTION:") Then
            MessageBox.Show(result, "Prediction Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblPredictionResult.Text = "Prediction: (error)"
        ElseIf result = "" Then
            lblPredictionResult.Text = "Prediction: (no output)"
        Else
            lblPredictionResult.Text = "Prediction: " & result
        End If
    End Sub
End Class
