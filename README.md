# Jogo da Forca 2024

![](https://i.imgur.com/r3tuu1h.gif)

## Introdução

Um jogo de console clássico onde você precisa adivinhar uma palavra secreta letra por letra, antes que o boneco seja completamente desenhado na forca.

## Funcionalidades

- **Palavras Temáticas**: Lista de palavras de frutas brasileiras
- **Interface Visual**: Desenho da forca que evolui a cada erro
- **Sistema de Tentativas**: 5 chances para acertar a palavra
- **Feedback Visual**:
  - Visualização das letras já descobertas
  - Contador de erros
  - Desenho do boneco progressivo
- **Validação de Entrada**: Aceita apenas uma letra por vez
- **Feedback de Vitória/Derrota**: Mensagem especial ao final do jogo

## Como utilizar

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

```
dotnet restore
```

4. Em seguida, compile a solução utilizando o comando:

```
dotnet build --configuration Release
```

5. Para executar o projeto compilando em tempo real:

```
dotnet run --project JogoDaForca.ConsoleApp
```

6. Para executar o arquivo compilado, navegue até a pasta `./JogoDaForca.ConsoleApp/bin/Release/net8.0/` e execute o arquivo:

```
JogoDaForca.ConsoleApp.exe
```

## Como Jogar

1. Uma palavra secreta será escolhida aleatoriamente
2. Digite uma letra por vez e pressione Enter
3. Se a letra existir na palavra, ela será revelada nas posições corretas
4. Se errar, uma parte do boneco será desenhada na forca
5. Você vence se descobrir a palavra antes do boneco ser completamente desenhado
6. Você perde se o boneco for completamente desenhado (6 erros)

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
