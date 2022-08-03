using System;
using System.Linq;
using LinqPractices.Entities;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
         public static void Initialize()
        {
            using(var context = new LinqDbContext() )
            {
                if (context.Students.Any())
                {
                    return;
                }
                else
                {
                    context.Students.AddRange(
                        new Student()
                        {
                            Name = "Anıl",
                            Surname = "Düz",
                            ClassId = 1
                        },

                        new Student()
                         {
                             Name = "Kamil",
                             Surname = "Düz",
                             ClassId = 2
                         },


                        new Student()
                          {
                              Name = "Onur",
                              Surname = "Düz",
                              ClassId = 5
                          },
                         new Student()
                         {
                             Name = "ahmet",
                             Surname = "hakan",
                             ClassId = 5
                         },
                          new Student()
                          {
                              Name = "esra",
                              Surname = "kibar",
                              ClassId = 5
                          },
                           new Student()
                           {
                               Name = "sümeyye",
                               Surname = "kibar",
                               ClassId = 5
                           },
                            new Student()
                            {
                                Name = "selin",
                                Surname = "yılmaz",
                                ClassId = 5
                            },

                         new Student()
                          {
                              Name = "Hakan",
                              Surname = "Düz",
                              ClassId = 3
                          }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
