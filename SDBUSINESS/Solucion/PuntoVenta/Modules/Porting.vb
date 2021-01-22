Module porting
    Public Declare Function Inp Lib "inpout32.dll" _
    Alias "Inp32" (ByVal PortAddress As Integer) As Integer
End Module