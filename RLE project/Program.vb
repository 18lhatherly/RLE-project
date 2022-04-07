'TODO debug, get luca to break the program
'TODO loop thru chars, 3 vars - count, lastchar and currentchar
'TODO find percentage of compression

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
                convertToRLE()
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
                If choice >= 1 And choice < 6 And choice.Length = 1 Then
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
        Dim ASCIIartFile As New StreamReader("\\hgs6\users$\students\18\18lhatherly\My Documents\LogoArt.txt")
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
        Dim ASCIIRLEFile As New StreamReader("\\hgs6\users$\students\18\18lhatherly\My Documents\LogoRLE.txt")
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

    Sub convertToRLE()
        Dim currentChar As Char
        Dim nextChar As Char
        Dim count As Integer = 1
        Dim ASCIIlines As Integer = 14
        Dim ASCIIart(ASCIIlines) As String
        Dim CompArr(ASCIIlines) As String
        Dim twoDigitCount As String
        Dim charCompTotal As Integer
        Dim charDecompTotal As Integer

        Console.WriteLine("Please enter the name of the text file. ")
        While Console.ReadLine().ToLower <> "logoart.txt"
            Console.WriteLine("Enter a valid file name.")
        End While
        Dim ASCIIArtFile As New StreamReader("\\hgs6\users$\students\18\18lhatherly\My Documents\Logoart.txt")
        For i = 0 To ASCIIlines - 1
            ASCIIart(i) = ASCIIArtFile.ReadLine()
            'Console.WriteLine(ASCIIart(i))
        Next

        For i = 0 To ASCIIlines - 1
            For j = 0 To ASCIIart(i).Length - 2
                currentChar = ASCIIart(i).Substring(j, 1)
                nextChar = ASCIIart(i).Substring(j + 1, 1)
                If currentChar = nextChar Then
                    count += 1
                Else
                    twoDigitCount = twoDigitNum(count)
                    CompArr(i) = CompArr(i) & twoDigitCount & currentChar
                    count = 1
                End If
            Next
            If nextChar <> currentChar Then
                twoDigitCount = twoDigitNum(count)
                CompArr(i) = CompArr(i) & twoDigitCount & nextChar
                count = 1
            End If
            Console.WriteLine(CompArr(i))
        Next
        For i = 0 To ASCIIlines - 1
            For j = 0 To CompArr(i).Length
                charCompTotal += 1
            Next
        Next
        Console.WriteLine()
        Console.WriteLine("The compressed array containts " & charCompTotal & " values")

        For i = 0 To ASCIIlines - 1
            For j = 0 To ASCIIart(i).Length
                charDecompTotal += 1
            Next
        Next
        Console.WriteLine("The decompressed array containts " & charDecompTotal & " values")

        Main()
    End Sub

    Function twoDigitNum(num)
        num = num.ToString
        num = "0" & num
        Return num
    End Function

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

