using AutoMapper;
using Core.Application.Pipelines.Authorization;
using EntitiesLayer.Concrete;
using MediatR;
using static BusinessLayer.Features.Warehouses.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;
using BusinessLayer.Features.Warehouses.Dtos;
using BusinessLayer.Features.Warehouses.Rules;
using DataAccessLayer.Repositories.Abstract;

namespace BusinessLayer.Features.Warehouses.Commands.CreateWarehouse;

public class CreateWarehouseCommand : IRequest<CreatedWarehouseDto>/*, ISecuredRequest*/
{
    public int Capacity { get; set; }
    public double SetupCost { get; set; }

    public string[] Roles => new[] { ADMIN, WarehouseAdd };

    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, CreatedWarehouseDto>
    {
        private readonly IMapper _mapper;
        private readonly WarehouseBusinessRules _warehouseBusinessRules;
        private readonly IWarehouseRepository _warehouseRepository;

        public CreateWarehouseCommandHandler(IMapper mapper, WarehouseBusinessRules warehouseBusinessRules, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseBusinessRules = warehouseBusinessRules;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<CreatedWarehouseDto> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            Warehouse mappedWarehouse = _mapper.Map<Warehouse>(request);
            Warehouse createdWarehouse = await _warehouseRepository.AddAsync(mappedWarehouse);

            CreatedWarehouseDto createdWarehouseDto = _mapper.Map<CreatedWarehouseDto>(createdWarehouse);

            return createdWarehouseDto;
        }
    }
}
