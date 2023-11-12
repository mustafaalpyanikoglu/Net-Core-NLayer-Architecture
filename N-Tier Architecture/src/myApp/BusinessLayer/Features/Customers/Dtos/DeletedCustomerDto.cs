using Core.Application.Dtos;

namespace BusinessLayer.Features.Customers.Dtos;

public class DeletedCustomerDto : IDto
{
    public int Id { get; set; }
}
