## parallel processing of pdf files with pdf extractor sdk in VB.NET using ByteScout PDF Suite

### Simple tutorial on how to do parallel processing of pdf files with pdf extractor sdk in VB.NET

ByteScout tutorials describe the stuff for programmers who use VB.NET. ByteScout PDF Suite was created to assist parallel processing of pdf files with pdf extractor sdk in VB.NET. ByteScout PDF Suite is the set that includes 6 SDK products to work with PDF from generating rich PDF reports to extracting data from PDF documents and converting them to HTML. This bundle includes PDF (Generator) SDK, PDF Renderer SDK, PDF Extractor SDK, PDF to HTML SDK, PDF Viewer SDK and PDF Generator SDK for Javascript.

 Want to speed up the application development? Then this VB.NET, code samples for VB.NET, developers help to speed up the application development and writing a code when using ByteScout PDF Suite. If you want to know how it works, then this VB.NET sample code should be copied and pasted into your application’s code editor. Then just compile and run it. Enjoy writing a code with ready-to-use sample VB.NET codes to add parallel processing of pdf files with pdf extractor sdk functions using ByteScout PDF Suite in VB.NET.

Trial version can be downloaded from our website for free. It contains this and other source code samples for VB.NET.

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
    ReadOnly ThreadLimiter As Semaphore = New Semaphore(4, 4)

    <MTAThread()>
    Sub Main()

        ' Get all PDF files in a folder
        Dim files = Directory.GetFiles("..\..\..\..\", "*.pdf")
        ' Array of events to wait
        Dim doneEvents(files.Length - 1) As ManualResetEvent

        For i As Integer = 0 To files.Length - 1

            ' Wait for the queue
            ThreadLimiter.WaitOne()

            ' Start thread with filename and event in params
            doneEvents(i) = New ManualResetEvent(False)
            Dim threadData As Object = New Object() {files(i), doneEvents(i)}
            ThreadPool.QueueUserWorkItem(AddressOf ConvertPdfToTxt, threadData)

        Next

        ' Wait until all threads finish
        WaitHandle.WaitAll(doneEvents)

        Console.WriteLine()
        Console.WriteLine("All is done.")
        Console.WriteLine()
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()

    End Sub

    Private Sub ConvertPdfToTxt(ByVal state As Object)

        ' Get filename and event from params
        Dim file As String = state(0)
        Dim doneEvent As ManualResetEvent = state(1)

        Dim resultFileName = Path.GetFileName(file) + ".txt"

        Try

            Console.WriteLine("Converting " + file)

            Using extractor As New TextExtractor("demo", "demo")

                extractor.LoadDocumentFromFile(file)
                extractor.SaveTextToFile(resultFileName)

            End Using

            Console.WriteLine("Finished " + resultFileName)

        Finally

            ' Signal the thread is finished
            doneEvent.Set()
            ' Release semaphore
            ThreadLimiter.Release()

        End Try

    End Sub

End Module

```

<!-- code block end -->    

<!-- code block begin -->

##### ****Parallel Processing.vbproj:**
    
```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">x86</Platform>
    <ProductVersion>
    </ProductVersion>
    <SchemaVersion>
    </SchemaVersion>
    <ProjectGuid>{07A9EE16-9FBC-47DD-992D-CBCB74593AF2}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <StartupObject>Parallel_Processing.Module1</StartupObject>
    <RootNamespace>Parallel_Processing</RootNamespace>
    <AssemblyName>Parallel Processing</AssemblyName>
    <FileAlignment>512</FileAlignment>
    <MyType>Console</MyType>
    <TargetFrameworkVersion>v2.0</TargetFrameworkVersion>
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
  <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'Debug|AnyCPU'">
    <DebugSymbols>true</DebugSymbols>
    <DefineDebug>true</DefineDebug>
    <DefineTrace>true</DefineTrace>
    <OutputPath>bin\Debug\</OutputPath>
    <DocumentationFile>Parallel Processing.xml</DocumentationFile>
    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <CodeAnalysisIgnoreBuiltInRuleSets>true</CodeAnalysisIgnoreBuiltInRuleSets>
    <CodeAnalysisIgnoreBuiltInRules>true</CodeAnalysisIgnoreBuiltInRules>
  </PropertyGroup>
  <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'Release|AnyCPU'">
    <DefineTrace>true</DefineTrace>
    <OutputPath>bin\Release\</OutputPath>
    <DocumentationFile>Parallel Processing.xml</DocumentationFile>
    <Optimize>true</Optimize>
    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>
    <DebugType>pdbonly</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <CodeAnalysisIgnoreBuiltInRuleSets>true</CodeAnalysisIgnoreBuiltInRuleSets>
    <CodeAnalysisIgnoreBuiltInRules>true</CodeAnalysisIgnoreBuiltInRules>
  </PropertyGroup>
  <PropertyGroup>
    <ApplicationManifest>My Project\app.manifest</ApplicationManifest>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Bytescout.PDFExtractor, Version=8.7.0.2981, Culture=neutral, PublicKeyToken=f7dd1bd9d40a50eb, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Program Files\Bytescout PDF Extractor SDK\net2.00\Bytescout.PDFExtractor.dll</HintPath>
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