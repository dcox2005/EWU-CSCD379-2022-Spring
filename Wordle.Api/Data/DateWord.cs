using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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


public class DateWordConfiguration : IEntityTypeConfiguration<DateWord>
{
    public void Configure(EntityTypeBuilder<DateWord> builder)
    {
        builder.HasData(new DateWord
        {
            DateWordId = 13,
            Date = new DateTime(2000, 01, 01),
            NumberOfPlays = 1,
            AverageScore = 3.01,
            AverageTime = 35,
            WordId = 1
        });

        builder.HasData(new DateWord
        {
            DateWordId = 2,
            Date = new DateTime(2022, 05, 22),
            NumberOfPlays = 25,
            AverageScore = 4.25,
            AverageTime = 180,
            WordId = 2
        });

        builder.HasData(new DateWord
        {
            DateWordId = 3,
            Date = new DateTime(2022, 05, 21),
            NumberOfPlays = 15,
            AverageScore = 5.3,
            AverageTime = 96,
            WordId = 3
        });

        builder.HasData(new DateWord
        {
            DateWordId = 1,
            Date = new DateTime(2022, 05, 20),
            NumberOfPlays = 45,
            AverageScore = 1.54,
            AverageTime = 78,
            WordId = 1
        });

        builder.HasData(new DateWord
        {
            DateWordId = 5,
            Date = new DateTime(2022, 05, 19),
            NumberOfPlays = 86,
            AverageScore = 5.31,
            AverageTime = 65,
            WordId = 5
        });

        builder.HasData(new DateWord
        {
            DateWordId = 6,
            Date = new DateTime(2022, 05, 18),
            NumberOfPlays = 758,
            AverageScore = 3.25,
            AverageTime = 87,
            WordId = 6
        });

        builder.HasData(new DateWord
        {
            DateWordId = 7,
            Date = new DateTime(2022, 05, 17),
            NumberOfPlays = 58,
            AverageScore = 5.34,
            AverageTime = 78,
            WordId = 7
        });

        builder.HasData(new DateWord
        {
            DateWordId = 8,
            Date = new DateTime(2022, 05, 16),
            NumberOfPlays = 456,
            AverageScore = 3.51,
            AverageTime = 98,
            WordId = 8
        });

        builder.HasData(new DateWord
        {
            DateWordId = 9,
            Date = new DateTime(2022, 05, 15),
            NumberOfPlays = 543,
            AverageScore = 3.54,
            AverageTime = 45,
            WordId = 9
        });

        builder.HasData(new DateWord
        {
            DateWordId = 10,
            Date = new DateTime(2022, 05, 14),
            NumberOfPlays = 456,
            AverageScore = 1.56,
            AverageTime = 254,
            WordId = 10
        });

        builder.HasData(new DateWord
        {
            DateWordId = 11,
            Date = new DateTime(2022, 05, 13),
            NumberOfPlays = 876,
            AverageScore = 1.35,
            AverageTime = 148,
            WordId = 11
        });

        builder.HasData(new DateWord
        {
            DateWordId = 12,
            Date = new DateTime(2022, 05, 12),
            NumberOfPlays = 115,
            AverageScore = 2.13,
            AverageTime = 92,
            WordId = 12
        });


    }
}
