using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordController : ControllerBase
{
    private readonly WordService _service;

    public WordController(WordService service)
    {
        _service = service;
    }

    [Route("[action]")]
    [HttpGet]
    public IEnumerable<Word> Get100Words()
    {
        return _service.Get100Words();
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordSized(int size)
    {
        return _service.GetSizedWordList(size);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordPage([FromBody] PagePost pagePost)
    {
        return _service.GetPageWordList(pagePost.Page, pagePost.PageSize);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordSearch(String searchParameter)
    {
        return _service.GetWordSearch(searchParameter);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordSearchPage([FromBody] SearchPagePost searchPagePost)
    {
        if(searchPagePost.SearchParameter is null)
        {
            return _service.GetPageWordList(searchPagePost.Page, searchPagePost.PageSize); ;
        }
        return _service.GetWordSearchPaggedList(searchPagePost.SearchParameter, searchPagePost.Page, searchPagePost.PageSize);
    }


    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordSearchLast([FromBody] SearchPagePost searchPagePost)
    {
        if (searchPagePost.SearchParameter is null)
        {
            return _service.GetLastPageWordList(searchPagePost.PageSize); ;
        }
        return _service.GetWordSearchLastPageList(searchPagePost.SearchParameter, searchPagePost.PageSize);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetLastPage([FromBody] PagePost pagePost)
    {
        return _service.GetLastPageWordList(pagePost.PageSize);
    }

    [Route("[action]")]
    [HttpPost]
    public bool AddWord([FromBody] IncomingWord incomingWord)
    {
        if (incomingWord.Word is null)
            return false;

        return _service.AddWord(incomingWord.Word);
    }

    [Route("[action]")]
    [HttpPost]
    public bool DeleteWord([FromBody] IncomingWord incomingWord)
    {
        if (incomingWord.Word is null)
            return false;

        return _service.DeleteWord(incomingWord.Word);
    }

    [Route("[action]")]
    [HttpPost]
    public bool ToggleCommonWord([FromBody] IncomingWord incomingWord)
    {
        if (incomingWord.Word is null)
            return false;

        return _service.ToggleCommonWord(incomingWord.Word);
    }

    public class IncomingWord
    {
        public string? Word { get; set; }
    }

    public class PagePost
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class SearchPagePost
    {
        public string? SearchParameter { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
