using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Components
{
    public class TodoCount : ViewComponent
    {
        private readonly TodoDbContext db;

        public TodoCount(TodoDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var incompleteCount = await db.Todo.CountAsync(t => !t.Completed);

            return View(new TodoCountViewModel
            {
                IncompleteCount = incompleteCount,
            });
        }
    }

    public class TodoCountViewModel
    {
        public int IncompleteCount { get; set; }
    }
}