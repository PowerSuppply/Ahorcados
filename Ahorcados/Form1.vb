Imports System.Random

Public Class Form1
    Public words As String() = {"perro", "gato", "vaca", "paloma", "caballo", "oveja", "jirafa", "ballena", "canguro", "oe", "causa", "mano", "jatear", "jamear", "palta", "atracar", "pepa", "peru", "rusia", "australia", "portugal", "argentina", "panama", "chile", "mexico", "alemania", "james", "aaron", "ingrid", "bayron", "sol", "kimberly", "jordan", "rodolfo", "alejandro", "pamela", "josue", "nelson", "jeremy", "bernal", "bryton"}
    Public disfavour As String() = {"Uy, que cerca", "CASI, CASI", "Frio, frio", "Sigue, papi, sigue", "Tu puedes mi kong", "Nooo pampu"}
    Public repeated As String() = {}
    Dim rand As New Random()
    Dim index As Integer = rand.Next(0, words.Length) 'Elije una palabra por index aleatorio
    Dim chosenWord As String = words(index) ' Guarda la palabra en una variable
    Dim dashes As String = New String("")
    Dim sentinel As Integer ' Variable sentinela a usar para controlar los errores
    Private Sub loadGame()
        bro.Visible = False
        sentinel = 0
        pierna2.Visible = True
        changeDaWorld.Visible = False
        congrats.Visible = False
        errorMessage.Text = ""
        index = 0
        index = rand.Next(0, words.Length)
        chosenWord = words(index)
        dashes = ""
        For i As Integer = 0 To chosenWord.Length - 1
            dashes &= "_ "
        Next
        hiddenWord.Text = dashes ' muestra la palabra con las letras ocultas
        If index <= 8 Then
            topicLabel.Text = "Animales"
        ElseIf index <= 16 And index > 8 Then
            topicLabel.Text = "Jergas peruanas"
        ElseIf index <= 25 And index > 16 Then
            topicLabel.Text = "Paises"
        Else
            topicLabel.Text = "Nombres de personas"
        End If

        vacio.Visible = True
        cabeza.Visible = True
        cuerpo.Visible = True
        brazo1.Visible = True
        brazo2.Visible = True
        pierna1.Visible = True
        pierna2.Visible = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadGame()
    End Sub

    Private Async Sub verifyButton_Click(sender As Object, e As EventArgs) Handles verifyButton.Click
        Dim toggle As Boolean = False ' variable usada para condicionar el muestraje de textos de aliento
        Dim counter As Integer = 0
        errorMessage.Visible = False
        For i As Integer = 0 To chosenWord.Length - 1 ' recorre la palabra
            Dim temp() As Char = hiddenWord.Text.ToCharArray() ' guarda el texto de la palabra oculta como array de char para poder modificarlo
            If input.Text = chosenWord(i) Then
                temp(i * 2) = UCase(input.Text) 'si la letra ingresada esta en la palabra, modifica el array para mostrarla
                hiddenWord.Text = New String(temp) ' actualiza el texto de "hiddenWord"
                toggle = True
            End If
        Next
        If toggle = False Then
            sentinel += 1
            errorMessage.Visible = True
            index = rand.Next(0, disfavour.Length) 'elije un mensaje de error aleatorio
            errorMessage.Text = disfavour(index)
        End If
        Select Case sentinel
            Case 1
                vacio.Visible = False
            Case 2
                cabeza.Visible = False
            Case 3
                cuerpo.Visible = False
            Case 4
                brazo1.Visible = False
            Case 5
                brazo2.Visible = False
            Case 6
                pierna1.Visible = False
            Case 7
                congrats.Visible = True
                changeDaWorld.Visible = True
                congrats.Text = "YA PERDISTE, PAPI!"
                dashes = ""
                For i As Integer = 0 To chosenWord.Length - 1
                    dashes &= UCase(chosenWord(i)) + " "
                Next
                hiddenWord.Text = dashes
                Await Task.Delay(800)
                pierna2.Visible = False
                Await Task.Delay(700)
                pierna2.Visible = True
                Await Task.Delay(700)
                pierna2.Visible = False
                Await Task.Delay(500)
                pierna2.Visible = True
                Await Task.Delay(500)
                pierna2.Visible = False
                Await Task.Delay(300)
                pierna2.Visible = True
                Await Task.Delay(300)
                pierna2.Visible = False
                Await Task.Delay(200)
                pierna2.Visible = False
                bro.Visible = True
                Await Task.Delay(300)
                loadGame()
        End Select
        input.Text = ""
        For i = 0 To hiddenWord.Text.Length - 1
            If "_" = hiddenWord.Text(i) Then
                counter += 1
            End If
        Next
        If counter = 0 Then
            congrats.Visible = True
            congrats.Text = "FELICITACIONES!"
            Await Task.Delay(700)
            loadGame()
        End If
    End Sub
End Class
