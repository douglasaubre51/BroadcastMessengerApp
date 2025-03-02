using System;
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

            if (!context.Channels.Any())
            {
                context.Channels.AddRange(new List<Channel>()
                {
                    new Channel(){
                        ChannelName="Soul Society",

                        Accounts=new List<Account>(){
                        new Account(){

                        ChannelId=1,

                        Username="Aizen Sosuke",
                        Email="hinamori@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/aizen.png",

                        roles=Enum.Roles.Admin,
                        departments=Enum.Departments.CT,
                        semesters=Enum.Semesters.S6,
                        status=Enum.Status.Offline
                    },

                    new Account(){
                        ChannelId=1,
                        Username="Reze",
                        Email="reze@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/chainsaw man.jpeg",

                        roles=Enum.Roles.Tutor,
                        departments=Enum.Departments.ME,
                        semesters=Enum.Semesters.S6,
                        status=Enum.Status.Offline
                    },
                    new Account(){
                        ChannelId=1,
                        Username="Boruto Uzumaki",
                        Email="himawari@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/boruto.jpg",

                        roles=Enum.Roles.Student,
                        departments=Enum.Departments.EEE,
                        semesters=Enum.Semesters.S3,
                        status=Enum.Status.Offline
                    },
                    new Account(){
                        ChannelId=1,
                        Username="Ken Takakura",
                        Email="momo@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/dandadan.jpg",

                        roles=Enum.Roles.Student,
                        departments=Enum.Departments.CT,
                        semesters=Enum.Semesters.S1,
                        status=Enum.Status.Offline
                    },
                    new Account(){
                        ChannelId=1,
                        Username="Asta",
                        Email="asta@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/blackclover.jpg",

                        roles=Enum.Roles.Student,
                        departments=Enum.Departments.ME,
                        semesters=Enum.Semesters.S1,
                        status=Enum.Status.Offline
                    }
                        }
                    }
                });
            }

            context.SaveChanges();

            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(new List<Account>()
                {
                    new Account(){
                        ChannelId=1,
                        Username="Aizen Sosuke",
                        Email="hinamori@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/aizen.png",

                        roles=Enum.Roles.Admin,
                        departments=Enum.Departments.CT,
                        semesters=Enum.Semesters.S6,
                        status=Enum.Status.Offline
                    },

                    new Account(){
                        ChannelId=1,
                        Username="Reze",
                        Email="reze@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/chainsaw man.jpeg",

                        roles=Enum.Roles.Tutor,
                        departments=Enum.Departments.ME,
                        semesters=Enum.Semesters.S6,
                        status=Enum.Status.Offline
                    },
                    new Account(){
                        ChannelId=1,
                        Username="Boruto Uzumaki",
                        Email="himawari@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/boruto.jpg",

                        roles=Enum.Roles.Student,
                        departments=Enum.Departments.EEE,
                        semesters=Enum.Semesters.S3,
                        status=Enum.Status.Offline
                    },
                    new Account(){
                        ChannelId=1,
                        Username="Ken Takakura",
                        Email="momo@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/dandadan.jpg",

                        roles=Enum.Roles.Student,
                        departments=Enum.Departments.CT,
                        semesters=Enum.Semesters.S1,
                        status=Enum.Status.Offline
                    },
                    new Account(){
                        ChannelId=1,
                        Username="Asta",
                        Email="asta@gmail.com",
                        Password="123",
                        ProfilePhotoURL="~/images/blackclover.jpg",

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
}
