﻿using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Warehouses;

public class UpdatedWarehouseDto : IDto
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public double SetupCost { get; set; }
}