using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Contex
{
    public class ApplicationDbContxt:DbContext
    {
        public ApplicationDbContxt(DbContextOptions<ApplicationDbContxt> options) : base(options)
        {

        }
    }
}
