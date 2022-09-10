using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Model.Migrations
{
    public partial class Add_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                USE [Student_Affairs]
                delete from [dbo].[StudentSubject]
                delete from [dbo].[Student]
                delete from [dbo].[Subject]
                delete from [dbo].[StudentClass]

                select * from [dbo].[StudentSubject]
                select * from [dbo].[StudentClass]
                select * from [dbo].[Student]
                select * from [dbo].[Subject]


                GO
                SET IDENTITY_INSERT [dbo].[StudentClass] ON 
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (1, N'Class1')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (2, N'Class2')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (3, N'Class3')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (4, N'Class4')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (5, N'Class5')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (6, N'Class6')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (7, N'Class7')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (8, N'Class8')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (9, N'Class9')
                GO
                INSERT [dbo].[StudentClass] ([StudentClass_ID], [StudentClass_Name]) VALUES (10, N'Class10')
                SET IDENTITY_INSERT [dbo].[StudentClass] OFF
                GO
                SET IDENTITY_INSERT [dbo].[Student] ON 
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (1, 1, N'A Student', N'Address 1', CAST(N'2020-01-04T22:00:00.0000000' AS DateTime2), N'Email1@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (2, 2, N'B Student', N'Address 2', CAST(N'2022-02-02T00:00:00.0000000' AS DateTime2), N'Email2@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (3, 3, N'C Student', N'Address 3', CAST(N'2022-03-03T00:00:00.0000000' AS DateTime2), N'Email3@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (4, 4, N'D Student', N'Address 4', CAST(N'2022-04-04T00:00:00.0000000' AS DateTime2), N'Email4@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (5, 5, N'E Student', N'Address 5', CAST(N'2022-05-05T00:00:00.0000000' AS DateTime2), N'Email5@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (6, 1, N'F Student', N'Address 6', CAST(N'2022-03-01T22:00:00.0000000' AS DateTime2), N'email1@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (7, 1, N'G Student', N'Address 7', CAST(N'2022-09-14T22:00:00.0000000' AS DateTime2), N'Email1@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (8, 5, N'H Student', N'Address 8', CAST(N'2022-09-09T19:30:00.2060000' AS DateTime2), N'Email6@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (9, 3, N'I Student', N'Address 9', CAST(N'2022-09-20T00:00:00.0000000' AS DateTime2), N'Email1@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (10, 9, N'J Student', N'Address 10', CAST(N'2022-09-10T02:35:36.7150000' AS DateTime2), N'Email7@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (11, 7, N'K Student', N'Address 11', CAST(N'2022-09-08T00:00:00.0000000' AS DateTime2), N'Email1@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (12, 8, N'L Student', N'Address 12', CAST(N'2022-09-10T02:41:31.3240000' AS DateTime2), N'Email8@gmail.com')
                GO
                INSERT [dbo].[Student] ([Student_ID], [StudentClass_ID], [Student_Name], [Student_Address], [Student_BirthDate], [Student_EmailAddress]) VALUES (13, 6, N'M Student', N'Address 13', CAST(N'2022-09-14T22:00:00.0000000' AS DateTime2), N'Email1@gmail.com')
                GO
                SET IDENTITY_INSERT [dbo].[Student] OFF
                GO
                SET IDENTITY_INSERT [dbo].[Subject] ON 
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (1, N'Subject 1', N'Description 1')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (2, N'Subject 2', N'Description 2')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (3, N'Subject 3', N'Description 3')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (4, N'Subject 4', N'Description 4')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (5, N'Subject 5', N'Description 5')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (6, N'Subject 6', N'Description 6')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (7, N'Subject 7', N'Description 7')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (8, N'Subject 8', N'Description 8')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (9, N'Subject 9', N'Description 9')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (10, N'Subject 10', N'Description 10')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (11, N'Subject 11', N'Description 11')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (12, N'Subject 12', N'Description 12')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (13, N'Subject 13', N'Description 13')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (14, N'Subject 14', N'Description 14')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (15, N'Subject 15', N'Description 15')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (16, N'Subject 16', N'Description 16')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (17, N'Subject 17', N'Description 17')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (18, N'Subject 18', N'Description 18')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (19, N'Subject 19', N'Description 19')
                GO
                INSERT [dbo].[Subject] ([Subject_ID], [Subject_Name], [Subject_Description]) VALUES (20, N'Subject 20', N'Description 20')
                GO
                SET IDENTITY_INSERT [dbo].[Subject] OFF
                GO
                SET IDENTITY_INSERT [dbo].[StudentSubject] ON 
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (1, 1, 2)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (2, 3, 3)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (3, 4, 4)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (4, 5, 5)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (5, 2, 8)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (6, 6, 9)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (7, 7, 10)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (8, 8, 12)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (9, 9, 13)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (10, 10, 14)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (11, 11, 15)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (12, 12, 16)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (13, 1, 11)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (14, 1, 16)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (15, 1, 3)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (16, 2, 1)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (17, 4, 2)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (18, 7, 1)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (19, 2, 17)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (20, 3, 18)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (21, 4, 19)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (22, 5, 20)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (23, 6, 1)
                GO
                INSERT [dbo].[StudentSubject] ([ID], [Student_ID], [Subject_ID]) VALUES (24, 7, 2)
                GO
                SET IDENTITY_INSERT [dbo].[StudentSubject] OFF
                GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    USE [Student_Affairs]
                    delete from [dbo].[StudentSubject]
                    delete from [dbo].[Student]
                    delete from [dbo].[Subject]
                    delete from [dbo].[StudentClass]");
        }
    }
}
