using Core.Application.Dtos;

namespace BusinessLayer.DTOs.CustomerWarehouseCosts;

public class CreatedCustomerWarehouseCostDto : IDto
{
    public int Capacity { get; set; }
    public double SetupCost { get; set; }
}
