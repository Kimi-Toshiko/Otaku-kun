﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL.DBO;

namespace WebApp.DAL
{
    public class AnimeDBContext : DbContext
    {
        public AnimeDBContext(DbContextOptions<AnimeDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Anime> Anime { get; set; }

        public virtual DbSet<Status> AnimeStatus { get; set; }
    }
}
