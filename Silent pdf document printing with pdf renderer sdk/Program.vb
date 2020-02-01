'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'



Imports Bytescout.PDFRenderer


Class Program
    Friend Shared Sub Main(args As String())

        Const PrinterName As String = "Microsoft Print to PDF"

        ' Create an instance of Bytescout.PDFRenderer.DocumentPrinter object and register it.
        Dim documentPrinter As New DocumentPrinter()
        documentPrinter.RegistrationName = "demo"
        documentPrinter.RegistrationKey = "demo"

        ' Load PDF document.
        documentPrinter.LoadDocumentFromFile("multipage.pdf")

        ' Change some printing options for demo purposes 
        ' (note, some options might be not supported by the printer):

        ' Change paper orientation
        documentPrinter.Landscape = True
        ' Set number of copies
        documentPrinter.Copies = 2
        ' Set collation
        documentPrinter.Collate = True
        ' Force black and white printing
        documentPrinter.Color = False

        ' Print all document pages to the specified printer
        documentPrinter.PrintDocument(PrinterName)

        ' To print specific pages use overridden methods allowing to define pages to print:
        'documentPrinter.PrintDocument(PrinterName, 2, 4) ' printer pages from 3 to 5
        'documentPrinter.PrintDocument(PrinterName, New Integer() {0, 2, 3, 4, 6}) ' print specific pages
        'documentPrinter.PrintDocument(PrinterName, "1,3-5,7-")

        documentPrinter.Dispose()

    End Sub
End Class
