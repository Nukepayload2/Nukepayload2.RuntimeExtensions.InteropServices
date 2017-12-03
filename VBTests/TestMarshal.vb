Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Runtime.InteropServices
Imports Nukepayload2.RuntimeExtensions.InteropServices.Marshal
Imports System.Text

<TestClass>
Public Class TestMarshal
    Private Const TestString As String = "WINNER WINNER, CHICKEN DINNER! 大吉大利，晚上吃鸡！"

    <TestMethod>
    Sub TestUnsafeCreateSecureString()
        Dim buf As Byte() = Encoding.Unicode.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim secStr = UnsafeCreateSecureString(ptr, TestString.Length)
        secStr.MakeReadOnly()
        Assert.AreEqual(TestString.Length, secStr.Length)
    End Sub

    <TestMethod>
    Sub TestUnsafeCreateNullTerminatedString()
        Dim buf As Byte() = Encoding.Unicode.GetBytes(TestString + vbNullChar)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim str = UnsafeCreateNullTerminatedString(ptr)
        Assert.AreEqual(TestString.Length, str.Length)
    End Sub

    <TestMethod>
    Sub TestUnsafeCreateString()
        Dim buf As Byte() = Encoding.Unicode.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim str = UnsafeCreateString(ptr, 0, TestString.Length)
        Assert.AreEqual(TestString, str)
    End Sub

    <TestMethod>
    Sub TestUnsafeCreateSpan()
        Dim buf As Byte() = Encoding.Unicode.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim str = UnsafeCreateSpan(Of Char)(ptr, TestString.Length)
        Assert.AreEqual(TestString.Length, str.Length)
    End Sub

    <TestMethod>
    Sub TestUnsafeCreateRoSpan()
        Dim buf As Byte() = Encoding.Unicode.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim str = UnsafeCreateReadOnlySpan(Of Char)(ptr, TestString.Length)
        Assert.AreEqual(TestString.Length, str.Length)
    End Sub

    <TestMethod>
    Sub TestUnsafeCreateUnmanagedMemoryStream()
        Dim buf As Byte() = Encoding.UTF8.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim str = UnsafeCreateUnmanagedMemoryStream(ptr, buf.Length)
        Assert.AreEqual(CLng(buf.Length), str.Length)
    End Sub
End Class
