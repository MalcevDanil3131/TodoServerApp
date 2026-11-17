using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodoServerApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var created = new DateTime(2024, 8, 10, 10, 0, 0);
        builder.Entity<TaskItem>().HasData(
            new TaskItem { Id = 1, Title = "Задача 1", Description = "Описание задачи 1", CreatedDate = created },
            new TaskItem { Id = 2, Title = "Задача 2", Description = "Описание задачи 2", CreatedDate = created },
            new TaskItem { Id = 3, Title = "Задача 3", Description = "Описание задачи 3", CreatedDate = created },
            new TaskItem { Id = 4, Title = "Задача 4", Description = "Описание задачи 4", CreatedDate = created }
        );
    }
}
