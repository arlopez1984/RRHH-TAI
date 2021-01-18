GO

DECLARE @mNumber AS SMALLINT

SELECT 1 FROM tsmModuleDef WHERE ModuleID = 'RH';

IF @@ROWCOUNT = 0
BEGIN
	SELECT @mNumber = 70;
	
	INSERT INTO tsmModuleDef VALUES(@mNumber,'RH');
	INSERT INTO tsmModuleStrDef VALUES(@mNumber,1033,'RRHH');
	INSERT INTO tsmModuleSetup(TaskID,SeqNo,ModuleNo)VALUES(33947768,1,@mNumber);
	insert into tciModule values (@mNumber,'7.90.0')
	INSERT INTO tsmModule VALUES (@mNumber,-1466301788,'7.90.0');
END

GO