﻿using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Services.Dtos
{
    public class ListingResponse
    {
        public Guid Id { get; set; }
        public SeismicRisk SeismicRisk { get; set; }
        public double TotalLivableArea { get; set; }
        public string Details { get; set; }
        public Guid UserId { get; set; }
        public List<ImageResponse> Images { get; set; } = new();
    }
}
