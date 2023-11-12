using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Warehouses;

public class CreatedWarehouseDto : IDto
{
    public int Capacity { get; set; }
    public double SetupCost { get; set; }
}
