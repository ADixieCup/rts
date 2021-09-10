Partial Class RTSLabs
    Inherits System.Web.UI.Page


    Dim bolSuccess As Boolean = False

    Private Sub bolUsePreDefined_CheckedChanged(sender As Object, e As EventArgs) Handles bolUsePreDefined.CheckedChanged
        subResetPreDefined()
    End Sub
    Private Sub bolTwoUsePredefined_CheckedChanged(sender As Object, e As EventArgs) Handles bolTwoUsePredefined.CheckedChanged
        subResetTwoPreDefined()
    End Sub

    Private Sub subResetPreDefined()
        Try
            If bolUsePreDefined.Checked Then
                txtDelimiter.Text = ","
                txtDelimitedArray.Text = "1,5,2,1,10"
                txtCompareValue.Text = "6"

            Else
                txtDelimitedArray.Text = ""
                txtDelimiter.Text = ""
                txtCompareValue.Text = ""

            End If

            'reset the output and the error
            lblOutput.Text = ""
            lblError.Text = ""


        Catch ex As Exception
            lblError.Text = ex.Message + " <br/> " + ex.ToString()
        End Try
    End Sub

    Private Sub subResetTwoPreDefined()
        Try
            If bolTwoUsePredefined.Checked Then
                txtString.Text = "MyString"
                txtRotateValue.Text = "2"

            Else
                txtString.Text = ""
                txtRotateValue.Text = ""

            End If

            'reset the output and the error
            lblTwoError.Text = ""
            lblTwoOutput.Text = ""

        Catch ex As Exception
            lblTwoError.Text = ex.Message + " <br/> " + ex.ToString()
        End Try
    End Sub


    Private Sub subValidate()
        Try
            Dim errMsg As String = ""

            If txtDelimiter.Text = "" Then
                errMsg += "Delimiter is required. <br/>"
            End If

            If txtDelimitedArray.Text = "" Then
                errMsg += "Delimited Array is required. <br/>"
            End If

            If txtCompareValue.Text = "" Then
                errMsg += "Compare Value is required. <br/>"
            End If


            If Not errMsg = "" Then
                bolSuccess = False
                lblError.Text = errMsg
            Else
                bolSuccess = True
            End If



        Catch ex As Exception
            lblError.Text = ex.Message + " <br/> " + ex.ToString()
        End Try
    End Sub

    Private Sub subValidateTwo()
        Try
            lblTwoOutput.Text = ""
            lblError.Text = ""

            Dim errMsg As String = ""

            If txtString.Text = "" Then
                errMsg += "String is required. <br/>"
            End If

            If txtRotateValue.Text = "" Then
                errMsg += "Rotate Value is required. <br/>"
            Else
                If Not IsNumeric(txtRotateValue.Text) Then
                    errMsg += "Rotate Value must be a number. <br/>"
                End If

            End If


            If Not errMsg = "" Then
                bolSuccess = False
                lblTwoError.Text = errMsg
            Else
                bolSuccess = True
            End If


        Catch ex As Exception
            lblTwoError.Text = ex.Message + " <br/> " + ex.ToString()
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try
            'reset the error message if there is one there. 
            lblError.Text = ""

            'reset the output text
            lblOutput.Text = ""


            subValidate()

            If bolSuccess Then




                'predefined variables to be used later. 
                Dim intAbove As Integer = 0
                Dim intBelow As Integer = 0

                'used in case there is a non-numberic entry added. want to make sure to catch those. 
                Dim intNAN As Integer = 0

                'set some other variables as well to use for the array. 
                Dim delim As String = txtDelimiter.Text.Trim()
                Dim ary As Array


                'make sure the delimetedArray contains the delimiter.
                If txtDelimitedArray.Text.Contains(delim) Then

                    If IsNumeric(txtCompareValue.Text.Trim()) Then

                        'set the compareValue
                        Dim compareValue As Integer = txtCompareValue.Text.Trim()

                        'split text into an array
                        ary = txtDelimitedArray.Text.Split(delim)


                        'for each item in the array. 
                        For Each itm As String In ary

                            'make sure its numeric. 
                            If IsNumeric(itm) Then

                                Dim value As Integer
                                value = CInt(itm)

                                'little confusing. if compareValue > value, its below. else, its above. 
                                If compareValue > value Then
                                    intBelow += 1
                                Else
                                    intAbove += 1
                                End If

                            Else
                                intNAN += 1
                            End If


                        Next

                        lblOutput.Text = "above: " + intAbove.ToString() + ", below: " + intBelow.ToString()


                        If intNAN > 0 Then
                            'we have a non-number. 
                            lblOutput.Text += "<br/> NaN: " + intNAN.ToString()
                        End If

                    Else
                        lblError.Text = "Your compare value must be a number. <br/>"
                    End If

                Else
                    lblError.Text = "Your delimiter does not match the delimited array. Please make sure the delimeter matches. <br/>"
                End If


            End If
        Catch ex As IndexOutOfRangeException
            lblError.Text = "There is something wrong with your array. <br/>"
        Catch ex As Exception
            lblError.Text = ex.Message + " <br/> " + ex.ToString()


        End Try



    End Sub

    Private Sub btnTwoSubmit_Click(sender As Object, e As EventArgs) Handles btnTwoSubmit.Click
        Try

            subValidateTwo()

            If bolSuccess Then

                Dim rotateValue As Integer = CInt(txtRotateValue.Text.Trim())
                Dim stringLength As Integer = txtString.Text.Length

                Dim startPosition As Integer = stringLength - rotateValue


                'made it passed the validation, do one more validation to make sure that the rotate value is not bigger than string value
                If Not CInt(rotateValue) > stringLength - 1 Then


                    Dim splitString As String = ""

                    'get the second part of the string 
                    Dim secondPartOfString As String = txtString.Text.Substring(0, startPosition)

                    'get the first part of the string
                    Dim firstPartOfString As String = txtString.Text.Substring(startPosition, rotateValue)



                    'concat
                    lblTwoOutput.Text = firstPartOfString & secondPartOfString




                Else
                    lblTwoError.Text = "Rotate Value cannot be bigger than total lenght of string"

                End If


            End If


        Catch ex As Exception
            lblTwoError.Text = ex.Message + " <br/> " + ex.ToString()
        End Try

    End Sub


    Private Sub RTSLabs_Load(sender As Object, e As EventArgs) Handles Me.Load
        'no onload functions. 

        If Not IsPostBack Then
            bolUsePreDefined.Checked = True
            subResetPreDefined()

            bolTwoUsePredefined.Checked = True
            subResetTwoPreDefined()
        End If


    End Sub


End Class
