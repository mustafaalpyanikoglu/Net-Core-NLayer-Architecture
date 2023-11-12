using BusinessLayer.Features.Customers.Dtos;
using Core.Persistence.Paging;

namespace BusinessLayer.Features.Customers.Models;

public class CustomerListModel : BasePageableModel
{
    public IList<CustomerListDto> Items { get; set; }
}
