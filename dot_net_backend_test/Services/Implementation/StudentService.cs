using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class StudentService : IStudentService
    {
        //Obtener alumnos de un Curso concreto
        public IEnumerable<Student> GetStudentsWhereCourseId(int courseId)
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Name = "martin",
                    LastName = "alvarez",
                    Dob = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course
                        {
                            Id = 1,
                            Name = "Angular",
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
                    Name = "enrique",
                    LastName = "torres",
                    Dob = DateTime.Now.AddYears(-21),
                    Courses = new List<Course>()
                    {
                    }
                },
                new Student()
                {
                    Name = "andres",
                    LastName = "perez",
                    Dob = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course
                        {
                            Id = 0,
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

                        }
                    }
                }
            };
            return (IEnumerable<Student>)students.Where(student => student.Courses.Any(course => course.Id == courseId));

        }

        //Obtener todos los alumnos que no tienen cursos asociados
        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            var students = new List<Student>()
            {
                new Student()
                {
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
                    Name = "enrique",
                    LastName = "torres",
                    Dob = DateTime.Now.AddYears(-21),
                    Courses = new List<Course>()
                    {
                    }
                },
                new Student()
                {
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

                        }
                    }
                }
            };
            return students.Where(student => student.Courses.Count == 0);
        }
    }

        
    
}
