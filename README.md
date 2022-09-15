SDK para VB Framework 6

Implementacion:

Se requiere agrega la biblioteca dll al proyecto que la implementará 
y se solicita agregar la librería  "FluentValidation" 11.2.2

si se ocupa un archivo csproj se visualiza de esta manera

  <ItemGroup>
    <Reference Include="SdkNet">
      <HintPath>........\SdkNet.dll</HintPath>
    </Reference>
	  <PackageReference Include="FluentValidation" Version="11.2.2" />
  </ItemGroup>

  o en su defecto si ocupa la librería que se agrega

    <ItemGroup>
    <Reference Include="FluentValidation">
      <HintPath>..\FluentValidation.dll</HintPath>
    </Reference>
    <Reference Include="SdkVisualBasic">
      <HintPath>..\SdkVisualBasic.dll</HintPath>
    </Reference>
  </ItemGroup>

  En la clase que se ocupará se necesita agregar 
...
Imports SdkVisualBasic.SdkVisualBasic
Imports SdkVisualBasic.vb.Models
...

ejemplo de su ejecución
        Dim client As WPPClient = New WPPClient("https://sandboxpo.mit.com.mx/gen", "SNDBX123", "5DCC67393750523CD165F17E1EFADD21")
        Dim urlData As UrlData = New UrlData()
        urlData.reference = "reference001"
        urlData.amount = 10.0
        urlData.moneda = UrlData.MonedaType.MXN
        urlData.promotions = "C"
        urlData.stEmail = 1
        urlData.expirationDate = DateTime.Now
        Dim businessData As BusinessData = New BusinessData()
        businessData.idBranch = "01SNBXBRNCH"
        businessData.idCompany = "SNBX"
        businessData.user = "SNBXUSR0123"
        businessData.pwd = "SECRETO"
        Dim paymentData As PaymentData = New PaymentData()
        paymentData.business = businessData
        paymentData.url = urlData
        Dim responseURL = client.GetUrlPayment(paymentData)
        Console.WriteLine("La url es: " & responseURL)
        Dim r = client.ProcessAfterPaymentResponse("UHkxa6LtFWnN45zIb1dPCIcLSR3WOHmM2wejZIIiyhmQOOFoKA2iJnKyXLa5Y/2FnqoiVH1XV7tM5Uhzw6W3v0xzfNfnKfee4oFqpLxHG1uCqxgYAbCI7eWT37Im7VVCzpxl3QSPiXRQGnKrLOdNjaART1omE8/lUvKSgOC8mVnBg0VD1bSwOUJl8PqfzAM9fwiboQ7ucGxF7JTTmt0hdN2Fz58MXpWYEWcGJDUE9TMNCbUCACO3S1u9e10bCDQa4oSZ0vFbp5NZVivk8Vbp2jqo6LFLQYt5nZKqdGOdfusg4rVYD2oDrvSV3njkI9onpxsAU4iJT4L3ebsqyXcHxaAmu/T/B1m+WoSphFeV5Wcla8R6vh0M2dZFjDX6X016Dr7JR25aulgy1TmpzM0PEOxHGcsl+iGHk17dNECZ8/kY9Vsf9R4sz0sFswjQb3QOuawCMUPht4pdKsN1RXioTvLyIQpAKAavuGOIF+YAg59KWHmFFFdcLmeNyppyuY5RiguhfQVk8bql4Zd8sDOv/nomrdLWyxYEKUdjtkeKcz5EeyAkLUDNXsHrmOFn6MoF9ThSWB9eVHIlvIdkuaW5Qy3r7juXjNMcBW4suq2LiEvs+DbwhGSoKYAd2WhrMtt6fST2/kiYdbZT3A8EyN4Tz/6Qh2KJ4ur/hfiZnkyV/r4R3Rmxm+FYJpbPatItHBQxWx/H9BUtXQ8BO3j2h7jcai5XwmmXSQAgvI+GvL/P6oO3h51dnrRfhVUfOjV0BF0Yiz4GJlvxrWoI8u/s2bIi4LEwjQ7CMJzmUCeCVIPro730JLhkYFNZsvV/ANCt1sNj7HS0olWO3QZdmX7cLK6gXLMO4b/LMAoVqmOW95Nk+PuTHp+TOtOL8FIUNCVEqpXB+kHgIVTN0GdCsBKgvVrmWi5IA8BSKPfX33e8+XWQ2KHJJ4VvH8yyDb2Akxuc8XoxIUoXtV1u0GG7icQVaNEV/Xmj9ofUTqDcGaqqYN4OsZZ7t0ruYMAYwQQw7Y7/OGhHJtmLba+MfGUhpTeSCuxW80AWTXftq2k9kDR0gxSacEufIOfVuhGtCf5eZqxTawk8RJ4hArxDiFS2ODDvHexOk8iEzkz5rysdBTi1cgPTq4w=")
