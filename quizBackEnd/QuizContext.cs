﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quizBackEnd.Models;
namespace quizBackEnd
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

        public DbSet<Models.Question> Questions { get; set; }

        public DbSet<quizBackEnd.Models.Quiz> Quiz { get; set; }
    }
}   