using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SakilaDB
{
    class SakilaDB : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionBuilder
            )
        {
            optionBuilder.UseMySQL("Server=localhost;Database=sakila;UID=root;Password=informatica");
        }
    }
}
