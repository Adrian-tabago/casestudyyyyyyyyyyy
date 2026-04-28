Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtBoxName.Text.Equals("") Or txtBoxPass.Text.Equals("") Then
            MessageBox.Show("Please fill in all fields")
        Else
            Dim Status As New FormStatus
            Dim frmComplaint As New Form2

            Form2.Show()
            Form2.lblName.Text = txtBoxName.Text


            Me.Hide()
        End If

    End Sub
End Class
