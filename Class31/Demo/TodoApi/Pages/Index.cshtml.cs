using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly TodoDbContext db;

        public IndexModel(TodoDbContext db)
        {
            this.db = db;
        }

        public async Task OnGetAsync()
        {
            Todos = await db.Todo.ToListAsync();
        }

        public List<Todo> Todos { get; set; }
    }
}