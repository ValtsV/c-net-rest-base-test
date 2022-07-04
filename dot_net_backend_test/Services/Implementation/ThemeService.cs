using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class ThemeService : IThemeService
    {
        //Obtener temario de un curso concreto
        public IEnumerable<Theme> GetThemesWhereCourseId(int courseId)
        {

            var chapters = new List<Chapters>() {
                new Chapters()
                            {
                                Id = 0,
                                Themes = new List<Theme>()
                                {
                                    new Theme
                                {
                                    Name = "Theme 1",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                },
                                    new Theme
                                {
                                    Name = "Theme 2",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                },
                                    new Theme
                                {
                                    Name = "Theme 3",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                },
                                    new Theme
                                {
                                    Name = "Theme 4",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                },
                                    new Theme
                                {
                                    Name = "Theme 5",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                }

                                },

                                CourseId = 0
                            },
                new Chapters()
                            {
                                Id = 1,
                                Themes = new List<Theme>()
                                {
                                    new Theme
                                {
                                    Name = "Theme 1",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                }

                                },

                                CourseId = 1
                            },
                new Chapters()
                            {
                                Id = 2,
                                Themes = new List<Theme>()
                                {
                                    new Theme
                                {
                                    Name = "Theme 1",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                },
                                    new Theme
                                {
                                    Name = "Theme 2",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                },
                                    new Theme
                                {
                                    Name = "Theme 3",
                                    Description = "Lorem Ipsum Dolor Sit amet"
                                }

                                },

                                CourseId = 2
                            }
            };

            return chapters.Where(chapter => chapter.CourseId == courseId).SelectMany(course => course.Themes);
        }
    }
}
