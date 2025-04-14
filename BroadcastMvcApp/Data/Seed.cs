using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.Data;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            context.Accounts.AddRange(new List<Account>()
                            {
                                new Account(){
                                    UserName="Aizen Sosuke",
                                    Email="hinamori@gmail.com",
                                    Password="123",
                                    ProfilePhotoURL="/images/aizen.png",

                                    roles=Enum.Roles.Admin,
                                    departments=Enum.Departments.CT,
                                    semesters=Enum.Semesters.S6,
                                    status=Enum.Status.Offline
                                },

                                new Account(){
                                    UserName="Reze",
                                    Email="reze@gmail.com",
                                    Password="123",
                                    ProfilePhotoURL="/images/reze.jpeg",

                                    roles=Enum.Roles.Tutor,
                                    departments=Enum.Departments.ME,
                                    semesters=Enum.Semesters.S6,
                                    status=Enum.Status.Offline
                                },
                                new Account(){
                                    UserName="Boruto Uzumaki",
                                    Email="himawari@gmail.com",
                                    Password="123",
                                    ProfilePhotoURL="/images/boruto.jpg",

                                    roles=Enum.Roles.Student,
                                    departments=Enum.Departments.EEE,
                                    semesters=Enum.Semesters.S3,
                                    status=Enum.Status.Offline
                                },
                                new Account(){
                                    UserName="Ken Takakura",
                                    Email="momo@gmail.com",
                                    Password="123",
                                    ProfilePhotoURL="/images/dandadan.jpg",

                                    roles=Enum.Roles.Student,
                                    departments=Enum.Departments.CT,
                                    semesters=Enum.Semesters.S1,
                                    status=Enum.Status.Offline
                                },
                                new Account(){
                                    UserName="Asta",
                                    Email="asta@gmail.com",
                                    Password="123",
                                    ProfilePhotoURL="/images/blackclover.jpg",

                                    roles=Enum.Roles.Student,
                                    departments=Enum.Departments.ME,
                                    semesters=Enum.Semesters.S1,
                                    status=Enum.Status.Offline
                                }
                            });

            context.SaveChanges();
        }
    }
}