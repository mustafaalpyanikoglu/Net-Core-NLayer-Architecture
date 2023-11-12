﻿using Core.Application.Dtos;

namespace BusinessLayer.DTOs.CustomerWarehouseCosts;

public class CustomerWarehouseCostListDto : IDto
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public double SetupCost { get; set; }
}
