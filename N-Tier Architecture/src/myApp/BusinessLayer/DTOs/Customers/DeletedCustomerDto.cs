using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Customers;

public class DeletedCustomerDto : IDto
{
    public int Id { get; set; }
}
