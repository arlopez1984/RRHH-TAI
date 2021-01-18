DECLARE @strNo AS INT

select 1 from tsmDataDictTbl where TableName = 'thrPeople'
if @@ROWCOUNT = 0 
begin
	insert into tsmDataDictTbl values ('thrPeople', 'CI', '')
end
select 1 from tsmDataDictCol where TableName = 'thrPeople' and ColumnName = 'Sex'
if @@ROWCOUNT = 0
begin
	insert into tsmDataDictCol values ('thrPeople', 'Sex', 'StaticCode', 0, 0, 0, 0, 0);
end 

SELECT @strNo = ts.StringNo FROM tsmString AS ts WHERE ts.ConstantName = 'kstrRHPeopleSexM'
IF @@ROWCOUNT = 0
BEGIN
	SELECT @strNo = StringNo + 1 FROM tsmString AS ts ORDER BY ts.StringNo
	INSERT INTO tsmString(StringNo,ConstantName)VALUES(@strNo,'kstrRHPeopleSexM')
	INSERT INTO tsmLocalString (StringNo,LanguageID, LocalText)VALUES(@strNo,1033,'Masculino')
END

SELECT 1 FROM tsmListValidation AS tlv WHERE tlv.TableName = 'thrPeople' AND tlv.ColumnName = 'Sex' AND tlv.DBValue = 1
IF @@ROWCOUNT = 0
BEGIN
	INSERT INTO tsmListValidation(TableName,ColumnName,	DBValue,IsDefault,StringNo,IsHidden)VALUES('thrPeople','Sex',1,1,@strNo,0)
END


SELECT @strNo = ts.StringNo FROM tsmString AS ts WHERE ts.ConstantName = 'kstrRHPeopleSexF'
IF @@ROWCOUNT = 0
BEGIN
	SELECT @strNo = StringNo + 1 FROM tsmString AS ts ORDER BY ts.StringNo
	INSERT INTO tsmString(StringNo,ConstantName)VALUES(@strNo,'kstrRHPeopleSexF')
	INSERT INTO tsmLocalString (StringNo,LanguageID, LocalText)VALUES(@strNo,1033,'Femenino')
END

SELECT 1 FROM tsmListValidation AS tlv WHERE tlv.TableName = 'thrPeople' AND tlv.ColumnName = 'Sex' AND tlv.DBValue = 2
IF @@ROWCOUNT = 0
BEGIN
	INSERT INTO tsmListValidation(TableName,ColumnName,	DBValue,IsDefault,StringNo,IsHidden)VALUES('thrPeople','Sex',2,0,@strNo,0)
END
