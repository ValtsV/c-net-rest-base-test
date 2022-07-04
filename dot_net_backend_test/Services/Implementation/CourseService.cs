using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class CourseService : ICourseService
    {
        //Obtener los Cursos de un Alumno
        public IEnumerable<Course> GetCoursesWhereStudentId(int studentId)
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Id = 0,
                    Name = "martin",
                    LastName = "alvarez",
                    Dob = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course
                        {
                            Name = "React",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Basic,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "Category 1"
                                }
                            }
                        }
                    }
                },
                new Student()
                {
                    Id = 1,
                    Name = "enrique",
                    LastName = "torres",
                    Dob = DateTime.Now.AddYears(-21),
                    Courses = new List<Course>()
                    {
                    }
                },
                new Student()
                {
                    Id = 2,
                    Name = "andres",
                    LastName = "perez",
                    Dob = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course
                        {
                            Name = "React",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Advanced,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "Category 1"
                                }
                            }

                        },
                        new Course
                        {
                            Name = "Angular",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Advanced,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "Category 2"
                                }
                            }

                        }
                    }
                }
            };
            return (IEnumerable<Course>)students.Where(student => student.Id == studentId).SelectMany(student => student.Courses).ToList();
        }

        //Obtener todos los Cursos de una categoría concreta
        public IEnumerable<Course> GetCoursesWhereCategoryId(int categoryId)
        {
            var courses = new List<Course>()
                    {
                        new Course
                        {
                            Name = "React",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Basic,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Id = 0,
                                    Name = "Category 1"
                                }
                            },
                            Students = new List<Student>()
                        },
                        new Course
                        {
                            Name = "Angular",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Advanced,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Id = 1,
                                    Name = "Category 2"
                                }
                            },
                            Students = new List<Student>()
                            {
                                new Student()
                                {
                                    Name = "martin",
                                    LastName = "alvarez",
                                    Dob = DateTime.Now
                                },
                                new Student()
                                {
                                    Name = "enrique",
                                    LastName = "torres",
                                    Dob = DateTime.Now.AddYears(-21)
                                },
                                new Student()
                                {
                                    Name = "andres",
                                    LastName = "perez",
                                    Dob = DateTime.Now
                                }
                            }
                        }
                    };
            return (IEnumerable<Course>)courses.Where(course => course.Categories.Any(category => category.Id == categoryId)).ToList();
        }

        //todo Obtener Cursos sin temarios
        public IEnumerable<Course> GetCoursesWithNoThemes()
        {
            var courses = new List<Course>()
                    {
                        new Course
                        {
                            Id = 0,
                            Name = "React",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Basic,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "Category 1"
                                }
                            },
                            Students = new List<Student>(),
                            Chapters = new Chapters()
                            {
                                Id = 0,
                                Themes = null,
                                CourseId = 0
                            }
                        },
                        new Course
                        {
                            Id = 1,
                            Name = "Angular",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Advanced,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "Category 2"
                                }
                            },
                            Students = new List<Student>()
                            {
                                new Student()
                                {
                                    Name = "martin",
                                    LastName = "alvarez",
                                    Dob = DateTime.Now
                                },
                                new Student()
                                {
                                    Name = "enrique",
                                    LastName = "torres",
                                    Dob = DateTime.Now.AddYears(-21)
                                },
                                new Student()
                                {
                                    Name = "andres",
                                    LastName = "perez",
                                    Dob = DateTime.Now
                                }
                            },
                            Chapters = new Chapters()
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
                            }
                        },
                        new Course
                        {
                            Id = 0,
                            Name = "Vue",
                            ShortDescription = "Lorem Ipsum",
                            Description = "Lorem ispum dolor sit amet",
                            Level = Level.Basic,
                            Categories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "Category 1"
                                }
                            },
                            Students = new List<Student>(),
                            Chapters = new Chapters()
                            {
                                Id = 0,
                                Themes = null,
                                CourseId = 0
                            }
                        }
                    };
            return courses.Where(course => course.Chapters.Themes == null);


        }
    }
}
