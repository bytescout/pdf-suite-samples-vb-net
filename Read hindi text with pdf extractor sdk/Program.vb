'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2019 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'


Imports System.Text
Imports Bytescout.PDFExtractor

Module Program

    Sub Main()

        Try

            ' Files
            Dim fileName As String = "hindiText.pdf"
            Dim destFileName As String = "extractedText.txt"

            ' Read all text from pdf file
            Dim extractor As TextExtractor = New TextExtractor

            ' Load PDF document
            extractor.LoadDocumentFromFile(fileName)

            ' Option 1: Extract all text and write to destination file
            extractor.SaveTextToFile(destFileName, encoding := Encoding.Unicode)

            Console.WriteLine("All extracted text (hindi) written successfully to destination text file.")

            Process.Start(destFileName)

            ' Option 2: Read all text to string variable
            'Dim allText As String = extractor.GetText

            ' Cleanup
            extractor.Dispose()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()

    End Sub

End Module
