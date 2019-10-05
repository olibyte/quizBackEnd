using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizBackEnd
{
    public class UserDBContext : IdentityDbContext<IdentityUser>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
    }
}
