using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services
{
    public interface IThemeService
    {
        IEnumerable<Theme> GetThemesWhereCourseId(int courseId);
    }
}
