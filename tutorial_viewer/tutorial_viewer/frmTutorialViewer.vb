Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.IO.TextReader

Public Class frmTutorialViewer
    Dim g_tutorialPages() As String = {}
    Dim g_currentPage As Integer = 0

    Sub loadEverything()
        Dim gmxFileName As String = getGMXFileName(txtProjectFolder.Text)
        Debug.Print("gmx file = " + gmxFileName)
        If (gmxFileName <> "NA") Then
            Dim tutorialPath As String = getTutorialFolder(gmxFileName)
            If (tutorialPath <> "") Then
                loadTutorialPages(tutorialPath)
            End If
        Else
            MessageBox.Show("Could not find a project file in " + txtProjectFolder.Text)
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

    Function getTutorialFolder(xmlFilePath As String) As String
        Dim toReturn As String = "NA"
        Dim reader As XmlTextReader = New XmlTextReader(xmlFilePath)

        reader.ReadToFollowing("TutorialName")
        toReturn = reader.ReadElementContentAsString()

        Return toReturn
    End Function

    Function getGMXFileName(inPath As String) As String
        Dim toReturn As String = "NA"

        'Brute force, get the last one always.
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                                            inPath,
                                            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                            "*.project.gmx")
            toReturn = foundFile
        Next

        Return toReturn
    End Function

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

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        loadEverything()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If (g_currentPage < g_tutorialPages.Count) Then
            g_currentPage = g_currentPage + 1
            displayCurrentTutorialPage()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If (g_currentPage > 1) Then
            g_currentPage = g_currentPage - 1
            displayCurrentTutorialPage()
        End If        
    End Sub


    Private Sub frmTutorialViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enableBackNextButtons()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dirBrowser As FolderBrowserDialog
        dirBrowser = New FolderBrowserDialog
        dirBrowser.SelectedPath = txtProjectFolder.Text

        If (dirBrowser.ShowDialog() = DialogResult.OK) Then
            txtProjectFolder.Text = dirBrowser.SelectedPath
            loadEverything()
        End If
    End Sub
End Class
