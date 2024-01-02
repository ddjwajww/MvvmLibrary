Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Text.Json

Public Class HttpApiService



    Public Async Function GetData(Of TResponse)(requestUri As String, Optional token As String = Nothing) As Task(Of TResponse)

        Using client As New HttpClient()

            ' Servise gönderilecek request
            Dim requestMessage = New HttpRequestMessage() With {
            .Method = HttpMethod.Get,
            .RequestUri = New Uri($"http://localhost:17593/api/{requestUri}")}
            requestMessage.Headers.Add("Accept", "application/json")

            ' Servise request gönderiliyor 
            Dim responseMessage = Await client.SendAsync(requestMessage)

            ' Servisten gelen yanıt T tipine dönüştürülüyor
            Dim jsonResponse = Await responseMessage.Content.ReadAsStringAsync()
            Dim response = JsonSerializer.Deserialize(Of TResponse)(jsonResponse, New JsonSerializerOptions() With {.PropertyNameCaseInsensitive = True})

            ' Servisten gelen yanıt T tipinde döndürülüyor
            Return response

        End Using

    End Function

    Public Async Function PostData(Of TResponse)(ByVal requestUri As String, ByVal jsonData As String, Optional ByVal token As String = Nothing) As Task(Of TResponse)

        Using client As New HttpClient()
            'Servise göndereceğimiz request
            Dim requestMessage As New HttpRequestMessage() With {
            .Method = HttpMethod.Post,
            .RequestUri = New Uri($"http://localhost:17593/api/{requestUri}"),
            .Content = New StringContent(jsonData, Encoding.UTF8, "application/json")}
            requestMessage.Headers.Add("Accept", "application/json")

            ' Servise request gönderiliyor 
            Dim responseMessage = Await client.SendAsync(requestMessage)

            ' Servisten gelen yanıt T tipine dönüştürülüyor
            Dim jsonResponse = Await responseMessage.Content.ReadAsStringAsync()
            Dim response = JsonSerializer.Deserialize(Of TResponse)(jsonResponse, New JsonSerializerOptions() With {.PropertyNameCaseInsensitive = True})

            ' Servisten gelen yanıt T tipinde döndürülüyor
            Return response
        End Using
    End Function

    Public Async Function PutData(Of TResponse)(ByVal requestUri As String, ByVal jsonData As String, Optional ByVal token As String = Nothing) As Task(Of TResponse)

        Using client As New HttpClient()

            'Servise göndereceğim request
            Dim requestMessage As New HttpRequestMessage() With {
            .Method = HttpMethod.Put,
            .RequestUri = New Uri($"http://localhost:17593/api/{requestUri}"),
            .Content = New StringContent(jsonData, Encoding.UTF8, "application/json")}
            requestMessage.Headers.Add("Accept", "application/json")

            ' servise requset gönderiliyor 
            Dim responseMessage = Await client.SendAsync(requestMessage)

            ' servisten gelen yanıt T tipine dönüştürülüyor
            Dim jsonResponse = Await responseMessage.Content.ReadAsStringAsync()
            Dim response = JsonSerializer.Deserialize(Of TResponse)(jsonResponse, New JsonSerializerOptions() With {.PropertyNameCaseInsensitive = True})

            ' servisten gelen yanıt T tipinde döndürülüyor
            Return response
        End Using

    End Function


    Public Async Function DeleteData(ByVal requestUri As String, Optional ByVal token As String = Nothing) As Task(Of Boolean)
        Using client As New HttpClient()
            'Servise göndereceğim request
            Dim requestMessage As New HttpRequestMessage() With {
            .Method = HttpMethod.Delete,
            .RequestUri = New Uri($"http://localhost:17593/api/{requestUri}")}
            ' servise requset gönderiliyor 
            Dim responseMessage = Await client.SendAsync(requestMessage)

            Return responseMessage.IsSuccessStatusCode
        End Using
    End Function
End Class