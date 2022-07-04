using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class ChapterService : IChapterService
    {
        public IEnumerable<Chapter> GetChaptersWhereCourseId(int courseId)
        {
            //var chapters = new List<Chapter>();
            //return (IEnumerable<Chapter>)chapters.Select(ch => ch.Course.Id == courseId).ToList();
            return null;
        }
    }
}
