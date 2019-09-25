## How to regular expression search and highlight in PDF in VB.NET and ByteScout PDF Suite

### Step-by-step tutorial on how to regular expression search and highlight in PDF in VB.NET

On this page you will learn from code samples for programming in VB.NET.Writing of the code to regular expression search and highlight in PDF in VB.NET can be executed by programmers of any level using ByteScout PDF Suite. ByteScout PDF Suite can regular expression search and highlight in PDF. It can be applied from VB.NET. ByteScout PDF Suite is the set that includes 6 SDK products to work with PDF from generating rich PDF reports to extracting data from PDF documents and converting them to HTML. This bundle includes PDF (Generator) SDK, PDF Renderer SDK, PDF Extractor SDK, PDF to HTML SDK, PDF Viewer SDK and PDF Generator SDK for Javascript.

 These VB.NET code samples for VB.NET guide developers to speed up coding of the application when using ByteScout PDF Suite. Just copy and paste the code into your VB.NET application’s code and follow the instructions. Use of ByteScout PDF Suite in VB.NET is also described in the documentation included along with the product.

If you want to try other source code samples then the free trial version of ByteScout PDF Suite is available for download from our website. Just try other source code samples for VB.NET.

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

##### ****Module1.vb:**
    
```
Imports System.Drawing
Imports Bytescout.PDF
Imports Bytescout.PDFExtractor

Module Module1

    Sub Main()

        Dim inputFile As String = ".\sample.pdf"
        Dim pageIndex As Integer = 0
        Dim searchPattern As String = "\d+\.\d+"

        ' Prepare TextExtractor
        Using textExtractor As TextExtractor = New TextExtractor("demo", "demo")

            textExtractor.RegexSearch = true
            textExtractor.LoadDocumentFromFile(inputFile)

            ' Load document with PDF SDK
            Using pdfDocument As Document = New Document(inputFile)

                pdfDocument.RegistrationName = "demo"
                pdfDocument.RegistrationKey = "demo"

                Dim pdfDocumentPage As Page = pdfDocument.Pages(pageIndex)
                Dim canvas As Canvas = pdfDocumentPage.Canvas

                Dim fillBrush As Bytescout.PDF.SolidBrush = new Bytescout.PDF.SolidBrush(new ColorRGB(255, 0, 0))
                fillBrush.Opacity = 50 ' make the brush transparent

                ' Search for pattern and highlight found pieces
                If textExtractor.Find(pageIndex, searchPattern, caseSensitive := False)

                    Do
                        For Each foundPiece In textExtractor.FoundText.Elements
                            
                            ' Inflate the rectangle a bit
                            Dim rect As RectangleF = RectangleF.Inflate(foundPiece.Bounds, 1, 2)
                            ' Draw rectangle over the PDF page
                            canvas.DrawRectangle(fillBrush, rect)

                        Next

                    Loop While textExtractor.FindNext()

                End If

                ' Save as new PDF document
                pdfDocument.Save("result.pdf")

                ' Open result document in default associated application (for demo purposes)
                Process.Start("result.pdf")
                
            End Using

        End Using

    End Sub

End Module

```

<!-- code block end -->    

<!-- code block begin -->

##### ****SearchAndHighlightExample.sln:**
    
```

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.27703.2018
MinimumVisualStudioVersion = 10.0.40219.1
Project("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}") = "SearchAndHighlightExample", "SearchAndHighlightExample.vbproj", "{23DFDE65-1DB4-4348-84C2-0E5BFD4473C1}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{23DFDE65-1DB4-4348-84C2-0E5BFD4473C1}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{23DFDE65-1DB4-4348-84C2-0E5BFD4473C1}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{23DFDE65-1DB4-4348-84C2-0E5BFD4473C1}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{23DFDE65-1DB4-4348-84C2-0E5BFD4473C1}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {D7B1CFBF-B914-4A51-9EC0-B8C10A2BEAB0}
	EndGlobalSection
EndGlobal

```

<!-- code block end -->    

<!-- code block begin -->

##### ****SearchAndHighlightExample.vbproj:**
    
```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{23DFDE65-1DB4-4348-84C2-0E5BFD4473C1}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <StartupObject>SearchAndHighlightExample.Module1</StartupObject>
    <RootNamespace>SearchAndHighlightExample</RootNamespace>
    <AssemblyName>SearchAndHighlightExample</AssemblyName>
    <FileAlignment>512</FileAlignment>
    <MyType>Console</MyType>
    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <DefineDebug>true</DefineDebug>
    <DefineTrace>true</DefineTrace>
    <OutputPath>bin\Debug\</OutputPath>
    <DocumentationFile>SearchAndHighlightExample.xml</DocumentationFile>
    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <DefineDebug>false</DefineDebug>
    <DefineTrace>true</DefineTrace>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DocumentationFile>SearchAndHighlightExample.xml</DocumentationFile>
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
    <Reference Include="Bytescout.PDF, Version=1.8.1.246, Culture=neutral, PublicKeyToken=f7dd1bd9d40a50eb, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Program Files\Bytescout PDF SDK\net4.0\Bytescout.PDF.dll</HintPath>
    </Reference>
    <Reference Include="Bytescout.PDFExtractor, Version=9.0.0.3087, Culture=neutral, PublicKeyToken=f7dd1bd9d40a50eb, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Program Files\Bytescout PDF Extractor SDK\net4.00\Bytescout.PDFExtractor.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Xml" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
  </ItemGroup>
  <ItemGroup>
    <Import Include="Microsoft.VisualBasic" />
    <Import Include="System" />
    <Import Include="System.Collections" />
    <Import Include="System.Collections.Generic" />
    <Import Include="System.Data" />
    <Import Include="System.Diagnostics" />
    <Import Include="System.Linq" />
    <Import Include="System.Xml.Linq" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Module1.vb" />
    <Compile Include="My Project\AssemblyInfo.vb" />
    <Compile Include="My Project\Application.Designer.vb">
      <AutoGen>True</AutoGen>
      <DependentUpon>Application.myapp</DependentUpon>
    </Compile>
    <Compile Include="My Project\Resources.Designer.vb">
      <AutoGen>True</AutoGen>
      <DesignTime>True</DesignTime>
      <DependentUpon>Resources.resx</DependentUpon>
    </Compile>
    <Compile Include="My Project\Settings.Designer.vb">
      <AutoGen>True</AutoGen>
      <DependentUpon>Settings.settings</DependentUpon>
      <DesignTimeSharedInput>True</DesignTimeSharedInput>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <EmbeddedResource Include="My Project\Resources.resx">
      <Generator>VbMyResourcesResXFileCodeGenerator</Generator>
      <LastGenOutput>Resources.Designer.vb</LastGenOutput>
      <CustomToolNamespace>My.Resources</CustomToolNamespace>
      <SubType>Designer</SubType>
    </EmbeddedResource>
  </ItemGroup>
  <ItemGroup>
    <None Include="My Project\Application.myapp">
      <Generator>MyApplicationCodeGenerator</Generator>
      <LastGenOutput>Application.Designer.vb</LastGenOutput>
    </None>
    <None Include="My Project\Settings.settings">
      <Generator>SettingsSingleFileGenerator</Generator>
      <CustomToolNamespace>My</CustomToolNamespace>
      <LastGenOutput>Settings.Designer.vb</LastGenOutput>
    </None>
    <Content Include="sample.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.VisualBasic.targets" />
</Project>
```

<!-- code block end -->