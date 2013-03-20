using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkdownTableFormatter
{
  public class TableFormatter
  {
    private readonly CellSizeCalculator cellSizeCalculator;

    public TableFormatter()
    {
      this.cellSizeCalculator = new CellSizeCalculator();
    }

    public string Format(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
      {
        throw new ArgumentNullException();
      }

      string[][] table = SplitIntoTable(input);

      int[] columnWidths = this.cellSizeCalculator.Calculate(table);

      IEnumerable<string> formattedLines = Enumerable.Range(0, table.Length).Select(row => ProcessOneLine(columnWidths, table[row]));

      var result = string.Join(Environment.NewLine, formattedLines);

      return result;
    }

    private static string[][] SplitIntoTable(string input)
    {
      string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

      string[][] table = lines
        .Select(l => l.StartsWith("|") ? l.Substring(1) : l)
        .Select(l => l.EndsWith("|") ? l.Substring(0, l.Length - 1) : l)
        .Select(l => l.Split(new[] { '|' }, StringSplitOptions.None).Select(cell => cell.Trim()).ToArray()).ToArray();
      return table;
    }

    private static string ProcessOneLine(int[] columnWidths, IEnumerable<string> cells)
    {
      var paddedCells = PadCells(columnWidths, cells);

      string joined = string.Join(" | ", paddedCells);

      string resultOfOneLine = "| " + joined + " |";
      return resultOfOneLine;
    }

    private static List<string> PadCells(int[] columnWidths, IEnumerable<string> cells)
    {
      string[] array = cells.ToArray();

      List<string> paddedCells;

      if (IsSeparationRow(array))
      {
        paddedCells = Enumerable.Range(0, array.Count()).Select(i => new string('-', columnWidths[i])).ToList();
      }
      else
      {
         paddedCells = array.Select((s, cellIndex) => s.PadRight(columnWidths[cellIndex])).ToList();
      }

      return paddedCells;
    }

    private static bool IsSeparationRow(string[] cells)
    {
      return cells.Select(cell => cell.Replace("-", string.Empty).Replace(":", string.Empty).Trim()).All(cell => cell == string.Empty);
    }
  }
}