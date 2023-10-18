﻿using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfiguration;
public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        #region UserOperationClaim Model Creation
        builder.ToTable("UserOperationClaims").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasOne(u => u.User).WithMany(u => u.UserOperationClaims).HasForeignKey(u => u.UserId);
        builder.HasOne(u => u.OperationClaim).WithMany().HasForeignKey(u => u.OperationClaimId);
        #endregion
    }
}
