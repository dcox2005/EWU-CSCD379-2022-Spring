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
            .OrderBy(w => w.Value)
            .Take(100);
        return result;
    }

    public IEnumerable<Word> GetSizedWordList(int size)
    {
        if (size < 1 || size > 500)
        {
            size = 10;
        }
        var result = _context.Words
            .OrderBy(w => w.Value)
            .Take(size);
        return result;
    }

    public IEnumerable<Word> GetPageWordList(int page, int pageSize)
    {
        if(pageSize < 1 || pageSize > 500)
        {
            pageSize = 10;
        }
        if(page < 1 || page >= (_context.Words.Count() / pageSize))
        {
            page = 1;
        }
        var result = _context.Words
            .OrderBy(w => w.Value)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        return result;
    }

    public IEnumerable<Word> GetWordSearch(String searchParameter)
    {
        var result = _context.Words
            .Where(x => x.Value.ToLower().Contains(searchParameter.ToLower()))
            .OrderBy(w => w.Value);
        return result;
    }

    public IEnumerable<Word> GetWordSearchPaggedList(String searchParameter, int page, int pageSize)
    {
        if (pageSize < 1 || pageSize > 500)
        {
            pageSize = 10;
        }
        if (page < 1 || page >= (_context.Words.Count() / pageSize))
        {
            page = 1;
        }
        var result = _context.Words
            .Where(x => x.Value.ToLower().Contains(searchParameter.ToLower()))
            .OrderBy(w => w.Value)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        return result;
    }

    public IEnumerable<Word> GetWordSearchLastPageList(String searchParameter, int pageSize)
    {
        if (pageSize < 1 || pageSize > 500)
        {
            pageSize = 10;
        }

        var result = _context.Words
            .OrderBy(w => w.Value)
            .Where(x => x.Value.ToLower().Contains(searchParameter.ToLower()));
        result = result.Skip(Math.Max(0, result.Count() - pageSize));
        return result;
    }

    public IEnumerable<Word> GetLastPageWordList(int pageSize)
    {
        if (pageSize < 1 || pageSize > 500)
        {
            pageSize = 10;
        }
        var result = _context.Words
            .OrderBy(w => w.Value)
            .Skip(Math.Max(0, _context.Words.Count() - pageSize));
        return result;
    }

    public bool AddWord(String incomingWord)
    {   
        bool wordAdded = false;
        if (incomingWord is null)
        {
            throw new ArgumentNullException(nameof(incomingWord));
        }

        if (incomingWord.Length < 5 || incomingWord.Length > 5)
        {
            return wordAdded;
        }
        
        var result = _context.Words
            .FirstOrDefault(x => x.Value.ToLower().Equals(incomingWord.ToLower()));
        if (result is null)
        {
            wordAdded = true;
            _context.Words.Add(new Word
            {
                Value = incomingWord,
                Common = false
            });
            _context.SaveChanges();
        }
        return wordAdded;
    }

    public bool DeleteWord(String incomingWord)
    {
        bool wordDeleted = false;
        if (incomingWord is null)
        {
            throw new ArgumentNullException(nameof(incomingWord));
        }

        if (incomingWord.Length < 5 || incomingWord.Length > 5)
        {
            return wordDeleted;
        }

        var result = _context.Words
            .FirstOrDefault(x => x.Value.ToLower().Equals(incomingWord.ToLower()));
        if (result is not null)
        {
            wordDeleted = true;
            _context.Words.Remove(result);
            _context.SaveChanges();
        }
        return wordDeleted;
    }

}
