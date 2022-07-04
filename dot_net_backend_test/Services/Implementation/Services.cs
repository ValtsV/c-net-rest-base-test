using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class Services : IServices
    {
        public IEnumerable<Course> GetCoursesWithLevelAndCategory(int level, int categoryId)
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
            return courses.Where(course => (int)course.Level == level).Where(c => c.Categories.Any(cat => cat.Id == categoryId));
        }

        public IEnumerable<Course> GetCoursesWithLevelAndHasStudents(int level)
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
                                    Name = "Category 1"
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
            return courses.Where(course => course.Students.Any() && (int)course.Level == level);
        }

        public IEnumerable<Course> GetCoursesWithNoStudents()
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
                                    Name = "Category 1"
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
            return courses.Where(course => !course.Students.Any());
        }

        public IEnumerable<Student> GetStudentsWhereAgeIsMoreThan18()
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

            return students.Where(student =>
            {
                int val = DateTime.Compare(DateTime.Now.AddYears(-18), student.Dob);
                if (val >= 0)
                {
                    return true;
                }
                return false;
            });
        }

        public IEnumerable<Student> GetStudentsWithOneOrMoreCourses()
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
                    Dob = DateTime.Now,
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
            return from student in students
                   where student.Courses.Any()
                   select student;
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            var users = new List<User>()
            {
                new User
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "martin@mail.com"
                        },
                        new User
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@mail.com"
                        },
                        new User
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "juanjo@mail.com"
                        }
            };

            return (from user in users where user.Email == email select user).ToList();
        }
    }
}

