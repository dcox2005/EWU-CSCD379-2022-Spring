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
    public IEnumerable<Word> GetPageWordList(int page, int pageSize)
    {
        return _service.GetPageWordList(page, pageSize);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordSearch(String searchParameter)
    {
        return _service.GetWordSearch(searchParameter);
    }

    [Route("[action]")]
    [HttpPost]
    public IEnumerable<Word> GetWordSearchPageList(String searchParameter, int page, int pageSize)
    {
        return _service.GetWordSearchPaggedList(searchParameter, page, pageSize);
    }
}
