--为RegTime设置为当前时间
ALTER TABLE dbo.UserInfo
	ADD CONSTRAINT DFT_UserInfo_RegTime
	DEFAULT(CURRENT_TIMESTAMP) FOR RegTime;
	
--查询UserInfo里的数据
SELECT Id,UserName,UserPwd,UserMail,CONVERT(NVARCHAR(50),RegTime,111) AS RegTime
	FROM dbo.UserInfo;

--为News的新闻发布时间添加当前时间
ALTER TABLE dbo.News
	ADD CONSTRAINT DFT_News_SubDateTime
	DEFAULT(CURRENT_TIMESTAMP) FOR SubDateTime;
	
--位评论表的评论时间添加当前时间
ALTER TABLE dbo.NewsComments
	ADD CONSTRAINT DFT_NewsComments_CreateDateTime
	DEFAULT(CURRENT_TIMESTAMP) FOR CreateDateTime;