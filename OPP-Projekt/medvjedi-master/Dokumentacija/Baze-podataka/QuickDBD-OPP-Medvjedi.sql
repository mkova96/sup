-- Exported from QuickDBD: https://www.quickdatatabasediagrams.com/
-- Link to schema: https://app.quickdatabasediagrams.com/#/schema/T3aGRCZ22UGwk6PfBzg_oA
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [User] (
    [UserId] int  NOT NULL ,
    [Name] varchar  NOT NULL ,
    [Surname] varchar  NOT NULL ,
    [Phone] varchar  NOT NULL ,
    [Email] varchar  NOT NULL ,
    [Password] text  NOT NULL ,
    [Role] varchar  NOT NULL ,
    [CompanyId] int  NOT NULL ,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED (
        [UserId] ASC
    )
)

CREATE TABLE [Profile] (
    [ProfileId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [UserPhoto] text  NOT NULL ,
    CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED (
        [ProfileId] ASC
    )
)

CREATE TABLE [Company] (
    [CompanyId] int  NOT NULL ,
    [CompanyName] varchar  NOT NULL ,
    [Address] varchar  NOT NULL ,
    [CityId] int  NOT NULL ,
    [IndustryId] int  NOT NULL ,
    [CompanyLogo] text  NOT NULL ,
    [Description] text  NOT NULL ,
    [Website] varchar  NOT NULL ,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED (
        [CompanyId] ASC
    )
)

CREATE TABLE [City] (
    [CityId] int  NOT NULL ,
    [Name] varchar  NOT NULL ,
    [CountryId] int  NOT NULL ,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED (
        [CityId] ASC
    )
)

CREATE TABLE [Country] (
    [CountryId] int  NOT NULL ,
    [Name] varchar  NOT NULL ,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED (
        [CountryId] ASC
    )
)

CREATE TABLE [Industry] (
    [IndustryId] int  NOT NULL ,
    [Name] varchar  NOT NULL ,
    CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED (
        [IndustryId] ASC
    )
)

CREATE TABLE [CompanyKeyword] (
    [KeywordId] int  NOT NULL ,
    [CompanyId] int  NOT NULL )

CREATE TABLE [Keyword] (
    [KeywordId] int  NOT NULL ,
    [Value] varchar  NOT NULL ,
    CONSTRAINT [PK_Keyword] PRIMARY KEY CLUSTERED (
        [KeywordId] ASC
    )
)

CREATE TABLE [AnnouncementUser] (
    [AnnouncementId] int  NOT NULL ,
    [UserId] int  NOT NULL )

CREATE TABLE [Announcement] (
    [AnnouncementId] int  NOT NULL ,
    [Message] text  NOT NULL ,
    [Time] timestamp  NOT NULL ,
    [RecieverType] varchar  NOT NULL ,
    [RecieverId] int?  NOT NULL ,
    CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED (
        [AnnouncementId] ASC
    )
)

CREATE TABLE [Message] (
    [MessageId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [RecieverId] int  NOT NULL ,
    [Meassage] text  NOT NULL ,
    [DateTime] datetime  NOT NULL ,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED (
        [MessageId] ASC
    )
)

CREATE TABLE [Group] (
    [GroupId] int  NOT NULL ,
    [Name] varchar  NOT NULL ,
    CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED (
        [GroupId] ASC
    )
)

CREATE TABLE [EmailNotification] (
    [EmailNotificationId] int  NOT NULL ,
    [NotificationType] varchar  NOT NULL ,
    [NotificationTypeId] int  NOT NULL ,
    [Text] text  NOT NULL ,
    [Email] varchar  NOT NULL ,
    CONSTRAINT [PK_EmailNotification] PRIMARY KEY CLUSTERED (
        [EmailNotificationId] ASC
    )
)

CREATE TABLE [Settings] (
    [SettingsId] int  NOT NULL ,
    [SettingsValue] int  NOT NULL ,
    [SettingsName] varchar  NOT NULL ,
    [UserId] int  NOT NULL ,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED (
        [SettingsId] ASC
    )
)

CREATE TABLE [GroupUser] (
    [GroupId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [Confirmed] boolean  NOT NULL )

CREATE TABLE [Event] (
    [EventId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [Title] varchar  NOT NULL ,
    [Description] text  NOT NULL ,
    [Date] date  NOT NULL ,
    [Time] time  NOT NULL ,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED (
        [EventId] ASC
    )
)

CREATE TABLE [EventUser] (
    [EventId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [Attending] boolean  NOT NULL )

CREATE TABLE [Payment] (
    [PaymentId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [Amount] float  NOT NULL ,
    [Date] date  NOT NULL ,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED (
        [PaymentId] ASC
    )
)

CREATE TABLE [LoginActivity] (
    [LoginActivityId] int  NOT NULL ,
    [UserId] int  NOT NULL ,
    [Date] date  NOT NULL ,
    [Time] time  NOT NULL ,
    CONSTRAINT [PK_LoginActivity] PRIMARY KEY CLUSTERED (
        [LoginActivityId] ASC
    )
)

CREATE TABLE [SearchLog] (
    [SearchLogId] int  NOT NULL ,
    [IndustryId] int?  NOT NULL ,
    [SearchText] text?  NOT NULL ,
    CONSTRAINT [PK_SearchLog] PRIMARY KEY CLUSTERED (
        [SearchLogId] ASC
    )
)

CREATE TABLE [Visits] (
    [VisitId] int  NOT NULL ,
    [UserAgentString] text  NOT NULL ,
    [UserIP] varchar  NOT NULL ,
    [Url] varchar  NOT NULL ,
    [Country] varchar  NOT NULL ,
    [City] varchar  NOT NULL ,
    CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED (
        [VisitId] ASC
    )
)

ALTER TABLE [User] WITH CHECK ADD CONSTRAINT [FK_User_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [Company] ([CompanyId])

ALTER TABLE [User] CHECK CONSTRAINT [FK_User_CompanyId]

ALTER TABLE [Profile] WITH CHECK ADD CONSTRAINT [FK_Profile_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [Profile] CHECK CONSTRAINT [FK_Profile_UserId]

ALTER TABLE [Company] WITH CHECK ADD CONSTRAINT [FK_Company_CityId] FOREIGN KEY([CityId])
REFERENCES [City] ([CityId])

ALTER TABLE [Company] CHECK CONSTRAINT [FK_Company_CityId]

ALTER TABLE [Company] WITH CHECK ADD CONSTRAINT [FK_Company_IndustryId] FOREIGN KEY([IndustryId])
REFERENCES [Industry] ([IndustryId])

ALTER TABLE [Company] CHECK CONSTRAINT [FK_Company_IndustryId]

ALTER TABLE [City] WITH CHECK ADD CONSTRAINT [FK_City_CountryId] FOREIGN KEY([CountryId])
REFERENCES [Country] ([CountryId])

ALTER TABLE [City] CHECK CONSTRAINT [FK_City_CountryId]

ALTER TABLE [CompanyKeyword] WITH CHECK ADD CONSTRAINT [FK_CompanyKeyword_KeywordId] FOREIGN KEY([KeywordId])
REFERENCES [Keyword] ([KeywordId])

ALTER TABLE [CompanyKeyword] CHECK CONSTRAINT [FK_CompanyKeyword_KeywordId]

ALTER TABLE [CompanyKeyword] WITH CHECK ADD CONSTRAINT [FK_CompanyKeyword_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [Company] ([CompanyId])

ALTER TABLE [CompanyKeyword] CHECK CONSTRAINT [FK_CompanyKeyword_CompanyId]

ALTER TABLE [AnnouncementUser] WITH CHECK ADD CONSTRAINT [FK_AnnouncementUser_AnnouncementId] FOREIGN KEY([AnnouncementId])
REFERENCES [Announcement] ([AnnouncementId])

ALTER TABLE [AnnouncementUser] CHECK CONSTRAINT [FK_AnnouncementUser_AnnouncementId]

ALTER TABLE [AnnouncementUser] WITH CHECK ADD CONSTRAINT [FK_AnnouncementUser_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [AnnouncementUser] CHECK CONSTRAINT [FK_AnnouncementUser_UserId]

ALTER TABLE [Message] WITH CHECK ADD CONSTRAINT [FK_Message_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [Message] CHECK CONSTRAINT [FK_Message_UserId]

ALTER TABLE [Message] WITH CHECK ADD CONSTRAINT [FK_Message_RecieverId] FOREIGN KEY([RecieverId])
REFERENCES [User] ([UserId])

ALTER TABLE [Message] CHECK CONSTRAINT [FK_Message_RecieverId]

ALTER TABLE [EmailNotification] WITH CHECK ADD CONSTRAINT [FK_EmailNotification_Email] FOREIGN KEY([Email])
REFERENCES [User] ([Email])

ALTER TABLE [EmailNotification] CHECK CONSTRAINT [FK_EmailNotification_Email]

ALTER TABLE [Settings] WITH CHECK ADD CONSTRAINT [FK_Settings_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [Settings] CHECK CONSTRAINT [FK_Settings_UserId]

ALTER TABLE [GroupUser] WITH CHECK ADD CONSTRAINT [FK_GroupUser_GroupId] FOREIGN KEY([GroupId])
REFERENCES [Group] ([GroupId])

ALTER TABLE [GroupUser] CHECK CONSTRAINT [FK_GroupUser_GroupId]

ALTER TABLE [GroupUser] WITH CHECK ADD CONSTRAINT [FK_GroupUser_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [GroupUser] CHECK CONSTRAINT [FK_GroupUser_UserId]

ALTER TABLE [Event] WITH CHECK ADD CONSTRAINT [FK_Event_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [Event] CHECK CONSTRAINT [FK_Event_UserId]

ALTER TABLE [EventUser] WITH CHECK ADD CONSTRAINT [FK_EventUser_EventId] FOREIGN KEY([EventId])
REFERENCES [Event] ([EventId])

ALTER TABLE [EventUser] CHECK CONSTRAINT [FK_EventUser_EventId]

ALTER TABLE [EventUser] WITH CHECK ADD CONSTRAINT [FK_EventUser_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [EventUser] CHECK CONSTRAINT [FK_EventUser_UserId]

ALTER TABLE [Payment] WITH CHECK ADD CONSTRAINT [FK_Payment_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [Payment] CHECK CONSTRAINT [FK_Payment_UserId]

ALTER TABLE [LoginActivity] WITH CHECK ADD CONSTRAINT [FK_LoginActivity_UserId] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])

ALTER TABLE [LoginActivity] CHECK CONSTRAINT [FK_LoginActivity_UserId]

COMMIT TRANSACTION QUICKDBD