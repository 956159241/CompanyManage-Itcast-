--ΪRegTime����Ϊ��ǰʱ��
ALTER TABLE dbo.UserInfo
	ADD CONSTRAINT DFT_UserInfo_RegTime
	DEFAULT(CURRENT_TIMESTAMP) FOR RegTime;
	
--��ѯUserInfo�������
SELECT Id,UserName,UserPwd,UserMail,CONVERT(NVARCHAR(50),RegTime,111) AS RegTime
	FROM dbo.UserInfo;

--ΪNews�����ŷ���ʱ����ӵ�ǰʱ��
ALTER TABLE dbo.News
	ADD CONSTRAINT DFT_News_SubDateTime
	DEFAULT(CURRENT_TIMESTAMP) FOR SubDateTime;
	
--λ���۱������ʱ����ӵ�ǰʱ��
ALTER TABLE dbo.NewsComments
	ADD CONSTRAINT DFT_NewsComments_CreateDateTime
	DEFAULT(CURRENT_TIMESTAMP) FOR CreateDateTime;