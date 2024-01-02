Imports System.Collections.ObjectModel
Imports System.Text.Json
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpf.Core


Public Class BookViewModel
    Inherits ViewModelBase


    Public Property Books As ObservableCollection(Of BookModel)

    Private _selectedBook As BookModel

    Public Property SelectedBook() As BookModel
        Get
            Return _selectedBook
        End Get
        Set(value As BookModel)
            _selectedBook = value
            RaisePropertiesChanged(NameOf(SelectedBook))
        End Set
    End Property

    Public Sub New()
        Books = New ObservableCollection(Of BookModel)
        Dim test = GetAllBooks()
    End Sub

    Public Async Function GetAllBooks() As Task
        Dim apiService As New HttpApiService()
        Dim resp As ResponseBody(Of List(Of BookModel)) = Await apiService.GetData(Of ResponseBody(Of List(Of BookModel)))("books/allbook")
        If resp.StatusCode = 200 Then
            Books.Clear()
            For Each emp In resp.Data
                Books.Add(emp)
            Next
        Else
            Books.Clear()
        End If
    End Function

    <Command>
    Public Async Function BookUpdateCommand() As Task
        If SelectedBook IsNot Nothing Then
            Dim result = ThemedMessageBox.Show(title:="Kitap Güncelleme", text:="Kitabı Güncellemek İstiyor Musunuz?", messageBoxButtons:=MessageBoxButton.OKCancel, defaultButton:=MessageBoxResult.OK, icon:=MessageBoxImage.Information)
            If result = MessageBoxResult.OK Then
                Dim apiService As New HttpApiService()
                Dim resp As ResponseBody(Of BookModel) = Await apiService.PutData(Of ResponseBody(Of BookModel))("Books", JsonSerializer.Serialize(SelectedBook))

                Await GetAllBooks()
                SelectedBook = Nothing
            End If
        End If
    End Function

    '<Command>
    'Public Async Function BookDeleteCommand() As Task
    '    Dim apiService As New HttpApiService()
    '    Dim resp As ResponseBody(Of List(Of BookModel)) = Await apiService.DeleteData(Of NoData)("books")
    '    If resp.StatusCode = 200 Then
    '        Books.Clear()
    '        For Each emp In resp.Data
    '            Books.Add(emp)
    '        Next
    '    Else
    '        Books.Clear()
    '    End If
    'End Function

    '<Command>
    'Public Async Function BookDeleteCommand() As Task
    '    If SelectedBook IsNot Nothing Then
    '        Dim result = ThemedMessageBox.Show(title:="Kitap Silme", text:="Kitabı Silmek İstiyor Musunuz?", messageBoxButtons:=MessageBoxButton.OKCancel, defaultButton:=MessageBoxResult.OK, icon:=MessageBoxImage.Information)
    '        If result = MessageBoxResult.OK Then
    '            Dim apiService As New HttpApiService()
    '            Dim resp As ResponseBody(Of NoData) = Await apiService.DeleteData(Of ResponseBody(Of NoData))($"Books/{SelectedBook.BookId}")

    '            If resp.StatusCode = 200 Then
    '                Await GetAllBooks()
    '                SelectedBook = Nothing
    '            Else
    '                ' Silme başarısız oldu
    '                ThemedMessageBox.Show(title:="Hata", text:="Kitap silme işlemi başarısız oldu.", messageBoxButtons:=MessageBoxButton.OK, icon:=MessageBoxImage.Error)
    '            End If
    '        End If
    '    End If
    'End Function

    <Command>
    Public Async Function BookDeleteCommand() As Task
        If SelectedBook IsNot Nothing Then
            Dim result = ThemedMessageBox.Show(
                title:="Kitap Silme",
                text:="Kitabı Silmek İstiyor Musunuz?",
                messageBoxButtons:=MessageBoxButton.OKCancel,
                defaultButton:=MessageBoxResult.OK,
                icon:=MessageBoxImage.Information)

            If result = MessageBoxResult.OK Then
                Dim apiService As New HttpApiService()
                Dim isSuccess As Boolean = Await apiService.DeleteData($"Books/{SelectedBook.BookId}")

                If isSuccess Then
                    Await GetAllBooks()
                    SelectedBook = Nothing
                Else
                    ' Handle failure if needed
                End If
            End If
        End If
    End Function

    '<Command>
    'Public Sub BookEmptyFormCommand()

    '    SelectedBook = Nothing

    '    RaisePropertiesChanged(NameOf(SelectedBook))
    'End Sub

    '<Command>
    'Public Async Function BookAddCommand() As Task



    '    If SelectedBook IsNot Nothing Then
    '        Dim result = ThemedMessageBox.Show(title:="Kitap Ekleme", text:="Kitabı Eklemek İstiyor Musunuz?", messageBoxButtons:=MessageBoxButton.OKCancel, defaultButton:=MessageBoxResult.OK, icon:=MessageBoxImage.Information)
    '        If result = MessageBoxResult.OK Then
    '            Dim apiService As New HttpApiService()
    '            Dim resp As ResponseBody(Of BookModel) = Await apiService.PostData(Of ResponseBody(Of BookModel))("Books", JsonSerializer.Serialize(SelectedBook))

    '            Await GetAllBooks()
    '            SelectedBook = Nothing
    '        End If
    '    End If
    'End Function



End Class
