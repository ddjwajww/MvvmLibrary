Imports System.Configuration
Imports System.Globalization
Imports System.Threading
Imports System.Windows
Imports DevExpress.Xpf.Core

Class Application
    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.


    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        MyBase.OnStartup(e)
        ThemedWindow.RoundCorners = True


    End Sub

    'Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
    '    Dim customPalette = New Dictionary(Of String, Color) From {
    '        {"Foreground", CType(ColorConverter.ConvertFromString("#FFFF7200"), Color)},
    '        {"SelectionBackground", Colors.White}
    '    }
    '    Dim customTheme = LightweightTheme.OverridePalette(
    '        basedOn:=LightweightTheme.Win10Dark,
    '        name:="CustomTheme",
    '        displayName:="Custom Theme",
    '        colors:=customPalette)

    '    LightweightThemeManager.RegisterTheme(customTheme)
    '    ApplicationThemeHelper.ApplicationThemeName = customTheme.Name

    '    MyBase.OnStartup(e)
    'End Sub



End Class