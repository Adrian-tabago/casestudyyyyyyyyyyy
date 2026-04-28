Imports System.Xml

Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdBtnOthers.Checked = True
        'txtBoxComOthers.ReadOnly = True

        If rdBtnOthers.Checked Then
            txtBoxComOthers.ReadOnly = False
        Else
            txtBoxComOthers.ReadOnly = True
        End If
    End Sub

    'Private Sub rdBtnOthers_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnOthers.CheckedChanged

    '    If rdBtnOthers.Checked Then
    '        txtBoxComOthers.ReadOnly = False
    '    Else
    '        txtBoxComOthers.Clear()
    '    End If

    'End Sub

    Private Sub btnFComplaint_Click(sender As Object, e As EventArgs) Handles btnFComplaint.Click
        Dim frmStatus As New FormStatus
        Dim dateToday As Date = Date.Now
        Dim pending As Integer = 0


        If txtBoxAddress.Text.Equals("") Or txtBoxContact.Text.Equals("") Or txtBoxDesc.Text.Equals("") Then
            If txtBoxComOthers.Text.Equals("") Then
                MessageBox.Show("Please fill in the empty fields")
            End If
        Else
            If rdBtnOthers.Checked Then
                FormStatus.dataStatus.Rows.Add(Form1.txtBoxName.Text, txtBoxAddress.Text, txtBoxContact.Text, txtBoxComOthers.Text, "Pending", dateToday)
            ElseIf rdBtnDispute.Checked Then
                FormStatus.dataStatus.Rows.Add(Form1.txtBoxName.Text, txtBoxAddress.Text, txtBoxContact.Text, "Dispute", "Pending", dateToday)

            ElseIf rdNoise.Checked Then
                FormStatus.dataStatus.Rows.Add(Form1.txtBoxName.Text, txtBoxAddress.Text, txtBoxContact.Text, "Noise", "Pending", dateToday)

            ElseIf rdInfrastructure.Checked Then
                FormStatus.dataStatus.Rows.Add(Form1.txtBoxName.Text, txtBoxAddress.Text, txtBoxContact.Text, "Infrastructure", "Pending", dateToday)
            End If
            pending += 1
            FormStatus.summary.Rows.Add("Pending", pending)
            FormStatus.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim frmLogin As New Form1
        Form1.Show()
        Me.Hide()
    End Sub
End Class