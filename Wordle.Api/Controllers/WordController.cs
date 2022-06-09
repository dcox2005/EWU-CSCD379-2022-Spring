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
    public IEnumerable<Word> GetSizedWordList(int size)
    {
        return _service.GetSizedWordList(size);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetPageWordList([FromBody] PagePost pagePost)
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
    public IEnumerable<Word> GetWordSearchPageList([FromBody] SearchPagePost searchPagePost)
    {
        return _service.GetWordSearchPaggedList(searchPagePost.SearchParameter, searchPagePost.Page, searchPagePost.PageSize);
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
