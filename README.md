# Console UI Library

## Table Of Contents
- [Purpose](#purpose)
- [Usage](#usage)
- [Example](#example)
- [To Do](#to-do)

## Purpose
The Console UI Library provides a basic reusable framework for creating console-based user interfaces in C#. It aims to enhance the visual appeal and interactivity of console applications by offering a variety of "UI" like elements. I got tired of recreating this everytime I wanted some basic things in prototype console applications and thats how we got to this point.

## Usage
To use the Console UI Library, include the compiled DLL in your C# console application project and reference it in your code.

## Example
```csharp
using ConsoleUI;
using ConsoleUI.UIElements;

class Program
{
    static void Main(string[] args)
    {
        MainConsoleWindow window = new MainConsoleWindow();

        // Add a simple text block
        window.AddElement(new TextBlock("Welcome to the Console UI Library!"));

        // Add a colored text block
        window.AddElement(new ColorTextBlock("Colored Text", ConsoleColor.White, ConsoleColor.Blue));

        // Add a table with headers
        var table = new TableBlock(new[] { "Header1", "Header2" });
        table.AddRow(new[] { "Row1 Col1", "Row1 Col2" });
        window.AddElement(table);

        // Display the composed window
        window.Display();
    }
}
```

## To Do
- [ ] Add `TitleBlock` component for more prominent title displays.
