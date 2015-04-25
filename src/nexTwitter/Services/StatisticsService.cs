using System.Linq;
using System.Threading.Tasks;
using nexTwitter.Models;

namespace nexTwitter.Services
{
  public class StatisticsService
  {
    private readonly ApplicationDbContext db;

    public StatisticsService(ApplicationDbContext context)
    {
      db = context;
    }

    public async Task<int> GetCount()
    {
      return await Task.FromResult(db.TodoItems.Count());
    }

    public async Task<int> GetCompletedCount()
    {
      return await Task.FromResult(
          db.TodoItems.Count(x => x.IsDone == true));
    }

    public async Task<double> GetAveragePriority()
    {
      return await Task.FromResult(
          db.TodoItems.Average(x =>
                     (double?)x.Priority) ?? 0.0);
    }
  }
}
