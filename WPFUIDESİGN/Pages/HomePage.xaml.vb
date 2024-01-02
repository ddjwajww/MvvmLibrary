Imports System.Collections.ObjectModel
Imports System.Text.Json
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpf.Core

Class HomePage


    Public Sub New()
        InitializeComponent()
        Books = New ObservableCollection(Of BookModel)

        DataContext = New BookViewModel()
    End Sub


    Public Property Books As ObservableCollection(Of BookModel)

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
    Public Async Function BookAddCommand() As Task

        Dim book As New BookModel()
        book.Title = txtTitle.Text
        book.CategoryId = Convert.ToInt32(txtCategory.Text)
        book.AuthorId = Convert.ToInt32(txtAuthor.Text)
        book.AvailableCopies = Convert.ToInt32(txtAvailableCopies.Text)
        book.TotalCopies = Convert.ToInt32(txtTotalCopies.Text)
        book.PublishDate = txtPublishDate.DateTime

        If book IsNot Nothing Then
            Dim result = ThemedMessageBox.Show(title:="Kitap Ekleme", text:="Kitabı Eklemek İstiyor Musunuz?", messageBoxButtons:=MessageBoxButton.OKCancel, defaultButton:=MessageBoxResult.OK, icon:=MessageBoxImage.Information)
            If result = MessageBoxResult.OK Then
                Dim apiService As New HttpApiService()
                Dim resp As ResponseBody(Of BookModel) = Await apiService.PostData(Of ResponseBody(Of BookModel))("Books", JsonSerializer.Serialize(book))

                Await GetAllBooks()
                book = Nothing
            End If
        End If
    End Function

    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Await BookAddCommand()
    End Sub
End Class
