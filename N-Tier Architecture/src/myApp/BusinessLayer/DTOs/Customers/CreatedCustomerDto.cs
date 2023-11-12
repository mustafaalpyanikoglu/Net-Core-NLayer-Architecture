using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Customers;

public class CreatedCustomerDto : IDto
{
    public int UserID { get; set; }
    public int Demand { get; set; }
}
