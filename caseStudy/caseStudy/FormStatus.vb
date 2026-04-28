Imports System.Text

Public Class FormStatus

    Private Sub FormStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbUpStatus.DropDownStyle = ComboBoxStyle.DropDownList
        summary.Visible = False
        gridSearch.Visible = False

    End Sub


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Form1.Show()
        Me.Hide()
        Form1.txtBoxName.Clear()
        Form1.txtBoxPass.Clear()
        Form2.txtBoxAddress.Clear()
        Form2.txtBoxContact.Clear()
        Form2.txtBoxDesc.Clear()
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim rowIndex As Integer = dataStatus.CurrentCell.RowIndex
        Dim colIndex As Integer = dataStatus.CurrentCell.ColumnIndex

        If colIndex = 4 Then

            ' 1. Update Grid1 status
            Dim newStatus As String = CmbUpStatus.Text
            dataStatus.Rows(rowIndex).Cells(4).Value = newStatus

            ' 2. Create counters
            Dim pending As Integer = 0
            Dim resolved As Integer = 0
            Dim underInvestigation As Integer = 0

            ' 3. Loop Grid1 and count statuses
            For Each row As DataGridViewRow In dataStatus.Rows

                If row.Cells(4).Value IsNot Nothing Then

                    Dim status As String = row.Cells(4).Value.ToString()

                    If status = "Pending" Then
                        pending += 1

                    ElseIf status = "Resolved" Then
                        resolved += 1

                    ElseIf status = "Under Investigation" Then
                        underInvestigation += 1
                    End If

                End If

            Next

            ' 4. Update Grid2 (summary)
            summary.Rows.Clear()

            summary.Rows.Add("Pending", pending)
            summary.Rows.Add("Resolved", resolved)
            summary.Rows.Add("Under Investigation", underInvestigation)

        Else
            MessageBox.Show("You can't change that value")
        End If


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            dataStatus.Rows.RemoveAt(dataStatus.CurrentRow.Index)
        Catch ex As Exception
            MessageBox.Show("Please select a row to delete")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "Summary" Then
            dataStatus.Visible = True
            summary.Visible = False
            LblName.Visible = False
            TextBox1.Visible = False
            search.Visible = False
            gridSearch.Visible = False
            btnDelete.Enabled = True
            btnUpdate.Enabled = True

        ElseIf ComboBox1.Text = "Status Summary" Then
            dataStatus.Visible = False
            summary.Visible = True
            LblName.Visible = False
            TextBox1.Visible = False
            search.Visible = False
            gridSearch.Visible = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = False

        ElseIf ComboBox1.Text = "Search" Then
            LblName.Visible = True
            TextBox1.Visible = True
            search.Visible = True
            gridSearch.Visible = False
            btnDelete.Enabled = True
            btnUpdate.Enabled = False
        End If
    End Sub

    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        gridSearch.Visible = True
    End Sub


End Class