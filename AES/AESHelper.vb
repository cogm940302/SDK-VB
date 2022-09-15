Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.IO

Namespace vb.AES
    Public Class AESHelper
        Private key As String

        Public Sub New(ByVal key As String)
            Me.key = key
        End Sub

        Public Function Encrypt(ByVal text As String) As String
            Dim encrypted As Byte() = Nothing

            Using aes As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                aes.KeySize = 128
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7
                aes.Key = ConvertHexStringToByte(key)
                Dim randomIV As Byte() = New Byte(15) {}
                Dim rng As RandomNumberGenerator = RandomNumberGenerator.Create()
                rng.GetBytes(randomIV)
                aes.IV = randomIV
                Dim encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)

                Using ms As MemoryStream = New MemoryStream()

                    Using cs As CryptoStream = New CryptoStream(ms, encryptor, CryptoStreamMode.Write)

                        Using sw As StreamWriter = New StreamWriter(cs)
                            sw.Write(text)
                        End Using

                        encrypted = ms.ToArray()
                    End Using

                    encrypted = ConcatenateByteArrays(aes.IV, encrypted)
                End Using
            End Using

            Dim resultado As String = Convert.ToBase64String(encrypted)
            Return resultado
        End Function

        Public Function Decrypt(ByVal text As String) As String
            Dim plaintext As String = Nothing

            Using aes As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                Dim fullData As Byte() = Convert.FromBase64String(text)
                Dim cipherData As Byte() = New Byte(fullData.Length - 16 - 1) {}
                Dim ivByte As Byte() = New Byte(15) {}
                Buffer.BlockCopy(fullData, 16, cipherData, 0, cipherData.Length)
                Buffer.BlockCopy(fullData, 0, ivByte, 0, 16)
                aes.KeySize = 128
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7
                aes.Key = ConvertHexStringToByte(key)
                aes.IV = ivByte
                Dim decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)
                Dim result As Byte() = decryptor.TransformFinalBlock(cipherData, 0, cipherData.Length)
                plaintext = Encoding.ASCII.GetString(result)
            End Using

            Return plaintext
        End Function

        Public Function ConcatenateByteArrays(ByVal first As Byte(), ByVal second As Byte()) As Byte()
            Dim result As Byte() = New Byte(first.Length + second.Length - 1) {}
            Buffer.BlockCopy(first, 0, result, 0, first.Length)
            Buffer.BlockCopy(second, 0, result, first.Length, second.Length)
            Return result
        End Function

        Public Function ConvertHexStringToByte(ByVal hexString As String) As Byte()
            Dim data As Byte() = New Byte(hexString.Length / 2 - 1) {}

            For index As Integer = 0 To data.Length - 1
                Dim byteValue As String = hexString.Substring(index * 2, 2)
                data(index) = Byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
            Next

            Return data
        End Function
    End Class
End Namespace
