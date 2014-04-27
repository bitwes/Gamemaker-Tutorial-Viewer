<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTutorialViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.webTutorial = New System.Windows.Forms.WebBrowser()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblCurPage = New System.Windows.Forms.Label()
        Me.cmbProjectDirectory = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project Folder"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(640, 43)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'webTutorial
        '
        Me.webTutorial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webTutorial.Location = New System.Drawing.Point(-1, 72)
        Me.webTutorial.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webTutorial.Name = "webTutorial"
        Me.webTutorial.Size = New System.Drawing.Size(799, 594)
        Me.webTutorial.TabIndex = 3
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGo.Location = New System.Drawing.Point(721, 43)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(67, 23)
        Me.btnGo.TabIndex = 4
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Location = New System.Drawing.Point(635, 672)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(724, 672)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(64, 23)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lblCurPage
        '
        Me.lblCurPage.AutoSize = True
        Me.lblCurPage.Location = New System.Drawing.Point(12, 53)
        Me.lblCurPage.Name = "lblCurPage"
        Me.lblCurPage.Size = New System.Drawing.Size(93, 13)
        Me.lblCurPage.TabIndex = 7
        Me.lblCurPage.Text = "No Pages Loaded"
        '
        'cmbProjectDirectory
        '
        Me.cmbProjectDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProjectDirectory.FormattingEnabled = True
        Me.cmbProjectDirectory.Location = New System.Drawing.Point(90, 16)
        Me.cmbProjectDirectory.Name = "cmbProjectDirectory"
        Me.cmbProjectDirectory.Size = New System.Drawing.Size(698, 21)
        Me.cmbProjectDirectory.TabIndex = 8
        '
        'frmTutorialViewer
        '
        Me.AcceptButton = Me.btnGo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 707)
        Me.Controls.Add(Me.cmbProjectDirectory)
        Me.Controls.Add(Me.lblCurPage)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.webTutorial)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTutorialViewer"
        Me.Text = "Game Maker Tutorial Viewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents webTutorial As System.Windows.Forms.WebBrowser
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblCurPage As System.Windows.Forms.Label
    Friend WithEvents cmbProjectDirectory As System.Windows.Forms.ComboBox

End Class
