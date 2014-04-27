Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.IO.TextReader

Public Class frmTutorialViewer
    Dim g_tutorialPages() As String = {}
    Dim g_currentPage As Integer = 0

    Sub fillComboBoxFromSettings()

        cmbProjectDirectory.Items.Clear()
        For i As Integer = My.Settings.urls.Count - 1 To 0 Step -1
            cmbProjectDirectory.Items.Add(My.Settings.urls(i))
        Next
    End Sub

    Sub addProjectPathToSettings(projectPath)
        If (My.Settings.urls.Contains(projectPath) = False) Then
            If (My.Settings.urls.Count = 10) Then
                My.Settings.urls.RemoveAt(0)
            End If
            My.Settings.urls.Add(projectPath)
            My.Settings.Save()
            fillComboBoxFromSettings()
        End If
    End Sub

    'Gets the tutorial path from the .project.gmx file in xmlFilePath
    Function getTutorialFolder(xmlFilePath As String) As String
        Dim toReturn As String = ""
        Dim reader As XmlTextReader = New XmlTextReader(xmlFilePath)

        reader.ReadToFollowing("TutorialName")
        toReturn = reader.ReadElementContentAsString()

        Return toReturn
    End Function

    'Gets the .project.gmx filepath from a directory.  Returns NA if not found.
    Function getGMXFileName(inPath As String) As String
        Dim toReturn As String = "NA"

        'Brute force, get the last one always, but there should only be one.
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                                            inPath,
                                            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                            "*.project.gmx")
            toReturn = foundFile
        Next

        Return toReturn
    End Function

    'Loads all the HTML filenames into g_tutorialPages given a path to the tutorial folder.
    Sub loadTutorialPages(tutorialPath As String)
        Dim count As Integer = 0
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                                            tutorialPath,
                                            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                            "page*.html")
            ReDim Preserve g_tutorialPages(count)
            g_tutorialPages(count) = foundFile
            count += 1
        Next

        If (g_tutorialPages.Count > 0) Then
            Debug.Print("loading:  " + g_tutorialPages(0))
            g_currentPage = 1
            displayCurrentTutorialPage()            
        Else
            MessageBox.Show("Could not find any tutorial pages in " + tutorialPath)
            g_currentPage = 0
        End If

    End Sub

    'Takes in the path to the project directory then loads up all the tutorial pages
    Sub loadEverything(projectDirectoryPath As String)
        Dim gmxFileName As String = getGMXFileName(projectDirectoryPath)

        If (gmxFileName <> "NA") Then
            Dim tutorialPath As String = getTutorialFolder(gmxFileName)
            If (tutorialPath <> "") Then
                loadTutorialPages(tutorialPath)
                addProjectPathToSettings(projectDirectoryPath)
            Else
                MsgBox("Could not find a tutorial for this project")
            End If
        Else
            MessageBox.Show("Could not find a project file in " + projectDirectoryPath)
        End If
    End Sub

    Sub enableBackNextButtons()
        btnNext.Enabled = True
        btnBack.Enabled = True

        If (g_currentPage <= 1) Then
            btnBack.Enabled = False
        End If

        If (g_currentPage >= g_tutorialPages.GetUpperBound(0)) Then
            btnNext.Enabled = False
        End If
    End Sub

    Sub displayCurrentTutorialPage()
        lblCurPage.Text = "Page " & g_currentPage & " of " & g_tutorialPages.Count
        webTutorial.Navigate(g_tutorialPages(g_currentPage - 1))
        enableBackNextButtons()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If (cmbProjectDirectory.Text = "") Then
            MsgBox("You must enter the path a game Maker Project")
            cmbProjectDirectory.Focus()
        Else
            If (Directory.Exists(cmbProjectDirectory.Text)) Then
                loadEverything(cmbProjectDirectory.Text)
                webTutorial.Focus()
            Else
                MsgBox("Invalid directory path:  " + cmbProjectDirectory.Text)
            End If
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If (g_currentPage < g_tutorialPages.Count) Then
            g_currentPage = g_currentPage + 1
            displayCurrentTutorialPage()
        End If
        webTutorial.Focus()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If (g_currentPage > 1) Then
            g_currentPage = g_currentPage - 1
            displayCurrentTutorialPage()
        End If
        webTutorial.Focus()        
    End Sub

    Private Sub frmTutorialViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enableBackNextButtons()
        fillComboBoxFromSettings()
        'For Each url As String In My.Settings.urls
        ' cmbProjectDirectory.Items.Add(url)
        ' Next url
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dirBrowser As FolderBrowserDialog
        dirBrowser = New FolderBrowserDialog
        dirBrowser.SelectedPath = cmbProjectDirectory.Text

        If (dirBrowser.ShowDialog() = DialogResult.OK) Then
            cmbProjectDirectory.Text = dirBrowser.SelectedPath
            loadEverything(cmbProjectDirectory.Text)
            webTutorial.Focus()
        End If
    End Sub

    Private Sub webTutorial_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles webTutorial.Navigated
        webTutorial.Focus()
    End Sub

    Private Sub frmTutorialViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub cmbProjectDirectory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjectDirectory.SelectedIndexChanged
        loadEverything(cmbProjectDirectory.Text)
    End Sub
End Class
