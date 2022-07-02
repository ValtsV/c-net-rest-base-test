using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services
{
    public interface IChapterService
    {
        IEnumerable<Chapter> GetChaptersWhereCourseId(int courseId);
    }
}
