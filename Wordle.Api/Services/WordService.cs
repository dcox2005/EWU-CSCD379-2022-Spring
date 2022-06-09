using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class WordService
{
    private readonly AppDbContext _context;

    public WordService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Word> Get100Words()
    {
        var result = _context.Words
            .Take(100);
        return result;
    }

    public IEnumerable<Word> GetSizedWordList(int size)
    {
        var result = _context.Words
            .Take(size);
        return result;
    }

    public IEnumerable<Word> GetPageWordList(int page, int pageSize)
    {
        var result = _context.Words
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        return result;
    }

    public IEnumerable<Word> GetWordSearch(String searchParameter)
    {
        var result = _context.Words
            .Where(x => x.Value.ToLower().Contains(searchParameter.ToLower()));
        return result;
    }

    public IEnumerable<Word> GetWordSearchPaggedList(String searchParameter, int page, int pageSize)
    {
        var result = _context.Words
            .Where(x => x.Value.ToLower().Contains(searchParameter.ToLower()))
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        return result;
    }
}
