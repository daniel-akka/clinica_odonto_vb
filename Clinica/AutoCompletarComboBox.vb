Imports System.Windows.Forms

'Cria uma combobox usando a herança e sobreescreve alguns dos seus métodos
Public Class AutoCompletarComboBox
    Inherits ComboBox

    'Esta variavel é usada para sinalizar para a sub OnTextChanged se iremos ou nao iremos usar o autocompletar
    Private _AutoComplete As Boolean = True

    'Este método é disparado quando uma tecla é pressionada e soltada na ComboBox
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        'ativa auto completar somente quando a tecla pressionada não for backspace e nem delete.
        _AutoComplete = (e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back)

        'Como sobre escrevemos o evento OnKeyDown event precisamos dizer para noossa classe "Base" que uma tecla foi pressionada
        MyBase.OnKeyDown(e)

    End Sub

    'É disparado quando o texto na combo mudar
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)

        'somente faça se o usuário não pressionou backspace ou delete
        If _AutoComplete Then

            Dim TextEntered As String = Me.Text

            ' pega o texto atual fora da ComboBox
            Dim index As Integer = Me.FindString(TextEntered)

            'FindString é o metodo na ComboBox que estamos usando

            'se o texto não existir nos itens da combo então...
            If index >= 0 Then

                'desabilita o auto completar enquanto mudamos o indice selecionado
                _AutoComplete = False

                'altera o index selecionado
                Me.SelectedIndex = index

                'habilita o auto completar
                _AutoComplete = True

                'seleciona somente o texto incluido
                Me.Select(TextEntered.Length, Me.Text.Length)

            End If

        End If

        'Como sobre escrevemos o evento OnTextChanged event precisamos dizer para nossa classe "Base" que uma tecla foi pressionada
        MyBase.OnTextChanged(e)

    End Sub

End Class
