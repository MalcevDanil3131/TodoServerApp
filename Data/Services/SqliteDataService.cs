using Microsoft.EntityFrameworkCore;
using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data.Services;

public class SqliteDataService(ApplicationDbContext context) : IDataService
{
    public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
    {
        return await context.TaskItems.AsNoTracking().OrderBy(task => task.Id).ToArrayAsync();
    }

    public async Task<TaskItem?> GetTaskAsync(int id)
    {
        return await context.TaskItems.AsNoTracking().SingleOrDefaultAsync(task => task.Id == id);
    }

    public async Task<bool> SaveAsync(int? id, TaskItem input)
    {
        if (id is null)
        {
            context.TaskItems.Add(new TaskItem
            {
                Title = input.Title,
                Description = input.Description,
                CreatedDate = DateTime.Now,
                FinishDate = input.FinishDate
            });
        }
        else
        {
            var existing = await context.TaskItems.FindAsync(id.Value);
            if (existing is null)
            {
                return false;
            }

            existing.Title = input.Title;
            existing.Description = input.Description;
            existing.FinishDate = input.FinishDate;
        }

        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var task = await context.TaskItems.FindAsync(id);
        if (task is null)
        {
            return;
        }

        context.TaskItems.Remove(task);
        await context.SaveChangesAsync();
    }
}
