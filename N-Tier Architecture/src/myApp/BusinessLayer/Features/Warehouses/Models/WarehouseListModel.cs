﻿using BusinessLayer.Features.Warehouses.Dtos;
using Core.Persistence.Paging;

namespace BusinessLayer.Features.Warehouses.Models;

public class WarehouseListModel : BasePageableModel
{
    public IList<WarehouseListDto> Items { get; set; }
}
