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


Imports Bytescout.PDFExtractor

Namespace ConsoleApplication1

    Class Program

        Shared Sub Main(ByVal args As String())

            ' Create Bytescout.PDFExtractor.JSONExtractor instance
            Dim extractor As New JSONExtractor()
            extractor.RegistrationName = "demo"
            extractor.RegistrationKey = "demo"

            ' Load sample PDF document
            extractor.LoadDocumentFromFile("sample1.pdf")

            ' Uncomment this line to get rid of empty nodes in JSON
            'extractor.PreserveFormattingOnTextExtraction = False

            ' Set output image format
            extractor.ImageFormat = OutputImageFormat.PNG

            ' Save images to external files
            extractor.SaveImages = ImageHandling.OuterFile
            extractor.ImageFolder = "images" ' Folder for external images
            extractor.SaveJSONToFile("result_with_external_images.json")

            ' Embed images into JSON as Base64 encoded string
            extractor.SaveImages = ImageHandling.Embed
            extractor.SaveJSONToFile("result_with_embedded_images.json")

            ' Cleanup
		    extractor.Dispose()

        End Sub

    End Class
    
End Namespace

