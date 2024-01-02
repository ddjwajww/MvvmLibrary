Imports System.Globalization
Imports System.Text
Imports System.Threading
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.XtraPrinting.Export

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits ThemedWindow
    Public Sub New()

        InitializeComponent()
        mainFrame.Navigate(New HomePage())
    End Sub

    Public Sub Border_MouseDown(sender As Object, e As MouseButtonEventArgs)

        If e.LeftButton = MouseButtonState.Pressed Then
            Me.DragMove()
        End If

    End Sub

    Private Sub Button_Minus(sender As Object, e As RoutedEventArgs)
        WindowState = WindowState.Minimized
    End Sub

    Private Sub Button_Square(sender As Object, e As RoutedEventArgs)
        If WindowState = WindowState.Maximized Then
            WindowState = WindowState.Normal
        Else
            WindowState = WindowState.Maximized
        End If
    End Sub

    Private Sub Button_Close(sender As Object, e As RoutedEventArgs)
        Application.Current.Shutdown()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        mainFrame.Navigate(New Page1())
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        mainFrame.Navigate(New Page2())
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        mainFrame.Navigate(New Page3())
    End Sub

    Private Sub Button_Click_3(sender As Object, e As RoutedEventArgs)
        mainFrame.Navigate(New Page4())
    End Sub
    Private Sub Button_HomePage(sender As Object, e As RoutedEventArgs)
        mainFrame.Navigate(New HomePage())
    End Sub




End Class