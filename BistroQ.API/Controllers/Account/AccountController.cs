using AutoMapper;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Account;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = BistroRoles.Admin)]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts([FromQuery] AccountCollectionQueryParams queryParams)
    {
        var (accounts, count) = await _accountService.GetAllAsync(queryParams);
        var res = _mapper.Map<IEnumerable<AccountResponseDto>>(accounts);
        return Ok(new PaginationResponseDto<IEnumerable<AccountResponseDto>>(res, count, queryParams.Page, queryParams.Size));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAccount([FromRoute] string id)
    {
        var account = await _accountService.GetByIdAsync(id);
        
        var res = _mapper.Map<AccountResponseDto>(account);
        return Ok(new ResponseDto<AccountResponseDto>(res));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createAccountDto)
    {
        var account = await _accountService.CreateAccountAsync(createAccountDto);
        var res = _mapper.Map<AccountResponseDto>(account);
        return Ok(new ResponseDto<AccountResponseDto>(res));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAccount([FromRoute] string id ,[FromBody] UpdateAccountDto updateAccountDto)
    {
        var account = await _accountService.UpdateAccountAsync(id, updateAccountDto);
        var res = _mapper.Map<AccountResponseDto>(account);
        return Ok(new ResponseDto<AccountResponseDto>(res));
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAccount([FromRoute] string id)
    {
        await _accountService.DeleteAccountAsync(id);
        return Ok();
    }
}