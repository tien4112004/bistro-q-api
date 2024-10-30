using AutoMapper;
using BistroQ.Core.Common.Builder;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class ZoneService : IZoneService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ZoneService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ZoneDto> GetByIdAsync(int id)
    {
        var zones = await _unitOfWork.ZoneRepository.GetByIdAsync(id);

        return _mapper.Map<ZoneDto>(zones);
    }

    public async Task<(IEnumerable<ZoneDto> Zones, int Count)> GetAllAsync(ZoneCollectionQueryParams queryParams)
    {
        var builder =
            new ZoneQueryableBuilder(await _unitOfWork.ZoneRepository.GetQueryable())
                .WithName(queryParams.Name);
        
        var count = await _unitOfWork.ZoneRepository.GetZonesCountAsync(builder.Build());
        builder
            .ApplySorting(queryParams.OrderBy, queryParams.OrderDirection)
            .ApplyPaging(queryParams.Page, queryParams.Size);
        
        var zones = await _unitOfWork.ZoneRepository.GetZonesAsync(builder.Build());
        await _unitOfWork.SaveChangesAsync();
        return (_mapper.Map<IEnumerable<ZoneDto>>(zones), count);
    }

    public async Task<ZoneDto> AddAsync(CreateZoneRequestDto zoneDto)
    {
        var zone = _mapper.Map<Zone>(zoneDto);
        
        var createdZone = await _unitOfWork.ZoneRepository.AddAsync(zone);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ZoneDto>(createdZone);
    }

    public async Task<ZoneDto> UpdateAsync(int zoneId, UpdateZoneRequestDto zoneDto)
    {
        var existingZone = await _unitOfWork.ZoneRepository.GetByIdAsync(zoneId);
        if (existingZone == null)
        {
            throw new ResourceNotFoundException("Zone not found");
        }
        
        var newZone = _mapper.Map<Zone>(zoneDto);
        newZone.ZoneId = zoneId;
        
        await _unitOfWork.ZoneRepository.UpdateAsync(existingZone, newZone);
        await _unitOfWork.SaveChangesAsync();
        
        var updatedZone = await _unitOfWork.ZoneRepository.GetByIdAsync(zoneId);
        
        return _mapper.Map<ZoneDto>(updatedZone);
    }

    public async Task DeleteAsync(int id)
    {
        var existingZone = await _unitOfWork.ZoneRepository.GetByIdAsync(id);
        if (existingZone == null)
        {
            throw new ResourceNotFoundException("Zone not found");
        }
        
        await _unitOfWork.ZoneRepository.DeleteAsync(existingZone);
        await _unitOfWork.SaveChangesAsync();
    }
}