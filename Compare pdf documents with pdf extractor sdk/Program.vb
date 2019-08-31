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


Imports Bytescout.PDFExtractor

Class Program
        Friend Shared Sub Main(args As String())

        ' Load first document
        Dim document1 As TextExtractor = New TextExtractor()
        document1.RegistrationName = "demo"
        document1.RegistrationKey = "demo"
        document1.LoadDocumentFromFile(".\comparison1.pdf")

        ' Load second  document
        Dim document2 As TextExtractor = New TextExtractor()
        document2.RegistrationName = "demo"
        document2.RegistrationKey = "demo"
        document2.LoadDocumentFromFile(".\comparison2.pdf")

        ' Compare documents
        Dim comparer As TextComparer = New TextComparer()
        comparer.RegistrationName = "demo"
        comparer.RegistrationKey = "demo"
        comparer.Compare(document1, document2)

        ' Generate report
        comparer.GenerateHtmlReport(".\report.html")

        ' Cleanup
        document1.Dispose()
        document2.Dispose()

        ' Open the report in default browser
        System.Diagnostics.Process.Start(".\report.html")

        End Sub
End Class
