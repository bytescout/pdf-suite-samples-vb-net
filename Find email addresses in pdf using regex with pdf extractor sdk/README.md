## How to find email addresses in pdf using regex with pdf extractor sdk in VB.NET and ByteScout PDF Suite

### Step-by-step tutorial on how to find email addresses in pdf using regex with pdf extractor sdk in VB.NET

On this page you will learn from code samples for programming in VB.NET.Writing of the code to find email addresses in pdf using regex with pdf extractor sdk in VB.NET can be executed by programmers of any level using ByteScout PDF Suite. ByteScout PDF Suite is the bundle that provides six different SDK libraries to work with PDF from generating rich PDF reports to extracting data from PDF documents and converting them to HTML. This bundle includes PDF (Generator) SDK, PDF Renderer SDK, PDF Extractor SDK, PDF to HTML SDK, PDF Viewer SDK and PDF Generator SDK for Javascript. It can find email addresses in pdf using regex with pdf extractor sdk in VB.NET.

 These VB.NET code samples for VB.NET guide developers to speed up coding of the application when using ByteScout PDF Suite.  Simply copy and paste in your VB.NET project or application you and then run your app! This basic programming language sample code for VB.NET will do the whole work for you to find email addresses in pdf using regex with pdf extractor sdk.

All these programming tutorials along with source code samples and ByteScout free trial version are available for download from our website.

## REQUEST FREE TECH SUPPORT

[Click here to get in touch](https://bytescout.zendesk.com/hc/en-us/requests/new?subject=ByteScout%20PDF%20Suite%20Question)

or just send email to [support@bytescout.com](mailto:support@bytescout.com?subject=ByteScout%20PDF%20Suite%20Question) 

## ON-PREMISE OFFLINE SDK 

[Get Your 60 Day Free Trial](https://bytescout.com/download/web-installer?utm_source=github-readme)
[Explore SDK Docs](https://bytescout.com/documentation/index.html?utm_source=github-readme)
[Sign Up For Online Training](https://academy.bytescout.com/)


## ON-DEMAND REST WEB API

[Get your API key](https://pdf.co/documentation/api?utm_source=github-readme)
[Explore Web API Documentation](https://pdf.co/documentation/api?utm_source=github-readme)
[Explore Web API Samples](https://github.com/bytescout/ByteScout-SDK-SourceCode/tree/master/PDF.co%20Web%20API)

## VIDEO REVIEW

[https://www.youtube.com/watch?v=NEwNs2b9YN8](https://www.youtube.com/watch?v=NEwNs2b9YN8)




<!-- code block begin -->

##### ****FindEmailAddressesRegex.vbproj:**
    
```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{80667702-F68F-42E8-AF48-A3F9D8C879CF}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <StartupObject>FindEmailAddressesRegex.Program</StartupObject>
    <RootNamespace>FindEmailAddressesRegex</RootNamespace>
    <AssemblyName>FindEmailAddressesRegex</AssemblyName>
    <FileAlignment>512</FileAlignment>
    <MyType>Console</MyType>
    <TargetFrameworkVersion>v2.0</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <DefineDebug>true</DefineDebug>
    <DefineTrace>true</DefineTrace>
    <OutputPath>bin\Debug\</OutputPath>
    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <DefineDebug>false</DefineDebug>
    <DefineTrace>true</DefineTrace>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>
  </PropertyGroup>
  <PropertyGroup>
    <OptionExplicit>On</OptionExplicit>
  </PropertyGroup>
  <PropertyGroup>
    <OptionCompare>Binary</OptionCompare>
  </PropertyGroup>
  <PropertyGroup>
    <OptionStrict>Off</OptionStrict>
  </PropertyGroup>
  <PropertyGroup>
    <OptionInfer>On</OptionInfer>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Bytescout.PDFExtractor, Version=9.1.0.3170, Culture=neutral, PublicKeyToken=f7dd1bd9d40a50eb, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>c:\Program Files\Bytescout PDF Extractor SDK\net2.00\Bytescout.PDFExtractor.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Deployment" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Import Include="Microsoft.VisualBasic" />
    <Import Include="System" />
    <Import Include="System.Collections" />
    <Import Include="System.Collections.Generic" />
    <Import Include="System.Data" />
    <Import Include="System.Diagnostics" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.vb" />
  </ItemGroup>
  <ItemGroup>
    <None Include="samplePDF_EmailAddress.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.VisualBasic.targets" />
</Project>
```

<!-- code block end -->    

<!-- code block begin -->

##### ****Program.vb:**
    
```
Imports Bytescout.PDFExtractor

Module Program

    Sub Main()

        Try
            ' Create Bytescout.PDFExtractor.TextExtractor instance
            Using extractor As TextExtractor = New TextExtractor()
                extractor.RegistrationName = "demo"
                extractor.RegistrationKey = "demo"

                ' Load sample PDF document
                extractor.LoadDocumentFromFile("samplePDF_EmailAddress.pdf")

                ' Enable the regular expression 
                extractor.RegexSearch = True

                Dim pageCount As Integer = extractor.GetPageCount()

                ' Search through pages
                For i As Integer = 0 To pageCount - 1
                    ' Search Email addresses
                    Dim regexPattern As String = "\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}\b"
                    ' See the complete regular expressions reference at https://msdn.microsoft.com/en-us/library/az24scfc(v=vs.110).aspx

                    ' Search each page for the pattern
                    If extractor.Find(i, regexPattern, False) Then

                        Do
                            ' Iterate through each element in the found text
                            For Each element As ISearchResultElement In extractor.FoundText.Elements
                                Console.WriteLine("Found Email Addresses: " & element.Text)
                            Next
                        Loop While extractor.FindNext()

                    End If
                Next
            End Using

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Console.WriteLine()
        Console.WriteLine("Press enter key to continue...")
        Console.ReadLine()

    End Sub

End Module

```

<!-- code block end -->