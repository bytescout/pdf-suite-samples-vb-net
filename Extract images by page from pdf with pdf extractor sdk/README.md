## How to extract images by page from pdf with pdf extractor sdk in VB.NET and ByteScout PDF Suite

### Learn to extract images by page from pdf with pdf extractor sdk in VB.NET

Extract images by page from pdf with pdf extractor sdk is simple to apply in VB.NET if you use these source codes below. ByteScout PDF Suite is the set that includes 6 SDK products to work with PDF from generating rich PDF reports to extracting data from PDF documents and converting them to HTML. This bundle includes PDF (Generator) SDK, PDF Renderer SDK, PDF Extractor SDK, PDF to HTML SDK, PDF Viewer SDK and PDF Generator SDK for Javascript and you can use it to extract images by page from pdf with pdf extractor sdk with VB.NET.

This prolific sample source code in VB.NET for ByteScout PDF Suite contains various functions and other necessary options you should do calling the API to extract images by page from pdf with pdf extractor sdk. IF you want to implement the functionality, just copy and paste this code for VB.NET below into your code editor with your app, compile and run your application. Enjoy writing a code with ready-to-use sample codes in VB.NET.

The trial version of ByteScout PDF Suite can be downloaded for free from our website. It also includes source code samples for VB.NET and other programming languages.

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

##### ****ExtractImagesByPages.VS2005.vbproj:**
    
```
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>8.0.50727</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{34509168-5D95-4323-8808-2A10FDE4E9A9}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ExtractImagesByPages</RootNamespace>
    <AssemblyName>ExtractImagesByPages</AssemblyName>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG,TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <Import Project="$(MSBuildBinPath)\Microsoft.VisualBasic.Targets" />
  <ItemGroup>
    <Import Include="Microsoft.VisualBasic" />
    <Import Include="System" />
    <Reference Include="Bytescout.PDFExtractor, Version=1.0.0.12, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Xml" />
    <Compile Include="Program.vb" />
    <Compile Include="Properties\AssemblyInfo.vb" />
    <Content Include="..\..\sample1.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <Link>sample1.pdf</Link>
    </Content>
    <Content Include="..\..\sample2.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <Link>sample2.pdf</Link>
    </Content>
  </ItemGroup>
  <ItemGroup>
  </ItemGroup>
</Project>
```

<!-- code block end -->    

<!-- code block begin -->

##### ****ExtractImagesByPages.VS2008.vbproj:**
    
```
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" ToolsVersion="3.5">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>9.0.21022</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{34509168-5D95-4323-8808-2A10FDE4E9A9}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ExtractImagesByPages</RootNamespace>
    <AssemblyName>ExtractImagesByPages</AssemblyName>
    <OldToolsVersion>2.0</OldToolsVersion>
    <TargetFrameworkVersion>v3.5</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG,TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.VisualBasic.Targets" />
  <ItemGroup>
    <Import Include="Microsoft.VisualBasic" />
    <Import Include="System" />
    <Reference Include="Bytescout.PDFExtractor, Version=1.0.0.12, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Xml" />
    <Compile Include="Program.vb" />
    <Compile Include="Properties\AssemblyInfo.vb" />
    <Content Include="..\..\sample1.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <Link>sample1.pdf</Link>
    </Content>
    <Content Include="..\..\sample2.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <Link>sample2.pdf</Link>
    </Content>
  </ItemGroup>
  <ItemGroup>
  </ItemGroup>
</Project>
```

<!-- code block end -->    

<!-- code block begin -->

##### ****ExtractImagesByPages.VS2010.vbproj:**
    
```
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" ToolsVersion="4.0">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>
    </ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{34509168-5D95-4323-8808-2A10FDE4E9A9}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ExtractImagesByPages</RootNamespace>
    <AssemblyName>ExtractImagesByPages</AssemblyName>
    <OldToolsVersion>3.5</OldToolsVersion>
    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG,TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.VisualBasic.Targets" />
  <ItemGroup>
    <Import Include="Microsoft.VisualBasic" />
    <Import Include="System" />
    <Reference Include="Bytescout.PDFExtractor, Version=1.0.0.12, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Xml" />
    <Compile Include="Program.vb" />
    <Compile Include="Properties\AssemblyInfo.vb" />
    <Content Include="..\..\sample1.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <Link>sample1.pdf</Link>
    </Content>
    <Content Include="..\..\sample2.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      <Link>sample2.pdf</Link>
    </Content>
  </ItemGroup>
  <ItemGroup>
  </ItemGroup>
</Project>
```

<!-- code block end -->    

<!-- code block begin -->

##### ****Program.vb:**
    
```
Imports Bytescout.PDFExtractor
Imports System.Drawing.Imaging

Class Program
	Friend Shared Sub Main(args As String())

        ' Create Bytescout.PDFExtractor.ImageExtractor instance
        Dim extractor As New ImageExtractor()
		extractor.RegistrationName = "demo"
		extractor.RegistrationKey = "demo"

		' Load sample PDF document
        extractor.LoadDocumentFromFile(".\sample1.pdf")

        ' Get count of pages
		Dim pageCount As Integer = extractor.GetPageCount()

        ' Extract images from each page
        For i As Integer = 0 To pageCount - 1

            Dim j As Integer = 0

            ' Initialize page images enumeration
            If extractor.GetFirstPageImage(i) Then
                Do
                    Dim outputFileName As String = "page" & i & "image" & j & ".png"

                    ' Save image to file
                    extractor.SaveCurrentImageToFile(outputFileName, ImageFormat.Png)

                    j = j + 1

                Loop While extractor.GetNextImage() ' Advance image enumeration
            End If

        Next

        ' Cleanup
		extractor.Dispose()

		' Open result file in default associated application (for demo purposes)
        System.Diagnostics.Process.Start("page0image0.png")
        
	End Sub
End Class

```

<!-- code block end -->