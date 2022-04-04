Imports System.IO
Module Module1
    Sub Main()
        Dim menuSelect As String
        menuSelect = menu()
        Select Case menuSelect
            Case 1
                RLE()
            Case 2
                displayASCII()
            Case 3
                convertToASCII()
            Case 4

            Case 5
                Console.WriteLine("Thank you for using my program, have a nice day.")
                End
        End Select
        Console.ReadLine()
    End Sub
    Function menu()
        Dim flag As Boolean = False
        Dim choice As String
        Console.WriteLine("Enter An Option")
        Console.WriteLine(" 1. Enter RLE")
        Console.WriteLine(" 2. Display ASCII Art")
        Console.WriteLine(" 3. Convert To ASCII Art")
        Console.WriteLine(" 4. Convert to RLE")
        Console.WriteLine(" 5. Quit")
        Console.WriteLine(" ")
        choice = Console.ReadLine()
        While flag = False
            If IsNumeric(choice) = True Then
                If choice >= 1 And choice < 5 And choice.Length = 1 Then
                    flag = True
                Else
                    Console.Write("Your input was too large/small/a decimal. Enter another option. ")
                    choice = Console.ReadLine()
                End If
            Else
                Console.Write("Your input wasn't a number. Enter another option. ")
                choice = Console.ReadLine()
            End If
        End While
        Return choice
    End Function
    Sub RLE()
        Dim lines As Integer
        Dim numofchar As String
        Dim theChar As Char
        Console.WriteLine("How many lines of RLE compressed data do you want to enter?")
        Dim userInput As String = Console.ReadLine()
        lines = valid(userInput)
        Dim deCompArr(lines) As String
        'Console.WriteLine(lines)
        Dim compDataArr(lines) As String
        Console.WriteLine("Please enter them below: ")
        For i = 0 To lines - 1
            compDataArr(i) = Console.ReadLine()
        Next

        Console.WriteLine()
        For i = 0 To lines - 1
            For j = 0 To compDataArr(i).Length - 1 Step 3
                numofchar = compDataArr(i).Substring(j, 2)
                theChar = compDataArr(i).Substring(j + 2, 1)
                For k As Integer = 1 To numofchar
                    deCompArr(i) += theChar
                Next

            Next
            Console.WriteLine(deCompArr(i))
        Next
        Console.WriteLine()
        Main()
    End Sub
    Sub displayASCII()
        Dim ASCIIlength As Integer = 14

        Console.WriteLine("Please enter the name of the text file. ")
        While Console.ReadLine().ToLower <> "logoart.txt"
            Console.WriteLine("Enter a valid file name.")
        End While
        Dim ASCIIart(ASCIIlength) As String
        Dim ASCIIartFile As New StreamReader("C:\Users\laure\Documents\LogoArt.txt")
        Console.WriteLine()
        For i = 0 To ASCIIlength - 1
            ASCIIart(i) = ASCIIartFile.ReadLine()
            Console.WriteLine(ASCIIart(i))
        Next
        ASCIIartFile.Close()
        Console.WriteLine()
        Main()
    End Sub

    Sub convertToASCII()
        Dim ASCIIlength As Integer = 14
        Dim ASCIIRLE(ASCIIlength) As String
        Dim numofchar As String
        Dim theChar As Char
        Dim deCompArr(ASCIIlength) As String
        Console.WriteLine("Please enter the name of the text file. ")
        While Console.ReadLine().ToLower <> "logorle.txt"
            Console.WriteLine("Enter a valid file name.")
        End While
        Dim ASCIIRLEFile As New StreamReader("C:\Users\laure\Documents\LogoRLE.txt")
        For i = 0 To ASCIIlength - 1
            ASCIIRLE(i) = ASCIIRLEFile.ReadLine()
            'Console.WriteLine(ASCIIRLE(i))
        Next
        ASCIIRLEFile.Close()
        Console.WriteLine()
        For i = 0 To ASCIIlength - 1
            For j = 0 To ASCIIRLE(i).Length - 1 Step 3
                numofchar = ASCIIRLE(i).Substring(j, 2)
                theChar = ASCIIRLE(i).Substring(j + 2, 1)
                For k As Integer = 1 To numofchar
                    deCompArr(i) += theChar
                Next

            Next
            Console.WriteLine(deCompArr(i))
        Next
        Console.WriteLine()
        Main()

    End Sub

    Function valid(input)
        Dim flag As Boolean
        While flag = False
            If IsNumeric(input) = True Then
                If input >= 2 Then
                    flag = True
                Else
                    Console.Write("Your input was too small/a decimal. Enter another option. ")
                    input = Console.ReadLine()
                End If
            Else
                Console.Write("Your input wasn't a number. Enter another option. ")
                input = Console.ReadLine()
            End If
        End While
        Return input
    End Function
End Module


