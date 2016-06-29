namespace ComedyClub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedComedyClub : DbMigration
    {
        public override void Up()
        {
            //Asp.NetUsers
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'39acfce1-9353-4e55-a99b-1f3fbfafad38', N'dave@domain.com', 0, N'AIFyISAh1utR2j+brQ71JYHmnxb6b7ysTnbk6YO5FR4I6jvDpE05zzlS87vygvTD0A==', N'c9f082e3-7b39-40f3-8ce1-a8d39c5e4310', NULL, 0, 0, NULL, 1, 0, N'dave@domain.com', N'Dave Chappelle')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532', N'aziz@domain.com', 0, N'AM89hN/xyb8tYsvYtisAX1FCE0vSOlEjtjurdnKor5loFeUrXJxXs4ax/YfuQSCTrA==', N'ca31eb5d-a72f-4491-a9f6-df888ec5c8f4', NULL, 0, 0, NULL, 1, 0, N'aziz@domain.com', N'Aziz Ansari')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'ab0e4065-862a-48cf-82d3-24a587c1efbb', N'louis@domain.com', 0, N'ALZYOKAzo4HWH1oUopkl03xmG2mGMkcmBtOGO5JPJBud/GMgvSTztr3g8GhVbbOYNw==', N'b7c29acb-6bcd-400b-9f45-a5e33ef51198', NULL, 0, 0, NULL, 1, 0, N'louis@domain.com', N'Louis C.K')
            ");

            //Shows
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Shows] ON
                INSERT INTO [dbo].[Shows] ([Id], [DateTime], [Venue], [ComedianId], [GenreId], [IsCanceled]) VALUES (1, N'2016-09-01 18:15:00', N'Comedy Underground', N'39acfce1-9353-4e55-a99b-1f3fbfafad38', 3, 1)
                INSERT INTO [dbo].[Shows] ([Id], [DateTime], [Venue], [ComedianId], [GenreId], [IsCanceled]) VALUES (2, N'2016-10-13 15:30:00', N'CSz Seattle', N'39acfce1-9353-4e55-a99b-1f3fbfafad38', 1, 0)
                INSERT INTO [dbo].[Shows] ([Id], [DateTime], [Venue], [ComedianId], [GenreId], [IsCanceled]) VALUES (3, N'2016-08-30 20:00:00', N'Unexpected', N'39acfce1-9353-4e55-a99b-1f3fbfafad38', 6, 0)
                INSERT INTO [dbo].[Shows] ([Id], [DateTime], [Venue], [ComedianId], [GenreId], [IsCanceled]) VALUES (4, N'2016-08-01 18:45:00', N'The Rendezvous', N'ab0e4065-862a-48cf-82d3-24a587c1efbb', 5, 0)
                INSERT INTO [dbo].[Shows] ([Id], [DateTime], [Venue], [ComedianId], [GenreId], [IsCanceled]) VALUES (5, N'2016-07-22 18:35:00', N'The Parlor', N'ab0e4065-862a-48cf-82d3-24a587c1efbb', 6, 0)
                INSERT INTO [dbo].[Shows] ([Id], [DateTime], [Venue], [ComedianId], [GenreId], [IsCanceled]) VALUES (6, N'2016-11-12 20:00:00', N'Laff Hole', N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532', 4, 0)
                SET IDENTITY_INSERT [dbo].[Shows] OFF
            ");

            //Followings
            Sql(@" 
                INSERT INTO [dbo].[Followings] ([FollowerId], [FolloweeId]) VALUES (N'ab0e4065-862a-48cf-82d3-24a587c1efbb', N'39acfce1-9353-4e55-a99b-1f3fbfafad38')
                INSERT INTO [dbo].[Followings] ([FollowerId], [FolloweeId]) VALUES (N'39acfce1-9353-4e55-a99b-1f3fbfafad38', N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532')
                INSERT INTO [dbo].[Followings] ([FollowerId], [FolloweeId]) VALUES (N'ab0e4065-862a-48cf-82d3-24a587c1efbb', N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532')
                INSERT INTO [dbo].[Followings] ([FollowerId], [FolloweeId]) VALUES (N'39acfce1-9353-4e55-a99b-1f3fbfafad38', N'ab0e4065-862a-48cf-82d3-24a587c1efbb')
                INSERT INTO [dbo].[Followings] ([FollowerId], [FolloweeId]) VALUES (N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532', N'ab0e4065-862a-48cf-82d3-24a587c1efbb')
            ");

            //Attendances
            Sql(@"
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (4, N'39acfce1-9353-4e55-a99b-1f3fbfafad38')
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (5, N'39acfce1-9353-4e55-a99b-1f3fbfafad38')
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (3, N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532')
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (4, N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532')
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (1, N'ab0e4065-862a-48cf-82d3-24a587c1efbb')
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (2, N'ab0e4065-862a-48cf-82d3-24a587c1efbb')
                INSERT INTO [dbo].[Attendances] ([ShowId], [AttendeeId]) VALUES (3, N'ab0e4065-862a-48cf-82d3-24a587c1efbb')
            ");

            //Notification
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Notifications] ON
                INSERT INTO [dbo].[Notifications] ([Id], [DateTime], [NotificationType], [OriginalDateTime], [OriginalVenue], [Show_Id]) VALUES (1, N'2016-06-28 21:28:20', 1, NULL, NULL, 1)
                INSERT INTO [dbo].[Notifications] ([Id], [DateTime], [NotificationType], [OriginalDateTime], [OriginalVenue], [Show_Id]) VALUES (2, N'2016-06-28 21:28:41', 2, N'2016-08-30 20:00:00', N'Unexpected', 3)
                INSERT INTO [dbo].[Notifications] ([Id], [DateTime], [NotificationType], [OriginalDateTime], [OriginalVenue], [Show_Id]) VALUES (3, N'2016-06-28 21:29:44', 2, N'2016-07-22 18:30:00', N'The Parlor', 5)
                SET IDENTITY_INSERT [dbo].[Notifications] OFF
            ");

            //UserNotifications
            Sql(@"
                INSERT INTO [dbo].[UserNotifications] ([UserId], [NotificationId], [IsRead]) VALUES (N'39acfce1-9353-4e55-a99b-1f3fbfafad38', 3, 0)
                INSERT INTO [dbo].[UserNotifications] ([UserId], [NotificationId], [IsRead]) VALUES (N'45a66007-dac9-4b79-b9fc-bc3f5a8e5532', 2, 0)
                INSERT INTO [dbo].[UserNotifications] ([UserId], [NotificationId], [IsRead]) VALUES (N'ab0e4065-862a-48cf-82d3-24a587c1efbb', 1, 0)
                INSERT INTO [dbo].[UserNotifications] ([UserId], [NotificationId], [IsRead]) VALUES (N'ab0e4065-862a-48cf-82d3-24a587c1efbb', 2, 0)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
