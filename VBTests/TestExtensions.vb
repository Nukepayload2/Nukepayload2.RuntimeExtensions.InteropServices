Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Nukepayload2.RuntimeExtensions.InteropServices.Marshal
Imports Nukepayload2.RuntimeExtensions.InteropServices.Extensions

<TestClass>
Public Class TestExtensions

    Private Const TestString As String = "WINNER WINNER, CHICKEN DINNER! 大吉大利，晚上吃鸡！"

    <TestMethod>
    Sub TestUnmanagedMemoryStreamExtensions()
        Dim buf As Byte() = Encoding.UTF8.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim str = UnsafeCreateUnmanagedMemoryStream(ptr, buf.Length)
        Assert.IsTrue(str.DangerousGetPositionPointer <> IntPtr.Zero)
        str.DangerousSetPositionPointer(str.DangerousGetPositionPointer)
        Assert.IsTrue(str.DangerousGetPositionPointer <> IntPtr.Zero)
    End Sub

    <TestMethod>
    Sub TestStringBuilderExtensions()
        Dim buf As Byte() = Encoding.Unicode.GetBytes(TestString)
        Dim ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buf, 0)
        Dim sb As New StringBuilder
        sb.DangerousAppend(ptr, TestString.Length)
        Assert.AreEqual(TestString, sb.ToString)
    End Sub

    <TestMethod>
    Sub TestEncodingExtensions()
        Dim ucode As Byte() = Encoding.Unicode.GetBytes(TestString)
        Dim utf8 As Byte() = Encoding.UTF8.GetBytes(TestString)
        Dim ptrUcode = Marshal.UnsafeAddrOfPinnedArrayElement(ucode, 0)
        Dim ptrUtf8 = Marshal.UnsafeAddrOfPinnedArrayElement(utf8, 0)
        Assert.AreEqual(utf8.Length, Encoding.UTF8.DangerousGetByteCount(ptrUcode, TestString.Length))
        Assert.AreEqual(utf8.Length, Encoding.UTF8.DangerousGetBytes(ptrUcode, TestString.Length, ptrUtf8, utf8.Length))
        Assert.AreEqual(TestString.Length, Encoding.Unicode.DangerousGetCharCount(ptrUcode, ucode.Length))
        Assert.AreEqual(TestString.Length, Encoding.UTF8.DangerousGetChars(ptrUtf8, utf8.Length, ptrUcode, TestString.Length))
    End Sub
End Class
