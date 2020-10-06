using System.Linq;
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

        public async Task<IViewComponentResult> InvokeAsync(string incompleteMessage)
        {
            /*
             * SELECT IncompleteCount = SUM(CASE WHEN t.Completed = 0 THEN 1 ELSE 0 END)
             *      , TotalCount = COUNT(t.Id)
             * FROM Todos AS t
             */
            var model = await db.Todo
                .GroupBy(t => 1) // Hack to aggregate all Todos
                .Select(g => new TodoCountViewModel
                {
                    IncompleteCount = g.Sum(t => t.Completed == false ? 1 : 0),
                    IncompleteMessage = incompleteMessage ?? "Incomplete count:",
                    TotalCount = g.Count(),
                })
                .FirstAsync();

            return View(model);
        }
    }

    public class TodoCountViewModel
    {
        public int IncompleteCount { get; set; }
        public int TotalCount { get; set; }
        public string IncompleteMessage { get; set; }
    }
}