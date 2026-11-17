namespace TodoServerApp.Data.Interfaces;

public interface IDataService
{
    Task<IEnumerable<TaskItem>> GetTaskItemsAsync();
    Task<TaskItem?> GetTaskAsync(int id);
    Task<bool> SaveAsync(int? id, TaskItem input);
    Task DeleteAsync(int id);
}
