## How to make large PDF document searchable using parallel processing in VB.NET and ByteScout PDF Suite

### Learning is essential in computer world and the tutorial below will demonstrate how to make large PDF document searchable using parallel processing in VB.NET

We made thousands of pre-made source code pieces for easy implementation in your own programming projects. ByteScout PDF Suite is the bundle that provides six different SDK libraries to work with PDF from generating rich PDF reports to extracting data from PDF documents and converting them to HTML. This bundle includes PDF (Generator) SDK, PDF Renderer SDK, PDF Extractor SDK, PDF to HTML SDK, PDF Viewer SDK and PDF Generator SDK for Javascript. It can be applied to make large PDF document searchable using parallel processing using VB.NET.

 These VB.NET code samples for VB.NET guide developers to speed up coding of the application when using ByteScout PDF Suite. Just copy and paste the code into your VB.NET application’s code and follow the instructions. Applying VB.NET application mostly includes various stages of the software development so even if the functionality works please test it with your data and the production environment.

You can download free trial version of ByteScout PDF Suite from our website with this and other source code samples for VB.NET.

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
Imports System.IO
Imports System.Threading
Imports Bytescout.PDFExtractor

Module Module1

    ' Limit to 4 threads in queue.
    ' Set this value to number of your processor cores for max performance.
    Dim ThreadLimiter as Semaphore = New Semaphore(4, 4)

	<MTAThread>
	Sub Main()

		Const inputFile = "sample.pdf"
		Const resultFile = "result.pdf"

		Dim pageCount As Integer

		' Get document page count
		Using infoExtractor = New InfoExtractor()
			infoExtractor.LoadDocumentFromFile(inputFile)
			pageCount = infoExtractor.GetPageCount()
		End Using

		' Process the document by 10-page pieces
		Dim numberOfThreads As Integer
		numberOfThreads = pageCount \ 10
		If (pageCount - numberOfThreads * 10 > 0) Then numberOfThreads = numberOfThreads + 1

		Dim doneEvents(numberOfThreads - 1) As WaitHandle
		Dim stopwatch As Stopwatch = Stopwatch.StartNew()
		Dim startPage, endPage As Integer
		Dim pieces(numberOfThreads - 1) As String

		' Run threads
		For i As Integer = 0 To numberOfThreads - 1

            ' Wait for the queue
		    ThreadLimiter.WaitOne()

			doneEvents(i) = New ManualResetEvent(False)
			startPage = i * 10
			endPage = Math.Min(pageCount - 1, (i + 1) * 10 - 1)
			
			If numberOfThreads = 1 Then
				endPage = endPage - 1
			End If
						
			pieces(i) = String.Format("temp-{0}-{1}.pdf", startPage, endPage)
			ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf ThreadProc), New Object() {i, doneEvents(i), inputFile, pieces(i), startPage, endPage})

		Next

		' Wait for all threads
		WaitHandle.WaitAll(doneEvents)

		' Merge pieces 
		Using merger = New DocumentMerger
			merger.Merge(pieces, resultFile)
		End Using

		' Delete temp files
		For Each tempFile As String In pieces
			File.Delete(tempFile)
		Next
		
		Console.WriteLine("All done in {0}.", stopwatch.Elapsed)
		Console.WriteLine()

		Console.WriteLine("Press any key to exit...")
		Console.ReadKey()

	End Sub

	Sub ThreadProc(ByVal stateInfo As Object)

		Dim threadIndex As Integer = stateInfo(0)
		Dim waitEvent As ManualResetEvent = stateInfo(1)
		Dim inputFile As String = stateInfo(2)
		Dim outputFile As String = stateInfo(3)
		Dim startPage As Integer = stateInfo(4)
		Dim endPage As Integer = stateInfo(5)

	    Try

	        Console.WriteLine("Thread #{0} started with the page range from {1} to {2}.", threadIndex, startPage, endPage)

		    Dim stopwatch As Stopwatch = Stopwatch.StartNew()

		    ' Extract a piece of document
		    Dim chunk As String = String.Format("temp-{0}-{1}", startPage, endPage)
		    Using splitter = New DocumentSplitter
			    splitter.ExtractPageRange(inputFile, chunk, startPage + 1, endPage + 1)
		    End Using

		    ' Process the piece
		    Using searchablePdfMaker As New SearchablePDFMaker("demo", "demo")

			    searchablePdfMaker.OCRDetectPageRotation = True
			    searchablePdfMaker.OCRLanguageDataFolder = "c:\Program Files\Bytescout PDF Extractor SDK\ocrdata_best\"
			    searchablePdfMaker.LoadDocumentFromFile(chunk)

			    ' 300 DPI resolution is recommended. 
			    ' Using of higher values will slow down the processing but does not guarantee the higher quality.
			    searchablePdfMaker.OCRResolution = 300

			    searchablePdfMaker.MakePDFSearchable(outputFile)

		    End Using

		    File.Delete(chunk)

		    Console.WriteLine("Thread #{0} finished in {1}.", threadIndex, stopwatch.Elapsed)

	    Finally

            ' Signal the thread is finished
	        waitEvent.Set()

            ' Release semaphore
	        ThreadLimiter.Release()

	    End Try

		
	End Sub

End Module

```

<!-- code block end -->    

<!-- code block begin -->

##### ****MultithreadProcessing.sln:**
    
```

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26730.8
MinimumVisualStudioVersion = 10.0.40219.1
Project("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}") = "MultithreadProcessing", "MultithreadProcessing.vbproj", "{F18881BC-38FA-4D69-AD4E-4DC6CB637251}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{F18881BC-38FA-4D69-AD4E-4DC6CB637251}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{F18881BC-38FA-4D69-AD4E-4DC6CB637251}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{F18881BC-38FA-4D69-AD4E-4DC6CB637251}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{F18881BC-38FA-4D69-AD4E-4DC6CB637251}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {BADFE9BE-5CD2-45AC-9023-A1BB794B42E4}
	EndGlobalSection
EndGlobal

```

<!-- code block end -->    

<!-- code block begin -->

##### ****MultithreadProcessing.vbproj:**
    
```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{F18881BC-38FA-4D69-AD4E-4DC6CB637251}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <StartupObject>MultithreadProcessing.Module1</StartupObject>
    <RootNamespace>MultithreadProcessing</RootNamespace>
    <AssemblyName>MultithreadProcessing</AssemblyName>
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
    <DocumentationFile>MultithreadProcessing.xml</DocumentationFile>
    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <DefineDebug>false</DefineDebug>
    <DefineTrace>true</DefineTrace>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DocumentationFile>MultithreadProcessing.xml</DocumentationFile>
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
  <PropertyGroup>
    <ApplicationManifest>My Project\app.manifest</ApplicationManifest>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Bytescout.PDFExtractor, Version=8.2.0.2710, Culture=neutral, PublicKeyToken=f7dd1bd9d40a50eb, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>S:\Bytescout\PDF Extractor SDK\Bytescout.PDFExtractor\bin\Debug_FULL_4.0\Bytescout.PDFExtractor.dll</HintPath>
    </Reference>
    <Reference Include="Bytescout.PDFExtractor.OCRExtension, Version=8.2.0.2710, Culture=neutral, PublicKeyToken=f7dd1bd9d40a50eb, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>S:\Bytescout\PDF Extractor SDK\Bytescout.PDFExtractor\bin\Debug_FULL_4.0\Bytescout.PDFExtractor.OCRExtension.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Deployment" />
    <Reference Include="System.Xml" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
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
    <None Include="My Project\app.manifest" />
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
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>
```

<!-- code block end -->