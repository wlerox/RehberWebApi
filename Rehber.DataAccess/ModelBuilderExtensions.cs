using Microsoft.EntityFrameworkCore;
using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoType>().HasData(
                new InfoType() { InfoTypeID = 1, InfoTypeName = "Phone Number" },
                new InfoType() { InfoTypeID = 2, InfoTypeName = "E-Mail" },
                new InfoType() { InfoTypeID = 3, InfoTypeName = "Location" });
        }
    }
}
