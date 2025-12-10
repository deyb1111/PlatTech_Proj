<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()

        ' ===========================
        ' DEFINE CONTROLS
        ' ===========================

        Me.pnlHeader = New Panel()
        Me.lblTitle = New Label()

        Me.btnLoadSummary = New Button()
        Me.btnShowCharts = New Button()

        Me.grpSummary = New GroupBox()
        Me.txtSummary = New TextBox()

        Me.grpModel = New GroupBox()
        Me.numTestSize = New NumericUpDown()
        Me.Label3 = New Label()
        Me.btnTrainModel = New Button()
        Me.txtAccuracy = New TextBox()
        Me.Label4 = New Label()
        Me.txtF1Score = New TextBox()
        Me.Label5 = New Label()

        Me.grpPredict = New GroupBox()
        Me.Label6 = New Label()
        Me.nudSleep = New NumericUpDown()
        Me.Label7 = New Label()
        Me.nudStudy = New NumericUpDown()
        Me.Label8 = New Label()
        Me.nudSubjects = New NumericUpDown()
        Me.Label9 = New Label()
        Me.nudStress = New NumericUpDown()
        Me.btnPredict = New Button()
        Me.lblPredictionResult = New Label()

        Me.tabVisuals = New TabControl()
        Me.tabWorkload = New TabPage()
        Me.picWorkloadDist = New PictureBox()

        Me.tabScatter = New TabPage()
        Me.picScatterPlot = New PictureBox()

        Me.tabConfusion = New TabPage()
        Me.picConfusionMatrix = New PictureBox()

        CType(Me.numTestSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSleep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStudy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSubjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStress, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()

        ' ===========================
        ' HEADER PANEL
        ' ===========================
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Height = 60
        Me.pnlHeader.BackColor = ColorTranslator.FromHtml("#8FABD4")

        Me.lblTitle.Text = "Machine Learning Analytics Dashboard"
        Me.lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(20, 15)

        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlHeader)

        ' ===========================
        ' BUTTONS (TOP AREA)
        ' ===========================
        Me.btnLoadSummary.Text = "Load Summary"
        Me.btnLoadSummary.Location = New Point(20, 80)
        Me.btnLoadSummary.Size = New Size(160, 40)

        Me.btnShowCharts.Text = "Show Charts"
        Me.btnShowCharts.Location = New Point(200, 80)
        Me.btnShowCharts.Size = New Size(160, 40)

        ' ===========================
        ' SUMMARY GROUP
        ' ===========================
        Me.grpSummary.Text = "Summary"
        Me.grpSummary.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Me.grpSummary.Location = New Point(20, 130)
        Me.grpSummary.Size = New Size(460, 220)

        Me.txtSummary.Multiline = True
        Me.txtSummary.ReadOnly = True
        Me.txtSummary.ScrollBars = ScrollBars.Vertical
        Me.txtSummary.Font = New Font("Consolas", 10)
        Me.txtSummary.Location = New Point(10, 25)
        Me.txtSummary.Size = New Size(440, 180)

        Me.grpSummary.Controls.Add(Me.txtSummary)

        ' ===========================
        ' MODEL GROUP (Random Forest only)
        ' ===========================
        Me.grpModel.Text = "Model Training"
        Me.grpModel.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Me.grpModel.Location = New Point(20, 360)
        Me.grpModel.Size = New Size(460, 200)

        ' Test size
        Me.Label3.Text = "Test Size (%):"
        Me.Label3.Location = New Point(10, 40)

        Me.numTestSize.Location = New Point(120, 38)
        Me.numTestSize.Minimum = 10
        Me.numTestSize.Maximum = 50
        Me.numTestSize.Value = 20

        ' Train button
        Me.btnTrainModel.Text = "Train Model"
        Me.btnTrainModel.Location = New Point(300, 30)
        Me.btnTrainModel.Size = New Size(130, 35)

        ' Accuracy
        Me.Label4.Text = "Accuracy:"
        Me.Label4.Location = New Point(10, 100)

        Me.txtAccuracy.Location = New Point(120, 98)
        Me.txtAccuracy.ReadOnly = True

        ' F1 Score
        Me.Label5.Text = "F1 Score:"
        Me.Label5.Location = New Point(10, 135)

        Me.txtF1Score.Location = New Point(120, 133)
        Me.txtF1Score.ReadOnly = True

        Me.grpModel.Controls.AddRange(
            {
                Label3, numTestSize,
                btnTrainModel,
                Label4, txtAccuracy,
                Label5, txtF1Score
            }
        )

        ' ===========================
        ' PREDICTION GROUP
        ' ===========================
        Me.grpPredict.Text = "Predict Workload"
        Me.grpPredict.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Me.grpPredict.Location = New Point(20, 570)
        Me.grpPredict.Size = New Size(460, 220)

        Me.Label6.Text = "Sleep Hours:"
        Me.Label6.Location = New Point(10, 40)
        Me.nudSleep.Location = New Point(120, 38)

        Me.Label7.Text = "Study Hours:"
        Me.Label7.Location = New Point(10, 80)
        Me.nudStudy.Location = New Point(120, 78)

        Me.Label8.Text = "Subjects:"
        Me.Label8.Location = New Point(10, 120)
        Me.nudSubjects.Location = New Point(120, 118)

        Me.Label9.Text = "Stress Level:"
        Me.Label9.Location = New Point(10, 160)
        Me.nudStress.Location = New Point(120, 158)

        Me.btnPredict.Text = "Predict"
        Me.btnPredict.Location = New Point(300, 90)
        Me.btnPredict.Size = New Size(130, 35)

        Me.lblPredictionResult.Text = "Prediction: "
        Me.lblPredictionResult.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        Me.lblPredictionResult.Location = New Point(300, 140)
        Me.lblPredictionResult.AutoSize = True

        Me.grpPredict.Controls.AddRange(
            {
                Label6, nudSleep,
                Label7, nudStudy,
                Label8, nudSubjects,
                Label9, nudStress,
                btnPredict,
                lblPredictionResult
            }
        )

        ' ===========================
        ' CHART TABS
        ' ===========================
        Me.tabVisuals.Location = New Point(500, 130)
        Me.tabVisuals.Size = New Size(660, 660)

        Me.tabWorkload.Text = "Workload Dist."
        Me.picWorkloadDist.Dock = DockStyle.Fill
        Me.picWorkloadDist.SizeMode = PictureBoxSizeMode.Zoom
        Me.tabWorkload.Controls.Add(Me.picWorkloadDist)

        Me.tabScatter.Text = "Scatter Plot"
        Me.picScatterPlot.Dock = DockStyle.Fill
        Me.picScatterPlot.SizeMode = PictureBoxSizeMode.Zoom
        Me.tabScatter.Controls.Add(Me.picScatterPlot)

        Me.tabConfusion.Text = "Confusion Matrix"
        Me.picConfusionMatrix.Dock = DockStyle.Fill
        Me.picConfusionMatrix.SizeMode = PictureBoxSizeMode.Zoom
        Me.tabConfusion.Controls.Add(Me.picConfusionMatrix)

        Me.tabVisuals.Controls.AddRange(
            {
                tabWorkload,
                tabScatter,
                tabConfusion
            }
        )

        ' ===========================
        ' ADD ROOT CONTROLS
        ' ===========================
        Me.Controls.AddRange(
            {
                pnlHeader,
                btnLoadSummary,
                btnShowCharts,
                grpSummary,
                grpModel,
                grpPredict,
                tabVisuals
            }
        )

        ' FORM SETTINGS
        Me.Text = "Machine Learning Analytics System"
        Me.ClientSize = New Size(1185, 820)
        Me.BackColor = ColorTranslator.FromHtml("#EFECE3")

        Me.ResumeLayout(False)

    End Sub

    ' ===== CONTROL DECLARATIONS =====

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label

    Friend WithEvents btnLoadSummary As Button
    Friend WithEvents btnShowCharts As Button

    Friend WithEvents grpSummary As GroupBox
    Friend WithEvents txtSummary As TextBox

    Friend WithEvents grpModel As GroupBox
    Friend WithEvents numTestSize As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTrainModel As Button
    Friend WithEvents txtAccuracy As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtF1Score As TextBox
    Friend WithEvents Label5 As Label

    Friend WithEvents grpPredict As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents nudSleep As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents nudStudy As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents nudSubjects As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents nudStress As NumericUpDown
    Friend WithEvents btnPredict As Button
    Friend WithEvents lblPredictionResult As Label

    Friend WithEvents tabVisuals As TabControl
    Friend WithEvents tabWorkload As TabPage
    Friend WithEvents picWorkloadDist As PictureBox

    Friend WithEvents tabScatter As TabPage
    Friend WithEvents picScatterPlot As PictureBox

    Friend WithEvents tabConfusion As TabPage
    Friend WithEvents picConfusionMatrix As PictureBox

End Class
