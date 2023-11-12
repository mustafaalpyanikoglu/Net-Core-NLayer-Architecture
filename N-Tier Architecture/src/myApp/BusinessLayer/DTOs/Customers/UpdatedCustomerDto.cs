using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Customers;

public class UpdatedCustomerDto : IDto
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public int Demand { get; set; }
}
