using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Data;
public class DateWord
{
    public int DateWordId { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfPlays { get; set; }
    public double AverageScore { get; set; }
    public double AverageTime { get; set; }
    
    public Word Word { get; set; } = null!;
    public int WordId { get; set; }
}